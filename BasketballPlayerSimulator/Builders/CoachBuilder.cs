using System.Collections.Generic;
using System.Linq;
using ApiReader;
using BasketballPlayerSimulator.Models;

namespace BasketballPlayerSimulator.Builders
{
    public class CoachBuilder
    {
        public CoachBuilder()
        {
            NbaReader = new NbaReader();
        }

        private NbaReader NbaReader { get; set; }

        public List<Coach> GetAllCoachesBasicInfo(List<Team> teams, string season)
        {
            var coaches = new List<Coach>();

            foreach (var team in teams)
            {
                var roster = NbaReader.GetCommonTeamRoster(team.Id, season);

                roster.ResultSets.Single(x => x.Name == "Coaches").Data.ForEach(
                    data => coaches.Add(new Coach
                    {
                        Id = data.Mapping["COACH_ID"],
                        Name = data.Mapping["COACH_NAME"],
                        Type = data.Mapping["COACH_TYPE"],
                        TeamId = team.Id
                    }));
            }

            return coaches;
        }

    }
}