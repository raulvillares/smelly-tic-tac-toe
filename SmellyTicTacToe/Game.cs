using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace SmellyTicTacToe
{
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
            if (IsRowFullWithSameSymbol(0)) return _board.SymbolAt(0, 0);
            if (IsRowFullWithSameSymbol(1)) return _board.SymbolAt(1, 0);
            if (IsRowFullWithSameSymbol(2)) return _board.SymbolAt(2, 0);
            return ' ';
        }
        
        private void updateGameState(char symbol, int x, int y)
        {
            _lastSymbol = symbol;
            var newTile = new Tile
            {
                X = x,
                Y = y,
                Symbol = symbol
            };
            _board.AddTileAt(newTile);
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