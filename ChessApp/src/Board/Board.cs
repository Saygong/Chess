
using ChessApp.src.Pieces;
using ChessApp.src.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// Created by andrea on 23/01/2022.
//

namespace ChessApp.src.Board
{
    internal abstract class Board {


        /**
         * Fields that represent the width and the height of the game board
         */
        protected int b_width, b_height;

        /**
         * Vector field that keep trace of all the pieces placed in the board
         */
        protected List<Piece> b_pieces;

        /**
         * String value representing the turn
         */
        protected string player_turn;

        
        public Board(int width, int height)
        {
            b_pieces = new List<Piece>();
            b_height = height;
            b_width = width;
            
        }

        /**
         * Method that retrieve the piece placed in a given position, use the information contained in b_pieces vector
         * @param p
         * @return Pointer of the piece in a given position, nullptr otherwise
         */
        public Piece? getPiece(Position p)
        {
            
            foreach (Piece i in b_pieces)
            {
                if ((i.p).equals(p))
                    return i;
            }
            return null;

        }

        // Pure virtual methods, I make sure they will be overridden
        /**
         * Pure virtual method used for the initialization of the board
         */
        public abstract void initBoard() ;

        public abstract void placePieces(TableLayoutPanel tbl);

        /**
         * Allow user to make a move
         */
        public abstract void makeMove();

        /**
         * Check if a move is allowed in the board
         * @return true if the move is allowed, false otherwise
         */
        public abstract bool allowedMove(List<Position> a);

        /**
         * Main game loop, every derived class will implements its own game logic
         */
        public abstract void run();



    }
}
