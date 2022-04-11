namespace ChessApp.Models.Pieces.Pawns
{
    public class Pawn : Piece
    {
        public Pawn(string own, string name) : base(own, name) { }


        private readonly static int[][] userEatingTemplate = new int[][]
        {
          new [] { -1, -1 },
          new [] { -1, 1 },
        };

        private readonly static int[][] aiEatingTemplate = new int[][]
        {
          new [] { 1, -1 },
          new [] { 1, 1 }
        };



        public override List<Position>? getAllowedMoves(Board board, Position start) 
        {

            List<Position>? valids = base.getAllowedMoves(board, start);
            if (valids != null)
            {


                int[][] template = this.owner == "user" ? userEatingTemplate : aiEatingTemplate;


                return this.getEatingMoves(board, start, template);
            }
            else return null;

        }


        private List<Position>? getEatingMoves(Board brd, Position start, int[][] template)
        {

            var ret = new List<Position>();

            foreach (var mult in template)
            {
                for (var radius = 1; radius <= 1; radius++)
                {

                    var deltaX = radius * mult[0];
                    var deltaY = radius * mult[1];
                    Position? toEat;

                    bool res = brd.isValid(start.row + deltaX, start.col + deltaY, start.piece, out toEat);
                    
                    if (res == false && toEat != null)
                        ret.Add(toEat);
                        
                    
                    
                }
            }
            return ret;

        }


        public List<Position> getPawnMoves(Board board, Position start, int[][] moveTemplates, int range)
        {

            if (board == null) throw new ArgumentNullException("board");

            var ret = new List<Position>();

            foreach (var mult in moveTemplates)
            {
                for (var radius = 1; radius <= range; radius++)
                {

                    var deltaX = radius * mult[0];
                    var deltaY = radius * mult[1];
                    Position? toEat;

                    if (board.isValid(start.row + deltaX, start.col + deltaY, start.piece, out toEat) && toEat == null)
                    {
                        ret.Add(board.getPosition(start.row + deltaX, start.col + deltaY));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return ret;

        }


    }
}
