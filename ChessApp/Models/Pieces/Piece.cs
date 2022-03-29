namespace ChessApp.Models.Pieces
{
    internal class Piece
    {
        public string name;
        public string owner;


        public Piece(string own, string name)
        {
            owner = own;
            this.name = name;
        }



        protected static int abs(int param)
        {
            return (param < 0) ? param * (-1) : param;
        }

        

        /**
         *  Return a valid vector containing all the position covered by the move if the move is valid
         *  a nullptr otherwise
         */
        public virtual List<Position>? validMove(Position start, Position end)
        {
            if (start.isValidPosition() && end.isValidPosition() && (!start.equals(end)))
                return new List<Position>();
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
