using System.Windows.Controls;

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
    }
}
