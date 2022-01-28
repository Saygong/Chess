//
// Created by andre on 22/01/2022.
//

#include <vector>
#include "Piece.h"
using namespace std;

vector<Position>* Piece::validMove(Position start, Position end) {
    if (start.isValidPosition() && end.isValidPosition())
        return new vector<Position>();
    return nullptr;
}


Piece::Piece(bool own, string name, Position p) {
    this->p = p;
    owner = own;
    this->name= name;
}

string Piece::toString() const {
    return "Piece: " + this->name;
}


void Piece::horizontalMovement(Position start, Position end, vector<Position>* trace){

    int a = (start.getRealCoord()).first;
    int b = (end.getRealCoord()).first;
    int mi = a < b ? a : b;
    int ma = a > b ? a : b;

    for(int i =  mi + 1; i <= ma; i++){
        char c = (char)(65+i);
        trace->insert(trace->begin(), Position(c, start.coord.second));
    }

}

void Piece::verticalMovement(Position start, Position end, vector<Position>* trace){

    int a = (start.getRealCoord()).second;
    int b = (end.getRealCoord()).second;
    int mi = a < b ? a : b;
    int ma = a > b ? a : b;

    for(int i =  mi + 1; i <= ma; i++){
        trace->insert(trace->begin(), Position(start.coord.first, i));
    }

}

void Piece::diagonalMovement(Position start, Position end, vector<Position>* trace){

    int colStart = start.getRealCoord().first;
    int rowStart = start.getRealCoord().second;
    int colEnd = end.getRealCoord().first;
    int rowEnd = end.getRealCoord().second;
    int minCol = colStart < colEnd ? colStart : colEnd;
    int maxCol = colStart > colEnd ? colStart : colEnd;
    int minRow = rowStart < rowEnd ? rowStart : rowEnd;
    int maxRow = rowStart > rowEnd ? rowStart : rowEnd;

    if ((colStart > colEnd && rowStart > rowEnd) || (colStart < colEnd && rowStart < rowEnd)){

        for (int i = minCol; i <= maxCol; i++) {
            if (!(Position(i, minRow).equals(start))) {
                trace->insert(trace->begin(), Position(i, minRow));
            }
            minRow++;
        }

    }
    else{

        for(int i = minCol; i <= maxCol; i++){
            if(!(Position(i, maxRow).equals(start))){
                trace->insert(trace->begin(), Position(i, maxRow));
            }
            maxRow--;
        }

    }

}
