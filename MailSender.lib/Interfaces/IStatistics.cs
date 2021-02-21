using System;

namespace MailSender.lib.Interfaces
{
    public interface IStatistics
    {
        event EventHandler SentMailCountChanged;
        int SentMailsCount { get; }

        int SendersCount { get; }
        int ReceiversCount { get; }

        void MailSended();
    }
}
