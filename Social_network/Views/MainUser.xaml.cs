﻿using MongoDB.Bson;
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
using System.Windows.Shapes;

namespace Social_network.Views
{
    /// <summary>
    /// Interaction logic for MainUser.xaml
    /// </summary>
    public partial class MainUser : Window
    {
        BsonObjectId userId;
        public MainUser(BsonObjectId userId, User user)
        {
            InitializeComponent();
            this.userId = userId;
            UserName.Text = user.FirstName;
            SocialDbController.UpdateScrollContent(this,userId);
            



            //stackContent.Children.Add();









        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SocialDbController.CreateNewPost(this,userId);
        }
    }
}
