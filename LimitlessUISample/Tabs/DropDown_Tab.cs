using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUISample.Tabs
{
    public partial class DropDown_Tab : UserControl
    {
        private static DropDown_Tab _instance;

        public DropDown_Tab()
        {
            InitializeComponent();
        }

        public static DropDown_Tab getInstance()
        {
            if (_instance == null)
                _instance = new DropDown_Tab();
            return _instance;
        }
    }
}
