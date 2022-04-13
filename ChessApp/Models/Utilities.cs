using ChessApp.Models.Boards;
using ChessApp.Models.Pieces;
using Newtonsoft.Json;

namespace ChessApp.Models
{
    public class Utility
    {


        public class MoveResult
        {
            public string result = "none";
            public string description = "none";

            public int rowS;
            public int colS;
            public int rowE;
            public int colE;

            public List<Position> positions = new List<Position>();



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

            public MoveResult(MoveResult toCopy)
            {
                this.result = toCopy.result;
                this.description = toCopy.description;
                this.rowS = toCopy.rowS;
                this.colS = toCopy.colS;
                this.rowE = toCopy.rowE;
                this.colE = toCopy.colE;
            }


            public MoveResult(List<Position>? positions)
            {
                if( positions != null)
                {
                    this.positions = positions;
                }
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
                            ret.Add(toEat);
                        break;
                    }
                }
            }
            return ret;

        }


        public static void debugBoardState(Board brd)
        {
            for (int i = 0; i < brd.getDimension(); i++)
            {
                for (int j = 0; j < brd.getDimension(); j++)
                {
                    Position p = brd.getPosition(i, j);
                    System.Diagnostics.Debug.Write(p.prettyPrint());
                }
                System.Diagnostics.Debug.WriteLine(" ");
            }
            System.Diagnostics.Debug.WriteLine("\n\n");
        }
       


    }

}
