//
// Created by andre on 23/01/2022.
//

#include "Rook.h"

Rook::Rook(bool own, string name, Position p) : Piece(own, move(name), p) {};


vector<Position>* Rook::validMove(Position start, Position end) {

    vector<Position>* trace = Piece::validMove(start, end);

    if(trace) {
        if (start.coord.first == end.coord.first){
            Piece::verticalMovement(start, end, trace);
        }
        else {
            Piece::horizontalMovement(start, end, trace);
        }
        return trace;
    }
    return nullptr;

}


