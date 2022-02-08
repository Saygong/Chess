using ChessApp.src.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.src.Pieces.Pawn
{
    internal class Pawn : Piece
    {

        private bool firstMove;

        //Field that contains the direction of the pawn - values: true if owner is true, false otherwise
        private bool movingUp;


        public Pawn(bool own, string name, Position p) : base(own, name, p)
        {
            firstMove = true;
            movingUp = this.owner;
        }
        public override List<Position>? validMove(Position start, Position end)
        {

            List<Position>? trace = base.validMove(start, end);

            if (trace != null)
            {
                int col = (start.getRealCoord()).first;
                int colEnd = (end.getRealCoord()).first;
                int rowEnd = (end.getRealCoord()).second;
                int rowStart = (start.getRealCoord()).second;
                // Direction disable the possibility for a pawn to go backward
                int direction = movingUp ? (rowStart - rowEnd) : (rowEnd - rowStart);
                if (col == colEnd && direction > 0)
                {
                    if (this.firstMove)
                    {
                        if(rowStart < rowEnd)
                        {
                            if(rowEnd - 2 <= rowStart)
                            {
                                for (int i = rowStart; i <= rowEnd; i++)
                                {

                                    if (!(new Position(col, i).equals(start)))
                                    {
                                        trace.Add(new Position(col, i));
                                    }
                                }
                                this.firstMove = false;

                                return trace;
                            }

                        }
                        else
                        {
                            if (rowEnd + 2 >= rowStart)
                            {
                                for (int i = rowEnd; i <= rowStart; i++)
                                {
                                    if (!(new Position(col, i).equals(start)))
                                    {
                                        trace.Add(new Position(col, i));
                                    }
                                }
                                this.firstMove = false;

                                return trace;
                            }
                        }

                    }
                    else
                    {
                        
                        if (rowEnd - 1 == rowStart || rowEnd + 1 == rowStart)
                        {
                            trace.Add(end);
                            return trace;
                        }
                        
                    }
                }

            }
            return null;

        }
        
    }

    
}
