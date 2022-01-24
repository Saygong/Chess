//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_BOARD_H
#define CHESS_BOARD_H

#include<vector>
#include "../Pieces/Piece.h"
#include "../Position/Position.h"
using namespace std;


/**
 * Base class that represent a generic board for a game
 */
class Board {

protected:
    /**
     * Fields that represent the width and the height of the game board
     */
    unsigned int b_width, b_height;

    /**
     * Vector field that keep trace of all the pieces placed in the board
     */
    vector<Piece> b_pieces;

    /**
     * String value representing the turn
     */
    string player_turn;

public:
    Board(int width, int height);

    /**
     * Method that retrieve the piece placed in a given position, use the information contained in b_pieces vector
     * @param p
     * @return Pointer of the piece in a given position, nullptr otherwise
     */
    Piece* getPiece(Position p);

    // Pure virtual methods, I make sure they will be overridden
    /**
     * Pure virtual method used for the initialization of the board
     */
    virtual void initBoard()=0;

    /**
     * Allow user to make a move
     * @return
     */
    virtual bool makeMove()=0;

    /**
     * Main game loop, every derived class will implements its own game logic
     */
    virtual void run()=0;

};


#endif //CHESS_BOARD_H
