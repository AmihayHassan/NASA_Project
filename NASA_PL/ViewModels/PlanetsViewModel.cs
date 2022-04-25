using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using NASA_BE;
using NASA_BE.Annotations;
using NASA_PL.Views;
using Syncfusion.Windows.Shared;


namespace NASA_PL.ViewModels
{
    public class PlanetsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private string _planetName;

        public string PlanetName
        {
            get { return _planetName; }
            set
            {
                _planetName = value;
                OnPropertyChanged(nameof(_planetName));
            }
        }

        private readonly Models.PlanetsModel _model;
        public ICommand OpenPlanetCardCommand { get; private set; }
        public ICommand MovePlanetRightCommand { get; private set; }
        public ICommand MovePlanetLeftCommand { get; private set; }
        public ICommand UpdatePlanetNameCommand { get; private set; }

        public PlanetsViewModel()
        {
            _planetName = "Mercury";
            _model = new Models.PlanetsModel();
            OpenPlanetCardCommand = new RelayCommand<Carousel>(OpenPlanetCard, o => true);
            MovePlanetRightCommand = new RelayCommand<Carousel>(MovePlanetRight, o => true);
            MovePlanetLeftCommand = new RelayCommand<Carousel>(MovePlanetLeft, o => true);
            UpdatePlanetNameCommand = new RelayCommand<Carousel>(UpdatePlanetName, o => true);

        }
        public List<Planet> GetPlanetsList => _model.GetSolarSystem();

        private void OpenPlanetCard(Carousel planetCarousel)
        {
            var pcv = new PlanetCardView(GetPlanetsList[planetCarousel.SelectedIndex]);
            pcv.ShowDialog();
        }

        private void MovePlanetRight(Carousel PlanetsCarousel)
        {
            int current = PlanetsCarousel.SelectedIndex;
            if (current < 7)
            {
                PlanetsCarousel.SelectedIndex = current + 1;
            }
            else
            {
                PlanetsCarousel.SelectedIndex = 0;
            }
        }

        private void MovePlanetLeft(Carousel PlanetsCarousel)
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
        private void UpdatePlanetName(Carousel PlanetsCarousel)
        {
            _planetName = GetPlanetsList[PlanetsCarousel.SelectedIndex].Name;
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}