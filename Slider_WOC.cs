using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUI
{
    public partial class Slider_WOC : Control
    {
        public delegate void onValueChangedEvent(float value);
        public event onValueChangedEvent onValueChanged;
        Color backgroundColor = Color.DarkGray;

        private float circleSize = 20;
        private float backLineThikness = 10;
        private float frontLineThikness = 10;
        private float xCord = 50;
        private float maxValue = 100;
        private bool drag = false;
        private bool drawCircle = true;
        private int increament = 10;

        public Slider_WOC()
        {
            ForeColor = Color.SeaGreen;
            DoubleBuffered = true;
            MouseDown += onClick;
            MouseUp += onMouseUp;
            MouseMove += onMouseMove;
            MouseWheel += onScroll;
        }

        private void onScroll(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                if (e.Delta > 0 && xCord <= Width - circleSize / 2)
                    xCord += increament;
                else if (e.Delta < 0 && xCord > circleSize / 2)
                    xCord -= increament;

                if (xCord > Width - circleSize)
                    xCord = Width - circleSize;
                else if (xCord < circleSize / 2)
                    xCord = 0;
                Invalidate();
                if (onValueChanged != null)
                    onValueChanged.Invoke(Value);
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void onMouseMove(object sender, MouseEventArgs e)
        {
            if (drag && e.X >= circleSize / 2 && e.X <= Width - circleSize / 2)
                xCord = e.X - circleSize / 2;
            else if (drag && e.X < circleSize / 2)
                xCord = 0;
            else if (drag && e.X > Width - circleSize / 2)
                xCord = Width - circleSize;

            if (onValueChanged != null)
                onValueChanged.Invoke(Value);

            Invalidate();
        }

        private void onClick(object sender, MouseEventArgs e)
        {
            drag = true;
            xCord = e.X;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pe.Graphics.DrawLine(new Pen(backgroundColor, backLineThikness), circleSize / 2, Height / 2, Width - circleSize / 2, Height / 2);
            pe.Graphics.DrawLine(new Pen(ForeColor, frontLineThikness), circleSize / 2, Height / 2, circleSize / 2 + xCord, Height / 2);
            if (drawCircle)
                pe.Graphics.FillEllipse(new SolidBrush(ForeColor), xCord, Height / 2 - circleSize / 2, circleSize, circleSize);
        }

        public float Value
        {
            get
            {
                return xCord / ((Width - circleSize) / maxValue);
            }
            set
            {

                this.xCord = value * ((Width - circleSize) / maxValue);
                Invalidate();

            }
        }

        public bool DrawCircle
        {
            get { return drawCircle; }
            set
            {
                drawCircle = value;
                Invalidate();
            }
        }

        public float MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                Invalidate();
            }
        }
        public float CircleSize
        {
            get { return circleSize; }
            set
            {
                circleSize = value;
                Invalidate();
            }
        }
        public float BackLineThikness
        {
            get { return backLineThikness; }
            set
            {
                backLineThikness = value;
                Invalidate();
            }
        }

        public float FrontLineThikness
        {
            get { return frontLineThikness; }
            set
            {
                frontLineThikness = value;
                Invalidate();
            }
        }
    }
}
