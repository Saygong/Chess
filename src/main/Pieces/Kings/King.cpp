//
// Created by Andrea on 28/01/2022.
//

#include <iostream>
#include "King.h"


King::King(bool own, string name, Position p) : Piece(own, move(name), p) { }


vector<Position>* King::validMove(Position start, Position end) {

    vector<Position>* trace = Piece::validMove(start, end);

    if(trace){

        int colStart = (start.getRealCoord()).first;
        int colEnd = (end.getRealCoord()).first;
        int rowEnd = (end.getRealCoord()).second;
        int rowStart = (start.getRealCoord()).second;

        if(colStart == colEnd+1 || colStart == colEnd-1 || colStart == colEnd){

            if(rowStart == rowEnd+1 || rowStart == rowEnd-1 || rowStart == rowEnd){

                trace->insert(trace->begin(), end);
                return trace;

            }
        }

    }

    return nullptr;

}
