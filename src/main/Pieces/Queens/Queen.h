//
// Created by Andrea on 28/01/2022.
//

#ifndef CHESS_QUEEN_H
#define CHESS_QUEEN_H


#include <string>
#include <utility>
#include <vector>
#include "../Piece.h"
#include "../../Position/Position.h"
using namespace std;


class Queen: public Piece {

public:
    Queen(bool own, string name, Position p);
    vector<Position>* validMove(Position start, Position end) override;

};


#endif //CHESS_QUEEN_H
