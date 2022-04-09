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
        private Models.PlanetsModel model;
        public PlanetsViewModel()
        {
            model = new Models.PlanetsModel();
        }
        public List<Planet> GetPlanetsList
        {
            get
            {
                return model.GetSolarSystem();
            }

        }





    }
}