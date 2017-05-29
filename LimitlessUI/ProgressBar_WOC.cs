using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


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
    public partial class ProgressBar_WOC : Control
    {
        private Color _progressBackColor = Color.Silver;
        private int _progress = 50;

        private float _line1Thikness = 10;
        private float _line2Thikness = 20;
        private float _extraPadding = 0;

        private bool _rounded = true;
        private bool _smoothing = true;

        public ProgressBar_WOC()
        {
            this.DoubleBuffered = true;
            ForeColor = Color.Chartreuse;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (_smoothing)
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float progressWidth = this.Width;
            float progressToDraw = ((progressWidth - Padding.Left - Padding.Right) / 100) * _progress;
            float progressNotToDraw = (progressWidth - Padding.Left - Padding.Right) - progressToDraw;
            float drawHeight = this.Height / 2;

            Pen penOne = new Pen(_progressBackColor, _line1Thikness);
            Pen penTwo = new Pen(ForeColor, _line2Thikness);

            if (_rounded)
            {
                penTwo.StartCap = LineCap.Round;
                penTwo.EndCap = LineCap.Round;

                penOne.StartCap = LineCap.Round;
                penOne.EndCap = LineCap.Round;

                _extraPadding = _line2Thikness / 2;
            }
            else
                _extraPadding = 0;

            pe.Graphics.DrawLine(penOne, ((float)Padding.Left) + _extraPadding, drawHeight, ((float)this.Width - Padding.Right) - _extraPadding, drawHeight);
            if (Value != 0)
                pe.Graphics.DrawLine(penTwo, Padding.Left + _extraPadding, drawHeight, this.Width - ((float)Padding.Right) - progressNotToDraw - _extraPadding, drawHeight);

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
            get { return _progress; }
            set
            {
                if (value != _progress)
                {
                    _progress = value;
                    Invalidate();
                }
            }
        }

        public Color ProgressBackColor
        {
            get { return _progressBackColor; }
            set
            {
                _progressBackColor = value;
                Invalidate();
            }
        }

        public bool Rounded
        {
            get { return _rounded; }
            set
            {
                _rounded = value;
                Invalidate();
            }
        }

        public bool Smooth
        {
            get { return _smoothing; }
            set
            {
                _smoothing = value;
                Invalidate();
            }
        }

        public float BackLineThikness
        {
            get { return _line1Thikness; }
            set
            {
                _line1Thikness = value;
                Invalidate();
            }
        }

        public float FrontLineThikness
        {
            get { return _line2Thikness; }
            set
            {
                _line2Thikness = value;
                Invalidate();
            }
        }
    }
}
