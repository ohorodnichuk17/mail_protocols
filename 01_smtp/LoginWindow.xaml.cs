using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _01_smtp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public event EventHandler<LoginEventArgs> LoginSuccessful;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = mailTxtBox.Text;
            string password = passTxtBox.Text;

            if (CheckLoginAndPassword(email, password))
            {
                LoginSuccessful?.Invoke(this, new LoginEventArgs(email, password));
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Invalid login or password.");
            }
        }

        private bool CheckLoginAndPassword(string email, string password)
        {
            return IsValidEmail(email) && IsValidGmailPassword(password);
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidGmailPassword(string password)
        {
            int minPasswordLength = 8;
            return password.Length >= minPasswordLength;
        }
    }
}
