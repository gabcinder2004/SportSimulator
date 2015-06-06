using System.Collections.Generic;
using System.Linq;
using ApiReader;

namespace BasketballPlayerSimulator
{
    public class TeamBuilder
    {
        private NbaReader NbaReader { get; set; }

        public TeamBuilder()
        {
            NbaReader = new NbaReader();
        }

        public void GetRoster(Team team, string season)
        {
            var roster = NbaReader.GetCommonTeamRoster(team.Id, season);
            roster.ResultSets.Single(x => x.Name == "CommonTeamRoster").Data.ForEach(
                data => team.Roster.Add(new Player()
                {
                    Age = data.Mapping["AGE"],
                    Experience = data.Mapping["EXP"],
                    Height = data.Mapping["HEIGHT"],
                    Id = data.Mapping["PLAYER_ID"],
                    Name = data.Mapping["PLAYER"],
                    PlayerNumber = data.Mapping["NUM"],
                    Position = data.Mapping["POSITION"],
                    Weight = data.Mapping["WEIGHT"]
                }));

            roster.ResultSets.Single(x => x.Name == "Coaches").Data.ForEach(
                data => team.Coaches.Add(new Coach
                {
                    Id = data.Mapping["COACH_ID"],
                    Name = data.Mapping["COACH_NAME"],
                    Type = data.Mapping["COACH_TYPE"]
                }));
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