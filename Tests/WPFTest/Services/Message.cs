﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WPFTestMailSender.Services
{
    static class Message
    {
        public static MailAddress From { get; set; } = new MailAddress("dm_91@bk.ru", "Dmitry");
        public static MailAddress To { get; set; } = new MailAddress("dmitry.meshkov@icloud.com", "Dmitry");

        public static MailMessage EmailMessage { get; set; } = new MailMessage(From, To);
    }
}
