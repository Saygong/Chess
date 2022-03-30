
using ChessApp.Models.Boards;
using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    public class Game
    {
        private Board brd;
        public int brd_dimension;
        private static Game game = null;


        private Game()
        {
            this.brd = new ChessBoard();
            this.brd_dimension = brd.getDimension();
        }


        public static Game getInstance()
        {
            // Crea l'oggetto solo se NON esiste:
            if (game == null)
            {
                game = new Game();
            }
            return game;
        }


        public string makeMove(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            
            if (this.brd != null)
            {
                
                Utility.MoveResult res = brd.setPiece(rowStart, colStart, rowEnd, colEnd);
                return res.convert();

            }
            else throw new ArgumentNullException("Board not initiated");

        }


        public string getCell(int r, int c) 
        {
            return brd.getPiece(r, c) != null ? brd.getPiece(r, c).name : "";
        }



    }
}
