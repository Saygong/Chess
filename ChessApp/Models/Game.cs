
using ChessApp.Models.Boards;
using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    public class Game
    {
        private Board brd;
        public int brd_dimension;
        private static Game? game = null;
        private bool turn;


        private Game()
        {
            
            this.brd = new ChessBoard();
            this.turn = brd.isUserWhite ? true : false;
            this.brd_dimension = brd.getDimension();
        }


        public static Game getInstance()
        {

            if (game == null)
            {
                game = new Game();
            }
            return game;
        }


        public string makeUserMove(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            
            if (this.brd != null)
            {
                if (turn)
                {
                    Utility.MoveResult res = brd.setPiece(rowStart, colStart, rowEnd, colEnd, "user");
                    if (res.getResult() == "valid")
                    {
                        turn = false;

                    }
                    return res.convert();
                }
                else return new Utility.MoveResult("invalid", "not user's turn").convert();

            }
            else throw new ArgumentNullException("Board not initiated");

        }



        public string makeAiMove()
        {

            if (this.brd != null)
            {
                Thread.Sleep(1000);
                AI aiPlayer = AI.getInstance(this.brd);
                turn = true;
                
                Utility.MoveResult selectedMove = aiPlayer.makeStudiedMove();
                
                return brd.setPiece(selectedMove.rowS, selectedMove.colS, selectedMove.rowE, selectedMove.colE, "ai").convert();

            }
            else throw new ArgumentNullException("Board not initiated");

        }



        public string getCell(int r, int c) 
        {
            
            Piece? p = brd.getPiece(r, c);
            
            if (p != null)
            {
                return p.name;
            }
            else return "";
        }



        public void debugBoardState()
        {
            for(int i = 0; i < this.brd_dimension; i++)
            {
                for(int j = 0; j < this.brd_dimension; j++)
                {
                    Position p = this.brd.getPosition(i, j);
                    System.Diagnostics.Debug.Write(p.prettyPrint());
                }
                System.Diagnostics.Debug.WriteLine(" ");
            }
        }



    }
}
