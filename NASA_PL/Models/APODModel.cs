using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BE;
using NASA_BL;

namespace NASA_PL.Models
{
    public class APODModel
    {
        BL bl;
        public APODModel()
        {
            bl = new BL();
        }

        public async Task<APOD> GetImageOfTheDay()
        {
            return await bl.GetAPOD();
        }
    }

}