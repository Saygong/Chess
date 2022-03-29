
using ChessApp.Models.Boards;

namespace ChessApp.Models.Pieces
{
    class Pawn : Piece
    {

        private bool firstMove;

        //Field that contains the direction of the pawn - values: true if owner is true, false otherwise
        private bool movingUp;


        public Pawn(string own, string name) : base(own, name)
        {
            firstMove = true;
            movingUp = this.owner.Equals("user");
        }

        private readonly static int[][] aiMoveTemplates = new int[][]
        {
          new [] { 1, 0 },

        };

        private readonly static int[][] userMoveTemplates = new int[][]
        {
          new [] { -1, 0 },

        };

        public List<Position> getValidMoves(ChessBoard board, Position start)
        {
            int[][] template = movingUp ? userMoveTemplates : aiMoveTemplates;
            int radius = this.firstMove ? 2 : 1;
            return Utility.getMoves(board, start, template, radius);

        }


    }

}
