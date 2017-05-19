using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LimitlessUISample
{
    public partial class Chart_WOC : Control
    {
        private int _lineThikness = 1;
        private int _chartLineThikness = 3;
        private int _minYValue = 0;
        private int _maxYValue = 100;
        private int _valueInterval = 50;
        private int _chartLength = 100;

        private bool _hovering = false;
        private float _xLineIncrement;

        private PointF _chartArea = new PointF(0, 0);
        public List<Serie> series = new List<Serie>();


        public Chart_WOC()
        {
            ForeColor = Color.FromArgb(42, 42, 42);
            DoubleBuffered = true;
            PaddingChanged += (object sender, EventArgs e) =>
            {
                calculateConsts();
                Invalidate();
            };
            MouseMove += (object sender, MouseEventArgs e) => Invalidate();
            MouseEnter += (object sender, EventArgs e) => _hovering = true;
            MouseLeave += (object sender, EventArgs e) => { _hovering = false; Invalidate(); };
            SizeChanged += (object sender, EventArgs e) => calculateConsts();
            calculateConsts();
        }


        private void calculateConsts()
        {
            _chartArea.X = Width - Padding.Right - Padding.Left;
            _chartArea.Y = Height - Padding.Top - Padding.Bottom;
            _xLineIncrement = _chartArea.X / _chartLength;
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

        private void drawMouseLine(Graphics g, Pen pen)
        {
            Point cor = PointToClient(Cursor.Position);
            float a = (cor.X - Padding.Left) / _xLineIncrement;
            int element = (int)Math.Round(a);

            if (_hovering && element > 0 && cor.X < _chartArea.X + Padding.Left)
            {
                pen.Color = ForeColor;
                pen.Width = 1F;
                g.DrawLine(pen, cor.X - Padding.Left, 0, cor.X - Padding.Left, -_chartArea.Y);

                float lastY = -_chartArea.Y;
                foreach (Serie serie in series)
                    if (serie.selected && element < serie.values.Count)
                    {
                        String s = serie.values.ElementAt(element).ToString();
                        SizeF strSize = g.MeasureString(s, Font);
                        SolidBrush brush = new SolidBrush(ForeColor);

                        float mouseXPos = cor.X - Padding.Left;
                        float labelSizeByTwo = strSize.Height / 2;

                        pen.Color = ForeColor;
                        pen.Width = 1;

                        g.DrawLine(pen, mouseXPos, lastY + labelSizeByTwo, mouseXPos - 10, lastY + labelSizeByTwo);
                        g.DrawString(s, Font, new SolidBrush(Color.Black), mouseXPos - 12 - strSize.Width, lastY);

                        pen.Color = serie.lineColor;
                        pen.Width = 2;
                        g.DrawLine(pen, mouseXPos - 10, lastY + 1, mouseXPos - 10, lastY + strSize.Height - 1);
                        lastY += strSize.Height;
                    }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Pen pen1 = new Pen(ForeColor, _lineThikness);

            drawChartArea(g, pen1, _chartArea.X, (_maxYValue - _minYValue) / _valueInterval);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;                 //check
            pen1.Width = _chartLineThikness;
            foreach (Serie serie in series)
            {
                pen1.Color = serie.lineColor;
                float xLineCord = 0;
                PointF lastPoint;
                if (serie.values.Count != 0)
                    lastPoint = new PointF(0, -serie.values.First());
                foreach (int yVal in serie.values)
                {
                    PointF point = new PointF(xLineCord, -yVal);
                    g.DrawLine(pen1, lastPoint, point);
                    lastPoint = point;
                    xLineCord += _xLineIncrement;
                }
            }
            drawMouseLine(g, pen1);

            pen1.Dispose();
        }

        public void addSerie(Color lineColor, string name, bool selected)
        {
            series.Add(new Serie(lineColor, name, selected));
        }

        public void addValue(int serie, int value)
        {
            List<int> values = series.ElementAt(serie).values;
            values.Add(value);
            Invalidate();
            if (_chartLength < values.Count)
                values.Remove(values.First());
        }
        #region Getters and Setters


        public int LineThikness
        {
            get { return _lineThikness; }
            set { _lineThikness = value; Invalidate(); }
        }

        public int ChartLineThikness
        {
            get { return _chartLineThikness; }
            set { _chartLineThikness = value; Invalidate(); }
        }

        public int MinYValue
        {
            get { return _minYValue; }
            set { _minYValue = value; Invalidate(); }
        }

        public int MaxYValue
        {
            get { return _maxYValue; }
            set { _maxYValue = value; Invalidate(); }
        }

        public int ValueInterval
        {
            get { return _valueInterval; }
            set { _valueInterval = value; Invalidate(); }
        }

        public int ChartLength
        {
            get { return _chartLength; }
            set { _chartLength = value; Invalidate(); }
        }
        #endregion
        //-----------------------------------[Serie Class]-----------------------------------//
        public class Serie
        {
            public string name;
            public bool selected = true;
            public List<int> values = new List<int>();
            public Color lineColor = Color.Black;

            public Serie(Color lineColor, string name, bool selected)
            {
                this.lineColor = lineColor;
                this.name = name;
                this.selected = selected;
            }
        }
    }
}
