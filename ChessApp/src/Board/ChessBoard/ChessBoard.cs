using ChessApp.src.Positions;
using ChessApp.src.Utilities;
using ChessApp.src.Pieces.Rook;
using ChessApp.src.Pieces.Knight;
using ChessApp.src.Pieces.Queen;
using ChessApp.src.Pieces.Pawn;
using ChessApp.src.Pieces.King;
using ChessApp.src.Pieces;
using ChessApp.src.Pieces.Bishop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// Created by andrea on 23/01/2022.
//

namespace ChessApp.src.Board.ChessBoard
{
    internal class ChessBoard : Board
    {

        bool isUserWhite;


        /**
         * Private helper method to set the pieces
         * @param owner
         */
        private void generateSets()
        {

            string userPrefix;
            string pcPrefix;
            if (isUserWhite)
            {
                userPrefix = "w";
                pcPrefix = "b";
            }
            else
            {
                userPrefix = "b";
                pcPrefix = "w";
            }


            // Placing pawns
            for (int i = 65; i < 73; i++)
            {
                Position userP = new Position((char)i, 2);
                b_pieces.Add(new Pawn(true, userPrefix + "Pawn", userP));

                Position pcP = new Position((char)i, 7);
                b_pieces.Add(new Pawn(true, pcPrefix + "Pawn", pcP));

            }

            // Placing Knights, Bishops, Rooks, Queens and Kings
            
                
            b_pieces.Add(new Rook(true, userPrefix + "Rook", new Position('A', 1)));
            b_pieces.Add(new Rook(true, userPrefix + "Rook", new Position('H', 1)));
            b_pieces.Add(new Knight(true, userPrefix + "Knight", new Position('B', 1)));
            b_pieces.Add(new Knight(true, userPrefix + "Knight", new Position('G', 1)));
            b_pieces.Add(new Bishop(true, userPrefix + "Bishop", new Position('C', 1)));
            b_pieces.Add(new Bishop(true, userPrefix + "Bishop", new Position('F', 1)));
            b_pieces.Add(new Queen(true, userPrefix + "Queen", new Position('D', 1)));
            b_pieces.Add(new King(true, userPrefix + "King", new Position('E', 1)));
              
            b_pieces.Add(new Rook(false, pcPrefix + "Rook", new Position('A', 8)));
            b_pieces.Add(new Rook(false, pcPrefix + "Rook", new Position('H', 8)));
            b_pieces.Add(new Knight(false, pcPrefix + "Knight", new Position('B', 8)));
            b_pieces.Add(new Knight(false, pcPrefix + "Knight", new Position('G', 8)));
            b_pieces.Add(new Bishop(false, pcPrefix + "Bishop", new Position('C', 8)));
            b_pieces.Add(new Bishop(false, pcPrefix + "Bishop", new Position('F', 8)));
            b_pieces.Add(new Queen(false, pcPrefix + "Queen", new Position('D', 8)));
            b_pieces.Add(new King(false, pcPrefix + "King", new Position('E', 8)));
            

        }
            

        public ChessBoard() : base(8, 8)
        {
            this.isUserWhite = Utility.random(50);
        }
         

        public override void initBoard()
        {
            this.player_turn = "white";

            /* Creation of the user set of pieces */
            generateSets();
            
        }

        public override void placePieces(TableLayoutPanel tbl)
        {

            // Adding pictureboxes with images
            foreach (Piece piece in b_pieces)
            {

                PictureBox pb = new PictureBox();
                pb.ImageLocation = @"../../../Resources/pieces/" + piece.name + ".png";
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Dock = DockStyle.Fill;
                int row = piece.p.getRealCoord().second;
                int col = piece.p.getRealCoord().first;
                tbl.Controls.Add(pb, col, row);
            }

            // Adding empty pictureboxes to enable movement
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    tbl.Controls.Add(pb, j, i);

                }
            }

        }


        //TODO

        /** Return 0 if White is checked, 1 if Black is checked, -1 if neither. */
        public int check()
        {
            return 1;
        }

        /** Return 1 if a stalemate is reached, 0 if not. */
        public int Stalemate()
        {
            return 1;
        }

        /** Return 1 if a checkmate is reached, 0 if not. */
        public bool checkMate(int status)
        {
            return true;
        }


        public override bool allowedMove(List<Position> a)
        {
            return false;
        }

        public override void makeMove()
        {
        
        }

        public override void run()
        {

        }

}
}
