using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BE;


namespace NASA_PL.ViewModels
{
    public class PlanetsViewModel
    {
        private readonly Models.PlanetsModel _model;
        public PlanetsViewModel()
        {
            _model = new Models.PlanetsModel();
        }
        public List<Planet> GetPlanetsList => _model.GetSolarSystem();
    }
}