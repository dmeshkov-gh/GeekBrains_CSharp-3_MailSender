using System.Windows.Controls;
using System.Windows;
using System;

namespace MailSender.Controls
{
    /// <summary>
    /// Interaction logic for ItemsPanel.xaml
    /// </summary>
    public partial class ItemsPanel : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(ItemsPanel),
                new PropertyMetadata("Отправитель", OnTitleChanged));

        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public string Title 
        { 
            get => (string)GetValue(TitleProperty); 
            set => SetValue(TitleProperty, value); 
        }
        public ItemsPanel()
        {
            InitializeComponent();
        }
    }
}
