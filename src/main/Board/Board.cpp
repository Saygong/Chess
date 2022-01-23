//
// Created by andre on 23/01/2022.
//

#include "Board.h"

Board::Board(int width, int height){
    b_height = height;
    b_width = width;
}


Piece* Board::getPiece(Position p) {
    for (auto i = b_pieces.begin(); i != b_pieces.end(); ++i){
        if(i->p.equals(p))
            return &(*i);
    }
    return nullptr;

}
