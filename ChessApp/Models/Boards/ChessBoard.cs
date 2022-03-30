
using ChessApp.Models.Pieces;

namespace ChessApp.Models.Boards
{
    class ChessBoard : Board
    {

        bool isUserWhite;
        public int board_dimension = 8;



        public ChessBoard() : base()
        {
            this.isUserWhite = Utility.random(50);
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


        


    }
    
}
