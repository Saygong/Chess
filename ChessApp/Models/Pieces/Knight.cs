
using ChessApp.Models.Boards;

namespace ChessApp.Models.Pieces
{
    class Knight : Piece
    {

        public Knight(string own, string name) : base(own, name) { }


        private readonly static int[][] moveTemplates = new int[][]
        {
          new [] { 1, -2 },
          new [] { 1, 2 },
          new [] { 2, 1 },
          new [] { 2, -1 },
          new [] { -2, -1 },
          new [] { -2, 1 },
          new [] { -1, 2 },
          new [] { -1, -2 },

        };

        public List<Position> getValidMoves(ChessBoard board, Position start)
        {
            return Utility.getMoves(board, start, moveTemplates, 1);


        }



    }
}
