namespace SmellyTicTacToe
{
    public class Tile
    
    {
        public Tile(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        private int X;
        private int Y;
        public char Symbol {get; set;}

        public bool IsInPosition(int x, int y)
        {
            return X == x && Y == y;
        }
        
        public bool IsInPosition(Tile anotherTile)
        {
            return IsInPosition(anotherTile.X, anotherTile.Y);
        }        
        
    }
}