using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using NASA_PL.ViewModels;


namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : Page
    {
        SearchViewModel searchViewModel = null;
        public SearchView()
        {
            InitializeComponent();
            searchViewModel = new SearchViewModel();
            DataContext = searchViewModel;
        }

        //private void btSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    try

        //    {
        //        var text = txtSearch.Text;
        //        progressBar.Visibility = Visibility.Visible;
        //        var searchList = searchViewModel.GetSearchResult(text);
        //        SearchListBox.ItemsSource= searchList;
        //        progressBar.Visibility = Visibility.Collapsed;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            var text = txtSearch.Text;
            var ImageDictionary = Task.Run(() => searchViewModel.GetSearchResult(text)).Result;
            SearchListBox.ItemsSource = ImageDictionary;

        }
    }
}
