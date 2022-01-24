//
// Created by andre on 22/01/2022.
//

#include "Piece.h"


int Piece::validMove(Position start, Position end) {
    if (start.isValidPosition() && end.isValidPosition())
        return 1;
    return 0;
}


Piece::Piece(bool own, string name, Position p) {
    this->p = p;
    owner = own;
    this->name= name;
}

string Piece::toString() const {
    return "Piece: " + this->name;
}
