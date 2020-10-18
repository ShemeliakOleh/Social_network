using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Social_network.Models;
using Social_network.Views;

namespace Social_network.Controller
{
  public  static class ViewsController
    {
        internal static void ShowMainUser(User user,MainWindow loginWindow, BsonObjectId userId)
        {
            loginWindow.tBlockIncorrectLogin.Visibility = System.Windows.Visibility.Visible;
            MainUser mainUser = new MainUser(userId,user);
            
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
    }
}
