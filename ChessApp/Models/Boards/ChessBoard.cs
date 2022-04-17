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
                this.board[6,i].piece = new PawnTwoMoves(players.USER, userPrefix + "Pawn");

                this.board[1,i].piece = new PawnTwoMoves(players.AI, pcPrefix + "Pawn");

            }

            // Placing Knights, Bishops, Rooks, Queens and Kings


            this.board[0,0].piece = new Rook(players.AI, pcPrefix + "Rook");
            this.board[0,7].piece = new Rook(players.AI, pcPrefix + "Rook");
            this.board[0,1].piece = new Knight(players.AI, pcPrefix + "Knight");
            this.board[0,6].piece = new Knight(players.AI, pcPrefix + "Knight");
            this.board[0,2].piece = new Bishop(players.AI, pcPrefix + "Bishop");
            this.board[0,5].piece = new Bishop(players.AI, pcPrefix + "Bishop");
            this.board[0,3].piece = new Queen(players.AI, pcPrefix + "Queen");
            this.board[0,4].piece = new King(players.AI, pcPrefix + "King");

            this.board[7,0].piece = new Rook(players.USER, userPrefix + "Rook");
            this.board[7,7].piece = new Rook(players.USER, userPrefix + "Rook");
            this.board[7,1].piece = new Knight(players.USER, userPrefix + "Knight");
            this.board[7,6].piece = new Knight(players.USER, userPrefix + "Knight");
            this.board[7,2].piece = new Bishop(players.USER, userPrefix + "Bishop");
            this.board[7,5].piece = new Bishop(players.USER, userPrefix + "Bishop");
            this.board[7,3].piece = new Queen(players.USER, userPrefix + "Queen");
            this.board[7,4].piece = new King(players.USER, userPrefix + "King");

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //this.updateCellsProtection(board[i, j]);
                }
            }


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



        public new ChessBoard clone()
        {
            ChessBoard newBoard = new ChessBoard();
            for (int i = 0; i < ROW_SIZE; i++)
            {

                for (int j = 0; j < COLUMN_SIZE; j++)
                {
                    newBoard.board[i, j] = board[i, j].clone();
                }
            }
            return newBoard;
        }




    }
    
}
