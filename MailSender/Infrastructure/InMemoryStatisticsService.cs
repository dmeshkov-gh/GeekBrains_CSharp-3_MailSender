using MailSender.Data;
using MailSender.lib.Interfaces;
using System;

namespace MailSender.Infrastructure
{
    internal class InMemoryStatisticsService : IStatistics
    {
        private int _sentMailCount;
        public int SentMailsCount => _sentMailCount;

        public int SendersCount => 0; //исправить

        public int ReceiversCount => 0; //исправить
            //TestData.Receivers.Count;

        public event EventHandler SentMailCountChanged;

        public void MailSended()
        {
            _sentMailCount++;
            SentMailCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
