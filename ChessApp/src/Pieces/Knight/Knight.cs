using ChessApp.src.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.src.Pieces.Knight
{
    internal class Knight : Piece
    {

        public Knight(bool own, string name, Position p) : base(own, name, p) { }
        public override List<Position>? validMove(Position start, Position end)
        {

            // No need to find the movement trace of a knight, it can jump other pieces

            List<Position>? trace = base.validMove(start, end);
            if (trace != null)
            {

                int colStart = start.getRealCoord().first;
                int rowStart = start.getRealCoord().second;
                int colEnd = end.getRealCoord().first;
                int rowEnd = end.getRealCoord().second;

                if (colStart == colEnd + 1 || colStart == colEnd - 1)
                {
                    if (rowStart == rowEnd + 1 || rowStart == rowEnd + 2 || rowStart == rowEnd - 1 || rowStart == rowEnd - 2)
                        return trace;
                }
            }
            return null;


        }

        

    }
}
