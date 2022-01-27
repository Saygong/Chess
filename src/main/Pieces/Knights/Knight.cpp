//
// Created by Andrea on 26/01/2022.
//

#include "Knight.h"


Knight::Knight(bool own, string name, Position p) : Piece(own, move(name), p){ }


vector<Position>* Knight::validMove(Position start, Position end) {


    // No need to find the movement trace of a knight, it can jump other pieces

    vector<Position>* trace = Piece::validMove(start, end);
    if(trace){

        int colStart = start.getRealCoord().first;
        int rowStart = start.getRealCoord().second;
        int colEnd = end.getRealCoord().first;
        int rowEnd = end.getRealCoord().second;

        if(colStart == colEnd+1 || colStart == colEnd-1){
            if(rowStart == rowEnd+1 || rowStart == rowEnd+2 || rowStart == rowEnd-1 || rowStart == rowEnd-2)
                return trace;
        }
    }
    return nullptr;

}