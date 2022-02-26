using NASA_BE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;


namespace NASA_DAL
{
    public class Dal
    {
        const string NasaApiKey = "7cJzNeeVHfpkbfQoRP1107Dfmo2kOFd5jktUCVc1";

        public Dal() 
        {
            using (var dbcontext = new NasaDB())
            {
                //TODO: add all planets, create Initialize function
                if (dbcontext.Planets.ToList().Count == 0)
                {
                    dbcontext.Planets.Add(new Planet()
                    {
                        Id = 1,
                        Name = "Mercury",
                        AverageDistanceFromTheSun = 57909176,
                        Aphelion = 69817079,
                        Perihelion = 46001272,
                        Radius = 2439,
                        Mass = 3.302 * (10 ^ 23),
                        SurfaceTemp = 166.85, //celzius
                        OrbitalPeriod = 87.9691, //זמן הקפה ימים
                        AverageSpeed = 47.36, //km second
                        RotationPeriod = 58.6462, //זמן סיבוב עצמי, ימים
                        MoonNumber = 0,
                        AtmosphericPressure = 0, // פסקל
                        MaterialsDict = new Dictionary<string, double> { {"Potassium", 31.7 },
                                                                        {"Calcium", 24.9 },
                                                                        {"Atomic Oxygen", 9.5 },
                                                                        {"Argon", 7 },
                                                                        {"Helium", 5.9},
                                                                        {"Molecular Oxygen", 5.6 },
                                                                        {"Nitrogen", 5.2 },
                                                                        {"Carbon dioxide", 3.6 },
                                                                        {"H2O", 3.4 },
                                                                        {"Hydrogenium", 3.2 }
                        },
                        ImageURL = " "
                    });

                    dbcontext.SaveChanges();
                }
            }
        }

        public List<Planet> GetSolarSystem()
        {
            using (var ctx = new NasaDB())
            {
                return ctx.Planets.ToList();
            }
        }

        public async Task<APOD> GetAPODFromNASAApi()
        {
            var url = "https://api.nasa.gov/planetary/apod?api_key=" + NasaApiKey;

            return await GetFromApi<APOD>(url);
        }

        public async Task<T> GetFromApi<T>(string url)
        {
            // make http GET request with the url
            var request = WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                // get the response from the request as json
                var response = request.GetResponse();

                // read the response as a stream
                var stream = response.GetResponseStream();

                // create a stream reader to read the stream
                var reader = new StreamReader(stream);

                // read the stream as a string
                var json = reader.ReadToEnd();

                // close the reader
                reader.Close();

                // convert the response to json object
                var responseObject = JsonConvert.DeserializeObject<T>(json);

                return responseObject;
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException();
                //TODO: throw right exception
            }

        }


        /*
 
        public async Task<Dictionary<string, string>> GetSearchResult(string search)
        {
            string request = $"https://images-api.nasa.gov/search?q={search}";
            var res = await PerformHttpRequest<SearchResult>(request);
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            foreach (Item i in res.collection.items)
            {
                if (i.links != null)
                {
                    valuePairs.Add(i.links.FirstOrDefault().href, i.data[0].description);
                }
            }
            return valuePairs;
        }
        public TagResult TagImage(string urlImage)
        {
            string apiKey = "acc_0fd8b9ede9c47e9";
            string apiSecret = "f4fde1a58c92ace9e4d9dca1b91e5744";

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient(String.Format("https://api.imagga.com/v2/tags"));
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("image_url", urlImage);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            IRestResponse response = client.Execute(request);
            var tagResult = JsonConvert.DeserializeObject<TagResult>(response.Content);

            return tagResult;
        }
        public async Task<NearEarthObjects> GetNearEarthObject(string start, string end)
        {
            string link = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={start}&end_date={end}&api_key={NasaApiKey}";
            var r = await PerformHttpRequest<NearEarthObjects>(link);
            return r;
        }



        */
    }
}



