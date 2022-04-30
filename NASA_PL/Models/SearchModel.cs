using NASA_BL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NASA_PL.Models
{

    class SearchModel
    {
        BL bl;

        public SearchModel()
        {
            bl = new BL();
        }


        // create function that send to dal imageURL and save it to Firebase
        public async Task SaveImageToFirebase(string imageURL, string imageDescription)
        {
            await bl.SaveImageToFirebase(imageURL, imageDescription);
        }

        public async Task<Dictionary<string, string>> GetSearchResult(string search, int confidence)
        {
            return await bl.GetSearchResult(search, confidence);
        }
    }
}
