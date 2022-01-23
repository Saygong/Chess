//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_POSITION_H
#define CHESS_POSITION_H


template<class A, class B>
class Tuple {
public:
    A first;
    B second;

    Tuple(A f, B s){
        first = f;
        second = s;
    }

    Tuple() = default;


};

class Position : public std::pair {

private:
    Tuple<int, int> real_coord;
    Tuple<int, int> parseCoord();

public:
    Position();
    Position(char col, int row);
    Tuple<char, int> ideal_coord;
    Tuple<int, int> getRealCoord();

};


#endif //CHESS_POSITION_H
