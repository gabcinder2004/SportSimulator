using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DataAccessLayer
{
    public class DatabaseManager
    {
        private MongoClient Client { get; set; }
        private IMongoDatabase Database { get; set; }

        public DatabaseManager()
        {
            Client = new MongoClient("mongodb://localhost:27017");
            Database = Client.GetDatabase("NBA");
        }

        public async void AddTeam(string team)
        {
            Console.WriteLine("Adding team");
            var collection = Database.GetCollection<BsonDocument>("Teams");
            var document = BsonSerializer.Deserialize<BsonDocument>(team);
            await collection.InsertOneAsync(document);
        }

        public bool DoesRowExist(string tableName, string columnName, string value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(columnName, value);
            var table = Database.GetCollection<BsonDocument>(tableName);
            var document = table.Find(filter).FirstAsync();

            return document != null;
        }

        public async void AddPlayer(string serializedPlayer)
        {
            Console.WriteLine("Adding player");
            var collection = Database.GetCollection<BsonDocument>("Players");
            var document = BsonSerializer.Deserialize<BsonDocument>(serializedPlayer);
            await collection.InsertOneAsync(document);

        }
    }
}
