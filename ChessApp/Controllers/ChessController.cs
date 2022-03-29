using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ChessApp.Models.Boards;
using ChessApp.Models;

namespace ChessApp.Controllers
{
    public class ChessController : Controller
    {

        Game? thisGame = new Game();


        public IActionResult Index()
        {

            //thisGame = new Game();
            return View("Chess", thisGame);
        }

       public bool check(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            if (thisGame != null)
            {
                return thisGame.makeMove(rowStart, colStart, rowEnd, colEnd);
            }
            else throw new ArgumentNullException("No game available");
        }


    }
}
