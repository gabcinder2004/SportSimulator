using System.Collections.Generic;

namespace BasketballPlayerSimulator
{
    public class Player
    {
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

    public enum StatDashboard
    {
        Overall,
        Location,
        Winlosses,
        Month,
        PrePostAllStar,
        StartingPosition,
        DaysRest
    }

    public class TraditionalStats
    {
        public string GamesPlayed { get; set; }
    }

    public class AdvancedStats
    {
        
    }

    public class MiscStats
    {
        
    }

    public class ScoringStats 
    {
        
    }

    public class UsageStats
    {
        
    }

    public class ShootingStats
    {
        
    }

    public class PlayerStats
    {
        public string Season { get; set; }

        public TraditionalStats Traditional { get; set; }
        public AdvancedStats Advanced { get; set; }
        public MiscStats Misc { get; set; }
        public ScoringStats Scoring { get; set; }
        public UsageStats Usage { get; set; }
        public ShootingStats Shooting { get; set; }

        public override string ToString()
        {
            return Season;
        }
    }
}