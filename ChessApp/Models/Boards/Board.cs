
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


        public bool isUserWhite;

       

        public Board()
        {
            // Need to have this on 100 because i don't know how to let ai start
            this.isUserWhite = Utility.random(100);
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

        public Utility.MoveResult setPiece(int rowStart, int colStart, int rowEnd, int colEnd, string player)
        {
            if (this.board != null)
            {
                
                Piece? moving = this.board[rowStart, colStart].piece;

                
                if (moving != null)
                {

                    if(moving.owner == player)
                    {

                         List<Position>? valids = (moving).getAllowedMoves(this, board[rowStart,colStart]);

                        /*
                        System.Diagnostics.Debug.WriteLine("Tocheck: " + (this.getPosition(rowEnd, colEnd)).toString());
                    
                        foreach (Position pos in valids) {
                            System.Diagnostics.Debug.WriteLine(pos.toString());

                        }
                        */

                        if (valids != null && valids.Contains(board[rowEnd, colEnd]))
                        {

                            board[rowEnd, colEnd].piece = moving;

                            if ( typeof(PawnTwoMoves).IsInstanceOfType(moving))
                            {
                                PawnOneMove toChange = new PawnOneMove(moving.owner, moving.name);
                                board[rowEnd, colEnd].piece = toChange;
                            }

                            board[rowStart, colStart].piece = null;
                            return new Utility.MoveResult("valid", "none", board[rowStart, colStart], board[rowEnd, colEnd]);
                        
                        }
                        return new Utility.MoveResult("invalid", "not allowed move", board[rowStart, colStart], board[rowEnd, colEnd]);

                    }
                    return new Utility.MoveResult("invalid", "not your piece", board[rowStart, colStart], board[rowEnd, colEnd]);

                }
                return new Utility.MoveResult("invalid", "no piece is selected", board[rowStart, colStart], board[rowEnd, colEnd]);

            }
            return new Utility.MoveResult("invalid", "board not initialized");
        }
        

        /**
         * Check if a position is valid. Inside the ranges [A-H] and [1-8]
         * @return true if the position is valid, false otherwise
         */
        public bool isValid(int destRow, int destCol, Piece? toMove, out Position? eat)
        {
            if (toMove != null)
            {
                eat = null;
                if (Position.isValidPosition(destRow, destCol) == true)
                {

                    Piece? destination = board[destRow, destCol].piece;
                    if (destination != null)
                    {
                        if (destination.owner.Equals(toMove.owner))
                        {
                            return false;
                        }
                        else
                        {
                            eat = board[destRow, destCol];
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
