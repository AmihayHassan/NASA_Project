﻿using NASA_BE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Firebase.Storage.Client;
using RestSharp;

namespace NASA_DAL
{
    public class Dal
    {
        const string NasaApiKey = "7cJzNeeVHfpkbfQoRP1107Dfmo2kOFd5jktUCVc1";

        public Dal()
        {
            NasaDB dbcontext = new NasaDB();

            SeedDataBaseIfEmpty(dbcontext).GetAwaiter().GetResult();

        }

        public async Task SeedDataBaseIfEmpty(NasaDB dbcontext)
        {
            if (dbcontext.Planets.ToList().Count == 0)
            {
                #region add planets
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
                    ImageURL = "https://firebasestorage.googleapis.com/v0/b/nasa-wpf-ronke-amiha-2022.appspot.com/o/Mercury.png?alt=media"
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
                    ImageURL = "https://firebasestorage.googleapis.com/v0/b/nasa-wpf-ronke-amiha-2022.appspot.com/o/Venus.png?alt=media"
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
                    ImageURL = "https://firebasestorage.googleapis.com/v0/b/nasa-wpf-ronke-amiha-2022.appspot.com/o/Earth.png?alt=media"
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
                    ImageURL = "https://firebasestorage.googleapis.com/v0/b/nasa-wpf-ronke-amiha-2022.appspot.com/o/Mars.png?alt=media"
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
                    ImageURL = "https://firebasestorage.googleapis.com/v0/b/nasa-wpf-ronke-amiha-2022.appspot.com/o/Jupiter.png?alt=media"
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
                    ImageURL = "https://firebasestorage.googleapis.com/v0/b/nasa-wpf-ronke-amiha-2022.appspot.com/o/Saturn.png?alt=media"
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
                    ImageURL = "https://firebasestorage.googleapis.com/v0/b/nasa-wpf-ronke-amiha-2022.appspot.com/o/Uranus.png?alt=media"
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
                    ImageURL = "https://firebasestorage.googleapis.com/v0/b/nasa-wpf-ronke-amiha-2022.appspot.com/o/Neptune.png?alt=media"
                });

                #endregion
                await dbcontext.SaveChangesAsync();
            }

            if (dbcontext.UsersAndPasswords.ToList().Count == 0)
            {
                #region add users

                dbcontext.UsersAndPasswords.Add(new User()
                {
                    Id = 1,
                    Username = "Ronke21",
                    Password = "Password1"
                });

                dbcontext.UsersAndPasswords.Add(new User()
                {
                    Id = 2,
                    Username = "Amihay1544",
                    Password = "ArabStyle123"
                });

                dbcontext.UsersAndPasswords.Add(new User()
                {
                    Id = 3,
                    Username = "Yossi",
                    Password = "Zaguri"
                });
                dbcontext.UsersAndPasswords.Add(new User()
                {
                    Id = 4,
                    Username = "admin",
                    Password = "123"
                });
                #endregion
                dbcontext.SaveChanges();
            }

            if (dbcontext.SavedImagesFB.ToList().Count == 0)
            {
                #region add images
                dbcontext.SavedImagesFB.Add(new FirebaseImage()
                {
                    Url = "https://devops.com.vn/wp-content/uploads/2021/02/firebase.png",
                    Name = "xxx",
                    savingeTime = DateTime.Now,
                    Description = "default",
                    Id = DateTime.Now.Ticks

                });

                #endregion
                dbcontext.SaveChanges();
            }            
        }

        public List<Planet> GetSolarSystem()
        {
            using (var ctx = new NasaDB())
            {
                return ctx.Planets.ToList();
            }
        }

        public async Task<T> GetFromApi<T>(string url)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                var response = await client.ExecuteAsync<T>(request);
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception e)
            {
                return JsonConvert.DeserializeObject<T>(string.Empty);
            }
        }

        public async Task<APOD> GetApodFromNasaApi()
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key={NasaApiKey}";
            return await GetFromApi<APOD>(url);
        }

        #region Imagga
        public async Task<ImaggaTag> GetImageTagsFromImagga(string imageUrl)
        {
            string apiKey = "acc_1d83319fb42c913";
            string apiSecret = "0eac00d57006acce575e22fe58ab27cf";

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("image_url", imageUrl);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            IRestResponse response = await client.ExecuteAsync(request);

            ImaggaTag imageTags = JsonConvert.DeserializeObject<ImaggaTag>(response.Content);

            return imageTags;
        }
        #endregion

        #region get images and media for planets
        public async Task<Dictionary<string, string>> GetSearchResult(string query)
        {
            var request = $"https://images-api.nasa.gov/search?q={query}";
            var resultsList = await GetFromApi<dynamic>(request);

            var linkAndDescriptionDictionary = new Dictionary<string, string>();

            foreach (var item in resultsList.collection.items)
            {
                if (item.links == null) continue;
                var href = (string)item.links[0].href;
                var description = (string)item.data[0].description;
                linkAndDescriptionDictionary.Add(href, description);
            }
            return linkAndDescriptionDictionary;
        }
        #endregion

        #region near earth object
        public async Task<NearEarthObjects> GetNearEarthObject(string startDate, string endDate)
        {
            string link =
                $"https://api.nasa.gov/neo/rest/v1/feed?start_date={startDate}&end_date={endDate}&api_key={NasaApiKey}";
            var r = await GetFromApi<NearEarthObjects>(link);
            return r;
        }
        #endregion

        public bool CheckUserAndPassword(string user, string password)
        {
            var ctx = new NasaDB();
            var usersFromDB = ctx.UsersAndPasswords.ToList();
            foreach (var userFromDB in usersFromDB)
            {
                if (userFromDB.Username == user && userFromDB.Password == password)
                {
                    return true;
                }
            }

            return false;
        }


        //create function that receive image url, download it and save it to firebase and return its url
        public async Task UploadImageToFirebase(string imageUrl, string imageDescription)
        {
            var dbcontext = new NasaDB();
            var imageList = dbcontext.SavedImagesFB.ToList();
            //check if image already exist in firebase
            var imageExist = imageList.FirstOrDefault(x => x.Url == imageUrl);
            if (imageExist != null)
            {
                return;
            }

            var client = new RestClient(imageUrl);
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);
            var image = response.RawBytes;
            //convert image to stream
            var imageStream = new MemoryStream(image);
            var imageName = Guid.NewGuid().ToString() + ".jpg";
            var task = new FirebaseStorage("nasa-wpf-ronke-amiha-2022.appspot.com")
                .Child("Images/" + imageName)
                .PutAsync(imageStream);
            var downloadUrl = await task;
            string x = "g";
            
            //add the image to the database

            //create new FirebaseImage
            var imageToAdd = new FirebaseImage()
            {
                Url = downloadUrl,
                Name = imageName,
                savingeTime = DateTime.Now,
                Description = imageDescription,
                Id = DateTime.Now.Ticks
            };
            
            UploadImageToDatabase(imageToAdd);
            var imageList2 = dbcontext.SavedImagesFB.ToList();

            return;

        }

        // create function that receive Firebaseimage and add it to the database
        public void UploadImageToDatabase(FirebaseImage image)
        {
            var dbcontext = new NasaDB();
            var imageList = dbcontext.SavedImagesFB.ToList();
            //check if image already exist in database
            var imageExist = imageList.FirstOrDefault(x => x.Url == image.Url);
            if (imageExist != null)
            {
                return;
            }

            dbcontext.SavedImagesFB.Add(new FirebaseImage()
            {
                Url = image.Url,
                Name = image.Name,
                savingeTime = DateTime.Now,
                Description = image.Description,
                Id = DateTime.Now.Ticks

            });
            dbcontext.SaveChanges();
        }


        public List<FirebaseImage> GetSavedImages()
        {
            using (var ctx = new NasaDB())
            {
                return ctx.SavedImagesFB.ToList();
            }

        }

    }
}



