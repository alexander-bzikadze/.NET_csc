using System;
using System.IO;

namespace Mini_Roguelike
{
    internal class CharGameMapReader : IGameMapReader
    {
        public CharGameMapReader(string filename = "./gameMap.txt") => _filename = filename;

        public GameMap GetMap()
        {
            string[] readStrings;
            try
            {
                readStrings = File.ReadAllLines(_filename);
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Error ocurred when reading map from {0}", _filename);
                throw;
            }
            return new GameMap()
                .GetBuilderForCharMap()
                .SetMap(readStrings)
                .Build();
        }

        private readonly string _filename;
    }
}