using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public interface IMailSender
    {
        void SendEmail(string from, string to, string title, string body);
    }
}
