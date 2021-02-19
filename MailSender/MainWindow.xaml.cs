using MailSender.Data;
using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Scheduler_Btn_Click(object sender, RoutedEventArgs e) => Schedule_TabItem.Focus();

        private void Exit_Btn_Click(object sender, RoutedEventArgs e) => Close();

        private void AddServer_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!ServerEditDialog.Create(out string name, out string address, out int port,
            out bool isSSL, out string login, out var password, out string description)) 
                return;

            Server server = new Server
            {
                Id = TestData.Servers.DefaultIfEmpty().Max(s => s.Id) + 1,
                Name = name,
                Address = address,
                Port = port,
                IsSSLUsed = isSSL,
                Description = description,
                Login = login,
                Password = password
            };

            TestData.Servers.Add(server);

            ServersList.ItemsSource = null;
            ServersList.ItemsSource = TestData.Servers;
            ServersList.SelectedItem = server;
        }
    }
}
