//
// Created by andre on 23/01/2022.
//


#include "ChessBoard.h"
#include "../../Utilities/random.cpp"

ChessBoard::ChessBoard() : Board(8,8){
    this-> isUserWhite = random(50);
};

void ChessBoard::createSet(bool owner){

    // Placing the pawns
    int row = owner ? 7 : 2;
    for(int i = 65; i < 72; i++){
        Position p = Position((char)i, row);
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Pawn", p));
    }

    // Placing Knights, Bishops, Rooks, Queens and Kings
    if (owner){
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Rook", Position('A', 8)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Rook", Position('H', 8)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Knight", Position('B', 8)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Knight", Position('G', 8)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Bishop", Position('C', 8)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Bishop", Position('F', 8)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Queen", Position('D', 8)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "King", Position('E', 8)));
    }
    else {
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Rook", Position('A', 1)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Rook", Position('H', 1)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Knight", Position('B', 1)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Knight", Position('G', 1)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Bishop", Position('C', 1)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Bishop", Position('F', 1)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "Queen", Position('D', 1)));
        b_pieces.insert(b_pieces.begin(), Piece(owner, "King", Position('E', 1)));
    }
}




void ChessBoard::initBoard() {;

    this-> player_turn = isUserWhite;

    /* Creation of the user set of pieces */
    createSet(true);
    /* Creation of the AI set of pieces */
    createSet(false);

}

void ChessBoard::printBoard() {

}

int ChessBoard::check() {
    return 0;
}


bool ChessBoard::makeMove() {
    return false;
}

void Board::run() {

}
