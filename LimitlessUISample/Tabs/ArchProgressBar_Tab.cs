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
    public partial class ArchProgressBar_Tab : UserControl, Tab_WOC
    {
        private static ArchProgressBar_Tab _instance;

        public ArchProgressBar_Tab()
        {
            InitializeComponent();
            timer1.Start();
        }

        public static ArchProgressBar_Tab getInstance()
        {
            if (_instance == null)
                _instance = new ArchProgressBar_Tab();
            return _instance;
        }

        public void onShowTab()
        {
            Debug.WriteLine("Showing ArchProgressBar_Tab");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int randomNumber = new Random().Next(100);
            archProgressBar_WOC1.Value = randomNumber;
            archProgressBar_WOC2.Value = randomNumber;
            archProgressBar_WOC3.Value = randomNumber;
            archProgressBar_WOC4.Value = randomNumber;
            archProgressBar_WOC5.Value = randomNumber;
            archProgressBar_WOC6.Value = randomNumber;
            archProgressBar_WOC8.Value = randomNumber;
            archProgressBar_WOC9.Value = randomNumber;
            archProgressBar_WOC10.Value = randomNumber;
            archProgressBar_WOC11.Value = randomNumber;
        }
    }
}
