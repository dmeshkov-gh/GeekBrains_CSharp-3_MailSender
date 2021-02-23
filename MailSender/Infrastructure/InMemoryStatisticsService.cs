using MailSender.Data;
using MailSender.lib.Interfaces;
using System;

namespace MailSender.Infrastructure
{
    internal class InMemoryStatisticsService : IStatistics
    {
        private int _sentMailCount;
        private int _sendersCount;
        private int _receiversCount;
        public int SentMailsCount => _sentMailCount;

        public int SendersCount => _sendersCount; 

        public int ReceiversCount => _receiversCount; 

        public event EventHandler SentMailCountChanged;
        public event EventHandler SendersCountChanged;
        public event EventHandler ReceiversCountChanged;

        public void GetReceiver()
        {
            _receiversCount++;
            ReceiversCountChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveReceiver()
        {
            _receiversCount--;
            ReceiversCountChanged?.Invoke(this, EventArgs.Empty);
        }

        public void GetSender()
        {
            _sendersCount++;
            SendersCountChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveSender()
        {
            _sendersCount--;
            SendersCountChanged?.Invoke(this, EventArgs.Empty);
        }

        public void MailSended()
        {
            _sentMailCount++;
            SentMailCountChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
