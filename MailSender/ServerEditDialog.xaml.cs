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
using System.Security;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
    public partial class ServerEditDialog
    {
        private ServerEditDialog() => InitializeComponent();

        private void OnPort_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (Port.Text is null || Port.Text == "") return;
            e.Handled = !int.TryParse(Port.Text, out _);
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e) => Close();

        private void Ok_Btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = !((Button)e.OriginalSource).IsCancel;
            Close();
        }

        public static bool ShowDialog(string title, ref string name, ref string address, ref int port,
            ref bool isSSL, ref string login, ref string password, ref string description)
        {
            ServerEditDialog window = new ServerEditDialog
            {
                Title = title,
                ServerName = { Text = name },
                ServerAddress = { Text = address },
                Port = { Text = port.ToString() },
                IsSSL = { IsChecked = isSSL},
                Login = {Text = login},
                Password = {Password = password},
                Description = {Text = description},

                Owner = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window.IsActive)
            };

            if (window.ShowDialog() != true) return false;

            name = window.ServerName.Text;
            address = window.ServerAddress.Text;
            port = int.Parse(window.Port.Text);
            login = window.Login.Text;
            password = window.Password.Password;

            return true;
        }

        public static bool Create(out string name, out string address, out int port,
            out bool isSSL, out string login, out string password, out string description)
        {
            name = null;
            address = null;
            port = 25;
            isSSL = false;
            description = null;
            login = null;
            password = null;

            return ShowDialog("Создать сервер", ref name, ref address, ref port,
                ref isSSL, ref login, ref password, ref description);
        }
    }
}
