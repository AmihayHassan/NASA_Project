using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BL;

namespace NASA_PL.Models
{

    class SearchModel
    {
        BL bl;

        public SearchModel()
        {
            bl = new BL();
        }
        public async Task<Dictionary<string, string>> GetSearchResult(string search)
        {
            var x= await bl.GetSearchResult(search);
            return x;
        }
    }
}
