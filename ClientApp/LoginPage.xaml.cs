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


namespace ClientApp
{
    public partial class LoginPage : Page
    {
        private Client client;
        public LoginPage()
        {
            InitializeComponent();
            client = new Client();
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми");
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
                return;
            }

            string response = client.SendRequest($"LOGIN1|{username}|{password}");

            if (response == "LOGIN_SUCCESS")
            {
                MessageBox.Show("Авторизация прошла успешно");
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
            }
        }
    }
}
