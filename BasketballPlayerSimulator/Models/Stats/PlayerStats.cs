using System.Collections.Generic;

namespace BasketballPlayerSimulator.Models.Stats
{
    public class PlayerStats
    {
        public PlayerStats(string season, string seasonType)
        {
            Season = season;
            SeasonType = seasonType;
            Traditional = new Dictionary<string, TraditionalStats>();
            Advanced = new Dictionary<string, AdvancedStats>();
            Misc = new Dictionary<string, MiscStats>();
            Scoring = new Dictionary<string, ScoringStats>();
            Usage = new Dictionary<string, UsageStats>();
        }

        public string Season { get; set; }
        public string SeasonType { get; set; }
        public Dictionary<string, TraditionalStats> Traditional { get; set; }
        public Dictionary<string, AdvancedStats> Advanced { get; set; }
        public Dictionary<string, MiscStats> Misc { get; set; }
        public Dictionary<string, ScoringStats> Scoring { get; set; }
        public Dictionary<string, UsageStats> Usage { get; set; }

        public override string ToString()
        {
            return Season;
        }
    }
}