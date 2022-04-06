﻿
using ChessApp.Models.Pieces.Pawns;


namespace ChessApp.Models.Pieces
{
    class PawnTwoMoves : Pawn
    {

        public static int range = 2;
        public PawnTwoMoves(string own, string name) : base(own, name) { }

        

        private readonly static int[][] userMoveTemplates = new int[][]
        {
          new [] { -1, 0 },

        };

        private readonly static int[][] aiMoveTemplates = new int[][]
        {
          new [] { 1, 0 },

        };

        public override List<Position>? getAllowedMoves(Board board, Position start)
        {
            
            List<Position>? eating = base.getAllowedMoves(board, start);
            if (eating != null)
            {
                int[][] template = this.owner == "user" ? userMoveTemplates : aiMoveTemplates;

                List<Position>? valids = this.getPawnMoves(board, start, template, range);
                if(valids != null)
                {
                    return valids.Concat(eating).ToList();
                }
                
            }
            return null;

        }


    }

}
