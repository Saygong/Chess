
using ChessApp.Models.Pieces;

//
// Created by andre on 23/01/2022.
//

namespace ChessApp.Models
{

    public class Position
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
        private int isProtectedByWhite = 0;


        /**
         * Boolean field representing wether or not black is protecting the cell
         */
        private int isProtectedByBlack = 0;



        /**
         * Constructor <int, int>
         */
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.piece = null;
        }

        public Position(int row, int col, Piece piece)
        {
            this.row = row;
            this.col = col;
            this.piece = piece;
        }

        public Position(int row, int col, Piece? piece, int threatWhite, int threatBlack)
        {
            this.row = row;
            this.col = col;
            this.piece = piece;
            this.isProtectedByWhite = threatWhite;
            this.isProtectedByBlack = threatBlack;
        }


        /**
         * Setter for the protection status of a cell
         * @param s representing the color of who is protecting the cell
         */
        public void setProtection(players s)
        {
            if (s == players.USER)
                this.isProtectedByWhite++;
            else this.isProtectedByBlack++;
        }


        //TODO
        public void resetProtection(players s)
        {
            if (s == players.USER)
                this.isProtectedByWhite--;
            else this.isProtectedByBlack--;
        }


        public bool isThreatened()
        {
            if (this.piece != null)
            {
                players s = this.piece.owner;
                if (s == players.USER && this.isProtectedByBlack > 0)
                    return true;
                else if (s == players.AI && this.isProtectedByWhite > 0)
                    return true;
                else return false;
            }
            else throw new ArgumentException("No piece is threathened");
        }



        /**
         * Method that compares two positions
         * @param p
         * @return true if positions are equals, false otherwise
         */

        public override bool Equals(object obj) {
            
            return this.equals(obj as Position);
            
        }

        private bool equals(Position? p)
        {
            if (p != null)
                return (p.row == this.row) && (p.col == this.col);
            // Awful
            else return false;
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

        public string protectionPrettyPrint()
        {

            string toPrint = " (" + this.isProtectedByWhite + ", " + this.isProtectedByBlack + ") ";
            
            
            return toPrint;
        
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

        public Position clone()
        {
            if (this.piece != null)
            {
                return new Position(this.row, this.col, this.piece.clone(), this.isProtectedByWhite, this.isProtectedByBlack);
            }
            else return new Position(this.row, this.col, null, this.isProtectedByWhite, this.isProtectedByBlack);
        }


    }
}
