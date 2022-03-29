
using ChessApp.Models.Pieces;

//
// Created by andrea on 23/01/2022.
//

namespace ChessApp.Models
{
    abstract class Board
    {

        /**
         * Field that represent the height of the game board
         */
        protected const int ROW_SIZE = 8;

        /**
         * Field that represent the WIDTH of the game board
         */
        protected const int COLUMN_SIZE = 8;

        /**
         * Vector field that keep trace of all the pieces placed in the board
         */
        protected Position[,] board;

       

        public Board()
        {
            board = new Position[ROW_SIZE, COLUMN_SIZE];
            for (int i = 0; i < ROW_SIZE; i++)
            {
                for(int j = 0; j < COLUMN_SIZE; j++)
                {
                    board[i, j] = new Position(i, j);
                }
            }

        }

        /**
         * Method that retrieve the piece placed in a given position
         * @param p
         * @return Pointer of the piece in a given position, null otherwise
         */
        public Piece? getPiece(Position p)
        {
            if (this.board != null)
            {
                return board[p.row, p.col].piece ;
            }
            else return null;
        }


        public Piece? getPiece(int row, int col)
        {
            if (this.board != null)
            {
                return board[row, col].piece;
            }
            else return null;
        }

        public void setPiece(Position pos, Piece piece)
        {
            if (this.board != null)
            {
                board[pos.row, pos.col].piece = piece;
            }
        }

        /**
         * Check if a position is valid. Inside the ranges [A-H] and [1-8]
         * @return true if the position is valid, false otherwise
         */
        public bool isValid(int row, int col, Piece? toMove, out Position? eat)
        {
            if (toMove != null)
            {
                eat = null;
                if ((board[row, col]).isValidPosition())
                {

                    Piece? destination = board[row, col].piece;
                    if (destination != null)
                    {
                        if (destination.owner.Equals(toMove.owner))
                        {
                            return false;
                        }
                        else
                        {
                            eat = board[row, col];
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else throw new ArgumentNullException("Piece to move");
        }
    }
}
