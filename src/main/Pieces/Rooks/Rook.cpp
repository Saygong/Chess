//
// Created by andre on 23/01/2022.
//

#include "Rook.h"

Rook::Rook(bool own, string name, Position p) : Piece(own, move(name), p) {};


vector<Position>* Rook::validMove(Position start, Position end) {

    vector<Position>* trace = Piece::validMove(start, end);

    if(trace) {
        if (start.coord.first == end.coord.first){
            int a = (start.getRealCoord()).second;
            int b = (end.getRealCoord()).second;
            int mi = a < b ? a : b;
            int ma = a > b ? a : b;

            for(int i =  mi + 1; i <= ma; i++){
                trace->insert(trace->begin(), Position(start.coord.first, i));
            }

        }
        else {
            int a = (start.getRealCoord()).first;
            int b = (end.getRealCoord()).first;
            int mi = a < b ? a : b;
            int ma = a > b ? a : b;

            for(int i =  mi + 1; i <= ma; i++){
                char c = (char)(65+i);
                trace->insert(trace->begin(), Position(c, start.coord.second));
            }

        }
    }
    return trace;

}


