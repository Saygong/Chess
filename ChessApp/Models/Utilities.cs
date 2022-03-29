using ChessApp.Models.Boards;
using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    class Utility
    {
        public static bool random(int percentage)
        {

            Random rand = new Random();

            int value = 100 / percentage;

            int n = rand.Next(0, value);

            return (n == 0);
        }



        public static List<Position> getMoves(ChessBoard board, Position start, int[][] moveTemplates, int range)
        {

            if (board == null) throw new ArgumentNullException("board");

            var ret = new List<Position>();

            foreach (var mult in moveTemplates)
            {
                for (var radius = 1; radius <= range; radius++)
                {

                    var deltaX = radius * mult[0];
                    var deltaY = radius * mult[1];
                    Position? toEat;
                    if (board.isValid(start.row + deltaY, start.col + deltaX, start.piece, out toEat))
                    {
                        ret.Add(new Position(deltaY, deltaX));
                    }
                    else
                    {
                        if (toEat != null)
                            ret.Add(new Position(deltaY, deltaX));
                        break;
                    }
                }
            }
            return ret;

        }





    }



}
