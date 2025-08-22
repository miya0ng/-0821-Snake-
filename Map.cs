using System.Drawing;

public class Map
{
    public int width;
    public int length;
    public int score;

    int[,] map;
    private enum MapInfo { Snake, Item, Wall, Blank }

    private MapInfo[,] mapInfos;

    public Map(int w, int l)
    {
        map = new int[w, l];
        this.width = map.Length / l;
        this.length = map.Length / w;
        DrawMap();
    }
    public void DrawMap()
    {
        for (int k = 0; k < length; k++)
        {
            if (k == 0 || k == length - 1)
            {
                for (int i = 0; i < width; i++)
                {
                    if (i == 0 || i == width - 1)
                    {
                        Console.Write("+");
                        mapInfos[k, i] = MapInfo.Wall;
                    }
                    else
                    {
                        Console.Write("-");
                        mapInfos[k, i] = MapInfo.Wall;
                    }
                }
            }
            else
            {
                for (int i = 0; i < width; i++)
                {
                    if (i == 0 || i == width - 1)
                    {
                        Console.Write("|");
                        mapInfos[k, i] = MapInfo.Wall;
                    }
                    else
                        Console.Write(" ");
                    mapInfos[k, i] = MapInfo.Blank;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"점수: {score}");
    }
}