using NASA_BE;
using NASA_BL;
using System.Collections.Generic;

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