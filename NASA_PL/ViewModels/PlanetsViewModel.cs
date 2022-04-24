using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using NASA_BE;
using NASA_PL.Views;
using Syncfusion.Windows.Shared;


namespace NASA_PL.ViewModels
{
    public class PlanetsViewModel
    {
        private readonly Models.PlanetsModel _model;
        public ICommand OpenPlanetCardCommand { get; private set; }
        public PlanetsViewModel()
        {
            _model = new Models.PlanetsModel();
            OpenPlanetCardCommand = new RelayCommand<Carousel>(OpenPlanetCard, O => true);

        }
        public List<Planet> GetPlanetsList => _model.GetSolarSystem();

        private void OpenPlanetCard(Carousel planetCarousel)
        {
            var pcv = new PlanetCardView(GetPlanetsList[planetCarousel.SelectedIndex]);
            pcv.ShowDialog();

        }

    }
}