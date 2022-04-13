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

namespace NASA_PL.UserControls
{
    /// <summary>
    /// Interaction logic for SidePanelUC.xaml
    /// </summary>
    public partial class SidePanelUC : UserControl
    {
        public string textBlock_text { get; set; }
        public string tooltip_text { get; set; }

        public SidePanelUC()
        {
            InitializeComponent();
            
        }
    }
}
