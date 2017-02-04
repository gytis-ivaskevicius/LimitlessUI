using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUI
{
    public partial class Separator_WOC : Control
    {
        private float thikness = 1;
        private Color lineColor = Color.DimGray;

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.DrawLine(new Pen(lineColor, thikness), Padding.Left, this.Height / 2, this.Width - Padding.Right, this.Height / 2);
        }

        public float LineThikness
        {
            get { return thikness; }
            set
            {
                thikness = value;
                Invalidate();
            }
        }

        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
                Invalidate();
            }
        }
    }
}
