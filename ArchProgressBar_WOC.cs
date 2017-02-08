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
    public partial class ArchProgressBar_WOC : Control
    {
        private string text1 = "CPU";
        private string text2 = "99%";
        private string text3 = "55C";

        private Font font1, font2, font3;

        private int angle = 360;

        private float progress = 50;
        private float line1Thinkness = 5;
        private float line2Thinkness = 9;
        private Color color1 = Color.Gray;
        private Color color2 = Color.Lime;
        private Color text1Color = DefaultForeColor;
        private Color text2Color = DefaultForeColor;
        private Color text3Color = DefaultForeColor;


        public ArchProgressBar_WOC()
        {
            DoubleBuffered = true;
            font1 = Font;
            font2 = Font;
            font3 = Font;
        }

        private void drawContent(PaintEventArgs e, int angle)
        {
            e.Graphics.RotateTransform(-angle);
            SizeF string1Size = e.Graphics.MeasureString(text1, Font);
            SizeF string2Size = e.Graphics.MeasureString(text2, Font);
            SizeF string3Size = e.Graphics.MeasureString(text3, Font);

            float radiusByTwo = (Width - Line2Thikness) / 2;
            int widthByTwo = Width / 2;
            e.Graphics.TranslateTransform(-(line2Thinkness / 2F + radiusByTwo), -(line2Thinkness / 2F + radiusByTwo));

            int style = 2;
            int x, y;

            switch (style)
            {
                case 0:
                    e.Graphics.DrawString(text1, font1, new SolidBrush(text1Color), widthByTwo - string1Size.Width / 2, widthByTwo - string1Size.Height / 2);
                    break;
                case 1:
                    e.Graphics.DrawString(text1, font1, new SolidBrush(text1Color), widthByTwo - string1Size.Width / 2, widthByTwo - string1Size.Height);
                    e.Graphics.DrawString(text2, font2, new SolidBrush(text2Color), widthByTwo - string2Size.Width / 2, widthByTwo);
                    break;
                case 2:
                    e.Graphics.DrawString(text1, font1, new SolidBrush(text1Color), widthByTwo - string1Size.Width / 2, widthByTwo - string1Size.Height);
                    e.Graphics.DrawString(text2, font2, new SolidBrush(text2Color), widthByTwo - string2Size.Width, widthByTwo);
                    e.Graphics.DrawString(text3, font3, new SolidBrush(text3Color), widthByTwo, widthByTwo);
                    break;
            }



        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Pen pen1 = new Pen(color1, line1Thinkness);
            Pen pen2 = new Pen(color2, line2Thinkness);
            float radiusByTwo = (Width - this.Line2Thikness) / 2F;


            float progressEndAngle = (angle - 0) / 100F;
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.TranslateTransform(line2Thinkness / 2F + radiusByTwo, line2Thinkness / 2F + radiusByTwo);

            pe.Graphics.RotateTransform((360 - angle) / 2 + 90);

            pe.Graphics.DrawArc(pen1, -radiusByTwo, -radiusByTwo, Width - Line2Thikness, Width - Line2Thikness, 0, angle);
            pe.Graphics.DrawArc(pen2, -radiusByTwo, -radiusByTwo, Width - Line2Thikness, Width - Line2Thikness, 0, progressEndAngle * progress);

            // drawContent(pe, (360 - angle) / 2 + 90);

            pen1.Dispose();
            pen2.Dispose();
        }



        public Font Font1
        {
            get { return font1; }
            set
            {
                font1 = value;
                Invalidate();
            }
        }
        public Font Font2
        {
            get { return font2; }
            set
            {
                font2 = value;
                Invalidate();
            }
        }
        public Font Font3
        {
            get { return font3; }
            set
            {
                font3 = value;
                Invalidate();
            }
        }



        public int Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                Invalidate();
            }
        }


        public float Value
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

        public float Line1Thikness
        {
            get { return line1Thinkness; }
            set
            {
                line1Thinkness = value;
                Invalidate();
            }
        }

        public float Line2Thikness
        {
            get { return line2Thinkness; }
            set
            {
                line2Thinkness = value;
                Invalidate();
            }
        }

        public Color ProgressColor
        {
            get { return color1; }
            set
            {
                color1 = value;
                Invalidate();
            }
        }

        public Color ProgressBackColor
        {
            get { return color2; }
            set
            {
                color2 = value;
                Invalidate();
            }
        }

        public Color Text1Color
        {
            get { return text1Color; }
            set
            {
                text1Color = value;
                Invalidate();
            }
        }

        public Color Text2Color
        {
            get { return text2Color; }
            set
            {
                text2Color = value;
                Invalidate();
            }
        }

        public Color Text3Color
        {
            get { return text3Color; }
            set
            {
                text3Color = value;
                Invalidate();
            }
        }
        public string Text1
        {
            get { return text1; }
            set
            {
                text1 = value;
                Invalidate();
            }
        }

        public string Text2
        {
            get { return text2; }
            set
            {
                text2 = value;
                Invalidate();
            }
        }

        public string Text3
        {
            get { return text3; }
            set
            {
                text3 = value;
                Invalidate();
            }
        }
        public void updateText(string text1, string text2, string text3)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            Invalidate();
        }
        public void updateText(string text1, string text2)
        {
            this.text1 = text1;
            this.text2 = text2;
            Invalidate();
        }
    }
}
