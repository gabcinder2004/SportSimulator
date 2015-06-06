using System;
using System.Collections.Generic;

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
        /// <param name="playerId"></param>
        /// <param name="perMode"></param>
        /// <param name="plusMinus"></param>
        /// <param name="measureType"></param>
        /// <param name="paceAdjust"></param>
        /// <param name="rank"></param>
        /// <param name="season"></param>
        /// <param name="seasonType"></param>
        /// <param name="outcome"></param>
        /// <param name="location"></param>
        /// <param name="month"></param>
        /// <param name="seasonSegment"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="opponentTeamId"></param>
        /// <param name="vsConference"></param>
        /// <param name="vsDivision"></param>
        /// <param name="gameSegment"></param>
        /// <param name="period"></param>
        /// <param name="lastNGames"></param>
        /// <returns></returns>
        public Response GetPlayerSplits(string playerId, string perMode, string plusMinus, string measureType, string paceAdjust,
            string rank, string season, string seasonType, string outcome, string location, string month, string seasonSegment,
            string dateFrom, string dateTo, string opponentTeamId, string vsConference, string vsDivision, string gameSegment, string period, string lastNGames)
        {
            var parameters = new List<Parameter>
                             {
                                 new Parameter("PlayerId", playerId),
                                 new Parameter("PerMode", perMode),
                                 new Parameter("PlusMinus", plusMinus),
                                 new Parameter("MeasureType", measureType),
                                 new Parameter("PaceAdjust", paceAdjust),
                                 new Parameter("Rank", rank),
                                 new Parameter("Season", season),
                                 new Parameter("SeasonType", seasonType),
                                 new Parameter("Outcome", outcome),
                                 new Parameter("Location", location),
                                 new Parameter("Month", month),
                                 new Parameter("SeasonSegment", seasonSegment),
                                 new Parameter("DateFrom", dateFrom),
                                 new Parameter("DateTo", dateTo),
                                 new Parameter("OpponentTeamId", opponentTeamId),
                                 new Parameter("vsConference", vsConference),
                                 new Parameter("vsDivision", vsDivision),
                                 new Parameter("GameSegment", gameSegment),
                                 new Parameter("Period", period),
                                 new Parameter("LastNGames", lastNGames),
                                };

            return GetInformation(NBAEndPoints.PlayerSplits, parameters);
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
    }
}