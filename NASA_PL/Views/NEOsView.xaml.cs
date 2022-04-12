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
using LiveCharts.Configurations;

using NASA_PL.ViewModels;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for NEOsView.xaml
    /// </summary>
    public partial class NEOsView : Page
    {

        NEOsViewModel viewModel;

        public NEOsView()
        {
            InitializeComponent();
            viewModel = new NEOsViewModel();
            DataContext = viewModel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var start = DateTime.Parse(startDate.Text).ToString("yyyy-MM-dd");
            var end = DateTime.Parse(endDate.Text).ToString("yyyy-MM-dd");
            // default value
            double diameter = 0;
            if (txtDiameter.Text != string.Empty)
            {
                double.TryParse(txtDiameter.Text, out diameter);
            }

            bool hazardous = is_potentially_hazardous_asteroid.IsChecked.Value;

            await Task.Run(() => viewModel.SearcNEO(start, end, diameter, hazardous));
        }


        private void Date_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startDate.SelectedDate >= endDate.SelectedDate)
            {
                FilterButton.IsEnabled = false;
            }
            else
            {
                FilterButton.IsEnabled = true;
            }

            if (startDate.SelectedDate >= DateTime.Today.Date)
            {
                FilterButton.IsEnabled = false;
                MessageBox.Show("start date must be in the past", "Error");
            }

            if (endDate.SelectedDate >= DateTime.Today.Date)
            {
                FilterButton.IsEnabled = false;
                MessageBox.Show("end date must be in the past", "Error");
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
    }
}
