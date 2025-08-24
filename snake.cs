using System;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

public class Snake
{
    private Item item;
    private LinkedList<(int x, int y)> bodyPos;

    private (int x, int y) prevHeadPos;
    private (int x, int y) oldHeadPos;

    private enum Direction { Up, Down, Left, Right }

    private (int dx, int dy) dir = (0, -1);

    private (int dx, int dy)[] directions =
{
    (0, -1),  // Up
    (0,  1),  // Down
    (-1, 0),  // Left
    (1,  0)   // Right
};

    public Snake(Item item)
    {
        this.item = item;
        Random random = new Random();
        prevHeadPos = (random.Next(1, Map.Instance.col - 1), random.Next(1, Map.Instance.row - 1));
        bodyPos = new LinkedList<(int x, int y)>();
        dir = directions[random.Next(0, 4)];
    }

    public void Init()
    {
        oldHeadPos = prevHeadPos;
        Console.SetCursorPosition(prevHeadPos.x, prevHeadPos.y);
        Console.Write("0");
        Map.mapInfos[prevHeadPos.y, prevHeadPos.x] = Map.MapInfo.Snake;
    }

    public void Update()
    {
        bool ate = false;

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            EventChangeDirection(keyInfo.Key);
        }

        var nextPos = (prevHeadPos.x + dir.dx, prevHeadPos.y + dir.dy);

        if (CheckCollisionWithGameOver(nextPos))
        {
            Map.Instance.isGameOver = true;
            return;
        }

        if (CheckCollisionWithItem(nextPos))
        {
            ate = true;
        }

        Move(nextPos);
        Grow();

        if (!ate)
        {
            Shrink();
        }
        else
        {
            Map.Instance.AddScore(1);
            item.ItemSpawn();
        }
    }
    public void EventChangeDirection(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                dir = directions[0];
                break;
            case ConsoleKey.DownArrow:
                dir = directions[1];
                break;
            case ConsoleKey.LeftArrow:
                dir = directions[2];
                break;
            case ConsoleKey.RightArrow:
                dir = directions[3];
                break;
            default:
                return;
        }
    }

    public void Move((int x, int y) nextPos)
    {
        prevHeadPos = nextPos;

        Map.Instance.map[prevHeadPos.y, prevHeadPos.x] = '0';
        Map.mapInfos[prevHeadPos.y, prevHeadPos.x] = Map.MapInfo.Snake;

        oldHeadPos = (prevHeadPos.x - dir.dx, prevHeadPos.y - dir.dy);
    }

    public bool CheckCollisionWithGameOver((int x, int y) nextPos)
    {
        if (nextPos.x <= 0 || nextPos.x >= Map.Instance.col - 1 ||
           nextPos.y <= 0 || nextPos.y >= Map.Instance.row - 1)
        {
            return true;
        }

        if (Map.mapInfos[nextPos.y, nextPos.x] == Map.MapInfo.Wall ||
            Map.mapInfos[nextPos.y, nextPos.x] == Map.MapInfo.Snake)
        {
            return true;
        }

        return false;
    }

    public bool CheckCollisionWithItem((int x, int y) nextPos)
    {
        if (Map.mapInfos[nextPos.y, nextPos.x] == Map.MapInfo.Item)
        {
            return true;
        }
        return false;
    }

    public void Grow()
    {
        bodyPos.AddFirst(oldHeadPos);
        Map.mapInfos[oldHeadPos.y, oldHeadPos.x] = Map.MapInfo.Snake;
    }

    public void Shrink()
    {
        if (bodyPos.Count > 0)
        {
            var tail = bodyPos.Last.Value;
            bodyPos.RemoveLast();

            if (Map.mapInfos[tail.y, tail.x] == Map.MapInfo.Snake)
            {
                Map.mapInfos[tail.y, tail.x] = Map.MapInfo.Blank;
                Console.SetCursorPosition(tail.x, tail.y);
                Console.Write(" ");
            }
        }
    }
    public void Draw()
    {
        Console.SetCursorPosition(prevHeadPos.x, prevHeadPos.y);
        Console.Write("0");
        foreach (var pos in bodyPos)
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write("o");
        }
    }
}