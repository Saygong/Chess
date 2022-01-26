//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_ROOK_H
#define CHESS_ROOK_H

#include <string>
#include <utility>
#include <vector>
#include "../Piece.h"
#include "../../Position/Position.h"
using namespace std;


class Rook: public Piece{

public:
    Rook(bool own, string name, Position p);
    vector<Position>* validMove(Position start, Position end) override;

};


#endif //CHESS_ROOK_H
