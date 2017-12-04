using System;

namespace TicTacToe
{
    class CompGameLogic : AbstractGameLogic
    {
        public CompGameLogic(Action firstPlayerWin, Action secondPlayerWin, Action noOneWins, GameWindow gameWindow) 
            : base(firstPlayerWin, secondPlayerWin, noOneWins, gameWindow)
        {
        }

        protected override string GameType { get; } = "Игра с компьютером";

        public override void ReactOnMove(object sender, ReactOnMoveArguments args)
        {
            base.ReactOnMove(sender, args);
            if (!_gameHasStopped && GameContinues())
            {
                NextTurn();
            }
        }

        protected override void NextTurn()
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
}
