//
// Created by Andrea on 28/01/2022.
//

#ifndef CHESS_KING_H
#define CHESS_KING_H

#include <string>
#include <utility>
#include <vector>
#include "../Piece.h"
#include "../../Position/Position.h"
using namespace std;

class King: public Piece {

public:
    King(bool own, string name, Position p);
    vector<Position>* validMove(Position start, Position end) override;

};


#endif //CHESS_KING_H
