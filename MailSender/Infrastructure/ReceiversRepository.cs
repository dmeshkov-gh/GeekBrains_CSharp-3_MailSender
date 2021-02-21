using MailSender.Models;
using System.Collections.Generic;

namespace MailSender.Infrastructure
{
    class ReceiversRepository
    {
        private List<Receiver> _receivers;

        public ReceiversRepository()
        {
            _receivers = new List<Receiver>
            {
                new Receiver
                {
                    Id = 1,
                    Name = "Иванов",
                    Address = "ivanov@server.ru",
                    Description = "Почта для Иванова"
                },

                new Receiver
                {
                    Id = 2,
                    Name = "Петров",
                    Address = "petrov@server.ru",
                    Description = "Почта для Петрова"
                },

                new Receiver
                {
                    Id = 3,
                    Name = "Сидоров",
                    Address = "sidorov@server.ru",
                    Description = "Почта для Сидорова"
                }
            };
        }

        public IEnumerable<Receiver> GetAll() => _receivers;

        public void Add(Receiver receiver) => _receivers.Add(receiver);

        public void Remove(Receiver receiver) => _receivers.Remove(receiver);
    }
}
