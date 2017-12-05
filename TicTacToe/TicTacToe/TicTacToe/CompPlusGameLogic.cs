using System;

namespace TicTacToe
{
    class CompPlusGameLogic : AbstractGameLogic
    {
        public CompPlusGameLogic(Action firstPlayerWin,
            Action secondPlayerWin,
            Action noOneWins,
            Action<int, int, string> setCell,
            Action<AbstractGameLogic> unsubscribe)
            : base(firstPlayerWin, secondPlayerWin, noOneWins, setCell, unsubscribe)
        {
        }

        public override string GameType { get; } = "Игра с продвинутым компьютером";

        public override void ReactOnMove(object sender, ReactOnMoveArguments args)
        {
            if (_field[args.X, args.Y] != PlayerOwner.None)
            {
                return;
            }
            base.ReactOnMove(sender, args);
            if (!_gameHasStopped && GameContinues())
            {
                NextTurn();
            }
        }

        private void NextTurn()
        {
            if (IsPlacedByFirst(0, 1, 0, 2, 0, 0)
                || IsPlacedByFirst(1, 1, 2, 2, 0, 0)
                || IsPlacedByFirst(1, 0, 2, 0, 0, 0))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(0, 0));
            }
            else if (IsPlacedByFirst(0, 0, 0, 2, 0, 1)
                || IsPlacedByFirst(1, 1, 2, 1, 0, 1))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(0, 1));
            }
            else if (IsPlacedByFirst(0, 0, 0, 1, 0, 2)
                || IsPlacedByFirst(1, 1, 2, 0, 0, 2)
                || IsPlacedByFirst(1, 2, 2, 2, 0, 2))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(0, 2));
            }
            else if (IsPlacedByFirst(0, 0, 2, 0, 1, 0)
                || IsPlacedByFirst(1, 1, 1, 2, 1, 0))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(1, 0));
            }
            else if (IsPlacedByFirst(0, 0, 2, 2, 1, 1)
                || IsPlacedByFirst(0, 1, 2, 1, 1, 1)
                || IsPlacedByFirst(0, 2, 2, 0, 1, 1)
                || IsPlacedByFirst(1, 0, 1, 2, 1, 1))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(1, 1));
            }
            else if (IsPlacedByFirst(0, 2, 2, 2, 1, 2)
                || IsPlacedByFirst(1, 0, 1, 1, 1, 2))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(1, 2));
            }
            else if (IsPlacedByFirst(0, 0, 1, 0, 2, 0)
                || IsPlacedByFirst(1, 1, 0, 2, 2, 0)
                || IsPlacedByFirst(2, 1, 2, 2, 2, 0))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(2, 0));
            }
            else if (IsPlacedByFirst(2, 0, 2, 2, 2, 1)
                || IsPlacedByFirst(0, 1, 1, 1, 2, 1))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(2, 1));
            }
            else if (IsPlacedByFirst(0, 0, 1, 1, 2, 2)
                || IsPlacedByFirst(2, 0, 2, 1, 2, 2)
                || IsPlacedByFirst(0, 2, 1, 2, 2, 2))
            {
                base.ReactOnMove(null, new ReactOnMoveArguments(2, 2));
            }
            else
            {
                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; ++j)
                    {
                        if (_field[i, j] == PlayerOwner.None)
                        {
                            base.ReactOnMove(null, new ReactOnMoveArguments(i, j));
                            return;
                        }
                    }
                }
            }

        }

        private bool IsPlacedByFirst(int x0, int y0, int x1, int y1, int x2, int y2)
        {
            return _field[x0, y0] == PlayerOwner.First && _field[x1, y1] == PlayerOwner.First && _field[x2, y2] == PlayerOwner.None;
        }
    }
}
