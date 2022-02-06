using ChessApp.src.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.src.Pieces.King
{
    internal class King : Piece
    {
        public King(bool own, string name, Position p) : base(own, name, p) { }


        public override List<Position>? validMove(Position start, Position end)
        {
            List<Position>? trace = base.validMove(start, end);

            if (trace != null)
            {

                int colStart = (start.getRealCoord()).first;
                int colEnd = (end.getRealCoord()).first;
                int rowEnd = (end.getRealCoord()).second;
                int rowStart = (start.getRealCoord()).second;

                if (colStart == colEnd + 1 || colStart == colEnd - 1 || colStart == colEnd)
                {

                    if (rowStart == rowEnd + 1 || rowStart == rowEnd - 1 || rowStart == rowEnd)
                    {

                        trace.Add(end);
                        return trace;

                    }
                }

            }

            return null;

        }
        

    }
}
