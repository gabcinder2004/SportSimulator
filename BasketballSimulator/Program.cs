using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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
            var teamBuilder = new TeamBuilder();
            var teams = teamBuilder.GetIds();
            teams.ForEach(team => teamBuilder.GetRoster(team, "2014-15"));
            teams.ForEach(team => teamBuilder.GetCommonInfo(team, "2014-15", "Regular Season"));
            var playerBuilder = new PlayerBuilder();

            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Regular Season")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Playoffs")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2013-14", "Regular Season")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2013-14", "Playoffs")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2012-13", "Regular Season")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2012-13", "Playoffs")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2011-12", "Regular Season")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2011-12", "Playoffs")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2010-11", "Regular Season")));
            teams.ForEach(team => team.Roster.ForEach(player => playerBuilder.GetPlayerSplits(player, "2010-11", "Playoffs")));

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
        }
    }
}
