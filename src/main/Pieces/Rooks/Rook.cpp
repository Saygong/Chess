//
// Created by andre on 23/01/2022.
//

#include "Rook.h"
#include<iostream>
#include <utility>

Rook::Rook(bool own, string name, Position p) : Piece(own, std::move(name), p) {};


vector<Position>* Rook::validMove(Position start, Position end) {

    vector<Position>* trace = new vector<Position>();
    //Piece::validMove(start, end);

    if(trace) {
        cout<<start.toString();
        if (start.coord.first == end.coord.first){
            int a = (start.getRealCoord()).second;
            int b = (end.getRealCoord()).second;
            int min = a > b ? b : a;
            int max = a < b ? b : a;
            for(int i =  min + 1; i <= max; i++){
                trace->insert(trace->begin(), Position(start.coord.first, i));
            }

        }
        else {

            int a = start.getRealCoord().first;
            int b = end.getRealCoord().first;
            int min = a > b ? b : a;
            int max = a < b ? b : a;

            for(int i =  min + 1; i <= max; i++){
                char c = (char)(65+i);
                trace->insert(trace->begin(), Position(c, start.coord.second));
            }

        }
    }
    return trace;

}


