using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



/*
End-User Licence Agreement (EULA) for WithoutCaps Software 

This version is current as of May 27, 2017. Please consult withoutcapsdev@gmail.com for new versions of this EULA.

You can only use software made by the WithoutCaps Team after you agree to this licence. By using this software, you agree to 
all of the clauses in the WithoutCaps Software EULA.

PLEASE READ CAREFULLY BEFORE USING THIS PRODUCT: This End-User Licence Agreement(EULA) is a legal agreement between you 
(either an individual or as a single entity) and the entity is known as the WithoutCaps Team.

(a) Introduction. This is the End-User Licence Agreement (EULA) for this software which is produced by the WithoutCaps Team. 
This EULA outlines the clauses of the licence that the WithoutCapsTeam is willing to grant you (the user) to use this software. 

(b) Licence. The entity known as the WithoutCaps Team will grant a free of charge, fully-revocable, non-exclusive, non-transferable 
licence to any person obtaining a copy of this software as well as the associated documentation. The aforementioned documentation 
consists of the End-User Licence Agreement (EULA) for products made by the WithoutCaps Team. This licence permits you to use, modify 
and re-distribute this software non-commercially so long as you (either an individual or as a single entity) has permission from the 
WithoutCaps Team to do so. If the user wants to re-distribute software made by the WithoutCaps Team this EULA must be included in the 
software package.

(c) Ownership. Software produced by the WithoutCaps Team is licenced, not sold, to you (either an individual or as a single entity) 
and as such the WithoutCaps Software Team reserves any rights not expressly granted to you (either an individual or as a single entity).

The WithoutCaps Team reserves the right to revoke any persons (either an individual or as a single entity) licence without previous notification or agreements.

Notwithstanding the terms and conditions of this EULA, any part of the software contained with product by the WithoutCaps Team which 
constitutes Third Party Software and as such now owned is licenced to you subject to the terms and conditions of the software licence 
agreement accompanying such Third Party Software. Whatever the form of the licence, whether it be in the form of a discrete agreement, 
shrink wrap licence or electronic licence terms are accepted at the time of download or purchase of any software made by the WithoutCaps Team.

(d) Limitation of Liability. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) 2017 WithoutCaps
*/

namespace LimitlessUI
{
    public partial class Slider_WOC : Control
    {
        public delegate void onValueChangedEvent(Slider_WOC slider, float value);
        public event onValueChangedEvent onValueChanged;

        private float _circleSize = 20;
        private float _backLineThikness = 10;
        private float _frontLineThikness = 10;
        private float _xCord = 50;
        private float _maxValue = 100;

        private bool _drag = false;
        private bool _drawCircle = true;
        private bool _rounded = false;

        private int _increament = 10;
        private Color _backgroundColor = Color.Silver;

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
                if (e.Delta > 0 && _xCord <= Width - _circleSize / 2)
                    _xCord += _increament;
                else if (e.Delta < 0 && _xCord > _circleSize / 2)
                    _xCord -= _increament;

                if (_xCord > Width - _circleSize)
                    _xCord = Width - _circleSize;
                else if (_xCord < _circleSize / 2)
                    _xCord = 0;
                Invalidate();
                if (onValueChanged != null)
                    onValueChanged.Invoke(this, Value);
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            _drag = false;
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            if (_drag && e.X >= _circleSize / 2 && e.X <= Width - _circleSize / 2)
                _xCord = e.X - _circleSize / 2;
            else if (_drag && e.X < _circleSize / 2)
                _xCord = 0;
            else if (_drag && e.X > Width - _circleSize / 2)
                _xCord = Width - _circleSize;

            if (onValueChanged != null)
                onValueChanged.Invoke(this, Value);

            Invalidate();
        }

        private void onClick(object sender, MouseEventArgs e)
        {
            _drag = true;
            _xCord = e.X;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen penOne = new Pen(_backgroundColor, _backLineThikness);
            Pen penTwo = new Pen(ForeColor, _frontLineThikness);

            if (_rounded)
            {
                penTwo.StartCap = LineCap.Round;
                penTwo.EndCap = LineCap.Round;

                penOne.StartCap = LineCap.Round;
                penOne.EndCap = LineCap.Round;
            }
            pe.Graphics.DrawLine(penOne, _circleSize / 2, Height / 2, Width - _circleSize / 2, Height / 2);
            pe.Graphics.DrawLine(penTwo, _circleSize / 2, Height / 2, _circleSize / 2 + _xCord, Height / 2);
            if (_drawCircle)
                pe.Graphics.FillEllipse(new SolidBrush(ForeColor), _xCord, Height / 2 - _circleSize / 2, _circleSize, _circleSize);
            penOne.Dispose();
            penTwo.Dispose();
        }

        #region Getters and Setters
        public Color BackLineColor
        {
            get { return _backgroundColor; }
            set
            {
                this._backgroundColor = value;
                Invalidate();
            }
        }

        public float Value
        {
            get { return _xCord / ((Width - _circleSize) / _maxValue); }
            set
            {
                this._xCord = value * ((Width - _circleSize) / _maxValue);
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

        public bool DrawCircle
        {
            get { return _drawCircle; }
            set
            {
                _drawCircle = value;
                Invalidate();
            }
        }

        public float MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                Invalidate();
            }
        }

        public float CircleSize
        {
            get { return _circleSize; }
            set
            {
                _circleSize = value;
                Invalidate();
            }
        }

        public float BackLineThikness
        {
            get { return _backLineThikness; }
            set
            {
                _backLineThikness = value;
                Invalidate();
            }
        }

        public float FrontLineThikness
        {
            get { return _frontLineThikness; }
            set
            {
                _frontLineThikness = value;
                Invalidate();
            }
        }
        #endregion
    }
}
