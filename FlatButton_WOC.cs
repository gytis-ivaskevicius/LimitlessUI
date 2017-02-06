using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUI
{
    public partial class FlatButton_WOC : System.Windows.Forms.Control
    {
        ContentAlignment textAligment = ContentAlignment.MiddleLeft;
        private System.Drawing.Image image;
        private SizeF imageSize = new SizeF(20, 20);
        public bool selected = false;
        private bool tab = true;
        private int activationLenght = 150;

        private Color selectedBackColor = Color.DarkSeaGreen;
        private Color selectedForeColor = Color.White;

        private Color onHoverColor = Color.MediumSeaGreen;
        private Color onHoverTextColor = Color.White;
        private Color defaultBackColor;
        private Color defaultForeColor;

        public FlatButton_WOC()
        {
            BackColor = Color.SeaGreen;
            ForeColor = Color.White;
            Height = 48;
            Width = 241;

            MouseEnter += onMouseEnter;
            MouseLeave += onMouseExit;
            MouseClick += onClick;
        }

        private void onClick(object sender, MouseEventArgs e)
        {
            if (!selected)
            {
                BackColor = selectedBackColor;
                ForeColor = selectedForeColor;

                if (tab)
                {
                    foreach (System.Windows.Forms.Control control in Parent.Controls)
                        if (control is FlatButton_WOC)
                            ((FlatButton_WOC)control).unselect();
                }
                else
                {
                    Thread.Sleep(150);
                    BackColor = onHoverColor;
                    ForeColor = onHoverTextColor;
                }
                selected = true;
            }

        }

        public void unselect()
        {
            if (selected)
            {
                selected = false;
                BackColor = defaultBackColor;
                ForeColor = defaultForeColor;
            }
        }

        private void onMouseExit(object sender, EventArgs e)
        {
            if (!selected)
            {
                BackColor = defaultBackColor;
                ForeColor = defaultForeColor;
            }
        }

        private void onMouseEnter(object sender, EventArgs e)
        {
            if (!selected)
            {
                defaultBackColor = BackColor;
                defaultForeColor = ForeColor;

                BackColor = OnHoverColor;
                ForeColor = OnHoverTextColor;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            drawString(pe.Graphics, Text, Font, ForeColor, textAligment.ToString());
            if (image != null)
            {
                float drawHeight = Height / 2 - imageSize.Height / 2;
                pe.Graphics.DrawImage(image, drawHeight, drawHeight, imageSize.Width, imageSize.Height);
            }
        }

        private void drawString(Graphics g, string text, Font font, Color color, string textAligment)
        {
            SizeF stringSize = g.MeasureString(Text, Font);
            float drawX = Height;
            float drawY = 0;

            if (textAligment.Contains("Middle"))
                drawY = Height / 2 - stringSize.Height / 2;
            else if (textAligment.Contains("Bottom"))
                drawY = Height - stringSize.Height;

            if (textAligment.Contains("Center"))
                drawX = Width / 2 - stringSize.Width / 2;
            else if (textAligment.Contains("Right"))
                drawX = Width - stringSize.Width;

            g.DrawString(Text, Font, new SolidBrush(ForeColor), drawX, drawY);
        }

        public ContentAlignment TextAligment
        {
            get
            {
                return textAligment;
            }
            set
            {
                textAligment = value;
                Invalidate();
            }
        }

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                Invalidate();
            }
        }
        public bool IsTab
        {
            get
            {
                return tab;
            }
            set
            {
                tab = value;
                Invalidate();
            }
        }

        public System.Drawing.Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                Invalidate();
            }
        }

        public Color OnHoverColor
        {
            get
            {
                return onHoverColor;
            }
            set
            {
                onHoverColor = value;
                Invalidate();
            }
        }

        public Color OnHoverTextColor
        {
            get
            {
                return onHoverTextColor;
            }
            set
            {
                onHoverTextColor = value;
                Invalidate();
            }
        }

        public Color ActiveColor
        {
            get
            {
                return selectedBackColor;
            }
            set
            {
                selectedBackColor = value;
                Invalidate();
            }
        }

        public Color ActiveTextColor
        {
            get
            {
                return selectedForeColor;
            }
            set
            {
                selectedForeColor = value;
                Invalidate();
            }
        }


        public SizeF ImageSize
        {
            get
            {
                return imageSize;
            }
            set
            {
                imageSize = value;
                Invalidate();
            }
        }
    }
}
