using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    class AI
    {


        public AI() { }



        public string makeRandomMove(Board board)
        {


            
            int row = (new Random()).Next(0, 7);
            int col = (new Random()).Next(0, 7);
            Position? p = board.getPosition(row, col);
            int i = 0;
            while (i<100)
            {
                row = (new Random()).Next(0, 4);
                col = (new Random()).Next(0, 7);
                p = board.getPosition(row, col);

                if (p.piece != null && p.piece.owner != "user")
                {
                    List<Position>? valid = p.piece.getAllowedMoves(board, p);
                    if (valid != null && valid.Count > 0)
                    {
                        int selection = (new Random()).Next(0, valid.Count()-1);
                        Position ending = valid[selection];
                        Utility.MoveResult res = board.setPiece(row, col, ending.row, ending.col, "ai");
                        if (res.result == "valid")
                        {
                            res.rowS = p.row;
                            res.colS = p.col;
                            res.rowE = ending.row;
                            res.colE = ending.col;
                            
                            return res.convert();
                        }

                        
                    }


                }
                i++;


            }
            return new Utility.MoveResult("invalid", "no moves found").convert();
            

        
        }



    }
}
