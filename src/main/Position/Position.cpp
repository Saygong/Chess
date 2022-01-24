//
// Created by andre on 23/01/2022.
//

#include "Position.h"


Position::Position() {};

Position::Position(char col, int row){
    this->coord = Tuple<char, int>(col,row);
    this->real_coord = parseCoord();

};


Tuple<int, int> Position::parseCoord() const {
    int int_col = (int)this->coord.first - 65;
    return Tuple<int, int>(int_col, (this->coord.second)-1);
};


Tuple<int, int> Position::getRealCoord() {
    this->parseCoord();
    return this->real_coord;
};


bool Position::equals(Position p) const{
    return (p.coord.first == this->coord.first) &&
           (p.coord.second == this->coord.second);
};

bool Position::isValidPosition() const {
    Tuple<char, int> c = this->coord;
    if ( (int)c.first < 65 || (int)c.first > 72 || c.second < 1 || c.second > 8 )
        return false;
    return true;


}


