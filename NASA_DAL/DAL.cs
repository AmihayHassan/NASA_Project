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
                        AverageSurfaceTemp = 166.85, //celzius
                        OrbitalPeriod = 87.9691, //זמן הקפה ימים
                        AverageSpeed = 47.36, //km second
                        RotationPeriod = 58.6462, //זמן סיבוב עצמי, ימים
                        MoonNumber = 0,
                        //AtmosphericPressure = 0, // פסקל
                        //MaterialsDict = new Dictionary<string, double> {
                        //    {"Potassium", 31.7 },
                        //    {"Calcium", 24.9 },
                        //    {"Atomic Oxygen", 9.5 },
                        //    {"Argon", 7 },
                        //    {"Helium", 5.9},
                        //    {"Molecular Oxygen", 5.6 },
                        //    {"Nitrogen", 5.2 },
                        //    {"Carbon dioxide", 3.6 },
                        //    {"H2O", 3.4 },
                        //    {"Hydrogenium", 3.2 }
                        //},
                        ImageURL = " "
                    });

                    dbcontext.Planets.Add(new Planet()
                    {
                        Id = 2,
                        Name = "Venus",
                        AverageDistanceFromTheSun = 108208926,
                        Aphelion = 108941849,
                        Perihelion = 107476002,
                        Radius = 6052,
                        Mass = 4.8685 * (10 ^ 24),
                        AverageSurfaceTemp = 463.8, //celzius
                        OrbitalPeriod = 224.70069, //זמן הקפה ימים
                        AverageSpeed = 35.020, //km second
                        RotationPeriod = 117, //זמן סיבוב עצמי, ימים
                        MoonNumber = 0,
                        //AtmosphericPressure = 9.3, // mega pascal
                        //MaterialsDict = new Dictionary<string, double> {
                        //    {"Carbon dioxide", 96.5 },
                        //    {"Nitrogen", 3.5 },
                        //    {"SO2", 0.015 },
                        //    {"Argon", 0.007 },
                        //    {"Water vapor", 0.002 },
                        //    {"Carbon monoxide", 0.0017},
                        //    {"Helium", 0.0012 },
                        //    {"Neon", 0.0007 },
                        //},
                        ImageURL = " "
                    });

                    dbcontext.Planets.Add(new Planet()
                    {
                        Id = 3,
                        Name = "Earth",
                        AverageDistanceFromTheSun = 149598023,
                        Aphelion = 152097701,
                        Perihelion = 147098074,
                        Radius = 6378.137,
                        Mass = 5.9742 * (10 ^ 24),
                        AverageSurfaceTemp = 14, //celzius
                        OrbitalPeriod = 365.256366, //זמן הקפה ימים
                        AverageSpeed = 29.783, //km second
                        RotationPeriod = 0.9972, //זמן סיבוב עצמי, ימים
                        MoonNumber = 1,
                        //AtmosphericPressure = 101.325, // kilo pascal
                        ImageURL = " "
                    });

                    dbcontext.Planets.Add(new Planet()
                    {
                        Id = 4,
                        Name = "Mars",
                        AverageDistanceFromTheSun = 227936637,
                        Aphelion = 249228730,
                        Perihelion = 206644545,
                        Radius = 3396.2,
                        Mass = 6.4191 * (10 ^ 23),
                        AverageSurfaceTemp = -63.15, //celzius
                        OrbitalPeriod = 686.971, //זמן הקפה ימים
                        AverageSpeed = 24.077, //km second
                        RotationPeriod = 1.02595417, //זמן סיבוב עצמי, ימים
                        MoonNumber = 2,
                        //AtmosphericPressure = 0.8, // kilo pascal
                        ImageURL = " "
                    });

                    dbcontext.Planets.Add(new Planet()
                    {
                        Id = 5,
                        Name = "Jupiter",
                        AverageDistanceFromTheSun = 778340821,
                        Aphelion = 816081455,
                        Perihelion = 740742598,
                        Radius = 71492,
                        Mass = 1.899 * (10 ^ 27),
                        AverageSurfaceTemp = -121, //celzius
                        OrbitalPeriod = 4332.589, //זמן הקפה ימים
                        AverageSpeed = 13.0697, //km second
                        RotationPeriod = 0.41354166, //זמן סיבוב עצמי, ימים
                        MoonNumber = 79,
                        ImageURL = " "
                    });

                    dbcontext.Planets.Add(new Planet()
                    {
                        Id = 6,
                        Name = "Saturn",
                        AverageDistanceFromTheSun = 1426725413,
                        Aphelion = 1503983449,
                        Perihelion = 1349467375,
                        Radius = 60268,
                        Mass = 5.6846 * (10 ^ 26),
                        AverageSurfaceTemp = -130, //celzius
                        OrbitalPeriod = 10832.327, //זמן הקפה ימים
                        AverageSpeed = 9.639, //km second
                        RotationPeriod = 0.439409722, //זמן סיבוב עצמי, ימים
                        MoonNumber = 53, // 82, but 29 are not approved yet
                        ImageURL = " "
                    });

                    dbcontext.Planets.Add(new Planet()
                    {
                        Id = 7,
                        Name = "Uranus",
                        AverageDistanceFromTheSun = 2870972220,
                        Aphelion = 3006389405,
                        Perihelion = 2735555035,
                        Radius = 25559,
                        Mass = 8.686 * (10 ^ 25),
                        AverageSurfaceTemp = -220, //celzius
                        OrbitalPeriod = 30799.095, //זמן הקפה ימים
                        AverageSpeed = 6.795, //km second
                        RotationPeriod = 0.71833, //זמן סיבוב עצמי, ימים
                        MoonNumber = 27,
                        ImageURL = " "
                    });

                    dbcontext.Planets.Add(new Planet()
                    {
                        Id = 8,
                        Name = "Neptune",
                        AverageDistanceFromTheSun = 4498252900,
                        Aphelion = 4536874325,
                        Perihelion = 4459631496,
                        Radius = 24786,
                        Mass = 1.024 * (10 ^ 26),
                        AverageSurfaceTemp = -212, //celzius
                        OrbitalPeriod = 60190, //זמן הקפה ימים
                        AverageSpeed = 5.432, //km second
                        RotationPeriod = 0.67118055, //זמן סיבוב עצמי, ימים
                        MoonNumber = 14,
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
                // get response from the request asynchronously
                using (var response = await request.GetResponseAsync())
                {
                    // get the response stream
                    using (var stream = response.GetResponseStream())
                    {
                        // create a stream reader to read the stream
                        using (var reader = new StreamReader(stream))
                        {
                            // read the response asynchronously
                            var content = await reader.ReadToEndAsync();

                            // deserialize the response to the specified type
                            return JsonConvert.DeserializeObject<T>(content);
                        }
                    }
                }
                //// get the response from the request as json
                //var response = await request.GetResponseAsync();

                //// read the response as a stream
                //var stream = response.GetResponseStream();

                //// create a stream reader to read the stream
                //var reader = new StreamReader(stream);

                //// read the stream as a string
                //var json = reader.ReadToEnd();

                //// close the reader
                //reader.Close();

                //// convert the response to json object
                //var responseObject = JsonConvert.DeserializeObject<T>(json);

                //return responseObject;
            }
            catch (HttpRequestException e)
            {

                throw new HttpRequestException();
                //TODO: throw proper exception
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



