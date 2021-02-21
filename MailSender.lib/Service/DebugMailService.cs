using MailSender.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Service
{
    public class DebugMailService : IMailSender
    {
        private readonly IStatistics _statistics;

        public DebugMailService(IStatistics statistics) => _statistics = statistics;

        public void SendEmail(string from, string to, string title, string body)
        {
            Debug.WriteLine($"Отправка письмо от {from} к {to}: {title} - {body}");
            _statistics.MailSended();
        }
    }
}
