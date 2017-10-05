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
    public class ArchProgressBar_WOC : Control
    {
        public enum StyleEnum
        {
            Style1,
            Style2,
            Style3,
            Style4,
            None
        }

        private StyleEnum _style = StyleEnum.Style1;
        private Font _font1, _font2, _font3;
        private int _angle = 360;
        private Point _offset = new Point(0, 0);
        private bool _ignoreHeight = true;

        private string _text1 = "CPU";
        private string _text2 = "99%";
        private string _text3 = "55C";

        private float _progress = 50;
        private float _line1Thinkness = 5;
        private float _line2Thinkness = 9;

        private Color _color1 = Color.Silver;
        private Color _color2 = Color.Lime;
        private Color _text1Color = DefaultForeColor;
        private Color _text2Color = DefaultForeColor;
        private Color _text3Color = DefaultForeColor;


        public ArchProgressBar_WOC()
        {
            DoubleBuffered = true;
            _font1 = Font;
            _font2 = Font;
            _font3 = Font;
        }

        private void DrawContent(PaintEventArgs e, int angle)
        {
            e.Graphics.RotateTransform(-angle);
            var string1Size = e.Graphics.MeasureString(_text1, _font1);
            var string2Size = e.Graphics.MeasureString(_text2, _font2);
            var string3Size = e.Graphics.MeasureString(_text3, _font3);

            var radiusByTwo = (Width - ProgressLineThikness) / 2;
            var widthByTwo = Width / 2;
            var heightByTwo = (int) radiusByTwo;


            e.Graphics.TranslateTransform(-(_line2Thinkness / 2F + radiusByTwo), -(_line2Thinkness / 2F + radiusByTwo));

            switch (_style)
            {
                case StyleEnum.Style1:
                    e.Graphics.DrawString(_text1, _font1, new SolidBrush(_text1Color),
                        widthByTwo - string1Size.Width / 2 + _offset.X,
                        heightByTwo - string1Size.Height / 2 + _offset.Y);
                    break;
                case StyleEnum.Style2:
                    e.Graphics.DrawString(_text1, _font1, new SolidBrush(_text1Color),
                        widthByTwo - (string1Size.Width / 2) + _offset.X, heightByTwo - string1Size.Height + _offset.Y);
                    e.Graphics.DrawString(_text2, _font2, new SolidBrush(_text2Color),
                        widthByTwo - string2Size.Width / 2 + _offset.X, heightByTwo + _offset.Y);
                    break;
                case StyleEnum.Style3:
                    e.Graphics.DrawString(_text1, _font1, new SolidBrush(_text1Color),
                        widthByTwo - string1Size.Width / 2 + _offset.X, heightByTwo - string1Size.Height + _offset.Y);
                    e.Graphics.DrawString(_text2, _font2, new SolidBrush(_text2Color),
                        widthByTwo - string2Size.Width + _offset.X, heightByTwo + _offset.Y);
                    e.Graphics.DrawString(_text3, _font3, new SolidBrush(_text3Color), widthByTwo + _offset.X,
                        heightByTwo + _offset.Y);
                    break;
                case StyleEnum.Style4:
                    e.Graphics.DrawString(_text1, _font1, new SolidBrush(_text1Color),
                        widthByTwo - string1Size.Width / 2, widthByTwo - string1Size.Height / 2 + _offset.Y);
                    e.Graphics.DrawString(_text2, _font2, new SolidBrush(_text2Color),
                        _line2Thinkness / 2 - (string2Size.Width / 2) + _offset.X, widthByTwo + _offset.Y);
                    e.Graphics.DrawString(_text3, _font3, new SolidBrush(_text3Color),
                        Width - (_line2Thinkness / 2) - (string3Size.Width / 2) - _offset.X, widthByTwo + _offset.Y);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var pen1 = new Pen(_color1, _line1Thinkness);
            var pen2 = new Pen(_color2, _line2Thinkness);

            var circleRadius = _ignoreHeight
                ? (Width - ProgressLineThikness)
                : (Width > Height ? (Height - ProgressLineThikness) : (Width - ProgressLineThikness));
            var radiusByTwo = circleRadius / 2;
            var progressEndAngle = (_angle) / 100F;

            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.TranslateTransform(_line2Thinkness / 2F + radiusByTwo, _line2Thinkness / 2F + radiusByTwo);
            pe.Graphics.RotateTransform((360 - _angle) / 2 + 90);

            pe.Graphics.DrawArc(pen1, -radiusByTwo, -radiusByTwo, circleRadius, circleRadius, 0, _angle);
            pe.Graphics.DrawArc(pen2, -radiusByTwo, -radiusByTwo, circleRadius, circleRadius, 0,
                progressEndAngle * _progress);

            if (_style != StyleEnum.None)
                DrawContent(pe, (360 - _angle) / 2 + 90);

            pen1.Dispose();
            pen2.Dispose();
        }

        public void UpdateData(string text2, int progress)
        {
            _text2 = text2;
            _progress = progress;
            Invalidate();
        }

        public void UpdateData(string text2, string text3, int progress, Color text3Color)
        {
            _text2 = text2;
            _text3 = text3;
            _text3Color = text3Color;
            _progress = progress;
            Invalidate();
        }

        public void UpdateData(string text1 = "", string text2 = "", string text3 = "")
        {
            _text1 = text1;
            _text2 = text2;
            _text3 = text3;
            Invalidate();
        }

        #region Getters and Setters

        public bool IgnoreHeight
        {
            get => _ignoreHeight;
            set
            {
                _ignoreHeight = value;
                Invalidate();
            }
        }

        public Point Offset
        {
            get => _offset;
            set
            {
                _offset = value;
                Invalidate();
            }
        }

        public StyleEnum Style
        {
            get => _style;
            set
            {
                _style = value;
                Invalidate();
            }
        }

        public Font Font1
        {
            get => _font1;
            set
            {
                _font1 = value;
                Invalidate();
            }
        }

        public Font Font2
        {
            get => _font2;
            set
            {
                _font2 = value;
                Invalidate();
            }
        }

        public Font Font3
        {
            get => _font3;
            set
            {
                _font3 = value;
                Invalidate();
            }
        }

        public int Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                Invalidate();
            }
        }

        public float Value
        {
            get => _progress;
            set
            {
                if (value != _progress)
                {
                    _progress = value;
                    Invalidate();
                }
            }
        }

        public float BackLineThikness
        {
            get => _line1Thinkness;
            set
            {
                _line1Thinkness = value;
                Invalidate();
            }
        }

        public float ProgressLineThikness
        {
            get => _line2Thinkness;
            set
            {
                _line2Thinkness = value;
                Invalidate();
            }
        }

        public Color ProgressBackColor
        {
            get => _color1;
            set
            {
                _color1 = value;
                Invalidate();
            }
        }

        public Color ProgressColor
        {
            get => _color2;
            set
            {
                _color2 = value;
                Invalidate();
            }
        }

        public Color Text1Color
        {
            get => _text1Color;
            set
            {
                _text1Color = value;
                Invalidate();
            }
        }

        public Color Text2Color
        {
            get => _text2Color;
            set
            {
                _text2Color = value;
                Invalidate();
            }
        }

        public Color Text3Color
        {
            get => _text3Color;
            set
            {
                _text3Color = value;
                Invalidate();
            }
        }

        public string Text1
        {
            get => _text1;
            set
            {
                _text1 = value;
                Invalidate();
            }
        }

        public string Text2
        {
            get => _text2;
            set
            {
                _text2 = value;
                Invalidate();
            }
        }

        public string Text3
        {
            get => _text3;
            set
            {
                _text3 = value;
                Invalidate();
            }
        }

        #endregion
    }
}