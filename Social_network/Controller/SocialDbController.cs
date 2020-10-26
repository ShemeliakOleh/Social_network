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
using System.Windows.Data;

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
                var user = BsonSerializer.Deserialize<User>(userBson);
                ViewsController.ShowMainUser(user,loginWindow);


            }
            else
            {
                ViewsController.IncorrectLogin(loginWindow);
            }

        }

        internal static async void UpdateCommentsScrollContent(PostCommentsStream postCommentsStream)
        {
            var filterForComments = Builders<BsonDocument>.Filter.Eq("post",postCommentsStream.Post.Id);
            var filterForUsers = Builders<BsonDocument>.Filter.Eq("_id", postCommentsStream.Post.User);
            var commentsBson = await GetDocumentsList(filterForComments, "comments");
            var userAsList = await GetDocumentsList(filterForUsers, "users");
            var userName = userAsList[0]["firstName"] + " " + userAsList[0]["secondName"];
            var comments = new List<Comment>();
            for(int i =0; i< commentsBson.Count; i++)
            {
                comments.Add(BsonSerializer.Deserialize<Comment>(commentsBson[i]));
            }
            
            ViewsController.ShowCommentsScrollContent(comments, userName,postCommentsStream);
















        }

        internal static async void CreateNewPost(ContentStream contentStream)

        {
            if (contentStream.newPostTextBox.Text.Length > 0)
            {
                Post post = new Post() {  User = contentStream.User.Id, PostsContent = contentStream.newPostTextBox.Text};
                contentStream.newPostTextBox.Text = "";
                var collection = GetCollection("posts");
                var usersCollection = GetCollection("users");
                await collection.InsertOneAsync(post.ToBsonDocument());
                var filter = Builders<BsonDocument>.Filter.Eq("_id", contentStream.User.Id);
                var update = Builders<BsonDocument>.Update.AddToSet("posts", post.Id);
                await usersCollection.UpdateOneAsync(filter,update);
                UpdatePostsScrollContent(contentStream);
            }
            

           

        }
        internal static async void ClickComments(ContentStream contentStream, int index)
        {
            var filterForPosts = Builders<BsonDocument>.Filter.Eq("_id", contentStream.postsStreamList[index].Id); 
           
            
            var postAsList = await GetDocumentsList(filterForPosts, "posts");

            var post = BsonSerializer.Deserialize<Post>(postAsList[0]);
           
            ViewsController.ShowCommentsPage(contentStream,post);

        }

        internal static void ClickMore(ContentStream contentStream, int index)
        {
            throw new NotImplementedException();
        }

        internal static void ClickLike(ContentStream contentStream, int index)
        {
            throw new NotImplementedException();
        }

        private static async Task<List<BsonDocument>> GetDocumentsList ( FilterDefinition<BsonDocument> filter, string CollectionsName)
        {
            var collection = GetCollection(CollectionsName);
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

            var collection = GetCollection(CollectionsName);
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
        private static async Task<List<BsonDocument>> SortCollectionById(string collectionName, bool ascending)
        {

            var collection = GetCollection(collectionName);
            List<BsonDocument> sortedCollection;
            if (ascending)
            {
                sortedCollection = await collection.Find(new BsonDocument()).Sort("{_id:1}").Limit(15).ToListAsync();
            }
            else
            {
                sortedCollection = await collection.Find(new BsonDocument()).Sort("{_id:-1}").Limit(15).ToListAsync();
            }
            
            return sortedCollection;
        }
        internal static async void UpdatePostsScrollContent(ContentStream contentStream)
        {

            var documentsList =await SortCollectionById("posts", false);
            List<string> headPosts = new List<string>();
            List<Post> posts = new List<Post>();
           
            for (int i =0; i< documentsList.Count; i++)
            {
                
              var filter = Builders<BsonDocument>.Filter.Eq("_id",documentsList[i]["user"]);
            
                List<BsonDocument> userCursor = new List<BsonDocument>();
                var User = await GetDocumentsList(filter,"users");
                headPosts.Add(User[0]["firstName"].ToString() + " " + User[0]["secondName"].ToString());
                
                posts.Add(BsonSerializer.Deserialize<Post>(documentsList[i]));
            }



            contentStream.postsStreamList = new List<Post>(posts);
            ViewsController.ShowScrollContent(contentStream,headPosts);
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
                    Password = singUpUser.tBoxRegPass.Text,
                    
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
