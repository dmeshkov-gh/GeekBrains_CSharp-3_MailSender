using MailSender.Data;
using MailSender.lib.Interfaces;

namespace MailSender.Infrastructure
{
    internal class InMemoryStatisticsService : IStatistics
    {
        private int _sentMailCount;
        public int SentMailsCount => _sentMailCount;

        public int SendersCount => TestData.Senders.Count;

        public int ReceiversCount => TestData.Receivers.Count;

        public void MailSended()
        {
            _sentMailCount++;
        }
    }
}
