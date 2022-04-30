using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BE;
using NASA_BL;

namespace NASA_PL.Models
{

    class FireBaseImagesModel
    {
        BL bl;

        public FireBaseImagesModel()
        {
            bl = new BL();
        }

        //create function that get all images in firebase and return them
        public List<FirebaseImage> GetImagesFromFirebase()
        {
            return bl.GetImagesFromFirebase();
        }
    }
}