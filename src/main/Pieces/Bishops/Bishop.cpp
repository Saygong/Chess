//
// Created by Andrea on 26/01/2022.
//

#include "Bishop.h"
#include <iostream>


Bishop::Bishop(bool own, string name, Position p) : Piece(own, move(name), p) { };


vector<Position>* Bishop::validMove(Position start, Position end) {

    vector<Position>* trace = Piece::validMove(start, end);

    if (trace){

        int colStart = start.getRealCoord().first;
        int rowStart = start.getRealCoord().second;
        int colEnd = end.getRealCoord().first;
        int rowEnd = end.getRealCoord().second;

        int diffCol = abs(colStart - colEnd);
        int diffRow = abs(rowStart - rowEnd);

        if (diffCol == diffRow) {

            Piece::diagonalMovement(start, end, trace);
            return trace;
        }

    }
    return nullptr;

}


