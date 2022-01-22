using System.Collections.Generic;
using System.Linq;

namespace SmellyTicTacToe
{
    public class Board
    {
        private List<Tile> _plays = new List<Tile>();
   
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile(x: i, y: j, symbol: ' '));
                }  
            }       
        }
        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.IsInPosition(x, y));
        }

        public char SymbolAt(int x, int y)
        {
            return TileAt(x, y).Symbol;
        }

        public void AddTileAt(Tile tile)
        {
            _plays.Single(playedTile => playedTile.IsInPosition(tile)).Symbol = tile.Symbol;
        }
    }
}