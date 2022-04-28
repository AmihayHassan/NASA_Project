
using System;
using System.Collections.Generic;
using System.Dynamic;
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
using System.Windows.Shapes;
using NASA_PL.Models;
using NASA_PL.ViewModels;

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
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                _viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}


