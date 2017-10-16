namespace Mini_Roguelike
{
    internal interface IGameMapBuilder
    {
        IGameMapBuilder SetMap(string[] charMap);
        GameMap Build();
    }
}