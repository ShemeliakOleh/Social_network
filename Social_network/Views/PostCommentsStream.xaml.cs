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
    /// Interaction logic for PostCommentsStream.xaml
    /// </summary>
    public partial class PostCommentsStream : Page
    {
        public Post Post { get; set; }
        public List<Button> LikeButtonsList { get; set; }
        public List<TextBlock> CommentsContentList { get; set; }
        public List<Comment> CommentsStreamList { get; set; }
        public PostCommentsStream(Post post)
        {
            this.Post = post;
            InitializeComponent();
            LikeButtonsList = new List<Button>();
            CommentsContentList = new List<TextBlock>();
            CommentsStreamList = new List<Comment>();
        }

        private void bComment_Click(object sender, RoutedEventArgs e)
        {
            SocialDbController.CreateNewComment(this);
        }
        internal void BMore_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)sender).Tag.ToString());
            ViewsController.ShowUpdatedBMore(this, index);
        }

        internal void BLike_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)sender).Tag.ToString());
            SocialDbController.ClickLike(this, index);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SocialDbController.UpdateCommentsScrollContent(this);
        }
    }
}
