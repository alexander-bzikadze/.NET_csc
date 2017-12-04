using System;

namespace TicTacToe
{
    public abstract class AbstractGameLogic
    {
        private readonly Action _firstPlayerWin;
        private readonly Action _secondPlayerWin;
        private readonly Action _noOneWins;
        private readonly GameWindow _gameWindow;
        protected readonly PlayerOwner[,] _field;
        protected bool _isFirstPlayerTurn;
        protected bool _gameHasStopped;

        public const string Xs = "X";
        public const string Os = "O";
        private Action firstPlayerWin;
        private Action secondPlayerWin;
        private GameWindow gameWindow;

        protected abstract string GameType { get; }
        protected abstract void NextTurn();

        public AbstractGameLogic(Action firstPlayerWin, Action secondPlayerWin, Action noOneWins, GameWindow gameWindow)
        {
            _firstPlayerWin = firstPlayerWin;
            _secondPlayerWin = secondPlayerWin;
            _noOneWins = noOneWins;
            _gameWindow = gameWindow;
            _gameWindow.MoveMade += ReactOnMove;
            _gameWindow.SetGameType(GameType);
            _field = new PlayerOwner[3, 3];
            _isFirstPlayerTurn = true;
        }

        public AbstractGameLogic(Action firstPlayerWin, Action secondPlayerWin, GameWindow gameWindow)
        {
            this.firstPlayerWin = firstPlayerWin;
            this.secondPlayerWin = secondPlayerWin;
            this.gameWindow = gameWindow;
        }

        public virtual void ReactOnMove(object sender, ReactOnMoveArguments args)
        {
            var x = args.X;
            var y = args.Y;
            if (_field[x, y] == PlayerOwner.None)
            {
                _field[x, y] = _isFirstPlayerTurn ? PlayerOwner.First : PlayerOwner.Second;
                _gameWindow.SetCell(x, y, _isFirstPlayerTurn ? Xs : Os);
                _isFirstPlayerTurn = !_isFirstPlayerTurn;
                switch (CheckForWin())
                {
                    case PlayerOwner.First:
                       _firstPlayerWin();
                        StopGame();
                        _gameHasStopped = true;
                        break;
                    case PlayerOwner.Second:
                        _secondPlayerWin();
                        StopGame();
                        _gameHasStopped = true;
                        break;
                    case PlayerOwner.None:
                        if (!GameContinues())
                        {
                            _noOneWins();
                            StopGame();
                            _gameHasStopped = true;
                        }
                        break;
                }
            }
        }

        public void StopGame()
        {
            _gameWindow.MoveMade -= ReactOnMove;
            _gameWindow.Close();
        }

        private bool CheckThreeCells(int x0, int y0, int x1, int y1, int x2, int y2) 
            => _field[x0, y0] != PlayerOwner.None && _field[x0, y0] == _field[x1, y1] && _field[x1, y1] == _field[x2, y2];

        private PlayerOwner CheckForWin()
        {
            if (CheckThreeCells(0, 0, 0, 1, 0, 2) || CheckThreeCells(0, 0, 1, 0, 2, 0))
            {
                return _field[0, 0];
            }
            else if (CheckThreeCells(2, 0, 2, 1, 2, 2) || CheckThreeCells(0, 2, 1, 2, 2, 2))
            {
                return _field[2, 2];
            }
            else if (CheckThreeCells(0, 0, 1, 1, 2, 2) || CheckThreeCells(1, 0, 1, 1, 1, 2) || CheckThreeCells(2, 0, 1, 1, 0, 2) || CheckThreeCells(0, 1, 1, 1, 2, 1))
            {
                return _field[1, 1];
            }
            return PlayerOwner.None;
        }

        protected bool GameContinues()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; ++j)
                {
                    if (_field[i, j] == PlayerOwner.None)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public enum PlayerOwner
        {
            None,
            First,
            Second
        }
    }
}
