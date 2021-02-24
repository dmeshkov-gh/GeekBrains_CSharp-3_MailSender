using MailSender.lib.Interfaces;
using System;
using System.Net;
using System.Net.Mail;

namespace MailSender.Service
{
    public class MailSendService : IMailService
    {
        public IMailSender GetSender(string address, int port, bool useSSL, string login, string password, IStatistics statistics) 
            => new MailSender(address, port, useSSL, login, password, statistics);

        private class MailSender : IMailSender
        {
            public event Action<string> ShowEndWindowMessage;

            private string _address;
            private int _port;
            private bool _isSSL;
            private string _login;
            private string _password;
            private readonly IStatistics _statistics;

            public MailSender(string address, int port, bool useSSL, string login, string password, IStatistics statistics)
            {
                _address = address;
                _port = port;
                _isSSL = useSSL;
                _login = login;
                _password = password;
                _statistics = statistics;
            }

            public void SendEmail(string from, string to, string title, string message)
            {
                using MailMessage mailMessage = new MailMessage(from, to)
                {
                    Subject = title,
                    Body = message
                };

                using SmtpClient client = new SmtpClient(_address, _port)
                {
                    EnableSsl = _isSSL,
                    Credentials = new NetworkCredential
                    {
                        UserName = _login,
                        Password = _password
                    }
                };

                try
                {
                    client.Send(mailMessage);
                    _statistics.MailSended();
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
}
