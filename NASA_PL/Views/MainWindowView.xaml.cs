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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using NASA_BL;
namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {

        #region init decleration
        private readonly BL _bl;

        private bool _hidden;

        #endregion
        public MainWindowView()
        {
            InitializeComponent();


        }

        #region mouse effects and functionality for exit button
        private void Exit_OnMouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Exit.Background = (Brush)bc.ConvertFrom("#F1707A");
        }
        private void Exit_OnMouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Exit.Background = (Brush)bc.ConvertFrom("#E81123");
        }
        private void Exit_OnMouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }


        #endregion

        #region open close menu and drag window

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (_hidden)
            {
                var sb = Resources["OpenMenu"] as Storyboard;
                sb?.Begin(SideBar);
                _hidden = false;
                OpenCloseButtonIcon.Kind = PackIconKind.MenuOpen;
            }
            else
            {
                var sb = Resources["CloseMenu"] as Storyboard;
                sb?.Begin(SideBar);
                _hidden = true;
                OpenCloseButtonIcon.Kind = PackIconKind.Menu;
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        #endregion

        #region Buses button
        private void BusesSidePanel_OnMouseEnter(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            BusesSidePanel.Background = (Brush)bc.ConvertFrom("#30ABFF");
        }
        private void BusesSidePanel_OnMouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            BusesSidePanel.Background = (Brush)bc.ConvertFrom("#FF0064A6");
        }
        private void BusesSidePanel_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_hidden)
            {
                ButtonBase_OnClick(sender, e);
            }

            //if (!(DataDisplay.Content is BusesViewPage))
            //{
            //    DataDisplay.Content = new BusesViewPage(_bl);
            //}
        }
        #endregion

        #region Stations button
        private void StationsSidePanel_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_hidden)
            {
                ButtonBase_OnClick(sender, e);
            }

            //if (!(DataDisplay.Content is StationsViewPage))
            //{
            //    DataDisplay.Content = new StationsViewPage(_bl, _simulationPage);
            //}
        }

        #region colors
        private void StationsSidePanel_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            StationsSidePanel.Background = (Brush)bc.ConvertFrom("#30ABFF");
        }

        private void StationsSidePanel_OnMouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            StationsSidePanel.Background = (Brush)bc.ConvertFrom("#FF0064A6");
        }

        #endregion
        #endregion

        #region Lines button
        private void LinesSidePanel_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_hidden)
            {
                ButtonBase_OnClick(sender, e);
            }

            //if (!(DataDisplay.Content is LinesViewPage))
            //{
            //    DataDisplay.Content = new LinesViewPage(_bl);
            //}
        }
        private void LinesSidePanel_OnMouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            LinesSidePanel.Background = (Brush)bc.ConvertFrom("#FF0064A6");
        }
        private void LinesSidePanel_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            LinesSidePanel.Background = (Brush)bc.ConvertFrom("#30ABFF");
        }
        #endregion

        #region  Consecutive stations
        private void ConsecutiveStationsSidePanel_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_hidden)
            {
                ButtonBase_OnClick(sender, e);
            }

            //if (!(DataDisplay.Content is ConStatViewPage))
            //{
            //    DataDisplay.Content = new ConStatViewPage(_bl);
            //}

        }
        private void ConsecutiveStationsSidePanel_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            ConsecutiveStationsSidePanel.Background = (Brush)bc.ConvertFrom("#30ABFF");
        }
        private void ConsecutiveStationsSidePanel_OnMouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            ConsecutiveStationsSidePanel.Background = (Brush)bc.ConvertFrom("#FF0064A6");
        }
        #endregion

        #region Simulator
        private void SimulatorSidePanel_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            SimulatorSidePanel.Background = (Brush)bc.ConvertFrom("#30ABFF");
        }
        private void SimulatorSidePanel_OnMouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            SimulatorSidePanel.Background = (Brush)bc.ConvertFrom("#FF0064A6");
        }
        private void SimulatorSidePanel_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_hidden)
            {
                ButtonBase_OnClick(sender, e);
            }

            //if (!(DataDisplay.Content is SimulationPage))
            //{
            //    DataDisplay.Content = _simulationPage;
            //}
        }

        #endregion

        private void InfoButton_OnClick(object sender, RoutedEventArgs e)
        {
            //var info = new InfoWindow();
            //info.ShowDialog();
        }
    }
}

