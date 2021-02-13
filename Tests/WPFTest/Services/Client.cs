using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestMailSender.Services
{
    static class Client
    {
        public static string Host { get; set; } = "smtp.mail.ru";
        public static int Port { get; set; } = 25;
    }
}
