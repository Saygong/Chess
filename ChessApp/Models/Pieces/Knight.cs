
using ChessApp.Models.Boards;

namespace ChessApp.Models.Pieces
{
    public class Knight : Piece
    {

        public static int range = 1;

        public Knight(players own, string name) : base(own, name) { }


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

        public override List<Position> checkAllowedMoves(Board board, Position start)
        {
            List<Position> valids = base.checkAllowedMoves(board, start);
            
            return Utility.getMoves(board, start, moveTemplates, range);
            

        }



    }
}
