using ChessApp.Models.Boards;
using ChessApp.Models.Pieces;
using Newtonsoft.Json;

namespace ChessApp.Models
{
    class Utility
    {


        internal class MoveResult
        {
            public string result;
            public string description;

            public int rowS;
            public int colS;
            public int rowE;
            public int colE;



            public MoveResult(string r, string desc, Position p, Position p1)
            {
                this.result = r;
                this.description = desc;
                rowS = p.row;
                colS = p.col;
                rowE = p1.row;
                colE = p1.col;
            }

            public MoveResult(string r, string desc)
            {
                this.result = r;
                this.description = desc;
            }

            

            public string convert()
            {
                return JsonConvert.SerializeObject(this);
            }

            public string getResult()
            {
                return this.result;
            }


        }


        public static bool random(int percentage)
        {

            Random rand = new Random();

            int value = 100 / percentage;

            int n = rand.Next(0, value);

            return (n == 0);
        }



        public static List<Position> getMoves(Board board, Position start, int[][] moveTemplates, int range)
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

                    if (board.isValid(start.row + deltaX, start.col + deltaY, start.piece, out toEat))
                    {
                        ret.Add(board.getPosition(start.row+deltaX,start.col+deltaY));
                    }
                    else
                    {
                        if (toEat != null)
                            ret.Add(board.getPosition(start.row + deltaX, start.col + deltaY));
                        break;
                    }
                }
            }
            return ret;

        }





    }

}
