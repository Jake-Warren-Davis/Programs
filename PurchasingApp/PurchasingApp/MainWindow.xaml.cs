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

namespace PurchasingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //Set up variables.
        static string[] UserNames = {"Guest1","Guest2","Guest3"};
        string[] Passwords = { "Pass1","Pass2","Pass3" };
        int numOfUsers = UserNames.Length;//This is starting from 0 so there are 3 users.
        public static string Username = "";
        
        
        public MainWindow()
        {
            InitializeComponent();
            
            //Reset login status label.
            lblLoginStatus.Content = "";
            imgDanger.Visibility = System.Windows.Visibility.Hidden;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            
        }

        private void imgLog_In_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //This checks to see if the username entred is matching one that is one stored. If it doesnt then it is marked as not a username.
            for (int i = 0; i < numOfUsers; i++)
            {
                if (txtUserName.Text != UserNames[i])
                {
                    if (i == numOfUsers - 1)
                    {
                        lblLoginStatus.Content = "Username not found.";
                        imgDanger.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }

            //Loop through all passwords and usernames.
            for (int i = 0; i < numOfUsers; i++)
            {
                if (txtUserName.Text == UserNames[i])
                {
                    if (txtPassword.Text == Passwords[i])
                    {
                        //Username and password match. This means that they can login.
                        lblLoginStatus.Content = "You can login";
                        imgDanger.Visibility = System.Windows.Visibility.Hidden;
                        Username = txtUserName.Text;
                        PurchaseWindow PW = new PurchaseWindow();
                        PW.Show();
                        Close();
                    }
                    else
                    {
                        //Password does not match the username.
                        lblLoginStatus.Content = "Password is incorrect.";
                        imgDanger.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        
    }
}
