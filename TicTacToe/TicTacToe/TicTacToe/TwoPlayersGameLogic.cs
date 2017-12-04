using System;

namespace TicTacToe
{
    public class TwoPlayersGameLogic : AbstractGameLogic
    {
        public TwoPlayersGameLogic(Action firstPlayerWin, Action secondPlayerWin, Action noOneWins, GameWindow gameWindow) 
            : base(firstPlayerWin, secondPlayerWin, noOneWins, gameWindow)
        {
        }

        protected override string GameType { get; } = "Игра на двух игроков";

        protected override void NextTurn()
        {
        }
    }
}
