using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;
using System.Diagnostics;

namespace LimitlessUI
{
    public partial class DropDown_WOC : Control
    {
        private float _textDistance = 35;

        private int _expandedControlHeight;
        private int _arrowSize = 25;
        private int _aniationLength = 300;
        private int _value;

        private bool _isExpanded = true;
        private bool _justUpdated = false;
        private Image _image;
        private Control _control;
        private AnimatorTimer_WOC _animationTimer;
        private float _proportion;
        private float _arrowAngle;

        public DropDown_WOC()
        {
            DoubleBuffered = true;
            _animationTimer = new AnimatorTimer_WOC();
            _animationTimer.onAnimationTimerTick += (int value) =>
            {
                _control.FindForm().SuspendLayout();
                _value = value;
                _control.Height = value;
                _control.FindForm().ResumeLayout();
                _justUpdated = true;
                Invalidate();
            };

            Click += click;
            DoubleClick += click;
        }

        private void click(object sender, EventArgs e)
        {
            _animationTimer.setValueRange(_isExpanded ? 0 : _expandedControlHeight, _control.Height, _aniationLength, true);
            _isExpanded = !_isExpanded;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            SizeF textSize = pe.Graphics.MeasureString(Text, Font);
            pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), _textDistance, Height / 2 - (textSize.Height / 2));

            if (_justUpdated)
            {
                _justUpdated = false;
                _arrowAngle = 180 - (_value / _proportion);
            }

            pe.Graphics.TranslateTransform(Height / 2, Height / 2);
            pe.Graphics.RotateTransform(_arrowAngle);
            pe.Graphics.TranslateTransform(-Height / 2, -Height / 2);

            if (_image != null)
                pe.Graphics.DrawImage(_image, (Height - _arrowSize) / 2, (Height - _arrowSize) / 2, _arrowSize, _arrowSize);
        }

        #region Getters and Setters

        public int AnimationLength
        {
            get { return _aniationLength; }
            set { _aniationLength = value; }
        }

        public Image Image
        {
            get { return _image; }
            set { _image = value; Invalidate(); }
        }

        public int ArrowSize
        {
            get { return _arrowSize; }
            set
            {
                _arrowSize = value;
                Invalidate();
            }
        }

        public Control Control
        {
            get { return _control; }
            set
            {
                _control = value;
                _expandedControlHeight = _control.Height;
                _proportion = _expandedControlHeight / 180F;
                Invalidate();
            }
        }
        #endregion
    }
}

