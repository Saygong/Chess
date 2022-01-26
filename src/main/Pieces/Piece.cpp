//
// Created by andre on 22/01/2022.
//

#include <vector>
#include "Piece.h"
using namespace std;

vector<Position>* Piece::validMove(Position start, Position end) {
    if (start.isValidPosition() && end.isValidPosition())
        return new vector<Position>();
    return nullptr;
}


Piece::Piece(bool own, string name, Position p) {
    this->p = p;
    owner = own;
    this->name= name;
}




string Piece::toString() const {
    return "Piece: " + this->name;
}
