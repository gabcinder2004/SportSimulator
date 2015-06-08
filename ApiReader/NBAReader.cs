using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiReader
{
    public class NbaReader
    {
        private const string BaseUrl = @"http://stats.nba.com/stats/";

        private readonly Dictionary<NBAEndPoints, string> _endPoints = new Dictionary<NBAEndPoints, string>{
                                { NBAEndPoints.CommonPlayerInfo, "commonplayerinfo" },
                                { NBAEndPoints.CommonAllPlayers, "commonallplayers" },
                                { NBAEndPoints.PlayerSplits, "playerdashboardbygeneralsplits"},
                                { NBAEndPoints.CommonTeamInfo, "teaminfocommon"},
                                { NBAEndPoints.CommonTeamYears, "commonteamyears"},
                                { NBAEndPoints.CommonTeamRoster, "commonteamroster"}
                            };

        /// <summary>
        /// Get the common information about a player given their id
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public Response GetCommonPlayerInfo(string playerId)
        {
            var parameters = new List<Parameter>
                             {
                                 new Parameter("PlayerId", playerId)
                             };

            return GetInformation(NBAEndPoints.CommonPlayerInfo, parameters);
        }

        /// <summary>
        /// Get Information about all players including their ids
        /// </summary>
        /// <param name="leagueId"></param>
        /// <param name="season"></param>
        /// <param name="isOnlyCurrentSeason"></param>
        /// <returns></returns>
        public Response GetCommonAllPlayers(string leagueId, string season, bool isOnlyCurrentSeason)
        {
            var parameters = new List<Parameter>
                             {
                                 new Parameter("LeagueId", leagueId),
                                 new Parameter("Season", season),
                                 new Parameter("IsOnlyCurrentSeason", Convert.ToInt32(isOnlyCurrentSeason).ToString())
                             };

            return GetInformation(NBAEndPoints.CommonAllPlayers, parameters);
        }

        /// <summary>
        /// Split statistical data for a player with a lot of parameters...
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Response GetPlayerSplits(PlayerSplitOptions options)
        {
            var parameters = new List<Parameter>
                             {
                                 new Parameter("PlayerId", options.PlayerId),
                                 new Parameter("PerMode", options.PerMode),
                                 new Parameter("PlusMinus", options.PlusMinus),
                                 new Parameter("MeasureType", options.MeasureType),
                                 new Parameter("PaceAdjust", options.PaceAdjust),
                                 new Parameter("Rank", options.Rank),
                                 new Parameter("Season", options.Season),
                                 new Parameter("SeasonType", options.SeasonType),
                                 new Parameter("Outcome", options.Outcome),
                                 new Parameter("Location", options.Location),
                                 new Parameter("Month", options.Month),
                                 new Parameter("SeasonSegment", options.SeasonSegment),
                                 new Parameter("DateFrom", options.DateFrom),
                                 new Parameter("DateTo", options.DateTo),
                                 new Parameter("OpponentTeamId", options.OpponentTeamId),
                                 new Parameter("vsConference", options.VsConference),
                                 new Parameter("vsDivision", options.VsDivision),
                                 new Parameter("GameSegment", options.GameSegment),
                                 new Parameter("Period", options.Period),
                                 new Parameter("LastNGames", options.LastNGames),
                                };

            return GetInformation(NBAEndPoints.PlayerSplits, parameters);
        }  
        
        /// <summary>
        /// Split statistical data for a player with a lot of parameters...
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Response GetPlayerSplitsAsync(PlayerSplitOptions options)
        {
            var parameters = new List<Parameter>
                             {
                                 new Parameter("PlayerId", options.PlayerId),
                                 new Parameter("PerMode", options.PerMode),
                                 new Parameter("PlusMinus", options.PlusMinus),
                                 new Parameter("MeasureType", options.MeasureType),
                                 new Parameter("PaceAdjust", options.PaceAdjust),
                                 new Parameter("Rank", options.Rank),
                                 new Parameter("Season", options.Season),
                                 new Parameter("SeasonType", options.SeasonType),
                                 new Parameter("Outcome", options.Outcome),
                                 new Parameter("Location", options.Location),
                                 new Parameter("Month", options.Month),
                                 new Parameter("SeasonSegment", options.SeasonSegment),
                                 new Parameter("DateFrom", options.DateFrom),
                                 new Parameter("DateTo", options.DateTo),
                                 new Parameter("OpponentTeamId", options.OpponentTeamId),
                                 new Parameter("vsConference", options.VsConference),
                                 new Parameter("vsDivision", options.VsDivision),
                                 new Parameter("GameSegment", options.GameSegment),
                                 new Parameter("Period", options.Period),
                                 new Parameter("LastNGames", options.LastNGames),
                                };

            return GetInformationAsync(NBAEndPoints.PlayerSplits, parameters);
        }

        /// <summary>
        /// Detailed team information, useful after we get team ids
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="leagueId"></param>
        /// <param name="season"></param>
        /// <param name="seasonType"></param>
        /// <returns></returns>
        public Response GetCommonTeamInfo(string teamId, string leagueId, string season, string seasonType)
        {
            var parameters = new List<Parameter>
                             {
                                 new Parameter("teamId", teamId),
                                 new Parameter("leagueId", leagueId),
                                 new Parameter("season", season),
                                 new Parameter("seasonType", seasonType),
                             };

            return GetInformation(NBAEndPoints.CommonTeamInfo, parameters);
        }     
        
        /// <summary>
        /// Our best way to get team ids?
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        public Response GetCommonTeamYears(string leagueId)
        {
            var parameters = new List<Parameter>
                             {
                                 new Parameter("leagueId", leagueId),
                             };

            return GetInformation(NBAEndPoints.CommonTeamYears, parameters);
        }        
        
        /// <summary>
        /// Get the roster for a team given the teamID and the season year
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="season"></param>
        /// <returns></returns>
        public Response GetCommonTeamRoster(string teamId, string season)
        {
            var parameters = new List<Parameter>
                             {
                                 new Parameter("teamId", teamId),
                                 new Parameter("season", season),
                             };

            return GetInformation(NBAEndPoints.CommonTeamRoster, parameters);
        }

        /// <summary>
        /// Our main helper method used to call the APICaller
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private Response GetInformation(NBAEndPoints endpoint, List<Parameter> parameters)
        {
            var fullUrl = string.Format("{0}{1}", BaseUrl, _endPoints[endpoint]);
            var response = ApiCaller.ExecuteCall<Response>(fullUrl, parameters);
            response.OrganizeResults();
            return response;
        } 
        
        /// <summary>
        /// Our main helper method used to call the APICaller
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private Response GetInformationAsync(NBAEndPoints endpoint, List<Parameter> parameters)
        {
            var fullUrl = string.Format("{0}{1}", BaseUrl, _endPoints[endpoint]);
            return ApiCaller.ExecuteCallAsync(fullUrl, parameters).Result;
        }
    }
}