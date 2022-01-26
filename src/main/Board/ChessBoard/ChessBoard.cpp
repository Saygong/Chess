//
// Created by andre on 23/01/2022.
//


#include <iostream>
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

    this-> player_turn = "white";

    /* Creation of the user set of pieces */
    createSet(true);
    /* Creation of the AI set of pieces */
    createSet(false);

}

int ChessBoard::check() {
    return 0;
}

int min(int a, int b){
    return a > b ? b : a;
}
int max(int a, int b){
    return a < b ? b : a;
}


bool ChessBoard::allowedMove(vector<Position> trace) {
    //TODO

    return true;
}


void ChessBoard::makeMove() {
    char startChar, endChar;
    int startInt, endInt;
    cout << "Insert coordinates [letter][number] x [letter][number]" <<endl;

    cin>> startChar;
    cin>> startInt;
    cin>> endChar;
    cin>> endInt;

    // TODO add integrity check for the coordinates
    Position start = Position(startChar, startInt);
    Position end = Position(endChar, endInt);

    Piece* p = this->getPiece(start);
    vector<Position>* validity = p->validMove(start, end);
    //TODO wait until the different validMove are implemented -> implement a method that check if the path of the piece is occupied
    // Note, the trace of a knight is empty because it's the only piece that can jump over other pieces



}

void printDiv(){
    cout << "   ";
    for(int i = 0; i < 8; i++){
        cout <<"-- ";
    }
    cout<<endl;
}

void ChessBoard::printBoard() {

    cout << "   ";
    for(int i = 65; i < 73; i++){
        cout <<" " <<(char)i << " ";
    }
    cout <<endl;

    for(int i = 8; i > 0; i--){
        printDiv();
        cout << i << " ";
        for(int j = 0; j < 8; j++){
            cout << "|  ";
        }
        cout << "|" << endl;

    }
    printDiv();

}


void Board::run() {




}
