using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MailAddress from = new MailAddress("dm_91@bk.ru", "Dmitry");
            MailAddress to = new MailAddress("dmitry.meshkov@icloud.com", "Dmitry");

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Test email";
            message.Body = "Some text";

            SmtpClient client = new SmtpClient("smtp.mail.ru", 465);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = "dm_91",
                Password = "Password"
            };
            client.Send(message);
        }
    }
}
