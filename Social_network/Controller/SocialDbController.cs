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
using MongoDB.Bson.Serialization;

namespace Social_network.Controller
{
   public static class SocialDbController
    {
        public static async void LoginUser(string email, string password, MainWindow loginWindow)
        {
            var collection = GetCollection("users");
            var filter = new BsonDocument("$and", new BsonArray { new BsonDocument("email",email), new BsonDocument("password", password) });
            List<BsonDocument> userCursor = new List<BsonDocument>();
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var users = cursor.Current;
                    foreach (var doc in users)
                    {
                        userCursor.Add(doc);
                    }
                }
            }
            if (userCursor.Count > 0)
            {
                var userBson = userCursor[0];
                BsonValue userId = userBson["_id"];
                
                    userBson.Remove("_id");
                    var user = BsonSerializer.Deserialize<User>(userBson);


                ViewsController.ShowMainUser(user,loginWindow, userId.AsObjectId);


            }
            else
            {
                ViewsController.IncorrectLogin(loginWindow);
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
