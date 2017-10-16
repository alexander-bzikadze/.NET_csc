using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mini_Roguelike
{
    internal class GameMap : IEnumerable<IEnumerable<bool>>
    {
        private bool _isBuilded;
        private readonly List<List<bool>> _isWall = new List<List<bool>>();

        public bool CanGo(int x, int y)
        {
            CheckBuilded(true);
            return CheckInMap(x, y) && !_isWall[y][x];
        }

        public IGameMapBuilder GetBuilderForCharMap() => new GameMapBuilderForCharGameMap(this);

        private bool CheckInMap(int y) => y < _isWall.Count && y >= 0;

        private bool CheckInMap(int x, int y) => CheckInMap(y) && x < _isWall[y].Count && x >= 0;

        // Template to check being builded or not builded for GameMap.
        // ReSharper disable once UnusedParameter.Local
        private void CheckBuilded(bool needBuilded)
        {
            if (needBuilded ^ _isBuilded)
            {
                throw new NoNullAllowedException("Map has not been build yet!");
            }
        }

        private void AddRow()
        {
            CheckBuilded(false);
            _isWall.Add(new List<bool>());
        }

        private void AddCellLstToRow(bool setted)
        {
            CheckBuilded(false);
            // Check map for non-empty.
            CheckInMap(0);
            _isWall.Last().Add(setted);
        }

        private void SetBuilded()
        {
            CheckBuilded(false);
            _isBuilded = true;
        }

        private class GameMapBuilderForCharGameMap : IGameMapBuilder
        {
            private string[] _charMap;
            private readonly GameMap _parent;

            public GameMapBuilderForCharGameMap(GameMap parent) => _parent = parent;

            public IGameMapBuilder SetMap(string[] charMap)
            {
                _charMap = charMap;
                return this;
            }

            public GameMap Build()
            {
                foreach (var row in _charMap)
                {
                    _parent.AddRow();
                    foreach (var symbol in row)
                    {
                        _parent.AddCellLstToRow(symbol == '#');
                    }
                }
                _parent.SetBuilded();
                return _parent;
            }
        }

        public IEnumerator<IEnumerable<bool>> GetEnumerator()
        {
            return _isWall.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}