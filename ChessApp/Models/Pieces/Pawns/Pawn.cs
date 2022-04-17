namespace ChessApp.Models.Pieces.Pawns
{
    public class Pawn : Piece
    {
        public Pawn(players own, string name) : base(own, name) { }


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



        public override List<Position> checkAllowedMoves(Board board, Position start) 
        {

            List<Position> valids = base.checkAllowedMoves(board, start);
           
            int[][] template = this.owner == players.USER ? userEatingTemplate : aiEatingTemplate;

            return this.getEatingMoves(board, start, template);
            
        }


        private List<Position> getEatingMoves(Board brd, Position start, int[][] template)
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


        public static List<Position> getProtectedCells(Board brd, Position start, players pl)
        {

            int[][] tmplt = (pl == players.USER) ? userEatingTemplate : aiEatingTemplate;

            var ret = new List<Position>();

            foreach (var mult in tmplt)
            {
                for (var radius = 1; radius <= 1; radius++)
                {

                    var deltaX = radius * mult[0];
                    var deltaY = radius * mult[1];
                    
                    if (Position.isValidPosition(start.row + deltaX, start.col + deltaY))
                    {
                        Position p = brd.getPosition(start.row + deltaX, start.col + deltaY);
                        if (p.piece != null && p.piece.owner != pl)
                        {
                            ret.Add(p);
                        }
                    }
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
