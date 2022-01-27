//
// Created by andre on 23/01/2022.
//

#include "Position.h"
#include<iostream>
#include <cstring>

Position::Position() {};

Position::Position(char col, int row){
    this->coord = Tuple<char, int>(col,row);
    this->real_coord = parseCoord();

};

Position::Position(int col, int row){
    this->real_coord = Tuple<int, int>(col,row);
    this->coord = parseRealCoord();

};


Tuple<int, int> Position::parseCoord() const {
    int int_col = (int)this->coord.first - 65;

    return Tuple<int, int>(int_col, (this->coord.second -1));
};

Tuple<char, int> Position::parseRealCoord() const {
    char char_col = (char)(this->real_coord.first + 65);
    return Tuple<char, int>(char_col, (this->real_coord.second)+1);
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

//Testing function
string Position::toString(const char *s) const{

    if(strcmp(s, "ideal")==0){
        string f  =  string(1,this->coord.first);
        string sec  = to_string(this->coord.second);
        return  "( " + f + ", " + sec + " )";
    }
    else{
        string f  =  to_string(this->real_coord.first);
        string sec  = to_string(this->real_coord.second);
        return  "( " + f + ", " + sec + " )";
    }

}


