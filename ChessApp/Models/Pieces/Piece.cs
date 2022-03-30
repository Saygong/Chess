namespace ChessApp.Models.Pieces
{
    class Piece
    {
        public string name;
        public string owner;


        public Piece(string own, string name)
        {
            owner = own;
            this.name = name;
        }

        

        
        public virtual List<Position>? getAllowedMoves(Board board, Position start)
        {
            if (Position.isValidPosition(start))
            {
                return new List<Position>();
            }
            return null;
        }

        


        /**
         * Provide a string representation of a piece
         * @return string
         */
        public string toString()
        {
            return "Piece: " + this.name;
        }


    }
}
