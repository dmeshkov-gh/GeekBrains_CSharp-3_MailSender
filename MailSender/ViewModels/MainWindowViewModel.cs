using MailSender.Infrastructure;
using MailSender.lib.Commands;
using MailSender.lib.Interfaces;
using MailSender.Models;
using MailSender.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _title = "Почтовый отправитель";
        private string _status = "Готов...";

        private ServersRepository _serversRepositry;
        private SendersRepository _sendersRepository;
        private ReceiversRepository _receiversRepository;
        private MessagesRepository _messagesRepository;

        private Server _selectedServer;
        private Sender _selectedSender;
        private Receiver _selectedReceiver;
        private Message _selectedMessage;

        private readonly IMailService _mailService;

        public string Title { get => _title; set => Set(ref _title, value); }

        public string Status { get => _status; set => Set(ref _status, value); }

        public ObservableCollection<Server> Servers { get; } = new();
        public ObservableCollection<Sender> Senders { get; } = new();
        public ObservableCollection<Receiver> Receivers { get; } = new();
        public ObservableCollection<Message> Messages { get; } = new();

        public Server SelectedServer { get => _selectedServer; set => Set(ref _selectedServer, value); }
        public Sender SelectedSender { get => _selectedSender; set => Set(ref _selectedSender, value); }
        public Receiver SelectedReceiver { get => _selectedReceiver; set => Set(ref _selectedReceiver, value); }
        public Message SelectedMessage { get => _selectedMessage; set => Set(ref _selectedMessage, value); }

        public MainWindowViewModel(ServersRepository servers, SendersRepository senders, ReceiversRepository receivers, MessagesRepository messages, IMailService mailService)
        {
            _serversRepositry = servers;
            _sendersRepository = senders;
            _receiversRepository = receivers;
            _messagesRepository = messages;
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
            foreach (var message in _messagesRepository.GetAll())
                Messages.Add(message);
        }

        private void LoadReceivers()
        {
            foreach (var receiver in _receiversRepository.GetAll())
                Receivers.Add(receiver);
        }

        private void LoadSenders()
        {
            foreach (var sender in _sendersRepository.GetAll())
                Senders.Add(sender);
        }

        private void LoadServers()
        {
            foreach (var server in _serversRepositry.GetAll())
                Servers.Add(server);
        }


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

        //Удалить сервер
        private ICommand _deleteServerCommand;

        public ICommand DeleteServerCommand => _deleteServerCommand ??= new LambdaCommand(OnDeleteServerCommandExecuted, CanDeleteServerCommandExecute);

        private bool CanDeleteServerCommandExecute(object p) => p is Server;

        private void OnDeleteServerCommandExecuted(object p) => DeleteServer(p);

        private void DeleteServer(object p)
        {
            if (!(p is Server server)) return;

            Servers.Remove(server);
        }

        //Отправить сообщение

        private ICommand _sendMessageCommand;

        public ICommand SendMessageCommand => _sendMessageCommand ??= new LambdaCommand(OnSendMessageCommandExecuted, CanSendMessageCommandExecute);

        private bool CanSendMessageCommandExecute(object p)
        {
            return SelectedServer != null
                 && SelectedSender != null
                 && SelectedReceiver != null
                 && SelectedMessage != null;
        }

        private void OnSendMessageCommandExecuted(object p) => SendMessage();

        private void SendMessage()
        {
            var server = SelectedServer;
            var client = _mailService.GetSender(server.Address, server.Port, server.IsSSLUsed, server.Login, server.Password);
            var sender = SelectedSender;
            var receiver = SelectedReceiver;
            var message = SelectedMessage;

            client.ShowEndWindowMessage += ShowStatusDeliveryMessage;
            client.SendEmail(sender.Address, receiver.Address, message.Title, message.Body);
        }

        private void ShowStatusDeliveryMessage(string message)
        {
            MessageBox.Show(message);
        }
        #endregion


    }
}
