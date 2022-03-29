
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

        public Position getPosition(int row, int col)
        {
            return board[row, col];
        }


        public Piece? getPiece(int row, int col)
        {
            if (this.board != null)
            {
                return board[row, col].piece;
            }
            else return null;
        }

        public bool setPiece(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            if (this.board != null)
            {
                
                Piece? moving = this.board[rowStart, colStart].piece;

                
                if (moving != null)
                {
                    List<Position>? valids = (moving).getAllowedMoves(this, board[rowStart,colStart], board[rowEnd, colEnd]);

                    System.Diagnostics.Debug.WriteLine("Tocheck: " + (this.getPosition(rowEnd, colEnd)).toString());
                    System.Diagnostics.Debug.WriteLine(valids == null);
                    foreach (Position pos in valids) {
                        System.Diagnostics.Debug.WriteLine(pos.toString());

                    }


                    if (valids != null && valids.Contains(board[rowEnd, colEnd]))
                    {
                        System.Diagnostics.Debug.WriteLine(moving.toString());
                        board[rowEnd, colEnd].piece = moving;
                        board[rowStart, colStart].piece = null;
                        return true;
                    }
                }
                
            }
            return false;
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



        public int getDimension()
        {
            return ROW_SIZE;
        }
    }
}
