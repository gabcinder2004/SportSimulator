namespace BasketballPlayerSimulator.Models.Stats
{
    public class MiscStats : BaseStats
    {

        /// <summary>
        /// Points off Turnovers - The number of points scored by a player or team following an opponent's turnover.
        /// </summary>
        public string PointsOffTurnover { get; set; }

        /// <summary>
        /// 2nd Chance Points - The number points scored by a team on a possession that they rebound the ball on offense.
        /// </summary>
        public string SecondChancePoints { get; set; }

        /// <summary>
        /// Fast Break Points - The number of points scored by a player or team while on a fast break.
        /// </summary>
        public string FastBreakPoints { get; set; }

        /// <summary>
        /// Points in the Paint - The number of points scored by a player or team in the paint.
        /// </summary>
        public string PointsInPaint { get; set; }

        /// <summary>
        /// Opponent Points off Turnovers - The number of points scored by an opposing player or team following a turnover.
        /// </summary>
        public string OpponentPointsOffTurnover { get; set; }

        /// <summary>
        /// Opponent 2nd Chance Points - The number of points an opposing team scores on a possession when the opposing team  rebounds the ball on offense.
        /// </summary>
        public string OpponentSecondChancePoints { get; set; }

        /// <summary>
        /// Opponent Fast Break Points - The number of points scored by an opposing player or team while on a fast break.
        /// </summary>
        public string OpponentFastBreakPoints { get; set; }

        /// <summary>
        /// Opponent Points in the Paint - The number of points scored by an opposing player or team in the paint.
        /// </summary>
        public string OpponentPointsInPaint { get; set; }

        /// <summary>
        /// Blocks - A block occurs when an offensive player attempts a shot, and the defense player tips the ball, blocking their chance to score.
        /// </summary>
        public string Blocks { get; set; }

        /// <summary>
        /// Blocked Field Goal Attempts - The number of field goal attempts by a player or team that was blocked by the opposing team.
        /// </summary>
        public string BlockedFieldGoalAttempts { get; set; }

        /// <summary>
        /// Personal Fouls - The total number of fouls that a player or team has committed.
        /// </summary>
        public string PersonalFouls { get; set; }

        /// <summary>
        /// Personal Fouls Drawn - The total number of fouls that a player or team has drawn on the other team.
        /// </summary>
        public string PersonalFoulsDrawn { get; set; }
    }
}