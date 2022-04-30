using NASA_BE;
using NASA_BL;
using System.Collections.Generic;

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
