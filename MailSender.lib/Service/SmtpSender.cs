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

        public string Address { get; set; }
        public int Port { get; set; }
        public bool IsSSLUsed { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public SmtpSender(string address, int port, bool useSSL, string login, string password)
        {
            Address = address;
            Port = port;
            IsSSLUsed = useSSL;
            Login = login;
            Password = password;
        }

        public void Send(string from, string to, string title, string message)
        {
            using MailMessage mailMessage = new MailMessage(from, to)
            {
                Subject = title,
                Body = message
            };

            using SmtpClient client = new SmtpClient(Address, Port)
            {
                EnableSsl = IsSSLUsed,
                Credentials = new NetworkCredential
                {
                    UserName = Login,
                    Password = Password
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
