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
    public partial class FlatButton_WOC : Control
    {
        private ContentAlignment _textAligment = ContentAlignment.MiddleLeft;
        private Image _image;
        private Image _selectedImage;
        private Point _offset = new Point(0, 0);
        private SizeF _imageSize = new SizeF(20, 20);

        private bool _selected = false;
        private bool _drawImage = false;
        private bool _drawText = true;
        private bool _mouseHovering = false;
        private bool _useActiveImageWhileHovering = false;

        private Color _selectedBackColor;
        private Color _selectedForeColor;
        private Color _onHoverColor;
        private Color _onHoverTextColor;

        public FlatButton_WOC()
        {
            DoubleBuffered = true;
            BackColor = Color.FromArgb(41, 53, 65);
            ForeColor = Color.White;
            Height = 50;
            Width = 220;

            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseExit;
            MouseClick += OnClick;
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            if (!_selected && IsTab)
            {
                BackColor = _selectedBackColor;
                ForeColor = _selectedForeColor;

                if (Parent != null)
                    foreach (Control control in Parent.Controls)
                        (control as FlatButton_WOC)?.Unselect();

                _selected = true;
            }
        }

        public void Unselect()
        {
            if (!_selected) return;

            _selected = false;
            BackColor = DefaultBackColor;
            ForeColor = DefaultForeColor;
        }

        private void OnMouseExit(object sender, EventArgs e)
        {
            _mouseHovering = false;
            if (!_selected)
            {
                BackColor = DefaultBackColor;
                ForeColor = DefaultForeColor;
                Invalidate();
            }
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            _mouseHovering = true;
            if (!_selected)
            {
                DefaultBackColor = BackColor;
                BackColor = _onHoverColor;

                DefaultForeColor = ForeColor;
                ForeColor = _onHoverTextColor;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (_drawText)
                DrawString(pe.Graphics, _textAligment.ToString());
            if (_drawImage && _image != null)
            {
                float drawHeight = Height / 2 - _imageSize.Height / 2;
                pe.Graphics.DrawImage(_selected ||
                                      (_mouseHovering && _useActiveImageWhileHovering)
                        ? (_selectedImage ?? _image)
                        : _image,
                    drawHeight, drawHeight, _imageSize.Width, _imageSize.Height);
            }
        }

        private void DrawString(Graphics g, string textAligment)
        {
            var stringSize = g.MeasureString(Text, Font);
            float drawX = _drawImage ? Height + _offset.X : _offset.X;
            float drawY = _offset.Y;

            if (textAligment.Contains("Middle"))
                drawY += Height / 2 - stringSize.Height / 2;
            else if (textAligment.Contains("Bottom"))
                drawY += Height - stringSize.Height;

            if (textAligment.Contains("Center"))
                drawX += Width / 2 - stringSize.Width / 2;
            else if (textAligment.Contains("Right"))
                drawX += Width - stringSize.Width;

            g.DrawString(Text, Font, new SolidBrush(ForeColor), drawX, drawY);
        }


        #region Getters and setters

        public bool Selected
        {
            get => _selected;
            set
            {
                if (_selected = value) //Intended
                {
                    BackColor = _selectedBackColor;
                    ForeColor = _selectedForeColor;
                }
                else
                {
                    BackColor = DefaultBackColor;
                    ForeColor = DefaultForeColor;
                }
            }
        }

        public new Color DefaultForeColor { get; set; }

        public new Color DefaultBackColor { get; set; }

        public Point TextOffset
        {
            get => _offset;
            set
            {
                _offset = value;
                Invalidate();
            }
        }

        public bool UseActiveImageWhileHovering
        {
            get => _useActiveImageWhileHovering;
            set => _useActiveImageWhileHovering = value;
        }

        public bool DrawText
        {
            get => _drawText;
            set
            {
                _drawText = value;
                Invalidate();
            }
        }

        public bool IsTab { get; set; } = true;

        public bool DrawImage
        {
            get => _drawImage;
            set
            {
                _drawImage = value;
                Invalidate();
            }
        }

        public ContentAlignment TextAligment
        {
            get => _textAligment;
            set
            {
                _textAligment = value;
                Invalidate();
            }
        }

        public Image ActiveImage
        {
            get => _selectedImage;
            set
            {
                _selectedImage = value;
                Invalidate();
            }
        }

        public Image Image
        {
            get => _image;
            set
            {
                _image = value;
                Invalidate();
            }
        }

        public Color OnHoverColor
        {
            get => _onHoverColor;
            set
            {
                _onHoverColor = value;
                Invalidate();
            }
        }

        public Color OnHoverTextColor
        {
            get => _onHoverTextColor;
            set
            {
                _onHoverTextColor = value;
                Invalidate();
            }
        }

        public Color ActiveColor
        {
            get => _selectedBackColor;
            set
            {
                _selectedBackColor = value;
                Invalidate();
            }
        }

        public Color ActiveTextColor
        {
            get => _selectedForeColor;
            set
            {
                _selectedForeColor = value;
                Invalidate();
            }
        }

        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public SizeF ImageSize
        {
            get => _imageSize;
            set
            {
                _imageSize = value;
                Invalidate();
            }
        }

        #endregion
    }
}