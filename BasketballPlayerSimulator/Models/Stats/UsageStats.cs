using BasketballPlayerSimulator.Models.Stats;

namespace BasketballPlayerSimulator
{
    public class UsageStats : BaseStats
    {

        /// <summary>
        /// Usage Percentage - The percentage of a team's offensive possessions that a player uses while on the court.
        /// </summary>
        public string UsagePercent { get; set; }

        /// <summary>
        /// Percent of Team's Field Goals Made - The percentage of a team's field goals made that a player has while on the court.
        /// </summary>
        public string PercentOfTeamFieldGoalsMade { get; set; }

        /// <summary>
        /// Percent of Team's Field Goals Attempted - The percentage of a team's field goals attempted that a player has while on the court.
        /// </summary>
        public string PercentOfTeamFieldGoalsAttempted { get; set; }

        /// <summary>
        /// Percent of Teams's 3 Point Field Goals Made - The percentage of a team's 3 point field goals made that a player has while on the court.
        /// </summary>
        public string PercentOfTeamThreePointersMade { get; set; }

        /// <summary>
        /// Percent of Team's 3 Point Field Goals Attempted - The percentage of a team's 3 point field goals attempted that a player has while on the court.
        /// </summary>
        public string PercentOfTeamThreePointersAttempted { get; set; }

        /// <summary>
        /// Percent of Team's Free Throws Made - The percentage of a team's free throws made that a player has while on the court.
        /// </summary>
        public string PercentOfTeamFreeThrowsMade { get; set; }

        /// <summary>
        /// Percent of Team's Free Throws Attempted - The percentage of a team's free throws attempted that a player has while on the court.
        /// </summary>
        public string PercentOfTeamFreeThrowsAttempted { get; set; }

        /// <summary>
        /// Percent of Team's Offensive Rebounds - The percentage of a team's offensive rebounds that a player has while on the court.
        /// </summary>
        public string PercentOfTeamOffensiveRebounds { get; set; }

        /// <summary>
        /// Percent of Team's Defensive Rebounds - The percentage of a team's defensive rebounds that a player has while on the court.
        /// </summary>
        public string PercentOfTeamDefensiveRebounds { get; set; }

        /// <summary>
        /// Percent of Team's Rebounds - The percentage of a team's total rebounds that a player has while on the court.
        /// </summary>
        public string PercentOfTeamRebounds { get; set; }

        /// <summary>
        /// Percent of Team's Assists  - The percentage of a team's assists that a player has while on the court.
        /// </summary>
        public string PercentOfTeamAssists { get; set; }

        /// <summary>
        /// Percent of Team's Turnovers - The percentage of a team's turnovers that a player has while on the court.
        /// </summary>
        public string PercentOfTeamTurnovers { get; set; }

        /// <summary>
        /// Percent of Team's Steals - The percentage of a team's steals that a player has while on the court.
        /// </summary>
        public string PercentOfTeamSteals { get; set; }

        /// <summary>
        /// Percent of Team's Blocks - The percentage of a team's blocks that a player has while on the court.
        /// </summary>
        public string PercentOfTeamBlocks { get; set; }

        /// <summary>
        /// Percent of Team's Blocked Field Goal Attempts - The percentage of a team's own blocked field goal attempts that a player has while on the court.
        /// </summary>
        public string PercentOfTeamBlockedFieldGoalAttempts { get; set; }

        /// <summary>
        /// Percent of Team's Personal Fouls - The percentage of a team's personal fouls that a player has while on the court.
        /// </summary>
        public string PercentOfTeamPersonalFouls { get; set; }

        /// <summary>
        /// Percent of Team's Personal Fouls Drawn - The percentage of a team's personal fouls drawn that a player has while on the court.
        /// </summary>
        public string PercentOfTeamPersonalFoulsDrawn { get; set; }

        /// <summary>
        /// Percent of Team's Points - The percentage of a team's points that a player has while on the court.
        /// </summary>
        public string PercentOfTeamPoints { get; set; }
    }
}