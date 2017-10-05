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
using LimitlessUI;

namespace LimitlessUISample.Tabs
{
    public partial class ProgressBar_Tab : UserControl, Tab_WOC
    {
        private static ProgressBar_Tab _instance;

        public ProgressBar_Tab()
        {
            InitializeComponent();
            timer1.Start();
        }

        public static ProgressBar_Tab getInstance()
        {
            if (_instance == null)
                _instance = new ProgressBar_Tab();
            return _instance;
        }

        public void OnShowTab()
        {
            Debug.WriteLine("Showing ProgressBar_Tab");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int randomInt = new Random().Next(100);
            progressBar_WOC1.Value = randomInt;
            progressBar_WOC2.Value = randomInt;
            progressBar_WOC3.Value = randomInt;
            progressBar_WOC4.Value = randomInt;
            progressBar_WOC5.Value = randomInt;
            progressBar_WOC6.Value = randomInt;
        }
    }
}
