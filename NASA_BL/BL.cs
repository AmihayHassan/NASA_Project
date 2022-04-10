using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NASA_BE;
using NASA_DAL;

namespace NASA_BL
{
    public class BL
    {
        private Dal dal = new Dal();
        
        public async Task<APOD> GetAPOD()
        {
            return await dal.GetApodFromNasaApi();
        }

        public async Task<List<NearEarthObject>> GetNearEarthObject(string start, string end)
        {
            NearEarthObjects nearEarthObject = await dal.GetNearEarthObject(start, end);
            var result = from s in nearEarthObject.near_earth_objects.Values
                         from q in s
                         select new NearEarthObject()
                         {
                             Id = q.id.ToString(),
                             Name = q.name,
                             Hazardous = q.is_potentially_hazardous_asteroid,
                             Diameter = q.estimated_diameter.meters.estimated_diameter_min,
                             Velocety = q.close_approach_data[0].relative_velocity.kilometers_per_hour,
                             MissDistance = q.close_approach_data[0].miss_distance.kilometers,
                             CloseApproach = q.close_approach_data[0].close_approach_date
                         };
            return result.ToList();
        }

        //TODO change SubDic to imagesAndDescription
        public async Task<Dictionary<string, string>> GetSearchResult(string querySearch, bool debug = false)
        {
            var tasks = new List<Task<Dictionary<string, string>>>();
            var imagesAndDescription = await dal.GetSearchResult(querySearch);
            var SubDic= (from Item in imagesAndDescription select Item)
                                                        .Take(5)
                                                        .ToDictionary(Item=>Item.Key); 
            var res = new Dictionary<string, string>();
            Parallel.ForEach(SubDic.Keys, async image =>
            {
                ImaggaTag tag = await dal.GetImageTagsFromImagga(image);
                if (tag.result == null) return;
                if (tag.result.tags.Any((x) => x.confidence > 85 && x.tag.en == "planet"))
                {
                    res.Add(image, imagesAndDescription[image]);
                }
            });
            return res;
        }

        public List<Planet> GetSolarSystem()
        {
            return dal.GetSolarSystem();
        }
    }

}
