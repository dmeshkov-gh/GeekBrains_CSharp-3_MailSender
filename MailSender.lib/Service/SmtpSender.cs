using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Service
{
    public class SmtpSender
    {
        public delegate void EmailSendServiceHandler(string message);
        public event EmailSendServiceHandler ShowEndWindowMessage;

        private readonly string _address;
        private readonly int _port;
        private readonly bool _isSSLUsed;
        private readonly string _login;
        private readonly SecureString _password;

        public SmtpSender(string address, int port, bool useSSL, string login, SecureString password)
        {
            _address = address;
            _port = port;
            _isSSLUsed = useSSL;
            _login = login;
            _password = password;
        }

        public void Send(string from, string to, string title, string message)
        {
            using MailMessage mailMessage = new MailMessage(from, to)
            {
                Subject = title,
                Body = message
            };

            using SmtpClient client = new SmtpClient(_address, _port)
            {
                EnableSsl = _isSSLUsed,
                Credentials = new NetworkCredential
                {
                    UserName = _login,
                    SecurePassword = _password
                }
            };

            try
            {
                client.Send(mailMessage);
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
