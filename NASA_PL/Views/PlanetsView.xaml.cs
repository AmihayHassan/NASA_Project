using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using NASA_BE;
using Syncfusion.Windows.Shared;
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
            currentPlanetTextBlock.Text = PlanetsList[PlanetsCarousel.SelectedIndex].Name;
        }

        private void CurrentPlanetTextBlock_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var pcv = new PlanetCardView(PlanetsList[PlanetsCarousel.SelectedIndex]);
            pcv.ShowDialog();
        }

        private void RightButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int current = PlanetsCarousel.SelectedIndex;
            if (current<7)
            {
                PlanetsCarousel.SelectedIndex = current + 1;
            }
            else
            {
                PlanetsCarousel.SelectedIndex = 0;
            }
        }

        private void LeftButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int current = PlanetsCarousel.SelectedIndex;
            if (current > 0)
            {
                PlanetsCarousel.SelectedIndex = current - 1;
            }
            else
            {
                PlanetsCarousel.SelectedIndex = 7;
            }
        }

    }
}
