using ChessApp.Models.Pieces.Pawns;

namespace ChessApp.Models.Pieces
{

    public enum players
    {
        USER,
        AI,

    }


    public class Piece
    {
        public string name;
        public players owner;
        private List<Position> coverage;


        public Piece(players own, string name)
        {            
            owner = own;
            this.name = name;
            coverage = new List<Position>();
        }


        
        public virtual List<Position> checkAllowedMoves(Board board, Position start)
        {
            if (Position.isValidPosition(start))
            {
                return new List<Position>();
            }
            throw new ArgumentException("Invalid position");
        }

        
        public List<Position> getAllowedMoves(Board board, Position start)
        {
            players? check = board.isChecked();
            if (check != null)
            {
                CheckHandler handler = new CheckHandler(board, this.owner);

                List<Position> valids = this.checkAllowedMoves(board, start);
                handler.avoidIllegalMoves(board, valids);
                
                this.coverage = valids;
                return valids;
            }
            else return this.checkAllowedMoves(board, start);
            
        }

        public List<Position> getActualCoverage()
        {
            return this.coverage;
        }

        public void setActualCoverage(List<Position> c)
        {
            this.coverage = c;
        }


        


        /**
         * Provide a string representation of a piece
         * @return string
         */
        public string toString()
        {
            return "Piece: " + this.name;
        }


        public Piece clone()
        {
            return new Piece(this.owner, this.name);
        }


    }
}
