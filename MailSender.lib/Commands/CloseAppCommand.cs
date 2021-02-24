using MailSender.lib.Commands.Base;
using System.Windows;

namespace MailSender.lib.Commands
{
    public class CloseAppCommand : Command
    {
        public override void Execute(object parameter) { Application.Current.Shutdown(); }
    }
}
