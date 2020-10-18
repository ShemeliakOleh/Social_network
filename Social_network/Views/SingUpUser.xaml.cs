using Social_network.Controller;
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
    /// Interaction logic for SingUpUser.xaml
    /// </summary>
    public partial class SingUpUser : Window
    {
        public SingUpUser()
        {
            InitializeComponent();
        }

        private void bRegister_Click(object sender, RoutedEventArgs e)
        {

             SocialDbController.RegisterUser(this);
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewsController.CancelRegistration(this);
        }
    }
}
