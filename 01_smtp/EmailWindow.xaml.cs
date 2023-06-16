using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace _01_smtp
{
    public partial class EmailWindow : Window
    {
        private string email;
        private string password;

        public EmailWindow(string email, string password)
        {
            InitializeComponent();

            this.email = email;
            this.password = password;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string myMailAddress = email;
            string myPassword = password;

            MailMessage mail = new MailMessage(myMailAddress, toTxtBox.Text)
            {
                Subject = subjectTxtBox.Text,
                Body = $"<h1>My Mail Message from C#</h1><p>{bodyTxtBox.Text}</p>",
                IsBodyHtml = true,
                Priority = MailPriority.High
            };

            var result = MessageBox.Show("Do you want to attach a file?", "Attach File", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                    mail.Attachments.Add(new Attachment(dialog.FileName));
            }

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(myMailAddress, myPassword),
                EnableSsl = true
            };

            try
            {
                client.Send(mail);
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email. Error: " + ex.Message);
            }
        }

        //private void EmailWindow_Closed(object sender, EventArgs e)
        //{
        //    loginWindow.Show();
        //    this.Close();
        //}
    }
}
