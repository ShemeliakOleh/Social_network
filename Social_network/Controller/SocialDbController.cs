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
using System.Windows.Media;

namespace Social_network.Controller
{
   public static class SocialDbController
    {
        public static async void LoginUser(string email, string password, MainWindow loginWindow)
        {
            
            var filter = new BsonDocument("$and", new BsonArray { new BsonDocument("email",email), new BsonDocument("password", password) });
            List<BsonDocument> userCursor = await GetDocumentsList(filter,"users");
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

        internal static async void CreateNewPost(MainUser mainUser, BsonObjectId userId)
        {
            if (mainUser.newPostTextBox.Text.Length > 0)
            {
                Post post = new Post() { User = userId, PostsContent = mainUser.newPostTextBox.Text, Comments = new List<BsonObjectId>(), Likers=new List<BsonObjectId>()};
                var collection = GetCollection("posts");
                await collection.InsertOneAsync(post.ToBsonDocument());
                UpdateScrollContent(mainUser, userId);
            }

           

        }

        private static async Task<List<BsonDocument>> GetDocumentsList ( FilterDefinition<BsonDocument> filter, string CollectionsName)
        {
            var collection = GetCollection("users");
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
            return userCursor;

        }
        private static async Task<List<BsonDocument>> GetDocumentsList(string CollectionsName)
        {

            var collection = GetCollection("users");
            List<BsonDocument> userCursor = new List<BsonDocument>();
            using (var cursor = await collection.FindAsync(new BsonDocument()))
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
            return userCursor;

        }
        private static async Task<List<BsonDocument>> SortCollectionById(string collectionName)
        {

            var collection = GetCollection(collectionName);

            var sortedCollection = await collection.Find(new BsonDocument()).Sort("{_id:1}").Limit(15).ToListAsync();
            return sortedCollection;
        }
        internal static async void UpdateScrollContent(MainUser mainUser, BsonObjectId userId)
        {

            var documentsList =await SortCollectionById("posts");
            List<string> headPosts = new List<string>();
            List<Post> posts = new List<Post>();
           
            for (int i =0; i< documentsList.Count; i++)
            {
                
              var filter = Builders<BsonDocument>.Filter.Eq("_id",documentsList[i]["user"]);
            
                List<BsonDocument> userCursor = new List<BsonDocument>();
                var User = await GetDocumentsList(filter,"users");
                headPosts.Add(User[0]["firstName"].ToString() + " " + User[0]["secondName"].ToString());
                documentsList[i].Remove("_id");
                posts.Add(BsonSerializer.Deserialize<Post>(documentsList[i]));
            }
            



            ViewsController.ShowScrollContent(mainUser,userId,posts,headPosts);
        }

        internal static async void RegisterUser(SingUpUser singUpUser)
        {
            string message = "";
            if (!(singUpUser.tBoxRegFName.Text.Length > 1))
            {
                
                message = "First name must be more than one character";
                

            }
            if (!(singUpUser.tBoxRegSName.Text.Length > 1))
            {
                
                if(message=="")message = "Second name must be more than one character";
            }
            if (!(singUpUser.tBoxRegEmail.Text.Length > 1))
            {
                
                if(message=="")message = "E-mail must be more than one character";
            }
            if (!(singUpUser.tBoxRegPass.Text.Length > 1))
            {
                
                if(message=="")message = "Password must be more than one character";
            }
            if (message == "") {
                singUpUser.tBlockMessage.Text = "Please wait";
                User user = new User()
                {
                    FirstName = singUpUser.tBoxRegFName.Text,
                    SecondName = singUpUser.tBoxRegSName.Text,
                    Email = singUpUser.tBoxRegEmail.Text,
                    Password = singUpUser.tBoxRegPass.Text
                };

                user.Interests = new List<string>(singUpUser.tBoxRegInterets.Text.Split(','));
                    
                var filter = new BsonDocument(new BsonDocument("email", user.Email));
                
                List<BsonDocument> userCursor = await GetDocumentsList(filter, "users");
                
                if (userCursor.Count > 0)
                {

                    singUpUser.tBlockMessage.Text = "User with this e-mail is already registered!";
                }
                else
                {
                    var collection = GetCollection("users");
                    await collection.InsertOneAsync(user.ToBsonDocument());
                    ViewsController.ShowLoginUser(singUpUser, user.Email,user.Password);
                }
               

            }
            else
            {
                singUpUser.tBlockMessage.Text = message;
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
