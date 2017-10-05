using System;
using System.Drawing;
using System.Windows.Forms;

namespace LimitlessUISample.Childs
{
    public partial class Chart_UC : UserControl
    {
        public Chart_UC()
        {
            InitializeComponent();
            if (!DesignMode)
                timer1.Start();
            chart_WOC2.AddSerie(Color.Green, "serie1", true);
            chart_WOC2.AddSerie(Color.Red, "serie2", false);
            legend_WOC2.NotifySeriesChanged();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int val = r.Next(100);
            chart_WOC2.AddValue(0, val);
            chart_WOC2.AddValue(1, val + 10);
        }
    }
}
