﻿using Social_network.Controller;
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
    /// Interaction logic for ContentStream.xaml
    /// </summary>
    public partial class ContentStream : Page
    {
        public User User { get; set; }
        public List<Button> LikeButtonsList { get; set; }
        public List<TextBlock> PostsContentList { get; set; }
        public List<Post> postsStreamList { get; set; }

        public ContentStream(User user)
        {
            postsStreamList = new List<Post>();
            this.User = user;
            InitializeComponent();
            LikeButtonsList = new List<Button>();
            PostsContentList = new List<TextBlock>();
           
            
            
            
        }

        private void BCreatePost_Click(object sender, RoutedEventArgs e)
        {
            SocialDbController.CreateNewPost(this);
        }

        internal void BComment_Click(object sender, RoutedEventArgs e)
        {

            int index = int.Parse(((Button)sender).Tag.ToString());
            SocialDbController.ClickComments(this,index);
           
        }

        internal void BMore_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)sender).Tag.ToString());
            ViewsController.ShowUpdatedBMore(this,index);
        }

        internal void BLike_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)sender).Tag.ToString());
            SocialDbController.ClickLike(this,index);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SocialDbController.UpdatePostsScrollContent(this);
        }
    }
}
