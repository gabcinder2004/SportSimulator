using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BasketballPlayerSimulator;
using BasketballPlayerSimulator.Builders;
using BasketballPlayerSimulator.Models;
using DataAccessLayer;
using Newtonsoft.Json;

namespace BasketballSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var players = new List<Player>();
            var teamBuilder = new TeamBuilder();
            var playerBuilder = new PlayerBuilder();
            var dataManager = new DatabaseManager();

            var teams = teamBuilder.GetIds();
            teams.ForEach(team => teamBuilder.GetRoster(team, "2014-15"));
            teams.ForEach(team => teamBuilder.GetCommonInfo(team, "2014-15", "Regular Season"));

            //I moved tasks out here due to concurrency issues within inviduals methods. This works well though
            Task[] t = new Task[4];
            t[0] = Task.Run(() => teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Regular Season"))));
            t[1] = Task.Run(() =>teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Playoffs"))));
            t[2] = Task.Run(() =>teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2013-14", "Regular Season"))));
            t[3] = Task.Run(() =>teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2013-14", "Playoffs"))));

            //teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2012-13", "Regular Season")));
            //teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2012-13", "Playoffs")));
            //teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2011-12", "Regular Season")));
            //teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2011-12", "Playoffs")));
            //teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2010-11", "Regular Season")));
            //teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2010-11", "Playoffs")));

            Task.WaitAll(t);

            // MONGODB STUFF BELOW

            foreach (var serializedTeam in teams.Select(JsonConvert.SerializeObject))
            {
                dataManager.AddTeam(serializedTeam);
            }

            teams.ForEach(team => team.Roster.ForEach(player => players.Add(player)));

            foreach (var serializedPlayer in players.Select(JsonConvert.SerializeObject))
            {
                dataManager.AddPlayer(serializedPlayer);
            }

            
        }
    }
}
