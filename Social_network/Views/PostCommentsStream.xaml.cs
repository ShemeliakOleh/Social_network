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
        public PostCommentsStream(Post post)
        {

           
            this.Post = post;
            InitializeComponent();
            SocialDbController.UpdateCommentsScrollContent(this);
            

        }
    }
}
