using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BE;
using NASA_PL.Models;

namespace NASA_PL.ViewModels
{

    class APODViewModel
    {
        APODModel model;
        APOD apod;
        public APODViewModel()
        {
            model = new APODModel();
            apod = Task.Run( () =>  model.GetImageOfTheDay()).Result;
        }

        public string urlImage
        {
            get
            {
                return apod.Url;
            }
        }

        public string Title
        {
            get
            {
                return apod.Title;
            }
        }

        public string Explanation
        {
            get
            {
                return apod.Explanation;
            }
        }

    }
}
