using System.Collections.Generic;
using ApiReader;

namespace BasketballPlayerSimulator.Models.Stats
{
    public abstract class BaseStats
    {
        public string GroupSet { get; set; }
        public string GroupValue { get; set; }

        /// <summary>
        /// The number of games a player has played
        /// </summary>
        public string GamesPlayed { get; set; }

        /// <summary>
        /// The number of games a player has won
        /// </summary>
        public string Wins { get; set; }

        /// <summary>
        /// The number of games a player has lost
        /// </summary>
        public string Losses { get; set; }

        /// <summary>
        /// The win percentage of the games the player has played
        /// </summary>
        public string WinPercent { get; set; }

        /// <summary>
        /// The number of minutes a player has played
        /// </summary>
        public string Minutes { get; set; }
    }
}