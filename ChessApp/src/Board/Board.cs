
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
        public List<Piece> b_pieces;

        /**
         * Bool value representing the turn, true if it's the user turn, false otherwise
         */
        public bool player_turn;

        private Position firstClicked;
        private bool secondClick = false;
        private List<Position>? allowed;



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

        private void movePiece(Position start, Position end)
        {
            
            this.getPiece(start).p = end;
        }


        /**
         * Allow user to make a move
         * @return a list of position to color or un-color
         */
        public List<Position>? makeMove(Position click)
        {
            if (!secondClick)
            {
                this.allowed = (this.getPiece(click)).getAllowedMoves(this);

                if (allowed != null)
                {
                    secondClick = true;
                    firstClicked = click;
                }
                return allowed;

            }
            else
            {
                // Movement track: this.lblInfo.Text = board.getPiece(starting).p.toString("ideal");   and    board.getPiece(destination).p.toString("ideal");

                if (allowed != null)
                {
                    bool correct = false;
                    foreach (Position p in allowed)
                    {
                        if (click.equals(p))
                        {
                            correct = true;
                        }
                    }
                    if (correct)
                    {
                        movePiece(firstClicked, click);
                        secondClick = false;
                        return allowed;
                    }
                    else
                    {
                        secondClick = false;
                        firstClicked = null;

                    }
                    secondClick = false;
                }
                return null;
            }

        }


        public List<Position> randomAiMove()
        {
            Random rand = new Random();
            Piece? pick;
            List<Position> toReturn = new List<Position>();
            Position ending = null;
            Position starting = null;
            do
            {
                int col = rand.Next(0, 8);
                int row = rand.Next(0, 8);
                System.Diagnostics.Debug.WriteLine("(" + col + ", " + row + ")");
                pick = this.getPiece(new Position(col, row));
                if (pick != null && !pick.owner)
                {
                    starting = pick.p;
                    List<Position>? allow = pick.getAllowedMoves(this);
                    
                    if (allow != null)
                    {
                        int dest = rand.Next(0, allow.Count - 1);
                        ending = allow[dest]; 

                    }


                }
            }
            while (pick == null || pick.owner || ending == null);
            toReturn.Add(starting);
            toReturn.Add(ending);
            movePiece(starting, ending);
            return toReturn;
        }


        /**
         * Main game loop, every derived class will implements its own game logic
         */
        public abstract void run();

    }
}
