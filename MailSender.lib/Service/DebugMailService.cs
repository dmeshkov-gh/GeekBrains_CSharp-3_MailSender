using MailSender.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Service
{
    public class DebugMailService : IMailService
    {
        private readonly IStatistics _statistics;

        public IMailSender GetSender(string address, int port, bool useSSL, string login, string password, IStatistics statistics)
        {
            return new DebugMailSender(address, port, useSSL, login, password, statistics);
        }

        private class DebugMailSender : IMailSender
        {
            public event Action<string> ShowEndWindowMessage;

            private string _address;
            private int _port;
            private bool _useSSL;
            private string _login;
            private string _password;
            private IStatistics _statistics;

            public DebugMailSender(string address, int port, bool useSSL, string login, string password, IStatistics statistics)
            {
                _address = address;
                _port = port;
                _useSSL = useSSL;
                _login = login;
                _password = password;
                _statistics = statistics;
            }

            public void SendEmail(string from, string to, string title, string body)
            {
                Debug.WriteLine($"Адрес сервера - {_address}. Порт сервера - {_port}. SSL - {_useSSL}");
                Debug.WriteLine($"Отправка письмо от {from} к {to}: {title} - {body}");
                _statistics.MailSended();
            }
        }


    }
}
