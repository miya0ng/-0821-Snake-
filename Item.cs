using static Map;
public class Item
{
    Random random = new Random();
    public Item()
    {
        
    }

    public void Init()
    {
        ItemSpawn();
    }

    public void ItemSpawn()
    {
        int itemX = random.Next(1, Map.Instance.col - 1);
        int itemY = random.Next(1, Map.Instance.row - 1);
        if (Map.mapInfos[itemY, itemX] == MapInfo.Blank)
        {
            Map.Instance.map[itemY, itemX] = '*';
            Map.mapInfos[itemY, itemX] = Map.MapInfo.Item;
            Console.SetCursorPosition(itemX, itemY);
            Console.Write("*");
        }
    }
}