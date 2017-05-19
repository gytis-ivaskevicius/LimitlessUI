using System;
using System.Drawing;
using System.Windows.Forms;
using static LimitlessUISample.Chart_WOC;

namespace LimitlessUISample
{
    public partial class Legend_WOC : ListView_WOC
    {
        private Chart_WOC _chart;
        private Color _textColor = Color.Empty;

        public Legend_WOC()
        {
            Vertical = false;
        }

        public void notifySeriesChanged()
        {
            clear();
            foreach (Serie s in _chart.series)
                add(new LegendChild_WOC(s, Font, _textColor, Height, _chart));
        }


        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }

        public Chart_WOC Chart
        {
            get { return _chart; }
            set { _chart = value; }
        }

        //-------------------------------------[Legendary Child :D ]-------------------------------------//
        private class LegendChild_WOC : Control
        {
            private int _recSize = 10;
            private Color _textColor;
            private Serie _serie;
            private Chart_WOC _chart;

            public LegendChild_WOC(Serie serie, Font font, Color textColor, int height, Chart_WOC chart)
            {
                Text = serie.name;
                Font = font;
                ForeColor = serie.lineColor;
                Width = 100;
                _chart = chart;
                _serie = serie;
                _textColor = textColor == Color.Empty ? ForeColor : textColor;
                Font = new Font(Font, _serie.selected ? FontStyle.Bold : FontStyle.Regular);

                Click += click;
                DoubleClick += click;
            }

            private void click(object sender, EventArgs e)
            {
                _serie.selected = !_serie.selected;
                Font = new Font(Font, _serie.selected ? FontStyle.Bold : FontStyle.Regular);
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);
                Graphics g = pe.Graphics;
                Pen p = new Pen(ForeColor);
                drawLabel(g, p);

                p.Dispose();
            }

            private void drawLabel(Graphics g, Pen p)
            {
                SizeF labelSize = g.MeasureString(Text, Font);
                SolidBrush s = new SolidBrush(ForeColor);
                g.FillRectangle(s, (Height - _recSize) / 2, (Height - _recSize) / 2, _recSize, _recSize);
                s.Color = _textColor;
                g.DrawString(Text, Font, s, Height - 5, (Height - labelSize.Height) / 2);
                Width = Height + (int)labelSize.Width;
            }
        }
    }
}
