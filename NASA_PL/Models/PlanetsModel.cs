using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BE;
using NASA_BL;

namespace NASA_PL.Models
{
    public class PlanetsModel
    {
        BL bl;
        public PlanetsModel()
        {
            bl = new BL();
        }

        public List<Planet> GetSolarSystem()
        {
            return bl.GetSolarSystem();
        }
    }
}
