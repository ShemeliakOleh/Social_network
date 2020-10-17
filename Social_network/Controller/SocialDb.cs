using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Windows.Navigation;
using Social_network.Views;
using System.Runtime.CompilerServices;

namespace Social_network.Controller
{
   public static class SocialDb
    {
        public static async void LoginUser(string email, string password, MainWindow loginWindow)
        {
            var collection = GetCollection("users");
            var filter = new BsonDocument("$and", new BsonArray { new BsonDocument("email",email), new BsonDocument("password", password) });
            List<BsonDocument> User = new List<BsonDocument>();
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var users = cursor.Current;
                    foreach (var doc in users)
                    {
                        User.Add(doc);
                    }
                }
            }
            if (User.Count > 0)
            {
                MainUser mainUser = new MainUser(User[0]["_id"].AsObjectId);
                
                mainUser.Show();
                loginWindow.Owner = mainUser;
                loginWindow.Close();
                

            }

        }

        private static IMongoCollection<BsonDocument> GetCollection(string CollectionsName)
        {
            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("social_network");
            var collection = database.GetCollection<BsonDocument>(CollectionsName);
            return collection;
        }
    }
}
