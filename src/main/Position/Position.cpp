//
// Created by andre on 23/01/2022.
//

#include "Position.h"


Position::Position() {};

Position::Position(char col, int row){
    this->ideal_coord = Tuple<char, int>(col,row);
    this->real_coord = parseCoord();

};


Tuple<int, int> Position::parseCoord() {
    int int_col = (int)this->ideal_coord.first - 65;
    return Tuple<int, int>(int_col, this->ideal_coord.second);
};


Tuple<int, int> Position::getRealCoord() {
    this->parseCoord();
    return this->real_coord;
};


bool Position::equals(Position p) const{
    return (p.ideal_coord.first == this->ideal_coord.first) &&
           (p.ideal_coord.second == this->ideal_coord.second);
};


