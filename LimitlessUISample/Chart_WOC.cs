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

namespace LimitlessUISample
{
    public partial class Chart_WOC : Control
    {
        private int _lineThikness = 1;
        private int _chartLineThinkness = 3;
        private int _minYValue = 0;
        private int _maxYValue = 100;
        private int _valueInterval = 50;
        private int _chartLength = 100;
        private bool _hovering = false;
        private List<Serie> _series = new List<Serie>();
        private PointF _chartArea = new PointF(0, 0);
        private float _xLineIncrement;

        private class Serie
        {
            public List<int> values = new List<int>();
            public Color lineColor = Color.Black;

            public Serie(Color lineColor)
            {
                this.lineColor = lineColor;
            }
        }
        public Chart_WOC()
        {
            DoubleBuffered = true;
            MouseHover += onMouseHover;
            MouseEnter += onMouseEnter;
            MouseLeave += onMouseLeave;
            SizeChanged += onSizeChanged;
            calculateConsts();
        }

        private void onSizeChanged(object sender, EventArgs e)
        {
            calculateConsts();
        }

        private void onMouseLeave(object sender, EventArgs e)
        {
            _hovering = false;
        }

        private void onMouseEnter(object sender, EventArgs e)
        {
            _hovering = true;
        }

        private void onMouseHover(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            calculateConsts();
            Invalidate();
        }

        private void drawChartArea(Graphics g, Pen pen1, float chartAreaLength, float labelsCountY)
        {
            g.TranslateTransform(Padding.Left, Height - Padding.Bottom);
            g.DrawLine(pen1, 0, 0, chartAreaLength, 0);
            g.DrawLine(pen1, 0, 0, 0, -(Height - Padding.Top - Padding.Bottom));

            float yLabelsCord = 0;
            for (int i = 0; i <= labelsCountY; i++)
            {
                string label = (i * _valueInterval).ToString();
                SizeF labelSize = g.MeasureString(label, Font);
                g.DrawString(label, Font, new SolidBrush(ForeColor), -labelSize.Width, -(yLabelsCord + labelSize.Height / 2));
                yLabelsCord += (Height - Padding.Top - Padding.Bottom) / labelsCountY;
            }
        }

        private void calculateConsts()
        {
            _chartArea.X = Width - Padding.Right - Padding.Left;
            _chartArea.Y = Height - Padding.Top - Padding.Bottom;
            _xLineIncrement = _chartArea.X / _chartLength;
        }
        private void drawMouseLine(Graphics g, Pen pen)
        {
            if (_hovering)
            {
                pen.Color = ForeColor;
                Point cor = PointToClient(Cursor.Position);
                g.DrawLine(pen, cor.X - Padding.Left, 0, cor.X - Padding.Left, -_chartArea.Y);
                
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Pen pen1 = new Pen(ForeColor, _lineThikness);

            drawChartArea(g, pen1, _chartArea.X, (_maxYValue - _minYValue) / _valueInterval);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;                 //check
            pen1.Width = _chartLineThinkness;
            foreach (Serie serie in _series)
            {
                pen1.Color = serie.lineColor;
                float xLineCord = 0;
                PointF lastPoint = new PointF(0, 0);

                foreach (int yVal in serie.values)
                {
                    PointF point = new PointF(xLineCord, -yVal);
                    g.DrawLine(pen1, lastPoint, point);
                    lastPoint = point;
                    xLineCord += _xLineIncrement;
                }
            }
            drawMouseLine(g, pen1);
        }

        public void addSerie(Color lineColor)
        {
            _series.Add(new Serie(lineColor));
        }
        public void addValue(int serie, int value)
        {
            List<int> values = _series.ElementAt(serie).values;
            values.Add(value);
            Invalidate();
            if (_chartLength < values.Count)
                values.Remove(values.First());
        }

    }
}
