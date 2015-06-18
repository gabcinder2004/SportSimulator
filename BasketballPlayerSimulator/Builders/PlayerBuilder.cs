using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApiReader;
using BasketballPlayerSimulator.Models;

namespace BasketballPlayerSimulator.Builders
{
    public class PlayerBuilder
    {
        private NbaReader NbaReader { get; set; }

        public PlayerBuilder()
        {
            NbaReader = new NbaReader();
        }

        public List<Player> GetAllPlayersBasicInfo(List<Team> teams, string season)
        {
            var players = new List<Player>();

            foreach (var team in teams)
            {
                var roster = NbaReader.GetCommonTeamRoster(team.Id, season);

                roster.ResultSets.Single(x => x.Name == "CommonTeamRoster").Data.ForEach(
                    data => players.Add(new Player()
                    {
                        Age = data.Mapping["AGE"],
                        Experience = data.Mapping["EXP"],
                        Height = data.Mapping["HEIGHT"],
                        Id = data.Mapping["PLAYER_ID"],
                        Name = data.Mapping["PLAYER"],
                        PlayerNumber = data.Mapping["NUM"],
                        Position = data.Mapping["POSITION"],
                        Weight = data.Mapping["WEIGHT"],
                        TeamId = team.Id
                    }));
            }
            return players;
        }

        public void GetPlayerSplits(Player player, string targetSeason, string seasonType)
        {
            var playerStatBuilder = new PlayerStatBuilder();
            playerStatBuilder.GetPlayerSplits(player, targetSeason, seasonType);
        }
    }
}
