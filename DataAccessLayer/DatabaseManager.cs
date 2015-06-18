using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BasketballPlayerSimulator.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccessLayer
{
    public class DatabaseManager
    {
        private MongoClient Client { get; set; }
        private IMongoDatabase Database { get; set; }

        public DatabaseManager(string connectionString)
        {
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase("nba");
        }

        public async void AddTeam(Team team)
        {
            Console.WriteLine("Adding team: {0}", team.Name);
            var collection = Database.GetCollection<Team>("Teams");
            await collection.InsertOneAsync(team);
        }

        public async void AddTeams(List<Team> teams)
        {
            Console.WriteLine("Adding all teams");

            var collection = Database.GetCollection<Team>("teams");
            await collection.InsertManyAsync(teams);
        }

        public async void AddPlayer(Player player)
        {
            Console.WriteLine("Adding player: {0}", player.Name);
            var collection = Database.GetCollection<Player>("Players");
            await collection.InsertOneAsync(player);
        }

        public async void AddCoach(Coach coach)
        {
            Console.WriteLine("Adding coach: {0}", coach.Name);
            var collection = Database.GetCollection<Coach>("Coaches");
            await collection.InsertOneAsync(coach);
        }
    }
}
