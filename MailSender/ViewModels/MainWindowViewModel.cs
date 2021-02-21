using MailSender.Infrastructure;
using MailSender.lib.Commands;
using MailSender.lib.Interfaces;
using MailSender.Models;
using MailSender.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _title = "Почтовый отправитель";
        private string _status = "Готов...";
        private ServersRepository _servers;
        private SendersRepository _senders;
        private ReceiversRepository _receivers;
        private MessagesRepository _messages;
        private readonly IMailService _mailService;

        public string Title { get => _title; set => Set(ref _title, value); }

        public string Status { get => _status; set => Set(ref _status, value); }

        public ObservableCollection<Server> Servers { get; } = new();
        public ObservableCollection<Sender> Senders { get; } = new();
        public ObservableCollection<Receiver> Receivers { get; } = new();
        public ObservableCollection<Message> Messages { get; } = new();

        public MainWindowViewModel(ServersRepository servers, SendersRepository senders, ReceiversRepository receivers, MessagesRepository messages, IMailService mailService)
        {
            _servers = servers;
            _senders = senders;
            _receivers = receivers;
            _messages = messages;
            _mailService = mailService;
        }

        #region Commands
        //Загрузить сервера, отправителей, получателей и письма
        private ICommand _loadDataCommand;

        public ICommand LoadDataCommand => _loadDataCommand ??= new LambdaCommand(OnLoadDataCommandExecuted);

        private void OnLoadDataCommandExecuted(object p)
        {
            LoadServers();
            LoadSenders();
            LoadReceivers();
            LoadMessages();
        }

        private void LoadMessages()
        {
            foreach (var message in _messages.GetAll())
                Messages.Add(message);
        }

        private void LoadReceivers()
        {
            foreach (var receiver in _receivers.GetAll())
                Receivers.Add(receiver);
        }

        private void LoadSenders()
        {
            foreach (var sender in _senders.GetAll())
                Senders.Add(sender);
        }

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
                Id = Servers.DefaultIfEmpty().Max(s => s.Id) + 1,
                Name = name,
                Address = address,
                Port = port,
                IsSSLUsed = isSSL,
                Description = description,
                Login = login,
                Password = password
            };

            Servers.Add(server);
        }

        //Редактировать сервер
        private ICommand _editServerCommand;

        public ICommand EditServerCommand => _editServerCommand ??= new LambdaCommand(OnEditServerCommandExecuted, CanEditServerCommandExecute);

        private bool CanEditServerCommandExecute(object p) => p is Server;

        private void OnEditServerCommandExecuted(object p) => EditServer(p);

        private void EditServer(object p)
        {
            if (!(p is Server server)) return;

            string name = server.Name;
            string address = server.Address;
            int port = server.Port;
            bool isSSL = server.IsSSLUsed;
            string login = server.Login;
            var password = server.Password;
            string description = server.Description;


            if (!ServerEditDialog.ShowDialog("Редактирование сервера", ref name, ref address, ref port,
            ref isSSL, ref login, ref password, ref description))
                return;

            server.Name = name;
            server.Address = address;
            server.Port = port;
            server.IsSSLUsed = isSSL;
            server.Login = login;
            server.Password = password;
            server.Description = description;
        }
        #endregion


    }
}
