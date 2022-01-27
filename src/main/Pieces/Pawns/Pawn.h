//
// Created by Andrea on 27/01/2022.
//

#ifndef CHESS_PAWN_H
#define CHESS_PAWN_H

#include <string>
#include <utility>
#include <vector>
#include "../Piece.h"
#include "../../Position/Position.h"
using namespace std;


class Pawn: public Piece {

private:
    bool firstMove;

    //Field that contains the direction of the pawn - values: true if owner is true, false otherwise
    bool movingUp;

public:
    Pawn(bool own, string name, Position p);
    vector<Position>* validMove(Position start, Position end) override;


};


#endif //CHESS_PAWN_H
