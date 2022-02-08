using System;
using ChessApp.src.Positions;
using ChessApp.src.Board;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ChessApp.src.Pieces
{
    internal class Piece
    {
        public string name;
        public Position p;
        public bool owner;

        protected static int abs(int param)
        {
            return (param < 0) ? param * (-1) : param;
        }

        public static void horizontalMovement(Position start, Position end, List<Position> trace)
        {
            int a = (start.getRealCoord()).first;
            int b = (end.getRealCoord()).first;
            int row = start.getRealCoord().second;

            if (a < b)
            {
                for (int i = a + 1; i <= b; i++)
                {
                    trace.Add(new Position(i, row));
                }
            }
            else
            {
                for (int i = a - 1; i >= b; i--)
                {
                    trace.Add(new Position(i, row));
                }

            }
            
        }


        public static void verticalMovement(Position start, Position end, List<Position> trace)
        {
            int a = (start.coord).second;
            int b = (end.coord).second;
            int mi = a < b ? a : b;
            int ma = a > b ? a : b;

            for (int i = mi + 1; i <= ma; i++)
            {
                trace.Add(new Position(start.coord.first, i));
            }
        }


        public static void diagonalMovement(Position start, Position end, List<Position> trace)
        {
            int colStart = start.getRealCoord().first;
            int rowStart = start.getRealCoord().second;
            int colEnd = end.getRealCoord().first;
            int rowEnd = end.getRealCoord().second;
            int minCol = colStart < colEnd ? colStart : colEnd;
            int maxCol = colStart > colEnd ? colStart : colEnd;
            int minRow = rowStart < rowEnd ? rowStart : rowEnd;
            int maxRow = rowStart > rowEnd ? rowStart : rowEnd;

            if ((colStart > colEnd && rowStart > rowEnd) || (colStart < colEnd && rowStart < rowEnd))
            {

                for (int i = minCol; i <= maxCol; i++)
                {
                    if (!(new Position(i, minRow).equals(start)))
                    {
                        trace.Add(new Position(i, minRow));
                    }
                    minRow++;
                }

            }
            else
            {
                for (int i = minCol; i <= maxCol; i++)
                {
                    if (!(new Position(i, maxRow).equals(start)))
                    {
                        trace.Add(new Position(i, maxRow));
                    }
                    maxRow--;
                }
            }
            
        }


        public Piece(bool own, string name, Position p)
        {
            this.p = p;
            owner = own;
            this.name = name;
        }


        /**
         *  Return a valid vector containing all the position covered by the move if the move is valid
         *  a nullptr otherwise
         */
        public virtual List<Position>? validMove(Position start, Position end)
        {
            if (start.isValidPosition() && end.isValidPosition() && (!start.equals(end)))
                return new List<Position>();
            return null;
        }

        //TODO moves getAllowedMoves into subclasses and use the movement methods (example -> queen use horizontal, vertical and diagonal)
        public List<Position>? getAllowedMoves(TableLayoutPanel tbl, Board.Board brd)
        {
            List<Position> allowed = new List<Position>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    List<Position>? valid = this.validMove(this.p, new Position(i, j));

                    if (valid != null)
                    {
                        
                        bool blocked = false;
                        foreach (Position pos in valid)
                        {
                            
                            if (brd.getPiece(pos) != null)
                            {
                                blocked = true;
                            }
                        }
                        if(blocked == false)
                            allowed.Add(new Position(i, j));

                    }
                }
            }
            if (allowed.Count > 0)
                return allowed;

            return null;
            
        }


        /**
         * Provide a string representation of a piece
         * @return string
         */
        public string toString()
        {
            return "Piece: " + this.name;
        }


    }
}
