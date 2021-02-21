using MailSender.Models;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.Infrastructure
{
    class MessagesRepository
    {
        private List<Message> _messages;

        public MessagesRepository()
        {
            _messages = Enumerable
            .Range(1, 10)
            .Select(i => new Message
            {
                Id = i,
                Title = $"Заголовок #{i}",
                Body = $"Сообщение #{i}"
            })
            .ToList();
        }

        public IEnumerable<Message> GetAll() => _messages;

        public void Add(Message message) => _messages.Add(message);

        public void Remove(Message message) => _messages.Remove(message);
    }
}
