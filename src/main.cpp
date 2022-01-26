//
// Created by andre on 22/01/2022.
//

#include<iostream>
#include "main/Pieces/Piece.h"
#include "main/Board/Board.h"
#include "main/Board/ChessBoard/ChessBoard.h"
#include "main/Position/Position.h"
#include "main/Pieces/Rooks/Rook.h"
#include "main/Pieces/Knights/Knight.h"
#include "main/Pieces/Bishops/Bishop.h"

using namespace std;

int main(){

    auto* board = new ChessBoard();

    board->initBoard();
    Piece* a = board->getPiece(Position('D', 5));

    a = board->getPiece(Position('D', 1));

    board->printBoard();
    //board->makeMove();


    Rook myRook = Rook(true,"rook", Position('A', 1));
    vector<Position>* traceRook = myRook.validMove(Position('A', 1), Position('F', 1));
    cout<<"Rook: ";
    for(Position i : *traceRook){
         cout<< i.toString();
    }
    cout <<endl;

    Knight myKnight = Knight(true,"knight", Position('A', 1));
    vector<Position>* traceKnight = myKnight.validMove(Position('C', 3), Position('D', 1));
    cout << "Knight: ";
    cout << traceKnight <<endl;

    Bishop myBish = Bishop(true,"bishop", Position('D', 3));
    vector<Position>* traceBishop = myBish.validMove(myBish.p, Position('F', 5));
    cout<<"Bishop: ";
    for(Position i : *traceBishop){
        cout<< i.toString();
    }
    cout <<endl;





    return 0;
}
