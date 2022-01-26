//
// Created by andre on 23/01/2022.
//

#ifndef CHESS_CHESSBOARD_H
#define CHESS_CHESSBOARD_H

#include "../Board.h"



/**
 * Derived class that specify a chess board
 */
class ChessBoard: public Board {

private:
    /**
     * Private helper method to set the pieces
     * @param owner
     */
    void createSet(bool owner);
    bool isUserWhite;

public:
    ChessBoard();
    Position WhiteKingPosition;
    Position BlackKingPosition;
    void initBoard() override;



    /** Display the chessboard in terminal. */
    void printBoard();

    /** Return 0 if White is checked, 1 if Black is checked, -1 if neither. */
    int check();

    /** Return 1 if a stalemate is reached, 0 if not. */
    int Stalemate();

    /** Return 1 if a checkmate is reached, 0 if not. */
    bool checkMate(int status);


    bool allowedMove(vector<Position> a) override;

    void makeMove() override;

    void run() override{

    }
};


#endif //CHESS_CHESSBOARD_H






