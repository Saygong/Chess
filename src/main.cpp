//
// Created by andre on 22/01/2022.
//

#include<iostream>
#include "main/Pieces/Piece.h"
#include "main/Board/Board.h"
#include "main/Board/ChessBoard/ChessBoard.h"
#include "main/Position/Position.h"
#include "main/Pieces/Rooks/Rook.h"

using namespace std;

int main(){

    auto* board = new ChessBoard();

    board->initBoard();
    Piece* a = board->getPiece(Position('D', 5));

    a = board->getPiece(Position('D', 1));

    board->printBoard();
    //board->makeMove();


    Rook myRook = Rook(true,"rook", Position('A', 1));
    vector<Position>* trace = myRook.validMove(Position('A', 1), Position('F', 1));

    for(Position i : *trace){
         cout<< i.toString();
    }





    return 0;
}
