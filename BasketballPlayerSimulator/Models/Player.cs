using System.Collections.Generic;
using BasketballPlayerSimulator.Models.Stats;

namespace BasketballPlayerSimulator
{
    public class Player
    {
        public Player()
        {
            Stats = new List<PlayerStats>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string PlayerNumber { get; set; }
        public string Position { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Age { get; set; }
        public string Experience { get; set; }

        public List<PlayerStats> Stats { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}