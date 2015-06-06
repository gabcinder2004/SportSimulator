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

            //var allPlayers = reader.GetCommonAllPlayers("00", "2014-15", true);
            //var playerSplits = reader.GetPlayerSplits("2548", "PerGame", "N", "Base", "N", "N", "2014-15",
            //   "Regular Season", "", "", "0", "", "", "", "0", "", "", "", "0", "0");

            Console.Read();
        }
    }
}
