using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BE;
using NASA_BL;


namespace NASA_PL.Models
{
    class NEOsModel
    {
        BL bl;
        public List<NearEarthObject> neoList;

        public NEOsModel()
        {
            bl = new BL();
        }

        public async Task<List<NearEarthObject>> GetNearEarthObject(string start, string end, double diameter)
        {
            neoList = (from s in await bl.GetNearEarthObject(start, end)
                where s.Diameter > diameter
                select s).ToList();
            return neoList;
        }
    }
}
