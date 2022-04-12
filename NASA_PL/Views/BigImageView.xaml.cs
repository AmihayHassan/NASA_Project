using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for BigImageView.xaml
    /// </summary>
    public partial class BigImageView : Window
    {
        public BitmapImage url { get; set; }
        public BigImageView(string imageUrl)
        {
            InitializeComponent();
            BigImage.Source = new BitmapImage(new Uri(imageUrl));
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
