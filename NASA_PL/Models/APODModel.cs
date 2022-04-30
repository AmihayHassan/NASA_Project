using NASA_BE;
using NASA_BL;
using System.Threading.Tasks;

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