using System.Drawing;

public class Map
{
    public int width;
    public int length;
    public int score;

    public Rectangle ActiveMap;
    public Map(int width, int length)
    {
        DrawMap(width, length);
    }

    public void DrawMap(int width, int length)
    {
        this.width = width;
        this.length = length;

        ActiveMap = new Rectangle(0, 0, width - 2, length - 2);

        for (int k = 0; k < length; k++)
        {
            if (k == 0 || k == length - 1)
            {
                for (int i = 0; i < width; i++)
                {
                    if (i == 0 || i == width - 1)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write("-");
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
                    }
                    else
                        Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"점수: {score}");
    }
}