using MailSender.Models;
using System.Collections.Generic;

namespace MailSender.Infrastructure
{
    internal class SendersRepository
    {
        private List<Sender> _senders;

        public SendersRepository()
        {
            _senders = new List<Sender>
            {
                new Sender
                {
                    Id = 1,
                    Name = "Иванов",
                    Address = "ivanov@server.ru",
                    Description = "Почта от Иванова"
                },

                new Sender
                {
                    Id = 2,
                    Name = "Петров",
                    Address = "petrov@server.ru",
                    Description = "Почта от Петрова"
                },

                new Sender
                {
                    Id = 3,
                    Name = "Сидоров",
                    Address = "sidorov@server.ru",
                    Description = "Почта от Сидорова"
                }
            };
        }

        public IEnumerable<Sender> GetAll() => _senders;

        public void Add(Sender sender) => _senders.Add(sender);

        public void Remove(Sender sender) => _senders.Remove(sender);
    }
}
