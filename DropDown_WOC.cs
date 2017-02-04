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
    public partial class DropDown_WOC : Control
    {
        private bool pointsDown = true;
        private float thikness = 2F;
        private SizeF arrowSize = new SizeF(10, 10);
        private float textDistance = 35;
        private Control panel;
        private int expandedPanelHeight;


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            pointsDown = !pointsDown;
            if (!pointsDown)
            {
                expandedPanelHeight = panel.Height;
                panel.Height = 0;
            }
            else
                panel.Height = expandedPanelHeight;
            Invalidate();
        }

        private void drawArrow(PaintEventArgs pe, float x, float y, float height, float width, bool pointsDown)
        {
            y = y - height / 2;
            if (!pointsDown)
            {
                pe.Graphics.DrawLine(new Pen(ForeColor, thikness), x, y + height / 2, x + width / 2, y + height);
                pe.Graphics.DrawLine(new Pen(ForeColor, thikness), x + width / 2, y + height, x + width, y + height / 2);
            }
            else
            {
                pe.Graphics.DrawLine(new Pen(ForeColor, thikness), x, y + height, x + width / 2, y + height / 2);
                pe.Graphics.DrawLine(new Pen(ForeColor, thikness), x + width / 2, y + height / 2, x + width, y + height);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            SizeF textSize = pe.Graphics.MeasureString(Text, Font);
            float padding = (Height - textSize.Height) / 2;
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textDistance, Height / 2 - (textSize.Height / 2));
            drawArrow(pe, padding, padding + arrowSize.Height / 2, arrowSize.Height, arrowSize.Width, pointsDown);
            base.OnPaint(pe);
        }

        public SizeF ArrowSize
        {
            get
            {
                return arrowSize;
            }
            set
            {
                arrowSize = value;
                Invalidate();
            }
        }

        public float ArrowThinkness
        {
            get
            {
                return thikness;
            }
            set
            {
                thikness = value;
                Invalidate();
            }
        }

        public float TextDistance
        {
            get
            {
                return textDistance;
            }
            set
            {
                textDistance = value;
                Invalidate();
            }
        }

        public Control SetLayout
        {
            get
            {
                return panel;
            }
            set
            {
                panel = value;
                Invalidate();
            }
        }
    }
}
