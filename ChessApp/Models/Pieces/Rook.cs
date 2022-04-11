
using ChessApp.Models.Boards;

namespace ChessApp.Models.Pieces
{
    public class Rook : Piece
    {

        public static int range = 8;

        public Rook(string own, string name) : base(own, name) { }


        private readonly static int[][] moveTemplates = new int[][]
        {
          new [] { 1, 0 },
          new [] { 0, -1 },
          new [] { 0, 1 },
          new [] { -1, 0 },
        };

        public override List<Position>? getAllowedMoves(Board board, Position start)
        {
            List<Position>? valids = base.getAllowedMoves(board, start);
            if (valids != null)
            {
                return Utility.getMoves(board, start, moveTemplates, range);
            }
            else return null;
        }

    }
}
