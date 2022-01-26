//
// Created by Andrea on 26/01/2022.
//

#ifndef CHESS_KNIGHT_H
#define CHESS_KNIGHT_H

#include<string>
#include<vector>
#include <utility>
#include "../../Position/Position.h"
#include "../Piece.h"
using namespace std;



class Knight: public Piece{

public:
    Knight(bool own, string name, Position p);
    vector<Position>* validMove(Position start, Position end) override;

};


#endif //CHESS_KNIGHT_H
