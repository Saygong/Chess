//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_BOARD_H
#define CHESS_BOARD_H

#include<map>
#include "../Pieces/Piece.h"
#include "../Position/Position.h"
using namespace std;

class Board {

protected:
    unsigned int b_width, b_height;
    map<Position, Piece> b_pieces;
    bool player_turn;

public:
    Board(int width, int height);
    Piece* getPiece(Position p) const;

    // Virtual methods allow to be runtime overridden by the sub-type -> implementation of ChessBoard & CheckersBoard
    virtual void initBoard();
    virtual bool makeMove();
    virtual void run();

};


#endif //CHESS_BOARD_H
