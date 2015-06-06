using System.Collections.Generic;

namespace BasketballPlayerSimulator
{
    public class Team
    {
        public string Id { get; set; }
        public string Abbreviation { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        
        public List<Player> Roster { get; set; }
        public List<Coach> Coaches { get; set; }

        public Team()
        {
            Roster = new List<Player>();
            Coaches = new List<Coach>();
        }

        public override string ToString()
        {
            return Abbreviation;
        }
    }
}