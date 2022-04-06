
using ChessApp.Models.Pieces;

//
// Created by andre on 23/01/2022.
//

namespace ChessApp.Models
{

    class Position
    {

        /**
        * Coordinate representing the column [0-7]
        */
        public int col;

        /**
        * Coordinate representing the row [0-7]
        */
        public int row;

        /**
         * Field containing the pieces in this position, null if the cell is empty
         */
        public Piece? piece;

        /**
         * Boolean field representing wether or not white is protecting the cell
         */
        private bool isProtectedByWhite = false;


        /**
         * Boolean field representing wether or not black is protecting the cell
         */
        private bool isProtectedByBlack = false;



        /**
         * Constructor <int, int>
         */
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.piece = null;
        }

        public Position(int col, int row, Piece piece)
        {
            this.row = row;
            this.col = col;
            this.piece = piece;
        }


        /**
         * Setter for the protection status of a cell
         * @param s representing the color of who is protecting the cell
         */ 
        public void setProtection(string s)
        {
            if (s == "user")
                this.isProtectedByWhite = true;
            else this.isProtectedByBlack = true;
        }

        public void resetProtection()
        {
            this.isProtectedByBlack = false;
            this.isProtectedByWhite = false;
        }


        public bool isThreatened(string s)
        {
            if (s == "white" && this.isProtectedByBlack)
                return true;
            else if (s == "black" && this.isProtectedByWhite)
                return true;
            else return false;
        }



        /**
         * Method that compares two positions
         * @param p
         * @return true if positions are equals, false otherwise
         */
        public bool equals(Position p)
        {
            return (p.row == this.row) &&
           (p.col == this.col);
        }

        /**
         * Method that allow to represent a Position with a string
         * @return string
         */
        public override string ToString()
        {
            return "( " + row + ", " + col + " )";
            
        }


        public string prettyPrint()
        {
            if(this.piece == null)
            {
                return "         ";
            }
            else
            {
                string toPrint = "  ";
                for (int i = 0; i < 5; i++)
                {
                    toPrint += this.piece.name[i];
                }
                toPrint += "  ";
                return toPrint;
            }

        }


        /**
         * Check if a position is valid. Inside the ranges [A-H] and [1-8]
         * @return true if the position is valid, false otherwise
         */
        public static bool isValidPosition(int row, int col)
        {
            if (row > 7 || row < 0 || col > 7 || col < 0)
                return false;
            return true;
        }

        public static bool isValidPosition(Position p)
        {
            if (p.row > 7 || p.row < 0 || p.col > 7 || p.row < 0)
                return false;
            return true;
        }


    }
}
