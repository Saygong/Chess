//
// Created by andre on 22/01/2022.
//

#include<iostream>
#include "main/Pieces/Piece.h"
#include "main/Board/Board.h"
#include "main/Board/ChessBoard/ChessBoard.h"
#include "main/Position/Position.h"
using namespace std;


int main(){

    auto* board = new ChessBoard();

    board->initBoard();
    Piece* a = board->getPiece(Position('D', 7));
    cout<< a->toString() << endl;

    a = board->getPiece(Position('D', 1));
    cout<< a->toString() << endl;

    return 0;
}
