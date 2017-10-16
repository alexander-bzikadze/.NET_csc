using System;

namespace Mini_Roguelike
{
    internal class Game
    {
        private readonly GameMap _gameMap;
        private readonly Player _player;
        private string _gameMapFileName = "./gameMap.txt";

        public event EventHandler<GameMapChangedArgs> MapChanged = (sender, args) => { };
        public event EventHandler<EventArgs> GameContinues = (sender, args) => { };
        
        public Game(string gameMapFileName = "./gameMap.txt")
        {
            _gameMapFileName = gameMapFileName;
            _gameMap = new CharGameMapReader(gameMapFileName).ReadFile().GetMap();
            _player = new Player();
        }

        public void Start()
        {
            var timeToBreak = true;
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
                    j++;
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
            MapChanged(this, new GameMapChangedArgs(_gameMap, _player));
            GameContinues(this, EventArgs.Empty);
        }

        public void NewGameIteration(object sender, KeyPressedArgs args)
        {
            var mapChanged = false;
            switch (args.Key)
            {
                case ConsoleKey.Q:
                {
                    return;
                }
                case ConsoleKey.LeftArrow:
                {
                    if (_gameMap.CanGo(_player.X - 1, _player.Y))
                    {
                        _player.MoveLeft();
                        mapChanged = true;
                    }
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (_gameMap.CanGo(_player.X + 1, _player.Y))
                    {
                        _player.MoveRight();
                        mapChanged = true;
                    }
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    if (_gameMap.CanGo(_player.X, _player.Y - 1))
                    {
                        _player.MoveUp();
                        mapChanged = true;
                    }
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (_gameMap.CanGo(_player.X, _player.Y + 1))
                    {
                        _player.MoveDown();
                        mapChanged = true;
                    }
                    break;
                }
            }
            if (mapChanged)
            {
                MapChanged(this, new GameMapChangedArgs(_gameMap, _player));
            }
            GameContinues(this, EventArgs.Empty);
        }
    }
}