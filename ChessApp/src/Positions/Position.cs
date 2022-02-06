using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//
// Created by andre on 23/01/2022.
//


namespace ChessApp.src.Positions
{

    internal class myTuple<A, B>
    {
        public A first;
        public B second;

        public myTuple(A f, B s)
        {
            first = f;
            second = s;
        }

    };

    internal class Position
    {

        private myTuple<int, int> real_coord;

        /**
         * Private helper method that allow to parse logical coordinates [A-H][1-8] into real matrix coordinates [0-7][0-7]
         * @return
         */
        private myTuple<int, int> parseCoord()
        {
            int int_col = (int)this.coord.first - 65;
            return new myTuple<int, int>(int_col, (8 - this.coord.second));
        }

        /**
         * Private helper method that allow to parse real coordinates [0-7][0-7] into real matrix coordinates [A-H][1-8]
         * @return
         */
        private myTuple<char, int> parseRealCoord()
        {
            char char_col = (char)(this.real_coord.first + 65);
            return new myTuple<char, int>(char_col, 8 - this.real_coord.second);
        }


        /**
         * Coordinate express by a tuple<char, int>
         * The char represents the column and the integer represents the row
         */
        public myTuple<char, int> coord;
        public myTuple<int, int> getRealCoord()
        {
            return this.real_coord;
        }

        public Position(char col, int row)
        {
            this.coord = new myTuple<char, int>(col, row);
            this.real_coord = parseCoord();
        }
        public Position(int col, int row)
        {
            this.real_coord = new myTuple<int, int>(col, row);
            this.coord = parseRealCoord();
        }


        /**
         * Method that compares two positions
         * @param p
         * @return true if positions are equals, false otherwise
         */
        public bool equals(Position p)
        {
            return (p.coord.first == this.coord.first) &&
           (p.coord.second == this.coord.second);
        }

        /**
         * Method that allow to represent a Position with a string
         * @return string
         */
        public string toString(string s){

            if (s.Equals("ideal"))
            {
                string f = this.coord.first.ToString();
                string sec = this.coord.second.ToString();
                return "( " + f + ", " + sec + " )";
            }
            else
            {
                string f = this.real_coord.first.ToString();
                string sec = this.real_coord.second.ToString();
                return "( " + f + ", " + sec + " )";
            }

        }

        /**
         * Check if a position is valid. Inside the ranges [A-H] and [1-8]
         * @return true if the position is valid, false otherwise
         */
        public bool isValidPosition()
        {
            myTuple<char, int> c = this.coord;
            if ((int)c.first < 65 || (int)c.first > 72 || c.second < 1 || c.second > 8)
                return false;
            return true;
        }


    }
}
