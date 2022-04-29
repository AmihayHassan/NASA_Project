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
        public async Task<Dictionary<string, string>> GetSearchResult(string querySearch, int confidence, bool debug = false)
        {
            return await dal.GetSearchResult(querySearch);
            //var imagesAndDescription = await dal.GetSearchResult(querySearch);

            //var res = new Dictionary<string, string>();
            //Parallel.ForEach(imagesAndDescription.Keys, async image =>
            //{
            //    ImaggaTag tag = await dal.GetImageTagsFromImagga(image);
            //    if (tag.result == null) return;
            //    if (tag.result.tags.Any((x) => x.confidence >= confidence && x.tag.en == "planet"))
            //    {
            //        res.Add(image, imagesAndDescription[image]);
            //    }
            //});
            //return res;
        }

        public List<Planet> GetSolarSystem()
        {
            return dal.GetSolarSystem();
        }
        public bool CheckUserAndPassword(string user, string password)
        {
            return dal.CheckUserAndPassword(user, password);
        }

        // create function that send to dal imageURL and save it to firebase
        public async Task SaveImageToFirebase(string imageURL, string imageDescription)
        {
            await dal.UploadImageToFirebase(imageURL, imageDescription);
        }

        //create function that get all images in firebase and return them
        public  List<FirebaseImage> GetImagesFromFirebase()
        {
            return  dal.GetSavedImages();
        }

    }

}
