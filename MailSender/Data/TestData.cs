using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Data
{
    static class TestData
    {
        public static IList<Server> Servers { get; } = new List<Server>
        {
            new Server
            {
                 Id = 1,
                 Name = "Яндекс",
                 Address = "smpt.yandex.com",
                 Port = 587,
                 IsSSLUsed = true,
                 Login = "user@yandex.ru",
                 Password = "PassWord",
            },

            new Server
            {
                 Id = 2,
                 Name = "Gmail",
                 Address = "smpt.gmail.com",
                 Port = 465,
                 IsSSLUsed = true,
                 Login = "user@gmail.com",
                 Password = "PassWord",
            },
        };

        public static IList<Sender> Senders { get; } = new List<Sender>
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

        public static IList<Receiver> Receivers { get; } = new List<Receiver> 
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

        public static IList<Message> Messages { get; } = Enumerable
            .Range(1, 10)
            .Select(i => new Message
            {
                Id = i,
                Title = $"Заголовок #{i}",
                Body = $"Сообщение #{i}"
            })
            .ToList();
    }
}
