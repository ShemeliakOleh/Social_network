using Social_network.Controller;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Social_network.Views
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public List<User> usersStreamList { get; set; }
        public SearchPage()
        {
            InitializeComponent();
            usersStreamList = new List<User>();
            
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            ViewsController.ShowPostsPage(((MainUser)Window.GetWindow(this)));
        }

        private void bSearch_Click(object sender, RoutedEventArgs e)
        {
            SocialDbController.UpdatePeopleScrollContent(this);
        }
        internal void bViewUser_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)sender).Tag.ToString());
            SocialDbController.ClickView(this, index);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SocialDbController.UpdatePeopleScrollContent(this);
        }
    }
}
