//
// Created by Andrea on 26/01/2022.
//

#ifndef CHESS_BISHOP_H
#define CHESS_BISHOP_H


#include<string>
#include<vector>
#include "../../Position/Position.h"
#include "../Piece.h"
using namespace std;



class Bishop: public Piece {

public:
    Bishop(bool own, string name, Position p);
    vector<Position>* validMove(Position start, Position end) override;

};


#endif //CHESS_BISHOP_H
