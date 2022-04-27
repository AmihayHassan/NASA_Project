using System;
using System.Windows;
using System.Windows.Controls;
using NASA_PL.ViewModels;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for APODView.xaml
    /// </summary>

    public partial class APODView : Page
    {
        APODViewModel ViewModel = new APODViewModel();

        public APODView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}