using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;


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
    public class DropDown_WOC : Control
    {
        private float _textDistance = 35;
        private float _proportion;
        private float _arrowAngle;

        private int _expandedControlHeight;
        private int _arrowSize = 25;
        private int _value;

        private bool _isExpanded = true;
        private bool _updated;
        private Image _image;
        private Control _control;
        private readonly AnimatorTimer_WOC _animationTimer;
        private Point _textOffset;

        public DropDown_WOC()
        {
            DoubleBuffered = true;
            _animationTimer = new AnimatorTimer_WOC(Utils_WOC.getFormForThreading());
            _animationTimer.OnAnimationTimerTick += (value) =>
            {
                _control.FindForm().SuspendLayout();
                _value = value;
                _control.Height = value;
                _control.FindForm().ResumeLayout();
                _updated = true;
                Invalidate();
            };

            DoubleClick += (s, e) => OnClick(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _animationTimer.SetValueRange(_isExpanded ? 0 : _expandedControlHeight, _control.Height, AnimationLength,
                true);
            _isExpanded = !_isExpanded;
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var textSize = pe.Graphics.MeasureString(Text, Font);
            pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), TextOffset.X + _textDistance,
                Height / 2f - (textSize.Height / 2) + TextOffset.Y);

            if (_updated)
            {
                _updated = false;
                _arrowAngle = 180 - (_value / _proportion);
            }

            pe.Graphics.TranslateTransform(Height / 2f, Height / 2f);
            pe.Graphics.RotateTransform(_arrowAngle);
            pe.Graphics.TranslateTransform(-Height / 2f, -Height / 2f);

            if (_image != null)
                pe.Graphics.DrawImage(_image, (Height - _arrowSize) / 2, (Height - _arrowSize) / 2, _arrowSize,
                    _arrowSize);
        }

        #region Getters and Setters

        public Point TextOffset
        {
            get => _textOffset;
            set
            {
                _textOffset = value;
                Invalidate();
            }
        }

        public int AnimationLength { get; set; } = 300;

        public Image Image
        {
            get => _image;
            set
            {
                _image = value;
                Invalidate();
            }
        }

        public int ArrowSize
        {
            get => _arrowSize;
            set
            {
                _arrowSize = value;
                Invalidate();
            }
        }

        public Control Control
        {
            get => _control;
            set
            {
                if (value != null)
                {
                    _control = value;
                    _expandedControlHeight = value.Height;
                    _proportion = _expandedControlHeight / 180F;
                    Invalidate();
                }
            }
        }

        #endregion
    }
}