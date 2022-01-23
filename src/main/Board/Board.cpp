//
// Created by andre on 23/01/2022.
//

#include "Board.h"

Board::Board(int width, int height){
    b_height = height;
    b_width = width;
}

void Board::initBoard() {

}

bool Board::makeMove() {
    return false;
}

void Board::run() {

}

Piece *Board::getPiece(Position p) const {
    return nullptr;
}
