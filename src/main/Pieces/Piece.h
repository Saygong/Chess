//
// Created by andre on 22/01/2022.
//

#ifndef CHESS_PIECE_H
#define CHESS_PIECE_H

#include<string>
#include "../Position/Position.h"
using namespace std;

class Piece {

protected:
    bool owner;

public:
    string name;
    Position p;
    Piece(bool own, string name, Position p);


    /**
     *  Return 0 if the move isn't valid, 1 otherwise
     */
    virtual int validMove(Position start, Position end);

    /**
     * Provide a string representation of a piece
     * @return string
     */
    string toString() const;



};


#endif //CHESS_PIECE_H
