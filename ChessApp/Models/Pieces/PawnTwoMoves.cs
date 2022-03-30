
namespace ChessApp.Models.Pieces
{
    class PawnTwoMoves : Piece
    {

        public PawnTwoMoves(string own, string name) : base(own, name) { }

        

        private readonly static int[][] userMoveTemplates = new int[][]
        {
          new [] { -1, 0 },

        };

        public override List<Position>? getAllowedMoves(Board board, Position start, Position end)
        {
            
            List<Position>? valids = base.getAllowedMoves(board, start, end);
            if (valids != null)
            {
                return Utility.getMoves(board, start, userMoveTemplates, 2);
            }
            else return null;

        }


    }

}
