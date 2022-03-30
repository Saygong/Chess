
using ChessApp.Models.Boards;

namespace ChessApp.Models.Pieces
{
    class Bishop : Piece
    {

        public Bishop(string own, string name) : base(own, name) { }

        private readonly static int[][] moveTemplates = new int[][]
        {
          new [] { 1, -1 },
          new [] { 1, 1 },
          new [] { -1, -1 },
          new [] { -1, 1 },

        };

        public override List<Position>? getAllowedMoves(Board board, Position start, Position end)
        {

            List<Position>? valids = base.getAllowedMoves(board, start, end);
            if (valids != null)
            {
                return Utility.getMoves(board, start, moveTemplates, board.getDimension());
            }
            else return null;
        }


    }
}
