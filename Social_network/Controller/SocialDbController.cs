using MongoDB.Bson;
using MongoDB.Driver;
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
        }

        internal static void UpdateCommentsScrollContent(PostCommentsStream postCommentsStream)
        {
            MongoDbController.UpdateCommentsScrollContent(postCommentsStream);
        }
        internal static void UpdateUserPostsScrollContent(UserPageStream userPageStream)
        {
            MongoDbController.UpdateUserPostsScrollContent(userPageStream);
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

        internal static void RegisterUser(SingUpUser singUpUser)
        {
            MongoDbController.RegisterUser(singUpUser);
        }

    }
}
