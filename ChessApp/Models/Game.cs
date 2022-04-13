
using ChessApp.Models.Boards;
using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    public class Game
    {
        private static Game? game = null;
        private ChessBoard brd;
        public int brd_dimension;
        private bool turn;
        private List<Position> allowedMoves;


        private Game()
        {
            
            this.brd = new ChessBoard();
            this.turn = brd.isUserWhite ? true : false;
            this.brd_dimension = brd.getDimension();
            this.allowedMoves = new List<Position>();
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
                    
                    Utility.MoveResult res = brd.setPiece(rowStart, colStart, rowEnd, colEnd, players.USER, allowedMoves);
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


        public string getPieceMoves(int rSt, int cSt)
        {

            this.allowedMoves.Clear();
            Position p = this.brd.getPosition(rSt, cSt);
            if (p.piece != null)
            {
                Utility.MoveResult res = new Utility.MoveResult(p.piece.getAllowedMoves(this.brd, p));
                this.allowedMoves = res.positions;
                return res.convert();
            }
            else throw new ArgumentNullException("no piece");
            
        }


        public string makeAiMove()
        {

            if (this.brd != null)
            {
                Thread.Sleep(1700);
                AI aiPlayer = AI.getInstance(this.brd);
                turn = true;
                allowedMoves.Clear();
                Utility.MoveResult selectedMove = aiPlayer.makeStudiedMove();
                allowedMoves.Add(this.brd.getPosition(selectedMove.rowE, selectedMove.colE));
                return brd.setPiece(selectedMove.rowS, selectedMove.colS, selectedMove.rowE, selectedMove.colE, players.AI, allowedMoves).convert();

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



        



    }
}
