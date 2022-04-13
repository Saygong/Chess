
using ChessApp.Models.Pieces.Pawns;


namespace ChessApp.Models.Pieces
{
    public class PawnTwoMoves : Pawn
    {

        public static int range = 2;
        public PawnTwoMoves(players own, string name) : base(own, name) { }

        

        private readonly static int[][] userMoveTemplates = new int[][]
        {
          new [] { -1, 0 },

        };

        private readonly static int[][] aiMoveTemplates = new int[][]
        {
          new [] { 1, 0 },

        };

        public override List<Position> checkAllowedMoves(Board board, Position start)
        {
            
            List<Position> eating = base.checkAllowedMoves(board, start);
            
            int[][] template = this.owner == players.USER ? userMoveTemplates : aiMoveTemplates;
            List<Position>? valids = this.getPawnMoves(board, start, template, range);
                
            return valids.Concat(eating).ToList();
                

        }


    }

}
