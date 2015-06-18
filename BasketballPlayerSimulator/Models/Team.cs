using System.Collections.Generic;

namespace BasketballPlayerSimulator.Models
{
    public class Team
    {
        public Team()
        {
        }

        public string Id { get; set; }
        public string Abbreviation { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }

        public override string ToString()
        {
            return Abbreviation;
        }
    }
}