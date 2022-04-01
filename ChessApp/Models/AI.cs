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


        private void updatePieceSet()
        {
            List<Position> newPieceSet = new List<Position>();

            for (int i = 0; i < brd.getDimension(); i++)
            {
                for (int j = 0; j < brd.getDimension(); j++)
                {
                    Position p = brd.getPosition(i, j);
                    if (p.piece != null)
                    {
                        if (p.piece.owner == "ai")
                            newPieceSet.Add(p);
                    }
                }
            }
            this.pieceSet = newPieceSet;
        }



        public static void debugPieceSet(AI ai) { 
            foreach(Position p in ai.pieceSet)
            {
                System.Diagnostics.Debug.Write(p.prettyPrint());
            }
        }



        public Utility.MoveResult makeRandomMove()
        {
            updatePieceSet();
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
                            
                            return res;
                        }

                        
                    }


                }
                i++;


            }
            return new Utility.MoveResult("invalid", "no moves found");
        
        }




        // TODO : MINMAX on 2/3 step that add points to the move if ends with a eat, loss point if ends with an own piece get eated
        public Utility.MoveResult makeStudiedMove()
        {
            updatePieceSet();
            int bestOutcome = -1;
            Utility.MoveResult? bestResult = null;

            foreach(Position p in this.pieceSet)
            {
                int pieceOutcome = -1;
                Utility.MoveResult? pieceResult = null;
                List<Position>? moves = null;

                if (p.piece != null)
                    moves = p.piece.getAllowedMoves(this.brd, p);

                if (moves != null && moves.Count() > 0) {

                    foreach(Position possible in moves)
                    {
                        int outcome = 0;
                        Utility.MoveResult? result = new Utility.MoveResult("valid", "none");

                        if (possible.row > 2 && possible.row < 5)
                        {
                            if (possible.col > 2 && possible.col < 5)
                                outcome += 2;
                        }

                        result.rowS = p.row;
                        result.colS = p.col;
                        result.rowE = possible.row;
                        result.colE = possible.col;

                        if (possible.piece != null && possible.piece.owner == "user")
                        {
                            switch (possible.piece.name)
                            {
                                case "wPawn":
                                    outcome += 2;
                                    break;
                                case "wKnight":
                                    outcome += 3;
                                    break;
                                case "wBishop":
                                    outcome += 4;
                                    break;
                                case "wRook":
                                    outcome += 5;
                                    break;
                                case "wQueen":
                                    outcome += 8;
                                    break;
                            }
                        }


                        if (outcome > pieceOutcome)
                        {
                            pieceOutcome = outcome;
                            pieceResult = new Utility.MoveResult(result);
                        }


                    }
                }

                if (pieceOutcome > bestOutcome)
                {
                    bestOutcome = pieceOutcome;
                    bestResult = new Utility.MoveResult(pieceResult);
                }
            
            }
            if (bestResult == null)
                return makeRandomMove();
            else
            {
                
                return bestResult;
            }


        }


    }
}
