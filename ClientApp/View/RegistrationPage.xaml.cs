using ClientApp.Utils;
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
    public partial class RegistrationPage : Page
    {
        private readonly Client client = new Client();
        public RegistrationPage()
        {
            InitializeComponent();
            LoadOrganizations();

        }

        private void LoadOrganizations()
        {
            string response = client.SendRequest(ConstResponse.GetOrganizations);
            var org = response.Split(',');
            OrgNameComboBox.ItemsSource = org;
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            string orgName = OrgNameComboBox.SelectedItem.ToString();
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми");
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
                return;
            }

            string response = client.SendRequest($"{ConstResponse.RegistrationResponse}|{username}|{password}|{orgName}");

            if (response == ConstResponse.RegistrationSuccess)
            {
                MessageBox.Show("Регистрация прошла успешно");
            }
            else
            {
                MessageBox.Show("Данный пользователь уже существует");
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
            }
        }
    }
}
