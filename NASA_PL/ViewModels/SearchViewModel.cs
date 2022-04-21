using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using NASA_PL.Models;

namespace NASA_PL.ViewModels
{
    [INotifyPropertyChanged]
    public class SearchViewModel
    {
        private readonly SearchModel _searchModel;
        public SearchViewModel()
        {
            _searchModel = new SearchModel();
        }
        public async Task<Dictionary<string, string>> GetSearchResult(string search)
        {
            return await _searchModel.GetSearchResult(search);
        }
    }
}
