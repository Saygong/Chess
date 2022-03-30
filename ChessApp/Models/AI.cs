using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    class AI
    {

        private static AI? ai = null;
        private List<Position> pieceSet;
        private Board brd;

        private AI(Board brd) {

            pieceSet = new List<Position>();
            this.brd = brd;
            for(int i = 0; i < brd.getDimension(); i++)
            {
                for(int j = 0; j < brd.getDimension(); j++)
                {
                    Position p = brd.getPosition(i, j);
                    if (p.piece != null)
                    {
                        if (p.piece.owner == "ai")
                            pieceSet.Add(p);
                    }
                }
            }
        
        }

        public static AI getInstance(Board brd)
        {

            if (ai == null)
            {
                ai = new AI(brd);
            }
            return ai;
        }




        public string makeRandomMove()
        {

            Board board = this.brd;
            
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

        public string makeStudiedMove()
        {
            int bestOutcome = -1;
            Utility.MoveResult? bestResult = null;

            for(int i = 0; i < pieceSet.Count(); i++)
            {
                int outcome = 0;

                Position p = pieceSet[i];
                List<Position>? moves = null;

                if (p.piece != null)
                    moves = p.piece.getAllowedMoves(this.brd, p);

                if (moves != null && moves.Count() > 0) {

                    foreach(Position possible in moves)
                    {
                        int bestMove = 0;
                        Utility.MoveResult moveDesc = new Utility.MoveResult("valid", "none");
                        if (possible.row > 2 && possible.row < 5)
                        {
                            bestMove += 1;
                            if (possible.col > 2 && possible.col < 5)
                                bestMove += 2;
                        }
                                

                        if(possible.piece != null  && possible.piece.owner == "user")
                            switch (possible.piece.name)
                            {
                                case "wPawn":
                                    bestMove += 1;
                                    break;
                                case "wKnight":
                                    bestMove += 3;
                                    break;
                                case "wBishop":
                                    bestMove += 4;
                                    break;
                                case "wRook":
                                    bestMove += 5;
                                    break;
                                case "wQueen":
                                    bestMove += 10;
                                    break;
                            }

                        moveDesc.rowS = p.row;
                        moveDesc.colS = p.col;
                        moveDesc.rowE = possible.row;
                        moveDesc.colE = possible.col;

                        if (bestMove > outcome)
                        {
                            outcome = bestMove;
                            bestResult = moveDesc;
                        }


                    }
                }

                if (outcome > bestOutcome)
                    bestOutcome = outcome;
            
            }
            if (bestResult == null)
                return makeRandomMove();
            else
            {
                this.brd.setPiece(bestResult.rowS, bestResult.colS, bestResult.rowE, bestResult.colE, "ai");
                return bestResult.convert();
            }


        }


    }
}
