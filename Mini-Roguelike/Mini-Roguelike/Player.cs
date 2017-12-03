namespace Mini_Roguelike
{
    internal class Player
    {
        public Player(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; private set; }
        public int Y { get; private set; }

        public void MoveUp() => Y--;
        public void MoveDown() => Y++;
        public void MoveRight() => X++;
        public void MoveLeft() => X--;
    }
}