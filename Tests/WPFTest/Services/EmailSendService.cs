using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WPFTestMailSender.Services
{
    class EmailSendService
    {
        public EmailSendService(MailAddress from, MailAddress to, MailMessage mailMessage,
            string subject, string body)
        {
            from = Message.From;
            to = Message.To;
            mailMessage = Message.EmailMessage;
            subject = Message.EmailMessage.Subject;
            body = Message.EmailMessage.Body;
        }
    }
}
