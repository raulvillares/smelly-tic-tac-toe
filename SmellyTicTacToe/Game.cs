using System;
using System.Collections.Generic;
using System.Linq;

namespace SmellyTicTacToe
{
    public class Tile
    {
        public int X {get; set;}
        public int Y {get; set;}
        public char Symbol {get; set;}
    }

    public class Board
    {
        private List<Tile> _plays = new List<Tile>();
   
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile{ X = i, Y = j, Symbol = ' '});
                }  
            }       
        }
        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }

        public void AddTileAt(char symbol, int x, int y)
        {
            var newTile = new Tile
            {
                X = x,
                Y = y,
                Symbol = symbol
            };

            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
        }
    }

    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board();
    
        public void Play(char symbol, int x, int y)
        {
            checkValidFirstMovement(symbol);
            checkIsNotRepeatedPlayer(symbol);
            checkMovementIsValid(x, y);
            updateGameState(symbol, x, y);
        }
        
        public char Winner()
        {
            if (IsRowFullWithSameSymbol(0)) return _board.TileAt(0, 0).Symbol;
            if (IsRowFullWithSameSymbol(1)) return _board.TileAt(1, 0).Symbol;
            if (IsRowFullWithSameSymbol(2)) return _board.TileAt(2, 0).Symbol;
            return ' ';
        }    

        private void updateGameState(char symbol, int x, int y)
        {
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private void checkMovementIsValid(int x, int y)
        {
            if (_board.TileAt(x, y).Symbol != ' ')
            {
                throw new Exception("Invalid position");
            }
        }

        private void checkIsNotRepeatedPlayer(char symbol)
        {
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
        }

        private void checkValidFirstMovement(char symbol)
        {
            if(isFirstMove() && isInvalidFirstPlayer(symbol))
            {
                throw new Exception("Invalid first player");
            } 
        }

        private static bool isInvalidFirstPlayer(char symbol)
        {
            return symbol == 'O';
        }

        private bool isFirstMove()
        {
            return _lastSymbol == ' ';
        }

        private bool IsRowFullWithSameSymbol(int row)
        {
            if (_board.TileAt(row, 0).Symbol != ' ' &&
                _board.TileAt(row, 1).Symbol != ' ' &&
                _board.TileAt(row, 2).Symbol != ' ')
            {
                //if first row is full with same symbol
                if (_board.TileAt(row, 0).Symbol ==
                    _board.TileAt(row, 1).Symbol &&
                    _board.TileAt(row, 2).Symbol ==
                    _board.TileAt(row, 1).Symbol)
                {
                    return true;
                }
            }

            return false;
        }
    }
}