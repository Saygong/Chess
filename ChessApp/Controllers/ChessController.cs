using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ChessApp.Models.Boards;

namespace ChessApp.Controllers
{
    public class ChessController : Controller
    {
        public IActionResult Index()
        {

            ChessBoard brd = new ChessBoard();
            return View("Chess", brd);
        }

        public string Welcome(int id)
        {
            return "This is the Welcome action method... The ID is: " + id;
        }


    }
}
