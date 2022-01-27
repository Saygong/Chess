//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_POSITION_H
#define CHESS_POSITION_H

#include<string>
using namespace std;


template<class A, class B>
class Tuple {
public:
    A first;
    B second;

    Tuple(A f, B s){
        first = f;
        second = s;
    }

    Tuple() = default;


};


/**
 * Class that represent the position of a piece while on the board
 */
class Position {

private:
    Tuple<int, int> real_coord;
    /**
     * Private helper method that allow to parse logical coordinates [A-H][1-8] into real matrix coordinates [0-7][0-7]
     * @return
     */
    Tuple<int, int> parseCoord() const;

    /**
     * Private helper method that allow to parse real coordinates [0-7][0-7] into real matrix coordinates [A-H][1-8]
     * @return
     */
    Tuple<char, int> parseRealCoord() const;

public:
    Position();
    Position(char col, int row);
    Position(int col, int row);

    /**
     * Coordinate express by a tuple<char, int>
     * The char represents the column and the integer represents the row
     */
    Tuple<char, int> coord;
    Tuple<int, int> getRealCoord();

    /**
     * Method that compares two positions
     * @param p
     * @return true if positions are equals, false otherwise
     */
    bool equals(Position p) const;

    /**
     * Method that allow to represent a Position with a string
     * @return string
     */
    string toString(const char *s) const;

    /**
     * Check if a position is valid. Inside the ranges [A-H] and [1-8]
     * @return true if the position is valid, false otherwise
     */
    bool isValidPosition() const;



};


#endif //CHESS_POSITION_H
