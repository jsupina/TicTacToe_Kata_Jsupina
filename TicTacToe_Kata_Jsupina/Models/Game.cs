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
        public int TurnNum{ get; set; }
        public bool InProgress { get; set; }
        public string LastMove { get; set; }
    }
}
