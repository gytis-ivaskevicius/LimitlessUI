using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LimitlessUISample.Childs;

namespace LimitlessUISample.Tabs
{
    public partial class Other_Tab : UserControl
    {
        private static Other_Tab _instance;

        public Other_Tab()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                listView_WOC1.add(new Other_ListView_Child(" Amazing ListView Child "+i));
            }
        }

        public static Other_Tab getInstance()
        {
            if (_instance == null)
                _instance = new Other_Tab();
            return _instance;
        }
    }
}
