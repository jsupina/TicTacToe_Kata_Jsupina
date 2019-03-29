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
    }
}
