using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe_Kata_Jsupina.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerMark { get; set; }
        public List<Tile> HeldTiles { get; set; }

        public bool CheckForWin()
        {
            if (HeldTiles.Any(t => t.TileID == 0) == true && HeldTiles.Any(t => t.TileID == 1) == true &&
                HeldTiles.Any(t => t.TileID == 2) == true)
            {
                return true;
            }

            else if (HeldTiles.Any(t => t.TileID == 3) == true && HeldTiles.Any(t => t.TileID == 4) == true &&
                     HeldTiles.Any(t => t.TileID == 5) == true)
            {
                return true;
            }

            else if (HeldTiles.Any(t => t.TileID == 6) == true && HeldTiles.Any(t => t.TileID == 7) == true &&
                     HeldTiles.Any(t => t.TileID == 8) == true)
            {
                return true;
            }

            else if (HeldTiles.Any(t => t.TileID == 0) == true && HeldTiles.Any(t => t.TileID == 3) == true &&
                     HeldTiles.Any(t => t.TileID == 6) == true)
            {
                return true;
            }

            else if (HeldTiles.Any(t => t.TileID == 1) == true && HeldTiles.Any(t => t.TileID == 4) == true &&
                     HeldTiles.Any(t => t.TileID == 7) == true)
            {
                return true;
            }

            else if (HeldTiles.Any(t => t.TileID == 2) == true && HeldTiles.Any(t => t.TileID == 5) == true &&
                     HeldTiles.Any(t => t.TileID == 8) == true)
            {
                return true;
            }

            else if (HeldTiles.Any(t => t.TileID == 0) == true && HeldTiles.Any(t => t.TileID == 4) == true &&
                     HeldTiles.Any(t => t.TileID == 8) == true)
            {
                return true;
            }

            else if (HeldTiles.Any(t => t.TileID == 2) == true && HeldTiles.Any(t => t.TileID == 4) == true &&
                     HeldTiles.Any(t => t.TileID == 6) == true)
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }
    }
}
