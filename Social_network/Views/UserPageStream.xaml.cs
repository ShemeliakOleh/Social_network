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
    /// Interaction logic for UserPageStream.xaml
    /// </summary>
    public partial class UserPageStream : Page
    {
        public List<Post> postsStreamList { get; set; }
        public User User { get; set; }
        public UserPageStream(User user)
        {
            postsStreamList = new List<Post>();
            this.User = user;
            InitializeComponent();
            
        }
        internal void BComment_Click(object sender, RoutedEventArgs e)
        {

            int index = int.Parse(((Button)sender).Tag.ToString());
            SocialDbController.ClickComments(this, index);

        }

        internal void BMore_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)sender).Tag.ToString());
            SocialDbController.ClickMore(this, index);
        }

        internal void BLike_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)sender).Tag.ToString());
            SocialDbController.ClickLike(this, index);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SocialDbController.UpdateUserPostsScrollContent(this);
        }

        private void bFollow_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)sender).Tag.ToString());
            SocialDbController.ClickFollow(this,index);
        }
    }
}
