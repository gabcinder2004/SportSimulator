using System.Collections.Generic;
using System.Linq;
using ApiReader;
using BasketballPlayerSimulator.Models;

namespace BasketballPlayerSimulator.Builders
{
    public class TeamBuilder
    {
        private NbaReader NbaReader { get; set; }

        public TeamBuilder()
        {
            NbaReader = new NbaReader();
        }


        public void GetCommonInfo(Team team, string season, string seasonType, string leagueId = "00")
        {
            var commonInfo = NbaReader.GetCommonTeamInfo(team.Id, leagueId, season, seasonType);
            var data = commonInfo.ResultSets.Single(x => x.Name == "TeamInfoCommon").Data.First().Mapping;

            team.City = data["TEAM_CITY"];
            team.Name = data["TEAM_NAME"];
            team.Conference = data["TEAM_CONFERENCE"];
            team.Division = data["TEAM_DIVISION"];
        }

        public List<Team> GetIds()
        {
            var teams = new List<Team>();
            var baseTeamInfo = NbaReader.GetCommonTeamYears("00");
            baseTeamInfo.ResultSets.ForEach(resultSet => resultSet.Data.ForEach(data => teams.Add(new Team() { Id = data.Mapping["TEAM_ID"], Abbreviation = data.Mapping["ABBREVIATION"] })));
            teams.RemoveAll(x => x.Abbreviation == string.Empty);
            return teams;
        }
    }
}