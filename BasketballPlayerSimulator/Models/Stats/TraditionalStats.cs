namespace BasketballPlayerSimulator.Models.Stats
{
    public class TraditionalStats : BaseStats
    {
        /// <summary>
        /// The number of field goals that a player has made. This includes both two pointers and three pointers.
        /// </summary>
        public string FieldGoalMade { get; set; }

        /// <summary>
        /// The number of field goals that a player has attempted. This includes both two pointers and three pointers.
        /// </summary>
        public string FieldGoalAttempts { get; set; }

        /// <summary>
        /// The percentage of field goals that a player makes. 
        /// The formula to determine field goal percentage is: Field Goals Made / Field Goals Attempted
        /// </summary>
        public string FieldGoalPercent { get; set; }

        /// <summary>
        /// 3 Point Field Goals Made - The number of 3 point field goals that a player or team has made.
        /// </summary>
        public string ThreePointMade { get; set; }

        /// <summary>
        /// 3 Point Field Goals Attempted - The number of 3 point field goals that a player or team has attempted.
        /// </summary>
        public string ThreePointAttempts { get; set; }
        
        /// <summary>
        /// 3 Point Field Goal Percentage - The percentage of 3 point field goals that a player or team has made. 
        /// The formula to determine 3 point field goal percentage is: 3 Point Field Goals Made/3 Point Field Goals Attempted.
        /// </summary>
        public string ThreePointPercent { get; set; }

        /// <summary>
        /// Free Throws Made - The number of free throws that a player or team has successfully made.
        /// </summary>
        public string FreeThrowMade { get; set; }

        /// <summary>
        /// Free Throws Attempted - The number of free throws that a player or team has taken.
        /// </summary>
        public string FreeThrowAttempts { get; set; }

        /// <summary>
        /// Free Throw Percentage - The percentage of free throws that a player or team has made. 
        /// The formula to determine free throw percentage is: Free Throws Made/Free Throws Attempted.
        /// </summary>
        public string FreeThrowPercent { get; set; }

        /// <summary>
        /// Offensive Rebounds - The number of rebounds a player or team has collected while they were on offense.
        /// </summary>
        public string OffensiveRebound { get; set; }

        /// <summary>
        /// Defensive Rebounds - The number of rebounds a player or team has collected while they were on defense.
        /// </summary>
        public string DefensiveRebound { get; set; }

        /// <summary>
        /// Rebounds - A rebound occurs when a player recovers the ball after a missed shot. 
        /// This statistic is the number of total rebounds a player or team has collected on either offense or defense.
        /// </summary>
        public string Rebounds { get; set; }

        /// <summary>
        /// Assists - An assist occurs when a player completes a pass to a teammate that directly leads to a made field goal.
        /// </summary>
        public string Assists { get; set; }

        /// <summary>
        /// Turnovers - A turnover occurs when the team on offense loses the ball to the defense. 
        /// </summary>
        public string Turnovers { get; set; }

        /// <summary>
        /// Steals - A steal occurs when a defensive player takes the ball from a player on offense, causing a turnover.
        /// </summary>
        public string Steals { get; set; }

        /// <summary>
        /// Blocks - A block occurs when an offensive player attempts a shot, and the defense player tips the ball, blocking their chance to score.
        /// </summary>
        public string Blocks { get; set; }

        /// <summary>
        /// Personal Fouls - The total number of fouls that a player or team has committed.
        /// </summary>
        public string PersonalFouls { get; set; }

        /// <summary>
        /// Double Doubles - A player records a Double Double when they record 10 or more units in two stat categories. 
        /// A Double Double is most commonly recorded in the categories of points, rebounds, or assists.
        /// </summary>
        public string DoubleDouble { get; set; }

        /// <summary>
        /// Triple Doubles - A player records a Triple Double when they record 10 or more units in three different stat categories. 
        /// A Triple Double is most commonly recorded in the categories of points, rebounds, or assists.
        /// </summary>
        public string TripleDouble { get; set; }

        /// <summary>
        /// Points - The number of points a player or team has scored. A point is scored when a player makes a basket.
        /// </summary>
        public string Points { get; set; }

        /// <summary>
        /// Plus/Minus - The point differential of the score for a player while on the court. For a team, it is how much they are winning or losing by. 
        /// </summary>
        public string PlusMinus { get; set; }
    }
}