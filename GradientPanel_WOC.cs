using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUI
{
    public partial class GradientPanel_WOC : Control
    {
        Color startColor = Color.WhiteSmoke;
        Color endColor = Color.SteelBlue;
        float angle = 90;

        public GradientPanel_WOC()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                              startColor,
                                                                endColor,
                                                                angle);
            pe.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                Invalidate();
            }
        }
        public Color StartColor
        {
            get { return startColor; }
            set
            {
                startColor = value;
                Invalidate();
            }
        }

        public Color EndColor
        {
            get { return endColor; }
            set
            {
                endColor = value;
                Invalidate();
            }
        }
    }
}
