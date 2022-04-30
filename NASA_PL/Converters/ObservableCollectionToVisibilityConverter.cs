using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using NASA_BE;

namespace NASA_PL.Converters
{
    internal class ObservableCollectionToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value switch
            {
                null => Visibility.Collapsed,
                ObservableCollection<NearEarthObject> Neos => Neos.Count == 0 ? Visibility.Visible : Visibility.Collapsed,
                _ => Visibility.Collapsed
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
