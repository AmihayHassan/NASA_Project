using NASA_PL.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for LoginWindowView.xaml
    /// </summary>

    public partial class LoginWindowView : Window
    {
        private readonly LoginWindowViewModel _viewModel = new();

        public LoginWindowView()
        {
            InitializeComponent();
            DataContext = _viewModel;
            UserNameTextBox.Focus();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                _viewModel.Password = ((PasswordBox)sender).Password;
            }
        }

        private void PasswordBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            // call the login command from the view model
            if (e.Key == Key.Enter)
            {
                _viewModel.LoginCommand.Execute(this);
            }
        }
    }
}


