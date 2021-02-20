namespace MailSender.lib.Interfaces
{
    public interface IStatistics
    {
        int SentMailsCount { get; }

        int SendersCount { get; }
        int ReceiversCount { get; }

        void MailSended();
    }
}
