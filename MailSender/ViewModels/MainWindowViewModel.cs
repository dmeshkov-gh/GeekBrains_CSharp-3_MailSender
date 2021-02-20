using MailSender.Infrastructure;
using MailSender.lib.Commands;
using MailSender.Models;
using MailSender.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        #region Commands

        private ICommand _loadServersCommand;

        public ICommand LoadServersCommand => _loadServersCommand ??= new LambdaCommand(OnLoadServersCommandExecuted, CanLoadServersCommandExecute);

        private bool CanLoadServersCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadServersCommandExecuted(object p) => LoadServers();

        #endregion

        private void LoadServers()
        {
            foreach (var server in _servers.GetAll())
                Servers.Add(server);
        }
    }
}
