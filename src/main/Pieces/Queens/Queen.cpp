//
// Created by Andrea on 28/01/2022.
//

#include <iostream>
#include "Queen.h"


Queen::Queen(bool own, string name, Position p) : Piece(own, move(name), p) { }


vector<Position>* Queen::validMove(Position start, Position end) {


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
        else if(start.coord.first == end.coord.first){
            Piece::verticalMovement(start, end, trace);
            return trace;
        }
        else{
            Piece::horizontalMovement(start, end, trace);
            return trace;
        }



    }
    return nullptr;


}