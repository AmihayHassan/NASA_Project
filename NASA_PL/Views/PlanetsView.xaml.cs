using NASA_BE;
using System.Collections.Generic;
using System.Windows;
using Page = System.Windows.Controls.Page;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for PlanetsView.xaml
    /// </summary>
    public partial class PlanetsView : Page
    {

        ViewModels.PlanetsViewModel ViewModel;
        private List<Planet> PlanetsList;

        public PlanetsView()
        {
            // Syncfusion code activation
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjA3MjMyQDMyMzAyZTMxMmUzMGtjQnlrdnhGdXZ0ZVp4Q00xTnBlV0tWUGlFVXluZTNmdzUrVkp4Mmh3NlU9");

            InitializeComponent();
            ViewModel = new ViewModels.PlanetsViewModel();
            DataContext = ViewModel;
            PlanetsList = ViewModel.GetPlanetsList;
            PlanetsCarousel.SelectedIndex = 0;
        }


        private void PlanetsCarousel_OnSelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlanetName.Content = PlanetsList[PlanetsCarousel.SelectedIndex].Name;
        }

    }
}
