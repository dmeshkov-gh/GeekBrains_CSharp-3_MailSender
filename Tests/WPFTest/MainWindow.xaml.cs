using System;
using System.Windows;
using System.Net;
using System.Net.Mail;

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
            MailAddress from = new MailAddress("test-email-geekbrains@yandex.ru", "Dmitry");
            MailAddress to = new MailAddress("dm_91@bk.ru", "Dmitry");

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Тестовое письмо";
            message.Body = "Моё письмо";

            SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = Login.Text,
                SecurePassword = Password.SecurePassword
            };

            try
            {
                client.Send(message);

                MessageBox.Show("Почта успешно отправлена!", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (SmtpException)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка отправки почты", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Ошибка адреса сервера", "Ошибка отправки почты", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
