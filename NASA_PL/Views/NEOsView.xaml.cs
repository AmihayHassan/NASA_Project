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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts.Configurations;
using System.Text.RegularExpressions;

using NASA_PL.ViewModels;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for NEOsView.xaml
    /// </summary>

    public partial class NEOsView : Page
    {
        private readonly NEOsViewModel _viewModel;

        public NEOsView()
        {
            InitializeComponent();
            _viewModel = new NEOsViewModel();
            DataContext = _viewModel;
        }


        private void Date_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startDate.SelectedDate > endDate.SelectedDate)
            {
                FilterButton.IsEnabled = (startDate.SelectedDate > endDate.SelectedDate);
            }
            else
            {
                FilterButton.IsEnabled = true;
            }

            if (startDate.SelectedDate >= DateTime.Today.Date)
            {
                FilterButton.IsEnabled = false;
                MessageBox.Show("start date must be in the past", "Error");
                startDate.SelectedDate = DateTime.Today.Date.AddDays(-1);
            }

            if (endDate.SelectedDate >= DateTime.Today.Date)
            {
                FilterButton.IsEnabled = false;
                MessageBox.Show("end date must be in the past", "Error");
                endDate.SelectedDate = DateTime.Today.Date.AddDays(-1);
            }

            if (endDate.SelectedDate - startDate.SelectedDate > new TimeSpan(7, 0, 0, 0))
            {
                FilterButton.IsEnabled = false;
                MessageBox.Show("The Feed date limit is only 7 Days", "Error");
            }

            if (startDate.SelectedDate == null || endDate.SelectedDate == null)
            {
                FilterButton.IsEnabled = false;
            }
        }

        private void TxtDiameter_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
