using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BasketballPlayerSimulator;
using DataAccessLayer;
using Newtonsoft.Json;

namespace BasketballSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var teamBuilder = new TeamBuilder();
            var teams = teamBuilder.GetIds();
            teams.ForEach(team => teamBuilder.GetRoster(team, "2014-15"));
            teams.ForEach(team => teamBuilder.GetCommonInfo(team, "2014-15", "Regular Season"));

            Stopwatch stopwatch = new Stopwatch();

            var times = new Dictionary<string, TimeSpan>();

            var playerBuilder = new PlayerBuilder();

            Console.WriteLine("2014-15, regular season");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Regular Season")));
            times.Add("2014-15 RegularSeason", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2014-15, Playoffs");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Playoffs")));
            times.Add("2014-15 Playoffs", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2013-14, regular season");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2013-14", "Regular Season")));
            times.Add("2013-14 RegularSeason", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2013-14, Playoffs");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2013-14", "Playoffs")));
            times.Add("2013-14 Playoffs", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2012-13, regular season");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2012-13", "Regular Season")));
            times.Add("2012-13 RegularSeason", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2012-13, Playoffs");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2012-13", "Playoffs")));
            times.Add("2012-13 Playoffs", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2011-12, regular season");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2011-12", "Regular Season")));
            times.Add("2011-12 RegularSeason", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2011-12, Playoffs");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2011-12", "Playoffs")));
            times.Add("2011-12 Playoffs", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2010-11, regular season");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2010-11", "Regular Season")));
            times.Add("2010-11 RegularSeason", stopwatch.Elapsed);
            stopwatch.Restart();

            Console.WriteLine("2010-11, Playoffs");
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2010-11", "Playoffs")));
            times.Add("2010-11 Playoffs", stopwatch.Elapsed);
            stopwatch.Stop();

            var dataManager = new DatabaseManager();
            foreach (var serializedTeam in teams.Select(JsonConvert.SerializeObject))
            {
                dataManager.AddTeam(serializedTeam);
            }

            var players = new List<Player>();
            teams.ForEach(team => team.Roster.ForEach(player => players.Add(player)));

            foreach (var player in players)
            {
                var serializedPlayer = JsonConvert.SerializeObject(player);
                dataManager.AddPlayer(serializedPlayer);
            }

            foreach (var time in times)
            {
                Console.WriteLine("{0} : {1}", time.Key, time.Value);
            }
        }
    }
}
