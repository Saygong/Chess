//
// Created by Andrea on 26/01/2022.
//

#include "Bishop.h"



Bishop::Bishop(bool own, string name, Position p) : Piece(own, move(name), p) { };


//TODO to fix
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

            int minCol =  colStart < colEnd ? colStart : colEnd;
            int maxCol =  colStart > colEnd ? colStart : colEnd;
            int minRow =  rowStart < rowEnd ? rowStart : rowEnd;

            for(int i = minCol; i < maxCol; i++){
                trace->insert(trace->begin(), Position(i, minRow));
                minRow++;
            }
            return trace;
        }

    }
    return nullptr;

}


