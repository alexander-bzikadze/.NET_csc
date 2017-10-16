namespace Mini_Roguelike
{
    internal interface IGameMapReader
    {
        IGameMapReader ReadFile();
        GameMap GetMap();
    }
}