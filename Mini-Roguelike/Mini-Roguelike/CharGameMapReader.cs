using System.IO;

namespace Mini_Roguelike
{
    internal class CharGameMapReader : IGameMapReader
    {
        public CharGameMapReader(string filename) => _filename = filename;

        public IGameMapReader ReadFile()
        {
            _readStrings = File.ReadAllLines(_filename);
            return this;
        }

        public GameMap GetMap() 
            => new GameMap()
                .GetBuilderForCharMap()
                .SetMap(_readStrings)
                .Build();
        
        private readonly string _filename;
        private string[] _readStrings;
    }
}