using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            var test = File.Create(@"../../../data/test.txt");
            //GetDataFromServiceAndStore();
        }

        private static void GetDataFromServiceAndStore()
        {
            //var teamBuilder = new TeamBuilder();
            //var playerBuilder = new PlayerBuilder();
            //var coachBuilder = new CoachBuilder();
            var dataManager = new DatabaseManager("mongodb://gabcinder2004:cooper@ds047632.mongolab.com:47632/nba?maxPoolSize=5000");
            //var dataManager = new DatabaseManager("mongodb://localhost:27017");

            //var teams = teamBuilder.GetIds();

            //teams.ForEach(team => teamBuilder.GetCommonInfo(team, "2014-15", "Regular Season"));

            //var players = playerBuilder.GetAllPlayersBasicInfo(teams, "2014-15");
            //var coaches = coachBuilder.GetAllCoachesBasicInfo(teams, "2014-15");

            //var tasks = new List<Task>
            //{
            //    Task.Run( () => players.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Regular Season"))),
            //    Task.Run( () => players.ForEach(player => playerBuilder.GetPlayerSplits(player, "2014-15", "Playoffs"))),
            //    Task.Run( () => players.ForEach(player => playerBuilder.GetPlayerSplits(player, "2013-14", "Regular Season"))),
            //    Task.Run( () => players.ForEach(player => playerBuilder.GetPlayerSplits(player, "2013-14", "Playoffs")))
            //};

            //Task.WaitAll(tasks.ToArray());

            //var serializedTeams = JsonConvert.SerializeObject(teams);
            //var serializedPlayers = JsonConvert.SerializeObject(players);
            //var serializedCoaches = JsonConvert.SerializeObject(coaches);

            //File.WriteAllText(@"C:\Projects\BasketballPlayerSimulator\teams.txt", serializedTeams);
            //File.WriteAllText(@"C:\Projects\BasketballPlayerSimulator\players.txt", serializedPlayers);
            //File.WriteAllText(@"C:\Projects\BasketballPlayerSimulator\coaches.txt", serializedCoaches);

            // MONGODB STUFF BELOW

            var teams = JsonConvert.DeserializeObject<List<Team>>(File.ReadAllText(@"../../../data/teams.txt"));
            var players = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(@"../../../data/players.txt"));
            var coaches = JsonConvert.DeserializeObject<List<Coach>>(File.ReadAllText(@"../../../data/coaches.txt"));

            teams.ForEach(dataManager.AddTeam);
            players.ForEach(dataManager.AddPlayer);
            coaches.ForEach(dataManager.AddCoach);
            //dataManager.AddTeams(teams);

            Thread.Sleep(20000);
        }
    }
}
