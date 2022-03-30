using ChessApp.Models.Boards;

namespace ChessApp.Models.Pieces
{
    class King : Piece
    {
        public King(string own, string name) : base(own, name) { }


        private readonly static int[][] moveTemplates = new int[][]
        {
          new [] { 1, -1 },
          new [] { 1, 0 },
          new [] { 1, 1 },
          new [] { 0, -1 },
          new [] { 0, 1 },
          new [] { -1, -1 },
          new [] { -1, 0 },
          new [] { -1, 1 },

        };




        public override List<Position>? getAllowedMoves(Board board, Position start, Position end)
        {
            List<Position>? valids = base.getAllowedMoves(board, start, end);
            if (valids != null)
            {
                return Utility.getMoves(board, start, moveTemplates, 1);
            }
            else return null;

        }


    }
}
