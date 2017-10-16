using System;

namespace Mini_Roguelike
{
    internal class KeyPressedArgs : EventArgs
    {
        public KeyPressedArgs(ConsoleKey key)
        {
            Key = key;
        }

        public ConsoleKey Key { get; }
    }
}