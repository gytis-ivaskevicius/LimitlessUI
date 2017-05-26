using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            chart_WOC2.addSerie(Color.Green, "serie1", true);
            chart_WOC2.addSerie(Color.Red, "serie2", false);
            legend_WOC2.notifySeriesChanged();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int val = r.Next(100);
            chart_WOC2.addValue(0, val);
            chart_WOC2.addValue(1, val + 10);

        }
    }
}
