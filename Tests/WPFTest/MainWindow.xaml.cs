using System;
using System.Windows;
using System.Net;
using System.Net.Mail;
using WPFTestMailSender.Services;
using System.Security;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService yandexSender = new EmailSendService(Login.Text, Password.SecurePassword, EmailTo.Text, EmailHeader.Text, EmailBody.Text);
            yandexSender.Send();
        }
    }
}
