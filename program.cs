Console.WriteLine("Snake Game");
Console.WriteLine();
Console.WriteLine("SPACE 키를 눌러서 시작하세요!");
//Console.WriteLine("SPACE 키를 눌러서 다시 시작하세요!");

ConsoleKeyInfo keyInfo;
keyInfo = Console.ReadKey();
if (keyInfo.Key == ConsoleKey.Spacebar)
{
    Console.Clear();
    Map map = new Map(22, 22); // todo: 22 -> 20
}