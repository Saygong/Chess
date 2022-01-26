//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_ROOK_H
#define CHESS_ROOK_H

#include "../Piece.h"
#include <vector>
using namespace std;


class Rook: public Piece{

public:
    Rook(bool own, string name, Position p);
    vector<Position>* validMove(Position start, Position end) override;

};


#endif //CHESS_ROOK_H
