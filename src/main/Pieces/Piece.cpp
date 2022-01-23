//
// Created by andre on 22/01/2022.
//

#include "Piece.h"


int Piece::validMove(Position start, Position end) {
    Tuple<int, int> real_c = end.getRealCoord();
    if (real_c.first < 0 || real_c.first > 8 || real_c.second < 0 || real_c.second > 8)
        return 0;
    return 1;
}


Piece::Piece(bool own, string name, Position p) {
    this->p = p;
    owner = own;
    this->name= name;
}

string Piece::toString() const {
    return "Piece: " + this->name;
}
