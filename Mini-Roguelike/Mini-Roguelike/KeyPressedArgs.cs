using System;

namespace Mini_Roguelike
{
    internal class KeyPressedArgs : EventArgs
    {
        public KeyPressedArgs(ConsoleKey key)
        {
            Key = key;
            GameChange = key == ConsoleKey.Q ? GameChangeEnum.Cancel : GameChangeEnum.NewPosition;
        }

        public enum GameChangeEnum
        {
            NewPosition,
            Cancel
        }

        public GameChangeEnum GameChange { get; }
        public ConsoleKey Key { get; }
    }
}