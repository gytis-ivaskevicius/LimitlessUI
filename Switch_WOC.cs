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
    public partial class Switch_WOC : Control
    {
        private bool isOn = true;
        private Color onColor = Color.SeaGreen;
        private Color offColor = Color.DarkGray;

        private string onText = "On";
        private string offText = "Off";

        private bool textEnabled = true;

        public Switch_WOC()
        {
            Click += click;
            BackColor = Color.FromArgb(64, 64, 64);
            ForeColor = Color.FromArgb(224, 224, 224);
            Width = 51;
            Height = 18;
            DoubleBuffered = true;
        }

        private void click(object sender, EventArgs e)
        {
            isOn = !isOn;
            Invalidate();
        }

        private void drawString(PaintEventArgs pe, bool isOn)
        {
            SizeF stringSize = pe.Graphics.MeasureString(isOn ? onText : offText, Font);
            float drawHeight = Height / 2 - stringSize.Height / 2;

            if (isOn)
            {
                float drawWidth = Width / 2 + (Width / 4) - stringSize.Width / 2;
                pe.Graphics.DrawString(onText, Font, new SolidBrush(ForeColor), drawWidth, drawHeight);
            }
            else
            {
                float drawWidth = Width / 2 - (Width / 4) - stringSize.Width / 2;
                pe.Graphics.DrawString(offText, Font, new SolidBrush(ForeColor), drawWidth, drawHeight);
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Pen pen1 = new Pen(BackColor, Height);
            Pen pen2 = new Pen(isOn ? onColor : offColor, Height);

            pe.Graphics.DrawLine(pen1, 0, Height / 2, Width, Height / 2);
            if (isOn)
                pe.Graphics.DrawLine(pen2, 0, Height / 2, Width / 2, Height / 2);
            else
                pe.Graphics.DrawLine(pen2, Width / 2, Height / 2, Width, Height / 2);

            if (textEnabled)
                drawString(pe, isOn);

            pen1.Dispose();
            pen2.Dispose();
        }
    }
}
