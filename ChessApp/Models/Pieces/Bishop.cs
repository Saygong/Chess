﻿
using ChessApp.Models.Boards;

namespace ChessApp.Models.Pieces
{
    public class Bishop : Piece
    {
        public static int range = 8;
        public Bishop(players own, string name) : base(own, name) { }

        private readonly static int[][] moveTemplates = new int[][]
        {
          new [] { 1, -1 },
          new [] { 1, 1 },
          new [] { -1, -1 },
          new [] { -1, 1 },

        };

        public override List<Position> checkAllowedMoves(Board board, Position start)
        {

            List<Position> valids = base.checkAllowedMoves(board, start);
            
            return Utility.getMoves(board, start, moveTemplates, range);
            
        }


    }
}
