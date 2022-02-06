using ChessApp.src.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.src.Pieces.Rook
{
    internal class Rook : Piece
    {

        public Rook(bool own, string name, Position p) : base(own, name, p) { }
        public override List<Position>? validMove(Position start, Position end)
        {
            List<Position>? trace = base.validMove(start, end);

            if (trace != null)
            {
                if (start.coord.first == end.coord.first)
                {
                    Piece.verticalMovement(start, end, trace);
                    return trace;
                }
                else if(start.coord.second == end.coord.second)
                {
                    Piece.horizontalMovement(start, end, trace);
                    return trace;
                }
                
            }
            return null;
        }
        
        

    }
}
