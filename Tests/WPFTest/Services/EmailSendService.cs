using System;
using System.Windows;
using System.Security;
using System.Net;
using System.Net.Mail;

namespace WPFTestMailSender.Services
{
    class EmailSendService : EmailInfo
    {
        public delegate void EmailSendServiceHandler(string message);
        public event EmailSendServiceHandler ShowEndWindowMessage;
        public EmailSendService(string login, SecureString password, string mailTo, string subject, string body)
        {
            From = new MailAddress(login);
            To = new MailAddress(mailTo);

            EmailMessage = new MailMessage(From, To)
            {
                Subject = subject,
                Body = body
            };

            Client = new SmtpClient(Host, Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = login,
                    SecurePassword = password
                }
            };
        }

        public void Send()
        {
            try
            {
                Client.Send(EmailMessage);
                ShowEndWindowMessage?.Invoke("Почта успешно отправлена!");

            }
            catch (SmtpException)
            {
                ShowEndWindowMessage?.Invoke("Ошибка авторизации");
            }
            catch (TimeoutException)
            {
                ShowEndWindowMessage?.Invoke("Ошибка адреса сервера");
            }
        }
    }
}
