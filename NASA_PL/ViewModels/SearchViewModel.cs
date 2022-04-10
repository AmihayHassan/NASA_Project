using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NASA_PL.Models;

namespace NASA_PL.ViewModels
{
    //public class SearchViewModel
    //{
    //    SearchModel searchModel;
    //    public SearchViewModel()
    //    {
    //        searchModel = new SearchModel();
    //    }
    //    public async Task<Dictionary<string, string>> GetSearchResult(string search)
    //    {
    //        var x= await searchModel.GetSearchResult(search);
    //        return x;
    //    }
    //}

    public class SearchViewModel : INotifyPropertyChanged
    {
        SearchModel searchModel;
        public SearchViewModel()
        {
            searchModel = new SearchModel();
        }
        public void GetSearchResult(string search)
        {
            CollectionUrlImages = searchModel.GetSearchResult(search).Result;
        }

        Dictionary<string, string> collectionUrlImages;
        private ObservableCollection<string> collectionUrlImages2;
        public Dictionary<string, string> CollectionUrlImages
        {
            get
            {
                //if (collectionUrlImages == null)
                //    collectionUrlImages = new Dictionary<string, string>();
                //return collectionUrlImages;
                if (collectionUrlImages2 == null)
                    collectionUrlImages = new Dictionary<string, string>();
                return collectionUrlImages;
            }
            set
            {
                collectionUrlImages = value;
                OnPropertyChanged("CollectionUrlImages");
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
