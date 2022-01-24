//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_ROOK_H
#define CHESS_ROOK_H

#include "../Piece.h"

class Rook: public Piece{

public:
    Rook(bool own, string name);
    int validMove(Position start, Position end) override;

};


#endif //CHESS_ROOK_H
