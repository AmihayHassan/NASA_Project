using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlzEx.Theming;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using NASA_PL.Models;
using NASA_PL.ViewModels;



namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : Page
    {
        private SearchModel _searchModel;
        private SearchViewModel _searchViewModel;

        public SearchView()
        {
            InitializeComponent();
            _searchModel = new SearchModel();
            _searchViewModel = new SearchViewModel();
            DataContext = _searchViewModel;
        }

        //private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (SearchListBox.SelectedItem is null)
        //    {
        //        MessageBox.Show("you must select an item", "error");
        //    }
        //    else
        //    {
        //        var kvp = (KeyValuePair<string, string>)SearchListBox.SelectedItem;
        //        Task.Run(async () => await _searchModel.SaveImageToFirebase(kvp.Key, kvp.Value));
        //    }
        //}
    }
}
