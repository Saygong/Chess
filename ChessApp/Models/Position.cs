
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
         * Constructor <int, int>
         */
        public Position(int col, int row)
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
        public string toString()
        {
            return "( " + col + ", " + row + " )";
            
        }

        /**
         * Check if a position is valid. Inside the ranges [A-H] and [1-8]
         * @return true if the position is valid, false otherwise
         */
        public bool isValidPosition()
        {
            if (row > 8 || row < 0 || col > 8 || row < 0)
                return false;
            return true;
        }


    }
}
