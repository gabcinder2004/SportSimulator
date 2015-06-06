using System.Collections.Generic;
using System.Linq;
using ApiReader;
using BasketballPlayerSimulator.Models.Stats;

namespace BasketballPlayerSimulator
{
    public class PlayerBuilder
    {
        private NbaReader NbaReader { get; set; }

        public PlayerBuilder()
        {
            NbaReader = new NbaReader();
        }

        public void GetPlayerSplits(Player player, string targetSeason, string seasonType)
        {
            var dashboards = new List<StatDashboard>()
            {
                StatDashboard.Overall,
                StatDashboard.Location,
                StatDashboard.WinLosses,
                StatDashboard.Month,
                StatDashboard.PrePostAllStar,
                StatDashboard.StartingPosition,
                StatDashboard.DaysRest
            };

            var playerStats = player.Stats.Any(x => x.Season == targetSeason)
                ? player.Stats.Single(x => x.Season == targetSeason)
                : new PlayerStats(targetSeason);

            var playerSplitOptions = new PlayerSplitOptions
            {
                Season = targetSeason,
                PlayerId = player.Id,
                PerMode = "PerGame",
                SeasonType = seasonType,
                PlusMinus = "Y",
                PaceAdjust = "N",
                Rank = "N",
                Outcome = string.Empty,
                Location = string.Empty,
                Month = "0",
                SeasonSegment = string.Empty,
                DateFrom = string.Empty,
                DateTo = string.Empty,
                OpponentTeamId = "0",
                VsConference = string.Empty,
                VsDivision = string.Empty,
                GameSegment = string.Empty,
                Period = "0",
                LastNGames = "0",
            };

            // Traditional
            playerSplitOptions.MeasureType = "Base";
            var traditionalPlayerSplits = NbaReader.GetPlayerSplits(playerSplitOptions);
            traditionalPlayerSplits.ResultSets.ForEach(resultSet => GetBaseStats(playerStats, resultSet.Data));

            // Advanced stats
            playerSplitOptions.MeasureType = "Advanced";
            var advancedPlayerSplits = NbaReader.GetPlayerSplits(playerSplitOptions);
            advancedPlayerSplits.ResultSets.ForEach(resultSet => GetAdvancedStats(playerStats, resultSet.Data));

            // Misc stats
            playerSplitOptions.MeasureType = "Misc";
            var miscPlayerSplits = NbaReader.GetPlayerSplits(playerSplitOptions);
            miscPlayerSplits.ResultSets.ForEach(resultSet => GetMiscStats(playerStats, resultSet.Data));

            // Scoring stats
            playerSplitOptions.MeasureType = "Scoring";
            var scoringPlayerSplits = NbaReader.GetPlayerSplits(playerSplitOptions);
            scoringPlayerSplits.ResultSets.ForEach(resultSet => GetScoringStats(playerStats, resultSet.Data));

            // Usage stats
            playerSplitOptions.MeasureType = "Usage";
            var usagePlayerSplits = NbaReader.GetPlayerSplits(playerSplitOptions);
            usagePlayerSplits.ResultSets.ForEach(resultSet => GetUsageStats(playerStats, resultSet.Data));

        }

        private void GetUsageStats(PlayerStats playerStats, List<Data> dataSet)
        {
            dataSet.ForEach(data => playerStats.Usage.Add(data.Mapping["GROUP_VALUE"], new UsageStats()
            {
                GroupSet = data.Mapping["GROUP_SET"],
                GroupValue = data.Mapping["GROUP_VALUE"],
                GamesPlayed = data.Mapping["GP"],
                Wins = data.Mapping["W"],
                Losses = data.Mapping["L"],
                WinPercent = data.Mapping["W_PCT"],
                Minutes = data.Mapping["MIN"],
                UsagePercent = data.Mapping["USG_PCT"],
                PercentOfTeamFieldGoalsMade = data.Mapping["PCT_FGM"],
                PercentOfTeamFieldGoalsAttempted = data.Mapping["PCT_FGA"],
                PercentOfTeamThreePointersMade = data.Mapping["PCT_FG3M"],
                PercentOfTeamThreePointersAttempted = data.Mapping["PCT_FG3A"],
                PercentOfTeamFreeThrowsMade = data.Mapping["PCT_FTM"],
                PercentOfTeamFreeThrowsAttempted = data.Mapping["PCT_FTA"],
                PercentOfTeamOffensiveRebounds = data.Mapping["PCT_OREB"],
                PercentOfTeamDefensiveRebounds = data.Mapping["PCT_DREB"],
                PercentOfTeamRebounds = data.Mapping["PCT_REB"],
                PercentOfTeamAssists = data.Mapping["PCT_AST"],
                PercentOfTeamTurnovers = data.Mapping["PCT_TOV"],
                PercentOfTeamSteals = data.Mapping["PCT_STL"],
                PercentOfTeamBlocks = data.Mapping["PCT_BLK"],
                PercentOfTeamBlockedFieldGoalAttempts = data.Mapping["PCT_BLKA"],
                PercentOfTeamPersonalFouls = data.Mapping["PCT_PF"],
                PercentOfTeamPersonalFoulsDrawn = data.Mapping["PCT_PFD"],
                PercentOfTeamPoints = data.Mapping["PCT_PTS"]
            }));
        }

        private void GetScoringStats(PlayerStats playerStats, List<Data> dataSet)
        {
            dataSet.ForEach(data => playerStats.Scoring.Add(data.Mapping["GROUP_VALUE"], new ScoringStats()
            {
                GroupSet = data.Mapping["GROUP_SET"],
                GroupValue = data.Mapping["GROUP_VALUE"],
                GamesPlayed = data.Mapping["GP"],
                Wins = data.Mapping["W"],
                Losses = data.Mapping["L"],
                WinPercent = data.Mapping["W_PCT"],
                Minutes = data.Mapping["MIN"],
                PercentOfFieldGoalsAttemptedTwoPointer = data.Mapping["PCT_FGA_2PT"],
                PercentOfFieldGoalsAttemptedThreePointer = data.Mapping["PCT_FGA_3PT"],
                PercentOfPointsTwoPointers = data.Mapping["PCT_PTS_2PT"],
                PercentOfPointsTwoPointersMidRange = data.Mapping["PCT_PTS_2PT_MR"],
                PercentOfPointsThreePointers = data.Mapping["PCT_PTS_3PT"],
                PercentOfPointsFastBreak = data.Mapping["PCT_PTS_FB"],
                PercentOfPointsFreeThrow = data.Mapping["PCT_PTS_FT"],
                PercentOfPointsOffTurnovers = data.Mapping["PCT_PTS_OFF_TOV"],
                PercentOfPointsInPaint = data.Mapping["PCT_PTS_PAINT"],
                PercentOfPointsTwoPointersAssisted = data.Mapping["PCT_AST_2PM"],
                PercentOfPointsTwoPointersUnassisted = data.Mapping["PCT_UAST_2PM"],
                PercentOfPointsThreePointersAssisted = data.Mapping["PCT_AST_3PM"],
                PercentOfPointsThreePointersUnassisted = data.Mapping["PCT_UAST_3PM"],
                PercentOfFieldGoalsMadeAssisted = data.Mapping["PCT_AST_FGM"],
                PercentOfFieldGoalsMadeUnassisted = data.Mapping["PCT_UAST_FGM"]
            }));
        }

        private void GetMiscStats(PlayerStats playerStats, List<Data> dataSet)
        {
            dataSet.ForEach(data => playerStats.Misc.Add(data.Mapping["GROUP_VALUE"], new MiscStats()
            {
                GroupSet = data.Mapping["GROUP_SET"],
                GroupValue = data.Mapping["GROUP_VALUE"],
                GamesPlayed = data.Mapping["GP"],
                Wins = data.Mapping["W"],
                Losses = data.Mapping["L"],
                WinPercent = data.Mapping["W_PCT"],
                Minutes = data.Mapping["MIN"],
                PointsOffTurnover = data.Mapping["PTS_OFF_TOV"],
                SecondChancePoints = data.Mapping["PTS_2ND_CHANCE"],
                FastBreakPoints = data.Mapping["PTS_FB"],
                PointsInPaint = data.Mapping["PTS_PAINT"],
                OpponentPointsOffTurnover = data.Mapping["OPP_PTS_OFF_TOV"],
                OpponentSecondChancePoints = data.Mapping["OPP_PTS_2ND_CHANCE"],
                OpponentFastBreakPoints = data.Mapping["OPP_PTS_FB"],
                OpponentPointsInPaint = data.Mapping["OPP_PTS_PAINT"],
                Blocks = data.Mapping["BLK"],
                BlockedFieldGoalAttempts = data.Mapping["BLKA"],
                PersonalFouls = data.Mapping["PF"],
                PersonalFoulsDrawn = data.Mapping["PFD"]
            }));
        }

        private void GetAdvancedStats(PlayerStats playerStats, List<Data> dataSet)
        {
            dataSet.ForEach(data => playerStats.Advanced.Add(data.Mapping["GROUP_VALUE"], new AdvancedStats()
            {
                GroupSet = data.Mapping["GROUP_SET"],
                GroupValue = data.Mapping["GROUP_VALUE"],
                GamesPlayed = data.Mapping["GP"],
                Wins = data.Mapping["W"],
                Losses = data.Mapping["L"],
                WinPercent = data.Mapping["W_PCT"],
                Minutes = data.Mapping["MIN"],
                OffensiveRating = data.Mapping["OFF_RATING"],
                DefensiveRating = data.Mapping["DEF_RATING"],
                NetRating = data.Mapping["NET_RATING"],
                AssistPercent = data.Mapping["AST_PCT"],
                AssistPerTurnover = data.Mapping["AST_TO"],
                AssistRatio = data.Mapping["AST_RATIO"],
                OffensiveReboundPercent = data.Mapping["OREB_PCT"],
                DefensiveReboundPercent = data.Mapping["DREB_PCT"],
                ReboundPercent = data.Mapping["REB_PCT"],
                TurnoverRatio = data.Mapping["TM_TOV_PCT"],
                EffectiveFieldGoalPercent = data.Mapping["EFG_PCT"],
                TrueShootingPercent = data.Mapping["TS_PCT"],
                UsagePercent = data.Mapping["USG_PCT"],
                Pace = data.Mapping["PACE"],
                PlayerImpactEstimate = data.Mapping["PIE"],
            }));
        }

        private void GetBaseStats(PlayerStats playerStats, List<Data> dataset)
        {
            dataset.ForEach(data => playerStats.Traditional.Add(data.Mapping["GROUP_VALUE"], new TraditionalStats
            {
                GroupSet = data.Mapping["GROUP_SET"],
                GroupValue = data.Mapping["GROUP_VALUE"],
                GamesPlayed = data.Mapping["GP"],
                Wins = data.Mapping["W"],
                Losses = data.Mapping["L"],
                WinPercent = data.Mapping["W_PCT"],
                Minutes = data.Mapping["MIN"],
                FieldGoalMade = data.Mapping["FGM"],
                FieldGoalAttempts = data.Mapping["FGA"],
                FieldGoalPercent = data.Mapping["FG_PCT"],
                ThreePointMade = data.Mapping["FG3M"],
                ThreePointAttempts = data.Mapping["FG3A"],
                ThreePointPercent = data.Mapping["FG3_PCT"],
                FreeThrowMade = data.Mapping["FTM"],
                FreeThrowAttempts = data.Mapping["FTA"],
                FreeThrowPercent = data.Mapping["FT_PCT"],
                OffensiveRebound = data.Mapping["OREB"],
                DefensiveRebound = data.Mapping["DREB"],
                Rebounds = data.Mapping["REB"],
                Assists = data.Mapping["AST"],
                Turnovers = data.Mapping["TOV"],
                Steals = data.Mapping["STL"],
                Blocks = data.Mapping["BLK"],
                PersonalFouls = data.Mapping["PF"],
                PlusMinus = data.Mapping["PLUS_MINUS"],
                Points = data.Mapping["PTS"]
            }));
        }
    }
}
