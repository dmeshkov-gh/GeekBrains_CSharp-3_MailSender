using System;

namespace MailSender.lib.Interfaces
{
    public interface IStatistics
    {
        event EventHandler SentMailCountChanged;
        event EventHandler SendersCountChanged;
        event EventHandler ReceiversCountChanged;
        int SentMailsCount { get; }

        int SendersCount { get; }
        int ReceiversCount { get; }

        void MailSended();

        void GetSender();

        void GetReceiver();

        void RemoveSender();

        void RemoveReceiver();
    }
}
