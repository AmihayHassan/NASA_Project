using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Syncfusion.Windows.Shared;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for PlanetsView.xaml
    /// </summary>
    public partial class PlanetsView : Page
    {

        ViewModels.PlanetsViewModel viewModel;

        public PlanetsView()
        {
            InitializeComponent();
            viewModel = new ViewModels.PlanetsViewModel();
            DataContext = viewModel;


        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}
