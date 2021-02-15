using System.Net.Mail;

namespace WPFTestMailSender.Services
{
    abstract class EmailInfo
    {
        public MailAddress From { get; protected set; } 
        public MailAddress To { get; protected set; } 

        public MailMessage EmailMessage { get; protected set; }

        public SmtpClient Client { get; protected set; }
        public string Host { get; protected set; } = "smtp.yandex.com";
        public int Port { get; protected set; } = 587;
    }
}
