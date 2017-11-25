using System;
using System.Collections.Generic;

namespace Mini_Roguelike
{
    internal class Game
    {
        private readonly GameMap _gameMap;
        private readonly Player _player;
        private static readonly Dictionary<ConsoleKey, KeyReaction> Actions = new Dictionary<ConsoleKey, KeyReaction>()
        {
            {ConsoleKey.LeftArrow, new KeyReaction(p => p.MoveLeft(), -1, 0)},
            {ConsoleKey.RightArrow, new KeyReaction(p => p.MoveRight(), 1, 0)},
            {ConsoleKey.DownArrow, new KeyReaction(p => p.MoveDown(), 0, 1)},
            {ConsoleKey.UpArrow, new KeyReaction(p => p.MoveUp(), 0, -1)}
        };

        private class KeyReaction
        {
            private readonly Action<Player> _playerAction;
            private readonly int _xShift;
            private readonly int _yShift;

            internal KeyReaction(Action<Player> playerAction, int xShift, int yShift)
            {
                _playerAction = playerAction;
                _xShift = xShift;
                _yShift = yShift;
            }

            internal void React(GameMap gameMap, Player player)
            {
                if (gameMap.CanGo(player.X + _xShift, player.Y + _yShift))
                {
                    _playerAction.Invoke(player);
                }
            }
        }

        public event EventHandler<GameMapChangedArgs> MapChanged;
        public event EventHandler<EventArgs> GameContinues;
        
        public Game(IGameMapReader mapReader)
        {
            _gameMap = mapReader.GetMap();
            _player = new Player();
        }

        public void Start()
        {
            var timeToBreak = false;
            foreach (var line in _gameMap)
            {
                var j = 0;
                foreach (var isWall in line)
                {
                    timeToBreak = !isWall;
                    if (timeToBreak)
                    {
                        for (var k = 0; k < j; ++k)
                        {
                            _player.MoveRight();
                        }
                        break;
                    }
                    ++j;
                }
                if (timeToBreak)
                {
                    break;
                }
                _player.MoveDown();
            }
            if (!timeToBreak)
            {
                throw new ArgumentException("Not a single cell for a player on the map. Argh!");
            }
            MapChanged?.Invoke(this, new GameMapChangedArgs(_gameMap, _player));
            GameContinues?.Invoke(this, EventArgs.Empty);
        }

        public void NewGameIteration(object sender, KeyPressedArgs args)
        {
            switch (args.GameChange)
            {
                case KeyPressedArgs.GameChangeEnum.NewPosition:
                {
                    Actions[args.Key].React(_gameMap, _player);
                    break;
                }
                case KeyPressedArgs.GameChangeEnum.Cancel:
                {
                    return;   
                }
                default:
                {
                    Console.WriteLine("Wrong key, result ignored. Remind: Q to exit, arrows to move.");
                    return;
                }
            }
            MapChanged?.Invoke(this, new GameMapChangedArgs(_gameMap, _player));
            GameContinues?.Invoke(this, EventArgs.Empty);
        }
    }
}