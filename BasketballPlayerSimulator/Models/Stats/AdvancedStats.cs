namespace BasketballPlayerSimulator.Models.Stats
{
    public class AdvancedStats : BaseStats
    {

        /// <summary>
        /// Offensive Rating - The number of points scored per 100 possessions by a team. For a player, it is the number of points per 100 possessions that the team scores while that individual player is on the court.
        /// </summary>
        public string OffensiveRating { get; set; }

        /// <summary>
        /// Defensive Rating - The number of points allowed per 100 possessions by a team. For a player, it is the number of points per 100 possessions that the team allows while that individual player is on the court. 
        /// </summary>
        public string DefensiveRating { get; set; }

        /// <summary>
        /// Net Rating - Net Rating is the difference in a player or team's Offensive and Defensive Rating. The formula for this is: Offensive Rating - Defensive Rating
        /// </summary>
        public string NetRating { get; set; }

        /// <summary>
        /// Assist Percentage - Assist Percentage is the percent of teammate's field goals that the player assisted.
        /// </summary>
        public string AssistPercent { get; set; }

        /// <summary>
        /// Assist to Turnover Ratio - The number of assists a player has for every turnover that player commits.
        /// </summary>
        public string AssistPerTurnover { get; set; }

        /// <summary>
        /// Assist Ratio - Assist Ratio is the number of assists a player or team averages per 100 of their own possessions.
        /// </summary>
        public string AssistRatio { get; set; }
        
        /// <summary>
        /// Offensive Rebound Percentage - The percentage of offensive rebounds a player or team obtains while on the court.
        /// </summary>
        public string OffensiveReboundPercent { get; set; }

        /// <summary>
        /// Defensive Rebound Percentage - The percentage of defensive rebounds a player or team obtains while on the court.
        /// </summary>
        public string DefensiveReboundPercent { get; set; }

        /// <summary>
        /// Rebound Percentage - The percentage of total rebounds a player obtains while on the court.
        /// </summary>
        public string ReboundPercent { get; set; }

        /// <summary>
        /// Turnover Ratio - Turnover Ratio is the number of turnovers a player or team averages per 100 of their own possessions.
        /// </summary>
        public string TurnoverRatio { get; set; }

        /// <summary>
        /// Effective Field Goal Percentage - Effective Field Goal Percentage is a field goal percentage that is adjusted for made 3 pointers being 1.5 times more valuable than a 2 point shot.
        /// </summary>
        public string EffectiveFieldGoalPercent { get; set; }

        /// <summary>
        /// True Shooting Percentage - A shooting percentage that is adjusted to include the value three pointers and free throws. 
        /// The formula is: Points/ [2*(Field Goals Attempted+0.44*Free Throws Attempted)]
        /// </summary>
        public string TrueShootingPercent { get; set; }

        /// <summary>
        /// Usage Percentage - The percentage of a team's offensive possessions that a player uses while on the court.
        /// </summary>
        public string UsagePercent { get; set; }

        /// <summary>
        /// Pace - Pace is the number of possessions per 48 minutes for a player or team.
        /// </summary>
        public string Pace { get; set; }

        /// <summary>
        /// Player Impact Estimate - PIE is an estimate of a player's or team's contributions and impact on a game. PIE shows what % of game events did that player or team achieve.
        /// </summary>
        public string PlayerImpactEstimate { get; set; }
    }
}