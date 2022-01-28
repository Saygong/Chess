//
// Created by andre on 22/01/2022.
//

#ifndef CHESS_PIECE_H
#define CHESS_PIECE_H

#include<string>
#include<vector>
#include "../Position/Position.h"
using namespace std;

class Piece {

protected:
    bool owner;
    static void horizontalMovement(Position start, Position end, vector<Position>* trace);
    static void verticalMovement(Position start, Position end, vector<Position>* trace);
    static void diagonalMovement(Position start, Position end, vector<Position>* trace);

public:
    string name;
    Position p;
    Piece(bool own, string name, Position p);


    /**
     *  Return a valid vector containing all the position covered by the move if the move is valid
     *  a nullptr otherwise
     */
    virtual vector<Position>* validMove(Position start, Position end);

    /**
     * Provide a string representation of a piece
     * @return string
     */
    string toString() const;



};


#endif //CHESS_PIECE_H
