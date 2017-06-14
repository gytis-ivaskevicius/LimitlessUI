using System;
using System.Drawing;
using System.Windows.Forms;
using static LimitlessUI.Chart_WOC;



/*
End-User Licence Agreement (EULA) for WithoutCaps Software 

This version is current as of May 27, 2017. Please consult withoutcapsdev@gmail.com for any new versions of this EULA.

You can only use the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team after you agree to this licence. By using this software, you agree to all of the clauses in the WithoutCaps Software EULA.

PLEASE READ CAREFULLY BEFORE USING THIS PRODUCT: This End-User Licence Agreement(EULA) is a legal agreement between you (either an individual or as a single entity) and the entity that is known as the WithoutCaps Team.

(a) Introduction. This is the End-User Licence Agreement (EULA) for the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team. This EULA outlines the clauses of the licence that the WithoutCaps Team is willing to grant you (either as an individual or as a single entity) to use this software.

(b) Licence. The entity known as the WithoutCaps Team will grant a free of charge, fully-revocable, non-exclusive, non-transferable licence to any person obtaining a copy of the software known as "LimitlessUI" as well as the associated documentation. The aforementioned documentation consists of the End-User Licence Agreement (EULA) for the product known as "LimitlessUI" which is currently maintained by the WithoutCaps Team. This licence permits you to use, modify and re-distribute this software non-commercially so long as you (either an individual or as a single entity) has permission from the WithoutCaps Team to do so. If the user wants to re-distribute software made by the WithoutCaps Team this EULA must be included in the software package.

(c) Ownership. The software known as "LimitlessUI" and produced by the WithoutCaps Team is licenced, not sold, to you (either an individual or as a single entity) and as such the WithoutCaps Software Team reserves any rights not explicitly granted to you (either an individual or as a single entity).

The WithoutCaps Team also reserves the right to revoke any persons (either an individual or as a single entity) licence without previous notification or agreements as long as said the person (either an individual or as a single entity) didn't adhere to the End-User Licence Agreement (EULA) distributed with this software.

Notwithstanding the terms and conditions of this EULA, any part of the software contained within the product known as "LimitlessUI" which is currently maintained by the WithoutCaps Team which constitutes Third Party Software and as such now is licenced to you subject to the terms and conditions of the software licence agreement accompanying such Third Party Software. Whatever the form of the licence, whether it be in the form of a discrete agreement, shrink wrap licence or electronic licence terms are accepted at the time of acceptance of the End-User Licence Agreement for the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team.

(d) Limitation of Liability. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) 2017 WithoutCaps
*/


namespace LimitlessUI
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
        public class LegendChild_WOC : Control
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
