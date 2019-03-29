using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToe_Kata_Jsupina.Models;

namespace TicTacToe_Kata_Jsupina.Controllers
{
    public class HomeController : Controller
    {
        //Inden represents the page that the Tic-Tac-Toe game would be on.
        //Initialize the models that will be needed for the game logic and send the Game model
        //to the view.
        public ActionResult Index()
        {
            //Model Initialization
            var tttGame = new Game();

            //Send the fresh game model to the view
            return View(tttGame);
        }

        //The overloaded version of Index is for when the current player submits their move 
        //for it to be processed
        [HttpGet]
        public ActionResult Index(Game tttGame, int move)
        {
            if (tttGame.ValidMove(move) == false)
            {
                return View(tttGame);
            }

            //Else if the move is valid, start the logic for processing the turn
            else
            {
                tttGame.ProcessMove(move);
            }

            //Send the game instance back to the view to obtain the next move
            return View(tttGame);
        }

        //This is the modified version of the logic for me to test if it works. I declared a list of pre-defined
        //player moves and sent them, through the logic using a for loop. To carefully make sure the logic worked
        //every step of the way I placed a breakpoint after the model initialization and stepped through the logic
        //making sure everything was as it should be
        public ActionResult Test()
        {
            List<int> moves = new List<int> { 4, 0, 3, 8, 7, 5, 1, 1, 2 };
            var tttGame = new Game();

            for (int x = 0; x <= moves.Count; x++)
            {
                int moveNum = moves[x];

                if(tttGame.ValidMove(moveNum) == false)
                {
                    return View(tttGame);
                }

                //Else if the move is valid, start the logic for processing the turn
                else
                {
                    tttGame.ProcessMove(moveNum);
                }
            }

            //Send the game instance back to the view to obtain the next move
            return View(tttGame);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
