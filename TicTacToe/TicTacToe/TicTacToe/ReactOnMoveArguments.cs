using System.Diagnostics;

namespace TicTacToe
{
    public class ReactOnMoveArguments
    {
        public int X { get; }
        public int Y { get; }

        public ReactOnMoveArguments(int x, int y)
        {
            Debug.Assert(x >= 0 && x <= 2);
            Debug.Assert(y >= 0 && y <= 2);
            X = x;
            Y = y;
        }
    }
}