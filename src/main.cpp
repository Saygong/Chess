//
// Created by andre on 22/01/2022.
//

#include<iostream>
#include "main/Pieces/Piece.h"
#include "main/Board/Board.h"
#include "main/Board/ChessBoard/ChessBoard.h"
#include "main/Utilities/idGenerator.cpp"

using namespace std;

int count();

int main(){
    cout<< "Hello World!";

    ChessBoard* board = new ChessBoard();

    board->initBoard();
    board->run();


    return 0;
}
