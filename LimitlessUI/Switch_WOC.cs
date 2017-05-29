using System;
using System.Drawing;
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
    public partial class Switch_WOC : Control
    {
        private bool _textEnabled = true;
        private bool _isOn = true;

        private Color _onColor = Color.SeaGreen;
        private Color _offColor = Color.DarkGray;

        private string _onText = "On";
        private string _offText = "Off";

        public Switch_WOC()
        {
            Click += click;
            DoubleClick += click;

            BackColor = Color.FromArgb(64, 64, 64);
            ForeColor = Color.FromArgb(224, 224, 224);
            Width = 51;
            Height = 18;
            DoubleBuffered = true;
        }

        private void click(object sender, EventArgs e)
        {
            _isOn = !_isOn;
            Invalidate();
        }

        private void drawString(PaintEventArgs pe, bool isOn)
        {
            SizeF stringSize = pe.Graphics.MeasureString(isOn ? _onText : _offText, Font);
            float drawHeight = Height / 2 - stringSize.Height / 2;

            if (isOn)
            {
                float drawWidth = Width / 2 + (Width / 4) - stringSize.Width / 2;
                pe.Graphics.DrawString(_onText, Font, new SolidBrush(ForeColor), drawWidth, drawHeight);
            }
            else
            {
                float drawWidth = Width / 2 - (Width / 4) - stringSize.Width / 2;
                pe.Graphics.DrawString(_offText, Font, new SolidBrush(ForeColor), drawWidth, drawHeight);
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Pen pen1 = new Pen(BackColor, Height);
            Pen pen2 = new Pen(_isOn ? _onColor : _offColor, Height);

            pe.Graphics.DrawLine(pen1, 0, Height / 2, Width, Height / 2);
            if (_isOn)
                pe.Graphics.DrawLine(pen2, 0, Height / 2, Width / 2, Height / 2);
            else
                pe.Graphics.DrawLine(pen2, Width / 2, Height / 2, Width, Height / 2);

            if (_textEnabled)
                drawString(pe, _isOn);

            pen1.Dispose();
            pen2.Dispose();
        }

        #region Getters and Setters
        public bool IsOn
        {
            get { return _isOn; }
            set
            {
                _isOn = value;
                Invalidate();
            }
        }

        public bool TextEnabled
        {
            get { return _textEnabled; }
            set
            {
                _textEnabled = value;
                Invalidate();
            }
        }

        public Color OnColor
        {
            get { return _onColor; }
            set
            {
                _onColor = value;
                Invalidate();
            }
        }

        public Color OffColor
        {
            get { return _offColor; }
            set
            {
                _offColor = value;
                Invalidate();
            }
        }

        public string OnText
        {
            get { return _onText; }
            set
            {
                _onText = value;
                Invalidate();
            }
        }

        public string OffText
        {
            get { return _offText; }
            set
            {
                _offText = value;
                Invalidate();
            }
        }
        #endregion
    }
}
