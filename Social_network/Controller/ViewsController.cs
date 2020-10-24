using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        internal static void ShowLoginUser(SingUpUser singUpUser, string email, string password)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            loginWindow.tBoxEmail.Text = email;
            loginWindow.tBoxPassword.Text = password;
            singUpUser.Owner = loginWindow;
            singUpUser.Close();
        }

        internal static void ShowScrollContent(ContentStream contentStream, List<Post> posts, List<string> headPosts)
        {
            contentStream.mainStackContent.Children.RemoveRange(1, contentStream.mainStackContent.Children.Count-1);
            for (int i =0; i < posts.Count; i++)
            {
                
                StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Vertical};
                stackPanel.Children.Add(new TextBlock() {Text = headPosts[i]});
                stackPanel.Children.Add(new TextBlock() {TextWrapping = System.Windows.TextWrapping.Wrap, Margin= new System.Windows.Thickness(0,5,0,0), MaxHeight = 120, Width = 500 , Text = posts[i].PostsContent});
                Grid grid = new Grid();
                grid.Children.Add(new Button() {HorizontalAlignment = System.Windows.HorizontalAlignment.Left, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "Like" });
                grid.Children.Add(new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Center, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "More" });
                grid.Children.Add(new Button() { HorizontalAlignment = System.Windows.HorizontalAlignment.Right, Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.White), Content = "Comment" });
                stackPanel.Children.Add(grid);

                contentStream.mainStackContent.Children.Add(stackPanel);
            }
        }
    }
}
