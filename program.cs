using static System.Formats.Asn1.AsnWriter;

bool open = true;
bool isPlaying = false;

while (open)
{
    Console.Clear();
    Console.WriteLine("Snake Game");
    Console.WriteLine();
    Console.WriteLine("SPACE 키를 눌러서 시작하세요!");

    ConsoleKeyInfo Key;
    Key = Console.ReadKey(intercept: true);

    if (Key.Key == ConsoleKey.Spacebar)
    {
        isPlaying = true;
    }

    if (Key.Key == ConsoleKey.Escape)
    {
        open = false;
    }

    Console.Clear();
    Console.CursorVisible = false;

    Map map = new Map(22, 22);
    Item item = new Item();
    Snake snake = new Snake(item);

    snake.Init();
    item.Init();

    while (isPlaying)
    {
        snake.Update();
        snake.Draw(); 

        Console.SetCursorPosition(0, Map.Instance.row + 1);
        Console.Write($"Score: {Map.Instance.score}");

        if (Map.Instance.isGameOver)
        {
            Console.Clear();
            Console.SetCursorPosition(0, Map.Instance.row + 3);
            Console.WriteLine("Game Over!");
            Console.WriteLine("SPACE 키를 눌러서 다시 시작하세요!");
            isPlaying = false;
            Map.Instance.ResetScore();
            break;
        }

        Thread.Sleep(150);
    }
}
