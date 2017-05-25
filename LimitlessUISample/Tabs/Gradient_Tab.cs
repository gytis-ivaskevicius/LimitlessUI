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
    public partial class Gradient_Tab : UserControl, Tab_WOC
    {
        private static Gradient_Tab _instance;
        private bool _expanded = true;

        public Gradient_Tab()
        {
            InitializeComponent();

        }

        public static Gradient_Tab getInstance()
        {
            if (_instance == null)
                _instance = new Gradient_Tab();
            return _instance;
        }

        public void onShowTab()
        {
            Debug.WriteLine("Showing Gradient_Tab");
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            animator_WOC1.animate(500,_expanded ? 50: 200);
            _expanded = !_expanded;

            Debug.WriteLine("click" + (_expanded ? 50 : 200));
        }
    }
}
