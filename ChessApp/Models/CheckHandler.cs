
using ChessApp.Models.Pieces;

namespace ChessApp.Models
{

    
    public class CheckHandler
    {
        private Board clonedBoard;
        private Position? kingPosition;
        private List<Position> pieces;

        public CheckHandler(Board brd, players checkedKing)
        {
            this.pieces = new List<Position>();
            for (int i = 0; i < brd.getDimension(); i++)
            {
                for (int j = 0; j < brd.getDimension(); j++)
                {
                    Position? temp = brd.getPosition(i, j);
                    if (temp.piece != null)
                    {
                        if (temp.piece.name == "wKing" || temp.piece.name == "bKing")
                        {
                            kingPosition = temp;
                        }
                        if (temp.piece.owner == checkedKing)
                        {
                            this.pieces.Add(temp);
                        }
                    }
                }
            }


        }


        private static void rollback(Board clonedBoard, Position preStart, Position preEnd)
        {
            clonedBoard.setPosition(preStart);
            clonedBoard.setPosition(preEnd);

        }
        
       
        public List<Position> illegalMoves(Board board)
        {
           
            clonedBoard = board.clone();
            List<Position> moves = new List<Position>();
            foreach(Position p1 in this.pieces)
            {
                // sure that p.piece != null but i need to delete warnings
                if(p1.piece != null)
                {
                    List<Position> all = p1.piece.checkAllowedMoves(board, p1);

                    if (all.Count > 0)
                    {
                        foreach(Position p2 in all)
                        {
                            Position preStart = clonedBoard.getPosition(p1.row, p1.col).clone();
                            Position preEnd = clonedBoard.getPosition(p2.row, p2.col).clone();

                            Utility.MoveResult  res = clonedBoard.setPiece(p1.row, p1.col, p2.row, p2.col, p1.piece.owner, all);

                            if (res.result == "valid" && clonedBoard.isChecked() == p1.piece.owner)
                            {
                                moves.Add(p2);
                            }
                            rollback(clonedBoard, preStart, preEnd);
                            
                        }
                    }
                }
                
            }
            return moves;

        }
    
        public static void dangerousMoves(Board board, Position start, List<Position> valids, players pl)
        {

            Board clonedBoard = board.clone();
            List<Position> toDelete = new List<Position>();
            
            foreach (Position p2 in valids)
            {
                Position preStart = clonedBoard.getPosition(start.row, start.col).clone();
                Position preEnd = clonedBoard.getPosition(p2.row, p2.col).clone();
                Utility.MoveResult res = clonedBoard.setPiece(start.row, start.col, p2.row, p2.col, pl, valids);
                Utility.debugCellsProtection(clonedBoard);
                if (res.result == "valid" && clonedBoard.isChecked() == pl)
                {
                    toDelete.Add(p2);
                }
                rollback(clonedBoard, preStart, preEnd);

            }

            foreach(Position illegal in toDelete)
            {
                valids.Remove(illegal);
            }

            
        }



    }

}
