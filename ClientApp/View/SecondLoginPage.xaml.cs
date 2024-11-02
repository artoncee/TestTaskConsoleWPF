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
    public partial class SecondLoginPage : Page
    {
        private readonly Client client = new Client();
        public SecondLoginPage()
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

        private void LoadUsers()
        {
            string selectedOrgName = OrgNameComboBox.SelectedItem.ToString();
            string response = client.SendRequest($"{ConstResponse.GetUsers}|{selectedOrgName}");
            var users = response.Split(',');
            UsernameComboBox.ItemsSource = users;
        }

        private void OrgNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrgNameComboBox.SelectedValue != null)
            {
                UsernameComboBox.IsEnabled = true;
                LoadUsers();
            }
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            string orgName = OrgNameComboBox.SelectedItem.ToString();
            string username = UsernameComboBox.SelectedItem.ToString();
            string password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Укажите пароль");
                PasswordTextBox.Clear();
                return;
            }

            string response = client.SendRequest($"{ConstResponse.Login2Response}|{username}|{password}|{orgName}");

            if (response == "LOGIN_SUCCESS")
            {
                MessageBox.Show("Авторизация прошла успешно");
            }
            else
            {
                MessageBox.Show("Неверный пароль");
                PasswordTextBox.Clear();
            }
        }
    }
}
