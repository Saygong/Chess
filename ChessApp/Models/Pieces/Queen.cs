
using ChessApp.Models.Boards;

namespace ChessApp.Models.Pieces
{
    class Queen : Piece
    {
        public Queen(string own, string name) : base(own, name) { }


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

        public List<Position> getValidMoves(ChessBoard board, Position start)
        {
            return Utility.getMoves(board, start, moveTemplates, board.board_dimension);

        }

    }
}
