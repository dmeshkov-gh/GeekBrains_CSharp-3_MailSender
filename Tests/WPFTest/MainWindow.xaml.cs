using System;
using System.Windows;
using System.Net;
using System.Net.Mail;
using WPFTestMailSender.Services;
using System.Security;
using WPFTestMailSender;

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
            yandexSender.ShowEndWindowMessage += ShowMessage;
            yandexSender.Send();
        }

        private static void ShowMessage(string message)
        {
            SendEndWindow sendEndWindow = new SendEndWindow();
            sendEndWindow.ISendEnd.Content = message;
            sendEndWindow.ShowDialog();
        }
    }
}
