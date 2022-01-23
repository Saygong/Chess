//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_CHESSBOARD_H
#define CHESS_CHESSBOARD_H

#include "../Board.h"

class ChessBoard: public Board {

private:
    void createPlayerSet();

public:
    ChessBoard();
    void initBoard() override;

};


#endif //CHESS_CHESSBOARD_H
