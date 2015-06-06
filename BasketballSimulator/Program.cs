using System;
using System.Linq;
using BasketballPlayerSimulator;

namespace BasketballSimulator
{
    public class Program
    {
        //static readonly NBA NBA = new NBA();

        public static void Main(string[] args)
        {
            var teamBuilder = new TeamBuilder();
            var teams = teamBuilder.GetIds();
            teams.ForEach(team => teamBuilder.GetRoster(team, "2014-15"));
            teams.ForEach(team => teamBuilder.GetCommonInfo(team, "2014-15", "Regular Season"));

            var playerBuilder = new PlayerBuilder();

            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Regular Season")));

            Console.Read();
        }
    }
}
