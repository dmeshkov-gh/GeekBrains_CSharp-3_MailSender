using System.Windows.Controls;
using System.Windows;
using System;
using System.Windows.Input;
using MailSender.Models;
using System.Collections.ObjectModel;

namespace MailSender.Controls
{
    /// <summary>
    /// Interaction logic for ItemsPanel.xaml
    /// </summary>
    public partial class ItemsPanel : UserControl
    {
        public ItemsPanel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(ItemsPanel),
                new PropertyMetadata("Отправитель", OnTitleChanged));

        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public string Title 
        { 
            get => (string)GetValue(TitleProperty); 
            set => SetValue(TitleProperty, value); 
        }


        public static readonly DependencyProperty ServersProperty =
            DependencyProperty.Register(
                nameof(Servers),
                typeof(ObservableCollection<>),
                typeof(ItemsPanel));

        public ObservableCollection<Server> Servers
        {
            get => (ObservableCollection<Server>)GetValue(SelectedUserProperty);
            set => SetValue(SelectedUserProperty, value);
        }


        public static readonly DependencyProperty SelectedUserProperty =
            DependencyProperty.Register(
                nameof(SelectedUser),
                typeof(User),
                typeof(ItemsPanel));

        public User SelectedUser
        {
            get => (User)GetValue(SelectedUserProperty);
            set => SetValue(SelectedUserProperty, value);
        }


        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register(
                nameof(AddCommand),
                typeof(ICommand),
                typeof(ItemsPanel));

        public ICommand AddCommand
        {
            get => (ICommand)GetValue(AddCommandProperty);
            set => SetValue(AddCommandProperty, value);
        }


        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditCommand),
                typeof(ICommand),
                typeof(ItemsPanel));

        public ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }


        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(
                nameof(DeleteCommand),
                typeof(ICommand),
                typeof(ItemsPanel));

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }   
    }
}
