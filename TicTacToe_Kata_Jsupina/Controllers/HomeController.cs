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
            //Model Initializations
            var playerX = new Player
            {
                PlayerID = 0,
                PlayerMark = "X",
                HeldTiles = new List<Tile>()
            };

            var playerO = new Player
            {
                PlayerID = 1,
                PlayerMark = "O",
                HeldTiles = new List<Tile>()
            };

            var tileTL = new Tile
            {
                TileID = 0,
                TileName = "Top Left"
            };

            var tileTM = new Tile
            {
                TileID = 1,
                TileName = "Top Middle"
            };

            var tileTR = new Tile
            {
                TileID = 2,
                TileName = "Top Right"
            };

            var tileML = new Tile
            {
                TileID = 3,
                TileName = "Middle Left"
            };

            var tileMM = new Tile
            {
                TileID = 4,
                TileName = "Middle Center"
            };

            var tileMR = new Tile
            {
                TileID = 5,
                TileName = "Middle Right"
            };

            var tileBL = new Tile
            {
                TileID = 6,
                TileName = "Bottom Left"
            };

            var tileBM = new Tile
            {
                TileID = 7,
                TileName = "Bottom Middle"
            };

            var tileBR = new Tile
            {
                TileID = 8,
                TileName = "Bottom Right"
            };

            var tttGame = new Game
            {
                Participants = new List<Player> { playerX, playerO},
                AvailableTiles = new List<Tile> { tileTL, tileTM, tileTR, tileML, tileMM, tileMR, tileBL, tileBM, tileBR},
                Winner = null,
                TurnNum = 0,
                InProgress = true,
                LastMove = ""
            };

            //Send the fresh game model to the view
            return View(tttGame);
        }

        //The overloaded version of Index is for when the current player submits their move 
        //for it to be processed
        [HttpGet]
        public ActionResult Index(Game tttGame, int move)
        {
            //Check if the intended move is still available
            if (tttGame.AvailableTiles.Any(p => p.TileID == move) == false)
            {
                //The requested move is invalid, thus re-direct back to the view for
                //the player to make another move
                return View(tttGame);
            }

            //Else if the move is valid, start the logic for processing the turn
            else
            {
                //Determine if it is player X or O's turn 
                int whosTurn = tttGame.TurnNum % 2;
                //Pull the tile that the player selected
                var tileToRemove = tttGame.AvailableTiles.Single(t => t.TileID == move);
                //Pull the current player
                var currentPlayer = tttGame.Participants.Find(p => p.PlayerID == whosTurn);

                //"Give" the player possesion of the tile and remove it from available move options
                currentPlayer.HeldTiles.Add(tileToRemove);
                tttGame.AvailableTiles.Remove(tileToRemove);

                //Update the most recent move so that a moe history could be recorded and increase the turn counter 
                tttGame.LastMove = "Player " + currentPlayer.PlayerMark + " put their mark on the " + tileToRemove.TileName + " tile!";
                tttGame.TurnNum = tttGame.TurnNum + 1;

                //Else if's to check if the current player is in possesion of tiles that satisfy any of the eight
                //possible win conditions. If the player does have a win condition, declare the game over and the
                //current player as the winner
                if (currentPlayer.HeldTiles.Any(t => t.TileID == 0) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 1) == true &&
                   currentPlayer.HeldTiles.Any(t => t.TileID == 2) == true)
                {
                    tttGame.InProgress = false;
                    tttGame.Winner = currentPlayer;
                }

                else if (currentPlayer.HeldTiles.Any(t => t.TileID == 3) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 4) == true &&
                         currentPlayer.HeldTiles.Any(t => t.TileID == 5) == true)
                {
                    tttGame.InProgress = false;
                    tttGame.Winner = currentPlayer;
                }

                else if (currentPlayer.HeldTiles.Any(t => t.TileID == 6) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 7) == true &&
                         currentPlayer.HeldTiles.Any(t => t.TileID == 8) == true)
                {
                    tttGame.InProgress = false;
                    tttGame.Winner = currentPlayer;
                }

                else if (currentPlayer.HeldTiles.Any(t => t.TileID == 0) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 3) == true &&
                         currentPlayer.HeldTiles.Any(t => t.TileID == 6) == true)
                {
                    tttGame.InProgress = false;
                    tttGame.Winner = currentPlayer;
                }

                else if (currentPlayer.HeldTiles.Any(t => t.TileID == 1) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 4) == true &&
                         currentPlayer.HeldTiles.Any(t => t.TileID == 7) == true)
                {
                    tttGame.InProgress = false;
                    tttGame.Winner = currentPlayer;
                }

                else if (currentPlayer.HeldTiles.Any(t => t.TileID == 2) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 5) == true &&
                         currentPlayer.HeldTiles.Any(t => t.TileID == 8) == true)
                {
                    tttGame.InProgress = false;
                    tttGame.Winner = currentPlayer;
                }

                else if (currentPlayer.HeldTiles.Any(t => t.TileID == 0) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 4) == true &&
                         currentPlayer.HeldTiles.Any(t => t.TileID == 8) == true)
                {
                    tttGame.InProgress = false;
                    tttGame.Winner = currentPlayer;
                }

                else if (currentPlayer.HeldTiles.Any(t => t.TileID == 2) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 4) == true &&
                         currentPlayer.HeldTiles.Any(t => t.TileID == 6) == true)
                {
                    tttGame.InProgress = false;
                    tttGame.Winner = currentPlayer;
                }

                //Check if there are no more available tiles. If there are no more tiles after not satisfying a win
                //condition, end the game and leave the winner null.
                else if (tttGame.AvailableTiles.Count == 0)
                {
                    tttGame.InProgress = false;
                }
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
            var playerX = new Player
            {
                PlayerID = 0,
                PlayerMark = "X",
                HeldTiles = new List<Tile>()
            };

            var playerO = new Player
            {
                PlayerID = 1,
                PlayerMark = "O",
                HeldTiles = new List<Tile>()
            };

            var tileTL = new Tile
            {
                TileID = 0,
                TileName = "Top Left"
            };

            var tileTM = new Tile
            {
                TileID = 1,
                TileName = "Top Middle"
            };

            var tileTR = new Tile
            {
                TileID = 2,
                TileName = "Top Right"
            };

            var tileML = new Tile
            {
                TileID = 3,
                TileName = "Middle Left"
            };

            var tileMM = new Tile
            {
                TileID = 4,
                TileName = "Middle Center"
            };

            var tileMR = new Tile
            {
                TileID = 5,
                TileName = "Middle Right"
            };

            var tileBL = new Tile
            {
                TileID = 6,
                TileName = "Bottom Left"
            };

            var tileBM = new Tile
            {
                TileID = 7,
                TileName = "Bottom Middle"
            };

            var tileBR = new Tile
            {
                TileID = 8,
                TileName = "Bottom Right"
            };

            var tttGame = new Game
            {
                Participants = new List<Player> { playerX, playerO },
                AvailableTiles = new List<Tile> { tileTL, tileTM, tileTR, tileML, tileMM, tileMR, tileBL, tileBM, tileBR },
                Winner = null,
                TurnNum = 0,
                InProgress = true,
                LastMove = ""
            };

            List<int> moves = new List<int> { 4, 0, 3, 8, 7, 5, 1, 1, 2 };

            for (int x = 0; x <= moves.Count; x++)
            {
                int moveNum = moves[x];

                //Check if the intended move is still available
                if (tttGame.AvailableTiles.Any(p => p.TileID == moveNum) == false)
                {
                    //The requested move is invalid, thus re-direct back to the view for
                    //the player to make another move
                    return View(tttGame);
                }

                //Else if the move is valid, start the logic for processing the turn
                else
                {
                    //Determine if it is player X or O's turn 
                    int whosTurn = tttGame.TurnNum % 2;
                    //Pull the tile that the player selected
                    var tileToRemove = tttGame.AvailableTiles.Single(t => t.TileID == moveNum);
                    //Pull the current player
                    var currentPlayer = tttGame.Participants.Find(p => p.PlayerID == whosTurn);

                    //"Give" the player possesion of the tile and remove it from available move options
                    currentPlayer.HeldTiles.Add(tileToRemove);
                    tttGame.AvailableTiles.Remove(tileToRemove);

                    //Update the most recent move so that a moe history could be recorded and increase the turn counter 
                    tttGame.LastMove = "Player " + currentPlayer.PlayerMark + " put their mark on the " + tileToRemove.TileName + " tile!";
                    tttGame.TurnNum = tttGame.TurnNum + 1;

                    //Else if's to check if the current player is in possesion of tiles that satisfy any of the eight
                    //possible win conditions. If the player does have a win condition, declare the game over and the
                    //current player as the winner
                    if (currentPlayer.HeldTiles.Any(t => t.TileID == 0) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 1) == true &&
                       currentPlayer.HeldTiles.Any(t => t.TileID == 2) == true)
                    {
                        tttGame.InProgress = false;
                        tttGame.Winner = currentPlayer;
                    }

                    else if (currentPlayer.HeldTiles.Any(t => t.TileID == 3) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 4) == true &&
                             currentPlayer.HeldTiles.Any(t => t.TileID == 5) == true)
                    {
                        tttGame.InProgress = false;
                        tttGame.Winner = currentPlayer;
                    }

                    else if (currentPlayer.HeldTiles.Any(t => t.TileID == 6) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 7) == true &&
                             currentPlayer.HeldTiles.Any(t => t.TileID == 8) == true)
                    {
                        tttGame.InProgress = false;
                        tttGame.Winner = currentPlayer;
                    }

                    else if (currentPlayer.HeldTiles.Any(t => t.TileID == 0) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 3) == true &&
                             currentPlayer.HeldTiles.Any(t => t.TileID == 6) == true)
                    {
                        tttGame.InProgress = false;
                        tttGame.Winner = currentPlayer;
                    }

                    else if (currentPlayer.HeldTiles.Any(t => t.TileID == 1) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 4) == true &&
                             currentPlayer.HeldTiles.Any(t => t.TileID == 7) == true)
                    {
                        tttGame.InProgress = false;
                        tttGame.Winner = currentPlayer;
                    }

                    else if (currentPlayer.HeldTiles.Any(t => t.TileID == 2) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 5) == true &&
                             currentPlayer.HeldTiles.Any(t => t.TileID == 8) == true)
                    {
                        tttGame.InProgress = false;
                        tttGame.Winner = currentPlayer;
                    }

                    else if (currentPlayer.HeldTiles.Any(t => t.TileID == 0) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 4) == true &&
                             currentPlayer.HeldTiles.Any(t => t.TileID == 8) == true)
                    {
                        tttGame.InProgress = false;
                        tttGame.Winner = currentPlayer;
                    }

                    else if (currentPlayer.HeldTiles.Any(t => t.TileID == 2) == true && currentPlayer.HeldTiles.Any(t => t.TileID == 4) == true &&
                             currentPlayer.HeldTiles.Any(t => t.TileID == 6) == true)
                    {
                        tttGame.InProgress = false;
                        tttGame.Winner = currentPlayer;
                    }

                    //Check if there are no more available tiles. If there are no more tiles after not satisfying a win
                    //condition, end the game and leave the winner null.
                    else if (tttGame.AvailableTiles.Count == 0)
                    {
                        tttGame.InProgress = false;
                    }
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
