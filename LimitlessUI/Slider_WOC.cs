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
    public class Slider_WOC : Control
    {
        public delegate void OnValueChangedEvent(Slider_WOC slider, float value);
        public event OnValueChangedEvent OnValueChanged;

        private float _circleSize = 20;
        private float _backLineThikness = 10;
        private float _frontLineThikness = 10;
        private float _xCord = 50;
        private float _maxValue = 100;

        private bool _drag;
        private bool _drawCircle = true;
        private bool _rounded;

        private int _increament = 10;
        private Color _backgroundColor = Color.Silver;

        public Slider_WOC()
        {
            ForeColor = Color.SeaGreen;
            DoubleBuffered = true;
            MouseDown += OnClick;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
            MouseWheel += OnScroll;
        }

        private void OnScroll(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                if (e.Delta > 0 && _xCord <= Width - _circleSize / 2)
                    _xCord += _increament;
                else if (e.Delta < 0 && _xCord > _circleSize / 2)
                    _xCord -= _increament;

                if (_xCord > Width - _circleSize)
                    _xCord = Width - _circleSize;
                else if (_xCord < _circleSize / 2)
                    _xCord = 0;
                Invalidate();
                OnValueChanged?.Invoke(this, Value);
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e) => _drag = false;


        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_drag && e.X >= _circleSize / 2 && e.X <= Width - _circleSize / 2)
                _xCord = e.X - _circleSize / 2;
            else if (_drag && e.X < _circleSize / 2)
                _xCord = 0;
            else if (_drag && e.X > Width - _circleSize / 2)
                _xCord = Width - _circleSize;

            OnValueChanged?.Invoke(this, Value);

            Invalidate();
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            _drag = true;
            _xCord = e.X;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var penOne = new Pen(_backgroundColor, _backLineThikness);
            var penTwo = new Pen(ForeColor, _frontLineThikness);

            if (_rounded)
            {
                penTwo.StartCap = LineCap.Round;
                penTwo.EndCap = LineCap.Round;

                penOne.StartCap = LineCap.Round;
                penOne.EndCap = LineCap.Round;
            }
            pe.Graphics.DrawLine(penOne, _circleSize / 2, Height / 2f, Width - _circleSize / 2, Height / 2f);
            pe.Graphics.DrawLine(penTwo, _circleSize / 2, Height / 2f, _circleSize / 2 + _xCord, Height / 2f);
            if (_drawCircle)
                pe.Graphics.FillEllipse(new SolidBrush(ForeColor), _xCord, Height / 2f - _circleSize / 2, _circleSize,
                    _circleSize);
            penOne.Dispose();
            penTwo.Dispose();
        }

        #region Getters and Setters

        public Color BackLineColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                Invalidate();
            }
        }

        public float Value
        {
            get => _xCord / ((Width - _circleSize) / _maxValue);
            set
            {
                _xCord = value * ((Width - _circleSize) / _maxValue);
                Invalidate();
            }
        }

        public bool Rounded
        {
            get => _rounded;
            set
            {
                _rounded = value;
                Invalidate();
            }
        }

        public bool DrawCircle
        {
            get => _drawCircle;
            set
            {
                _drawCircle = value;
                Invalidate();
            }
        }

        public float MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                Invalidate();
            }
        }

        public float CircleSize
        {
            get => _circleSize;
            set
            {
                _circleSize = value;
                Invalidate();
            }
        }

        public float BackLineThikness
        {
            get => _backLineThikness;
            set
            {
                _backLineThikness = value;
                Invalidate();
            }
        }

        public float FrontLineThikness
        {
            get => _frontLineThikness;
            set
            {
                _frontLineThikness = value;
                Invalidate();
            }
        }

        #endregion
    }
}