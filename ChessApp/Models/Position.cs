
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
