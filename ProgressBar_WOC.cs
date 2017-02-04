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
    public partial class ProgressBar_WOC : Control
    {
        private Color progressBackColor = Color.Silver;
        private int progress = 50;
        private float line1Thikness = 10;
        private float line2Thikness = 20;
        private bool rounded = true;
        private bool smoothing = true;
        private float extraPadding = 0;

        public ProgressBar_WOC()
        {
            this.DoubleBuffered = true;

            ForeColor = Color.Chartreuse;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (smoothing)
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float progressWidth = this.Width;
            float progressToDraw = ((progressWidth - Padding.Left - Padding.Right) / 100) * progress;
            float progressNotToDraw = (progressWidth - Padding.Left - Padding.Right) - progressToDraw;
            float drawHeight = this.Height / 2;

            Pen penOne = new Pen(progressBackColor, line1Thikness);
            Pen penTwo = new Pen(ForeColor, line2Thikness);


            if (rounded)
            {
                penTwo.StartCap = LineCap.Round;
                penTwo.EndCap = LineCap.Round;

                penOne.StartCap = LineCap.Round;
                penOne.EndCap = LineCap.Round;

                extraPadding = line2Thikness / 2;
            }
            else
                extraPadding = 0;


            pe.Graphics.DrawLine(penOne, ((float)Padding.Left) + extraPadding, drawHeight, ((float)this.Width - Padding.Right) - extraPadding, drawHeight);
            if (Value != 0)
                pe.Graphics.DrawLine(penTwo, Padding.Left + extraPadding, drawHeight, this.Width - ((float)Padding.Right) - progressNotToDraw - extraPadding, drawHeight);


            penOne.Dispose();
            penTwo.Dispose();
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Invalidate();
        }

        public int Value
        {
            get { return progress; }
            set
            {
                if (value != progress)
                {
                    progress = value;
                    Invalidate();
                }
            }
        }

        public Color ProgressBackColor
        {
            get { return progressBackColor; }
            set
            {
                progressBackColor = value;
                Invalidate();
            }
        }

        public bool Rounded
        {
            get { return rounded; }
            set
            {
                rounded = value;
                Invalidate();
            }
        }

        public bool Smooth
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        public float Line1Thikness
        {
            get { return line1Thikness; }
            set
            {
                line1Thikness = value;
                Invalidate();
            }
        }

        public float Line2Thikness
        {
            get { return line2Thikness; }
            set
            {
                line2Thikness = value;
                Invalidate();
            }
        }
    }
}
