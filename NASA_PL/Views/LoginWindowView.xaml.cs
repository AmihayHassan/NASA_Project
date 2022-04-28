
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
        private LoginWindowViewModel ViewModel = new LoginWindowViewModel();
        MainWindowView wnd = (MainWindowView)Application.Current.MainWindow;
        public LoginWindowView()
        {

            InitializeComponent();
            DataContext = ViewModel;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        private void UserNameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            WrongPassword.Text = "";
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            WrongPassword.Text = "";
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
            wnd.Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var model = new LoginWindowModel();
            if (model.CheckUserAndPassword(UserNameTextBox.Text, PasswordBox.Password))
            {
                Close();
            }
            else
            {
                WrongPassword.Text = "username or password are incorrect";
            }
        }
    }
}


