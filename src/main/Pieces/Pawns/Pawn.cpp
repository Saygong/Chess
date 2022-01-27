//
// Created by Andrea on 27/01/2022.
//

#include <iostream>
#include "Pawn.h"

Pawn::Pawn(bool own, string name, Position p) : Piece(own, move(name), p) {
    firstMove = true;
    movingUp = this->owner;
};


vector<Position>* Pawn::validMove(Position start, Position end) {

    vector<Position>* trace = Piece::validMove(start, end);

    if(trace){
        int col = (start.getRealCoord()).first;
        int colEnd = (end.getRealCoord()).first;
        int rowEnd = (end.getRealCoord()).second;
        int rowStart = (start.getRealCoord()).second;
        int direction = movingUp ? (rowStart-rowEnd) : (rowEnd-rowStart);
        if(col == colEnd && direction > 0){

            if(this->firstMove) {


                int min = rowStart < rowEnd ? rowStart : rowEnd;
                int max = rowStart > rowEnd ? rowStart : rowEnd;

                if (((rowStart > rowEnd) && (rowEnd > rowStart - 3)) || ((rowStart < rowEnd) && (rowEnd < rowStart + 3))) {



                    for (int i = min; i <= max; i++) {

                        if (!(Position(col, i).equals(start))) {
                            trace->insert(trace->begin(), Position(col, i));
                        }
                    }
                    this->firstMove = false;

                    return trace;

                } else return nullptr;

            }

            else{
                trace->insert(trace->begin(), end);
                return trace;
            }


        }

    }
    return nullptr;

}
