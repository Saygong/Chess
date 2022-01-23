//
// Created by andre on 23/01/2022.
//

#include<iostream>
#include "ChessBoard.h"
#include "../../Pieces/Rook/Rook.h"


ChessBoard::ChessBoard() : Board(8,8){};

void ChessBoard::createPlayerSet(){
    map<Position, Piece> m = this->b_pieces;

    // TODO create different classes representing different pieces
    Rook rookr = Rook(true, "Rook");


    auto it = m.find(Position('A', 8));
    if (it != m.end())
        it->second = rookr;

}

void createAISet(Board* board){

}


void ChessBoard::initBoard() {;
    map<Position, Piece> m = this->b_pieces;
    Piece empty = Piece(false, "empty");
    for(int i = 65; i < 72; i++){
        for(int j = 0; j < 8; j++){
            m.emplace( Position((char)i, j) , empty );
        }
    }

    createAISet();
    createPlayerSet();

}
