using System;

namespace TicTacToe
{
    public class TwoPlayersGameLogic : AbstractGameLogic
    {
        public TwoPlayersGameLogic(Action firstPlayerWin, 
            Action secondPlayerWin, 
            Action noOneWins, 
            Action<int, int, string> setCell, 
            Action<AbstractGameLogic> unsubscribe)
            : base(firstPlayerWin, secondPlayerWin, noOneWins, setCell, unsubscribe)
        {
        }

        public override string GameType { get; } = "Игра на двух игроков";
    }
}
