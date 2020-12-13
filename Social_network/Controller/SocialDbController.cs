using MongoDB.Bson;
using MongoDB.Driver;
using Social_network.Neo4JLayer.Neo4JController;
using Social_network.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Social_network.Controller
{
    class SocialDbController
    {
        public static void LoginUser(string email, string password, MainWindow loginWindow)
        {

             MongoDbController.LoginUser(email,password,loginWindow);
            
        }

        internal static void ClickView(FollowersPage followersPage, int index)
        {
            MongoDbController.ClickView(followersPage,index);
        }

        internal static void UpdateFollowersScrollContent(FollowersPage followersPage)
        {
            MongoDbController.UpdateFollowersScrollContent(followersPage);
        }

        internal static void ClickView(FollowingPage followingPage, int index)
        {
            MongoDbController.ClickView(followingPage,index);
        }

        internal static void UpdateFollowingScrollContent(FollowingPage followingPage)
        {
            MongoDbController.UpdateFollowingScrollContent(followingPage);
        }


        internal static void UpdatePeopleScrollContent(SearchPage searchPage)
        {
            MongoDbController.UpdatePeopleScrollContent(searchPage);

        }
        internal static void ClickComments(UserPageStream userPageStream, int index)
        {
           MongoDbController.ClickComments(userPageStream,index);
        }
        internal static void ClickLike(UserPageStream userPageStream, int index)
        {
            MongoDbController.ClickLike(userPageStream,index);
        }

        internal static void ClickLike(PostCommentsStream postCommentsStream, int index)
        {
            MongoDbController.ClickLike(postCommentsStream, index);
        }

        internal static void ClickLike(ContentStream contentStream, int index)
        {
            MongoDbController.ClickLike(contentStream, index);
        }

        internal static void ClickFollow(UserPageStream userPageStream, int index)
        {
            MongoDbController.ClickFollow(userPageStream, index);
            Neo4JController.ClickFollow(userPageStream, index);
        }

        internal static void UpdateCommentsScrollContent(PostCommentsStream postCommentsStream)
        {
            MongoDbController.UpdateCommentsScrollContent(postCommentsStream);
        }
        internal static void UpdateUserPostsScrollContent(UserPageStream userPageStream)
        {
            MongoDbController.UpdateUserPostsScrollContent(userPageStream);
            
            Neo4JController.GetDistance(userPageStream);
        }

        internal static void ClickView(SearchPage searchPage, int index)
        {
           MongoDbController.ClickView(searchPage, index);
        }


        internal static void UpdatePostsScrollContent(ContentStream contentStream)
        {
            MongoDbController.UpdatePostsScrollContent(contentStream);
        }


        internal static void CreateNewComment(PostCommentsStream postCommentsStream)
        {
            MongoDbController.CreateNewComment(postCommentsStream);
        }
        internal static void CreateNewPost(ContentStream contentStream)
        {
            MongoDbController.CreateNewPost(contentStream);
        }
        internal static void ClickComments(ContentStream contentStream, int index)
        {
            MongoDbController.ClickComments(contentStream, index);
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

                if (message == "") message = "Second name must be more than one character";
            }
            if (!(singUpUser.tBoxRegEmail.Text.Length > 1))
            {

                if (message == "") message = "E-mail must be more than one character";
            }
            if (!(singUpUser.tBoxRegPass.Text.Length > 1))
            {

                if (message == "") message = "Password must be more than one character";
            }
            if (message == "")
            {
                singUpUser.tBlockMessage.Text = "Please wait";
                if (await MongoDbController.RegisterUser(singUpUser))
                {
                    Neo4JController.RegisterUser(singUpUser);
                }
                else
                {
                    singUpUser.tBlockMessage.Text = "User with this e-mail is already registered!";
                }
                

            }
            else
            {
                singUpUser.tBlockMessage.Text = message;
            }
            
        }

    }
}
