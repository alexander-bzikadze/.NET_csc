using System;

namespace Mini_Roguelike
{
    internal class GameMapChangedArgs : EventArgs
    {
        public GameMapChangedArgs(GameMap gameMap, Player player)
        {
            GameMap = gameMap;
            Player = player;
        }

        public GameMap GameMap { get; }
        public Player Player { get; }
    }
}