using Microsoft.AspNetCore.Mvc;
using ChessApp.Models;

namespace ChessApp.Controllers
{
    public class ChessController : Controller
    {

        Game thisGame = Game.getInstance();


        public IActionResult Index()
        {

            //thisGame = new Game();
            return View("Chess", thisGame);
        }

        public string validateMove(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            if (thisGame != null)
            {
                
                return thisGame.makeUserMove(rowStart, colStart, rowEnd, colEnd);
            }
            else throw new ArgumentNullException("No game available");
        }


        public string generateAiMove()
        {
            if (thisGame != null)
            {
                
                return thisGame.makeAiMove();
            }
            else throw new ArgumentNullException("No game available");
        }

        public string getAllowedMoves(int rowStart, int colStart)
        {
            if (thisGame != null)
            {
                return thisGame.getPieceMoves(rowStart, colStart);
            }
            else throw new ArgumentNullException("No game available");
        }




    }
}
