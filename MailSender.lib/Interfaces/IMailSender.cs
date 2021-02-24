using System;

namespace MailSender.lib.Interfaces
{
    public interface IMailSender
    {
        public event Action<string> ShowEndWindowMessage;
        void SendEmail(string from, string to, string title, string body);
    }
}
