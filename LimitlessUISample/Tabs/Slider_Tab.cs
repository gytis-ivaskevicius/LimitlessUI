using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LimitlessUISample.Tabs
{
    public partial class Slider_Tab : UserControl, Tab_WOC
    {
        private static Slider_Tab _instance;

        public Slider_Tab()
        {
            InitializeComponent();
        }

        public static Slider_Tab getInstance()
        {
            if (_instance == null)
                _instance = new Slider_Tab();
            return _instance;
        }


        public void onShowTab()
        {
            Debug.WriteLine("Showing Slider_Tab");
        }
    }
}
