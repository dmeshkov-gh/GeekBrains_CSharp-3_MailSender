using System;
using System.Windows;
using System.Security;
using System.Net;
using System.Net.Mail;

namespace WPFTestMailSender.Services
{
    class EmailSendService : EmailInfo
    {
        public EmailSendService(string login, SecureString password, string mailTo, string subject, string body)
        {
            From = new MailAddress(login);
            To = new MailAddress(mailTo);

            EmailMessage = new MailMessage(From, To)
            {
                Subject = subject,
                Body = body
            };

            Client = new SmtpClient(Host, Port);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential
            {
                UserName = login,
                SecurePassword = password
            };
        }

        public void Send()
        {
            try
            {
                Client.Send(EmailMessage);
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
