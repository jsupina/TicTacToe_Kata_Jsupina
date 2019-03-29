using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe_Kata_Jsupina.Models
{
    public class Game
    {
        public List<Player> Participants { get; set; }
        public List<Tile> AvailableTiles { get; set; }
        public Player Winner { get; set; }
        public int TurnNum { get; set; }
        public bool InProgress { get; set; }
        public string LastMove { get; set; }

        public Game()
        {
            List<string> tileNames = new List<string> { "Top Left", "Top Center", "Top Right", "Middle Left", "Middle Center",
                                                        "Middle Right", "Bottom Left", "Bottom Center", "Bottom Right"};
            List<string> playerMarks = new List<string> { "X", "O" };
            AvailableTiles = new List<Tile>();
            Participants = new List<Player>();
            Winner = null;
            TurnNum = 0;
            InProgress = true;
            LastMove = "";

            for (int x = 0; x < tileNames.Count; x++)
            {
                var tile = new Tile
                {
                    TileID = x,
                    TileName = tileNames[x]
                };

                AvailableTiles.Add(tile);
            }

            for (int y = 0; y < playerMarks.Count; y++)
            {
                var player = new Player
                {
                    PlayerID = y,
                    PlayerMark = playerMarks[y],
                    HeldTiles = new List<Tile>()
                    
                };

                Participants.Add(player);
            }
        }

        public bool ValidMove(int tileNum)
        {
            //Check if the intended move is still available
            if (AvailableTiles.Any(p => p.TileID == tileNum) == false)
            {
                //The requested move is invalid, thus re-direct back to the view for
                //the player to make another move
                return false;
            }

            else
            {
                return true;
            }
        }

        public void ProcessMove(int moveNum)
        {
            int whosTurn = TurnNum % 2;
            //Pull the tile that the player selected
            var tileToRemove = AvailableTiles.Single(t => t.TileID == moveNum);
            //Pull the current player
            var currentPlayer = Participants.Find(p => p.PlayerID == whosTurn);

            //"Give" the player possesion of the tile and remove it from available move options
            currentPlayer.HeldTiles.Add(tileToRemove);
            AvailableTiles.Remove(tileToRemove);

            //Update the most recent move so that a moe history could be recorded and increase the turn counter 
            LastMove = "Player " + currentPlayer.PlayerMark + " put their mark on the " + tileToRemove.TileName + " tile!";
            TurnNum = TurnNum + 1;

            if(currentPlayer.CheckForWin() == true)
            {
                InProgress = false;
                Winner = currentPlayer;
            }

            //Check if there are no more available tiles. If there are no more tiles after not satisfying a win
            //condition, end the game and leave the winner null.
            else if (AvailableTiles.Count == 0)
            {
                InProgress = false;
            }
        }
    }
}
