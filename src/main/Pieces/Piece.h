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
    Piece();
    Piece(bool own, string name);
    string name;


    /**
     *  Return 0 if the move isn't valid, 1 otherwise
     */
    virtual int validMove(Position start, Position end);


};


#endif //CHESS_PIECE_H
