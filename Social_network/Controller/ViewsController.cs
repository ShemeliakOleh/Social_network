using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Social_network.Models;
using Social_network.Views;

namespace Social_network.Controller
{
  public  static class ViewsController
    {
        internal static void ShowMainUser(User user,MainWindow loginWindow)
        {
            loginWindow.tBlockIncorrectLogin.Visibility = System.Windows.Visibility.Visible;
            MainUser mainUser = new MainUser(user);
            mainUser.Show();
            loginWindow.Owner = mainUser;
            loginWindow.Close();
        }
        internal static void IncorrectLogin(MainWindow loginWindow)
        {
            loginWindow.tBlockIncorrectLogin.Visibility = System.Windows.Visibility.Visible;
        }

        internal static void ShowPostsPage(MainUser mainUser)
        {
            mainUser.mainPage.Navigate(new ContentStream(mainUser.User));
        }

        internal static void ShowSearchPage(MainUser mainUser)
        {
            mainUser.mainPage.Navigate(new SearchPage());
        }

        internal static void CancelRegistration(SingUpUser singUpUser)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            singUpUser.Owner = loginWindow;
            singUpUser.Close();
        }

        internal static void ShowSingUpUser(MainWindow loginWindow)
        {
            SingUpUser singUpUser = new SingUpUser();
            singUpUser.Show();
            loginWindow.Owner = singUpUser;
            loginWindow.Close();
        }

        internal static void ShowCommentsPage(UserPageStream userPageStream, Post post)
        {
            MainUser parentWindowUser = (MainUser)Window.GetWindow(userPageStream);
            parentWindowUser.mainPage.Navigate(new PostCommentsStream(post));
        }

        internal static void ShowUserScrollContent(UserPageStream userPageStream)
        {
            userPageStream.mainStackUserContent.Children.RemoveRange(1, userPageStream.mainStackUserContent.Children.Count - 1);


            
            userPageStream.blockFirstName.Text = userPageStream.User.FirstName;
            userPageStream.blockSecondName.Text = userPageStream.User.SecondName;
            userPageStream.blockEmail.Text = userPageStream.User.Email;
            userPageStream.blockInterests.Text = String.Join(", ",userPageStream.User.Interests);
            var parent = GetParentWindow(userPageStream);
            if ((parent.User.Following.Contains(userPageStream.User.Id)) &&(parent.User.Followers.Contains(userPageStream.User.Id)))
            {
                userPageStream.bFollow.Tag = 2;
                userPageStream.bFollow.Content = "Following";
                
            }
            else if (parent.User.Followers.Contains(userPageStream.User.Id))
                {
                    userPageStream.bFollow.Tag = 1;
                    userPageStream.bFollow.Content = "Follow Back";
                }
            else if (parent.User.Following.Contains(userPageStream.User.Id))
                {
                    userPageStream.bFollow.Tag = -1;
                    userPageStream.bFollow.Content = "Following";
                }
            else
                {
                    userPageStream.bFollow.Tag = -2;
                    userPageStream.bFollow.Content = "Follow";
                }
               
            
            for (int i = 0; i < userPageStream.postsStreamList.Count; i++)
            {

                StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Vertical };
                stackPanel.Children.Add(new TextBlock() { Text = userPageStream.User.FirstName + " " + userPageStream.User.SecondName });
                stackPanel.Children.Add(new TextBlock() { TextWrapping = System.Windows.TextWrapping.Wrap, Margin = new System.Windows.Thickness(0, 5, 0, 0), MaxHeight = 120, Width = 500, Text = userPageStream.postsStreamList[i].PostsContent });
                Grid grid = new Grid();
                var bLike = new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "Like", Tag = i };
                var bMore = new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Center, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "More", Tag = i };
                var bComment = new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Right, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "Comment", Tag = i };
                bComment.Click += new RoutedEventHandler(userPageStream.BComment_Click);
                bLike.Click += new RoutedEventHandler(userPageStream.BLike_Click);
                bMore.Click += new RoutedEventHandler(userPageStream.BMore_Click);
                grid.Children.Add(bLike);
                grid.Children.Add(bMore);
                grid.Children.Add(bComment);
                stackPanel.Children.Add(grid);
                userPageStream.mainStackUserContent.Children.Add(stackPanel);

            }
           
        }

        internal static void ShowLoginUser(SingUpUser singUpUser, string email, string password)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            loginWindow.tBoxEmail.Text = email;
            loginWindow.tBoxPassword.Text = password;
            singUpUser.Owner = loginWindow;
            singUpUser.Close();
        }

 

        internal static void ShowScrollContent(ContentStream contentStream, List<string> headPosts)
        {
            contentStream.mainStackContent.Children.RemoveRange(1, contentStream.mainStackContent.Children.Count-1);
            for (int i =0; i < contentStream.postsStreamList.Count; i++)
            {
                
                StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Vertical};
                stackPanel.Children.Add(new TextBlock() {Text = headPosts[i]});
                stackPanel.Children.Add(new TextBlock() {TextWrapping = System.Windows.TextWrapping.Wrap, Margin= new System.Windows.Thickness(0,5,0,0), MaxHeight = 120, Width = 500 , Text = contentStream.postsStreamList[i].PostsContent});
                Grid grid = new Grid();
                var bLike = new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "Like", Tag = i };
                var bMore = new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Center, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "More", Tag = i };
                var bComment = new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Right, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "Comment", Tag = i };
                bComment.Click += new RoutedEventHandler(contentStream.BComment_Click);
                bLike.Click += new RoutedEventHandler(contentStream.BLike_Click);
                bMore.Click += new RoutedEventHandler(contentStream.BMore_Click);
                grid.Children.Add(bLike);
                grid.Children.Add(bMore);
                grid.Children.Add(bComment);


                stackPanel.Children.Add(grid);
                contentStream.mainStackContent.Children.Add(stackPanel);
               
            }
            
        }

        internal static void ShowUserPage(SearchPage searchPage, User user)
        {
            var parent = GetParentWindow(searchPage);
            parent.mainPage.Navigate(new UserPageStream(user));
        }
        internal static MainUser GetParentWindow(Page page)
        {
            MainUser parentWindowUser = (MainUser)Window.GetWindow(page);
            return parentWindowUser;
        }
        internal static void ShowScrollPeopleContent(SearchPage searchPage)
        {
            searchPage.mainStackPeople.Children.Clear();
            for (int i =0; i< searchPage.usersStreamList.Count; i++)
            {
                StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
                var bViewUser = new Button() { MinWidth = 130, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.Wheat), FontSize = 20, Margin = new System.Windows.Thickness(20, 20, 0, 20), Content = "View user", Tag = i };
                bViewUser.Click+= new RoutedEventHandler(searchPage.bViewUser_Click);
                stackPanel.Children.Add(new TextBlock() {Height=30,HorizontalAlignment= HorizontalAlignment.Left, MinWidth = 170,FontSize = 20, Text = searchPage.usersStreamList[i].FirstName});
                stackPanel.Children.Add(new TextBlock() { Height = 30, HorizontalAlignment = HorizontalAlignment.Left, MinWidth = 170, FontSize = 20, Text = searchPage.usersStreamList[i].SecondName });
                stackPanel.Children.Add(new TextBlock() { Height = 30, HorizontalAlignment = HorizontalAlignment.Left, MinWidth = 170, FontSize = 20, Text = searchPage.usersStreamList[i].Email });
                stackPanel.Children.Add(bViewUser);
                searchPage.mainStackPeople.Children.Add(stackPanel);
            }
           

        }

        internal static void ShowCommentsScrollContent(List<Comment> comments, string userName,PostCommentsStream postCommentsStream,List<string> headComments)
        {
            var parent = GetParentWindow(postCommentsStream);
            postCommentsStream.mainStackContent.Children.Clear();
            StackPanel stackPanelMain = new StackPanel() { Orientation = Orientation.Vertical };
            stackPanelMain.Children.Add(new TextBlock() { Text = userName });
            stackPanelMain.Children.Add(new TextBlock() { TextWrapping = System.Windows.TextWrapping.Wrap, Margin = new System.Windows.Thickness(0, 5, 0, 0), MaxHeight = 120, Width = 700, Text = postCommentsStream.Post.PostsContent });
            Grid gridMain = new Grid();
            var bLike = new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "Like" };
            var bMore = new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Center, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "More"}; ;
            gridMain.Children.Add(bLike);
            gridMain.Children.Add(bMore);
            stackPanelMain.Children.Add(gridMain);
            postCommentsStream.mainStackContent.Children.Add(stackPanelMain);
            for (int i =0; i< comments.Count; i++) ////continue;
            {
                StackPanel stackPanelComment = new StackPanel() {Orientation = Orientation.Vertical };
                stackPanelComment.Children.Add(new TextBlock() {Margin = new Thickness(20,10,5,5) , Text = headComments[i] /*chi*/});
                stackPanelComment.Children.Add(new TextBlock() { MaxHeight = 120, Width = 600, Margin = new Thickness(0,5,0,0), TextWrapping= TextWrapping.Wrap, Text = comments[i].CommentContent /*chi*/});
                postCommentsStream.mainStackContent.Children.Add(stackPanelComment);
            }
        }

        internal static void ShowCommentsPage(ContentStream contentStream, Post post)
        {
            var parent =  GetParentWindow(contentStream);
            parent.mainPage.Navigate(new PostCommentsStream(post));

        }
    }
}
