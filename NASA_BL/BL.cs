using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BE;
using NASA_DAL;

namespace NASA_BL
{
    public class BL
    {
        private readonly Dal _dal = new Dal();

        public async Task<APOD> GetApodFromNasaApi()
        {
            return null;
        }

        public async Task<ImaggaTag> GetImageTagsFromImagga(string imageUrl)
        {
            return null;
        }

        public async Task<Dictionary<string, string>> GetSearchResult(string query)
        {
            return null;
        }

        public async Task<dynamic> GetNearEarthObject(string startDate, string endDate)
        {
            return null;
        }

    }
}
