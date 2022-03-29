
using ChessApp.Models.Boards;

using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    public class Game
    {
        private Board brd;
        public int brd_dimension;


        public Game()
        {
            this.brd = new ChessBoard();
            this.brd_dimension = brd.getDimension();
        }


        public bool makeMove(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            
            if (this.brd != null)
            {
                
                return brd.setPiece(rowStart, colStart, rowEnd, colEnd);
                
            }
            else throw new ArgumentNullException("Board not initiated");

        }


        public string getCell(int r, int c) 
        {
            return brd.getPiece(r, c) != null ? brd.getPiece(r, c).name : "";
        }



    }
}
