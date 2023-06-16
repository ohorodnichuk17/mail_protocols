using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace _01_smtp
{
    public partial class MainWindow : Window
    {
        private LoginWindow loginWindow;
        private EmailWindow emailWindow;

        public MainWindow()
        {
            InitializeComponent();

            loginWindow = new LoginWindow();
            loginWindow.LoginSuccessful += LoginWindow_LoginSuccessful;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loginWindow.ShowDialog() == true)
            {
                string myMailAddress = loginWindow.mailTxtBox.Text;
                string password = loginWindow.passTxtBox.Text;

                emailWindow = new EmailWindow(myMailAddress, password);
                emailWindow.Show();
                this.Hide(); 
            }
        }

        private void LoginWindow_LoginSuccessful(object sender, LoginEventArgs e)
        {
        }
    }

    public class LoginEventArgs : EventArgs
    {
        public string Email { get; }
        public string Password { get; }

        public LoginEventArgs(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
