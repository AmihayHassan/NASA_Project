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

        // create function that send to dal imageURL and save it to firebase
        public async Task SaveImageToFirebase(string imageURL, string imageDescription)
        {
            await bl.SaveImageToFirebase(imageURL, imageDescription);
        }

        //create function that get all images in firebase and return them
        public List<FirebaseImage> GetImagesFromFirebase()
        {
            return bl.GetImagesFromFirebase();
        }
    }
}