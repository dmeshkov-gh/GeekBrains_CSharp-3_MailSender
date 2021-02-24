using MailSender.Models;
using MailSender.Service;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.Infrastructure
{
    internal class ServersRepository
    {
        private List<Server> _servers;

        public ServersRepository()
        {
            _servers = Enumerable.Range(1, 3).Select(s => new Server
            {
                Name = $"Сервер #{s}",
                Address = $"smpt.server-{s}.com",
                Login = $"Login - {s}",
                Password = TextEncoder.Encode("password", 4),
                IsSSLUsed = true
            })
            .ToList();

            _servers.Add(new Server
            {
                Name = $"Yandex",
                Address = $"smtp.yandex.com",
                Login = $"test-email-geekbrains@yandex.ru",
                Password = "15022021",
                IsSSLUsed = true
            });
        }

        public IEnumerable<Server> GetAll() => _servers;

        public void Add(Server server) => _servers.Add(server);

        public void Remove(Server server) => _servers.Remove(server);
    }
}
