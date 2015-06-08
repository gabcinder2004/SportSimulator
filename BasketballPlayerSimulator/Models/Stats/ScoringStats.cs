namespace BasketballPlayerSimulator.Models.Stats
{
    public class ScoringStats : BaseStats
    {
        /// <summary>
        /// Percent of Field Goals Attempted (2 Pointers) - The percentage of field goals attempted by a player or team that are 2 pointers.
        /// </summary>
        public string PercentOfFieldGoalsAttemptedTwoPointer { get; set; }

        /// <summary>
        /// Percent of Field Goals Attempted (3 Pointers) - The percentage of field goals attempted by a player or team that are 3 pointers.
        /// </summary>
        public string PercentOfFieldGoalsAttemptedThreePointer { get; set; }

        /// <summary>
        /// Percent of Points (2 Pointers) - The percentage of points scored by a player or team that are 2 pointers.
        /// </summary>
        public string PercentOfPointsTwoPointers { get; set; }

        /// <summary>
        /// Percent of Points (Mid-Range) - The percentage of points scored by a player or team that are 2 point mid-range jump shots. 
        /// Mid-Range Jump Shots are generally jump shots that occur within the 3 point line, but not near the rim.
        /// </summary>
        public string PercentOfPointsTwoPointersMidRange { get; set; }

        /// <summary>
        /// Percent of Points (3 Pointers) - The percentage of points scored by a player or team that are 3 pointers.
        /// </summary>
        public string PercentOfPointsThreePointers { get; set; }

        /// <summary>
        /// Percent of Points (Fast Break Points) - The percentage of points scored by a player or team that are scored while on a fast break.
        /// </summary>
        public string PercentOfPointsFastBreak { get; set; }

        /// <summary>
        /// Percent of Points (Free Throws) - The percentage of points scored by a player or team that are free throws.
        /// </summary>
        public string PercentOfPointsFreeThrow { get; set; }

        /// <summary>
        /// Percent of Points (Off Turnovers) - The percentage of points scored by a player or team that are scored after forcing an opponent's turnover.
        /// </summary>
        public string PercentOfPointsOffTurnovers { get; set; }

        /// <summary>
        /// Percent of Points (Points in the Paint) - The percentage of points scored by a player or team that are scored in the paint.
        /// </summary>
        public string PercentOfPointsInPaint { get; set; }

        /// <summary>
        /// Percent of 2 Point Field Goals Made Assisted - The percentage of 2 point field goals made that are assisted by a teammate.
        /// </summary>
        public string PercentOfPointsTwoPointersAssisted { get; set; }

        /// <summary>
        /// Percent of 2 Point Field Goals Made Unassisted - The percentage of 2 point field goals that are not assisted by a teammate.
        /// </summary>
        public string PercentOfPointsTwoPointersUnassisted { get; set; }

        /// <summary>
        /// Percent of 3 Point Field Goals Made Assisted - The percentage of 3 point field goals made that are assisted by a teammate.
        /// </summary>
        public string PercentOfPointsThreePointersAssisted { get; set; }

        /// <summary>
        /// Percent of 3 Point Field Goals Made Unassisted - The percentage of 3 point field goals that are not assisted by a teammate.
        /// </summary>
        public string PercentOfPointsThreePointersUnassisted { get; set; }

        /// <summary>
        /// Percent of Field Goals Made Assisted - The percentage of field goals made that are assisted by a teammate.
        /// </summary>
        public string PercentOfFieldGoalsMadeAssisted { get; set; }

        /// <summary>
        /// Percent of Field Goals Made Unassisted - The percentage of field goals that are not assisted by a teammate.
        /// </summary>
        public string PercentOfFieldGoalsMadeUnassisted { get; set; }
    }
}