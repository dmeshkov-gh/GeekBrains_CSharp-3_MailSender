using MailSender.lib.Interfaces;
using MailSender.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ViewModels
{
    class StatisticsViewModel : ViewModel
    {
        private readonly IStatistics _statistics;

        public int SentMailsCount => _statistics.SentMailsCount;

        public int SendersCount => _statistics.SendersCount;

        public int ReceiversCount => _statistics.ReceiversCount;

        public StatisticsViewModel(IStatistics statistics)
        {
            _statistics = statistics;

            statistics.SentMailCountChanged += (_, _) => OnPropertyChanged(nameof(SentMailsCount));
        }
    }
}
