using MailSender.Infrastructure;
using MailSender.lib.Commands;
using MailSender.lib.Interfaces;
using MailSender.Models;
using MailSender.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _title = "Почтовый отправитель";
        private string _status = "Готов...";
        private ServersRepository _servers;
        private readonly IMailService _mailService;

        public string Title { get => _title; set => Set(ref _title, value); }

        public string Status { get => _status; set => Set(ref _status, value); }

        public ObservableCollection<Server> Servers { get; } = new();
        public MainWindowViewModel(ServersRepository servers, IMailService mailService)
        {
            _servers = servers;
            _mailService = mailService;
        }

        #region Commands
        //Загрузить сервера
        private ICommand _loadServersCommand;

        public ICommand LoadServersCommand => _loadServersCommand ??= new LambdaCommand(OnLoadServersCommandExecuted, CanLoadServersCommandExecute);

        private bool CanLoadServersCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadServersCommandExecuted(object p) => LoadServers();

        private void LoadServers()
        {
            foreach (var server in _servers.GetAll())
                Servers.Add(server);
        }

        //Отправить письмо
        private ICommand _sendEmailCommand;

        public ICommand SendEmailCommand => _sendEmailCommand ??= new LambdaCommand(OnSendEmailCommandExecuted, CanSendEmailCommandExecute);

        private bool CanSendEmailCommandExecute(object p) => true;

        private void OnSendEmailCommandExecuted(object p) => _mailService.SendEmail("Сергеев", "Артемов", "Заголовок", "Тело письма");

        //Добавить сервер
        private ICommand _addServerCommand;

        public ICommand AddServerCommand => _addServerCommand ??= new LambdaCommand(OnAddServerCommandExecuted, CanAddServerCommandExecute);

        private bool CanAddServerCommandExecute(object p) => true;

        private void OnAddServerCommandExecuted(object p) => AddServer();

        private void AddServer()
        {
            if (!ServerEditDialog.Create(out string name, out string address, out int port,
            out bool isSSL, out string login, out var password, out string description))
                return;

            Server server = new Server
            {
                Id = 1,
                Name = name,
                Address = address,
                Port = port,
                IsSSLUsed = isSSL,
                Description = description,
                Login = login,
                Password = password
            };

            _servers.Add(server);
        }
        #endregion


    }
}
