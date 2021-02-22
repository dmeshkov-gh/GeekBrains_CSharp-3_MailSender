using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MailSender
{
    public partial class EditUserWindow : Window
    {
        private EditUserWindow()
        {
            InitializeComponent();
        }

        public static bool Create(int nextId, out int id, out string name, out string address, out string description)
        {
            id = nextId;
            name = null;
            address = null;
            description = "-";

            return ShowDialog("Добавить пользователя", ref id, ref name, ref address, ref description);
        }

        private static bool ShowDialog(string title, ref int id, ref string name, ref string address, ref string description)
        {
            EditUserWindow window = new EditUserWindow
            {
                Title = title,
                Id = { Text = id.ToString() },
                Name = { Text = name },
                Address = { Text = address },
                Description = { Text = description },

                Owner = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window.IsActive)
            };

            if (window.ShowDialog() != true) return false;

            id = int.Parse(window.Id.Text);
            name = window.Name.Text;
            address = window.Address.Text;
            description = window.Description.Text;

            return true;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e) => Close();

        private void Ok_Btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = !((Button)e.OriginalSource).IsCancel;
            Close();
        }
    }
}
