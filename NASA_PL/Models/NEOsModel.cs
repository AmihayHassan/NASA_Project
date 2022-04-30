using CommunityToolkit.Mvvm.ComponentModel;
using NASA_BE;
using NASA_BL;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;


namespace NASA_PL.Models
{
    public class NEOsModel : ObservableObject
    {

        BL bl;

        [ObservableProperty]
        public ObservableCollection<NearEarthObject> neoList;

        public NEOsModel()
        {
            bl = new BL();
            neoList = new ObservableCollection<NearEarthObject>();
        }

        public async Task<ObservableCollection<NearEarthObject>> GetNearEarthObject(string start, string end, double diameter)
        {
            neoList = new ObservableCollection<NearEarthObject>(from s in await bl.GetNearEarthObject(start, end)
                                                                where s.Diameter > diameter
                                                                select s);
            return neoList;
        }
    }
}
