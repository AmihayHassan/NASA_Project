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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var start = DateTime.Parse(startDate.Text).ToString("yyyy-MM-dd");
            var end = DateTime.Parse(endDate.Text).ToString("yyyy-MM-dd");
            double diameter = 0;
            if (txtDiameter.Text != null)
            {
                double.TryParse(txtDiameter.Text, out diameter);
            }

            bool hazardous = is_potentially_hazardous_asteroid.IsChecked.Value;

            Task.Run(() => viewModel.SearcNEO(start, end, diameter, hazardous));
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

        }
    }
}
