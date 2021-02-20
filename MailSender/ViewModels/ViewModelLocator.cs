using Microsoft.Extensions.DependencyInjection;

namespace MailSender.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
