namespace ChessApp.Models.Pieces
{
    class PawnOneMove : Piece
    {

        public PawnOneMove(string own, string name) : base(own, name) { }

       

        private readonly static int[][] userMoveTemplates = new int[][]
        {
          new [] { -1, 0 },

        };

        private readonly static int[][] aiMoveTemplates = new int[][]
        {
          new [] { 1, 0 },

        };



        public override List<Position>? getAllowedMoves(Board board, Position start)
        {

            List<Position>? valids = base.getAllowedMoves(board, start);
            if (valids != null)
            {
                int[][] template = this.owner == "user" ? userMoveTemplates : aiMoveTemplates;
                return Utility.getMoves(board, start, template, 1);
            }
            else return null;

        }


    }

}
