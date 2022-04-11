
using ChessApp.Models.Pieces;

namespace ChessApp.Models.Boards
{
    public class ChessBoard : Board
    {

        public int board_dimension = 8;



        public ChessBoard() : base()
        {
            initBoard();
        }


        private void initBoard()
        {

            /* Creation of the user set of pieces */
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
            for (int i = 0; i < 8; i++)
            {
                this.board[6,i].piece = new PawnTwoMoves("user", userPrefix + "Pawn");

                this.board[1,i].piece = new PawnTwoMoves("ai", pcPrefix + "Pawn");

            }

            // Placing Knights, Bishops, Rooks, Queens and Kings


            this.board[0,0].piece = new Rook("ai", pcPrefix + "Rook");
            this.board[0,7].piece = new Rook("ai", pcPrefix + "Rook");
            this.board[0,1].piece = new Knight("ai", pcPrefix + "Knight");
            this.board[0,6].piece = new Knight("ai", pcPrefix + "Knight");
            this.board[0,2].piece = new Bishop("ai", pcPrefix + "Bishop");
            this.board[0,5].piece = new Bishop("ai", pcPrefix + "Bishop");
            this.board[0,3].piece = new Queen("ai", pcPrefix + "Queen");
            this.board[0,4].piece = new King("ai", pcPrefix + "King");

            this.board[7,0].piece = new Rook("user", userPrefix + "Rook");
            this.board[7,7].piece = new Rook("user", userPrefix + "Rook");
            this.board[7,1].piece = new Knight("user", userPrefix + "Knight");
            this.board[7,6].piece = new Knight("user", userPrefix + "Knight");
            this.board[7,2].piece = new Bishop("user", userPrefix + "Bishop");
            this.board[7,5].piece = new Bishop("user", userPrefix + "Bishop");
            this.board[7,3].piece = new Queen("user", userPrefix + "Queen");
            this.board[7,4].piece = new King("user", userPrefix + "King");

        }

        private void updateCellsProtection() {

            for (int i = 0; i < ROW_SIZE; i++)
            {
                for (int j = 0; j < COLUMN_SIZE; j++)
                {

                    Position p = board[i, j];
                    if (p.piece != null)
                    {
                        
                        p.resetProtection();
                        List<Position>? coverage = p.piece.getAllowedMoves(this, p);
                        if(coverage != null)
                        {
                            foreach(Position pos in coverage)
                            {
                                pos.setProtection(p.piece.owner);
                            }
                        }
                        


                    }
                }
            }
        }

        /** Return 0 if White is checked, 1 if Black is checked, -1 if neither. */
        public int check()
        {
            updateCellsProtection();
            for (int i = 0; i < ROW_SIZE; i++)
            {
                for (int j = 0; j < COLUMN_SIZE; j++)
                {
                    Position pos = board[i, j];
                    if (pos.piece != null)
                    {
                        if (pos.piece.name == "bKing" && pos.isThreatened("black"))
                            return 1;
                        else if (pos.piece.name == "wKing" && pos.isThreatened("white"))
                            return 0;

                    }
                }
            }
            return -1;
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


        


    }
    
}
