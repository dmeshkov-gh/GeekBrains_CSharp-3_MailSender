using MailSender.Infrastructure;
using MailSender.Models;
using MailSender.ViewModels.Base;
using System.Collections.ObjectModel;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _title = "Почтовый отправитель";
        private string _status = "Готов...";
        private ServersRepository _servers;

        public string Title { get => _title; set => Set(ref _title, value); }

        public string Status { get => _status; set => Set(ref _status, value); }

        public ObservableCollection<Server> Servers { get; } = new();
        public MainWindowViewModel(ServersRepository servers) => _servers = servers;

        private void LoadServers()
        {
            foreach (var server in _servers.GetAll())
                Servers.Add(server);
        }
    }
}
