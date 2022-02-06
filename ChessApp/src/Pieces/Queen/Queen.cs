using ChessApp.src.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.src.Pieces.Queen
{
    internal class Queen : Piece
    {
        public Queen(bool own, string name, Position p) : base(own, name, p) { }
        public override List<Position>? validMove(Position start, Position end)
        {

            List<Position>? trace = base.validMove(start, end);

            if (trace != null)
            {

                int colStart = start.getRealCoord().first;
                int rowStart = start.getRealCoord().second;
                int colEnd = end.getRealCoord().first;
                int rowEnd = end.getRealCoord().second;

                int diffCol = abs(colStart - colEnd);
                int diffRow = abs(rowStart - rowEnd);

                if (diffCol == diffRow)
                {

                    Piece.diagonalMovement(start, end, trace);
                    return trace;
                }
                else if (start.coord.first == end.coord.first)
                {
                    Piece.verticalMovement(start, end, trace);
                    return trace;
                }
                else if (start.coord.second == end.coord.second)
                {
                    Piece.horizontalMovement(start, end, trace);
                    return trace;
                }



            }
            return null;


        }

        

    }
}
