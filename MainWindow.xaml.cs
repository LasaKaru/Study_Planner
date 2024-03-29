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

namespace Study_Planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserService _userService;

        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (_userService.AuthenticateUser(username, password))
            {
                Dashboard dashboard = new Dashboard(username);
                dashboard.Show();
                this.Close();
            }
            else
            {
                txtMessage.Text = "Invalid username or password!";
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Implement registration logic
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Check if username already exists
            if (_userService.UserExists(username))
            {
                txtMessage.Text = "Username already exists. Please choose another.";
                return;
            }

            // Add new user
            _userService.AddUser(username, password);
            txtMessage.Text = "Registration successful. You can now log in.";
        }
    }
}
