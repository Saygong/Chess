
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
            
            if (board.isChecked() != null)
            {
                CheckHandler handler = new CheckHandler(board, this.owner);
                List<Position> illegal = handler.illegalMoves(board);
                List<Position> valids = this.checkAllowedMoves(board, start);
                foreach(Position p in illegal)
                {
                    valids.Remove(p);
                }
                this.coverage = valids;
                return valids;
            }
            else return this.checkAllowedMoves(board, start);
            
        }

        public List<Position> getCoverage()
        {
            return this.coverage;
        }

        public void setCoverage(List<Position> c)
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
