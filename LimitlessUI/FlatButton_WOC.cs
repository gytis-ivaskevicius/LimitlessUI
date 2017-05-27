using System;
using System.Drawing;
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
    public partial class FlatButton_WOC : Control
    {
        ContentAlignment _textAligment = ContentAlignment.MiddleLeft;
        private Image _image;
        private Image _selectedImage;
        private Point _offset = new Point(0, 0);
        private SizeF _imageSize = new SizeF(20, 20);

        private bool _selected = false;
        private bool _drawImage = false;
        private bool _drawText = true;
        private bool _mouseHovering = false;
        private bool _useActiveImageWhileHovering = false;
        private bool _isTab = true;

        private Color _selectedBackColor;
        private Color _selectedForeColor;
        private Color _onHoverColor;
        private Color _onHoverTextColor;
        private Color _defaultBackColor;
        private Color _defaultForeColor;

        public FlatButton_WOC()
        {
            DoubleBuffered = true;
            BackColor = Color.FromArgb(41, 53, 65);
            ForeColor = Color.White;
            Height = 50;
            Width = 220;

            MouseEnter += onMouseEnter;
            MouseLeave += onMouseExit;
            MouseClick += onClick;
        }

        private void onClick(object sender, MouseEventArgs e)
        {
            if (!_selected && _isTab)
            {
                BackColor = _selectedBackColor != null ? _selectedBackColor : BackColor;
                ForeColor = _selectedForeColor != null ? _selectedForeColor : ForeColor;

                if (Parent != null)
                    foreach (Control control in Parent.Controls)
                        if (control is FlatButton_WOC)
                            ((FlatButton_WOC)control).unselect();
                _selected = true;
            }
        }

        public void unselect()
        {
            if (_selected)
            {
                _selected = false;
                BackColor = _defaultBackColor;
                ForeColor = _defaultForeColor;
            }
        }

        private void onMouseExit(object sender, EventArgs e)
        {
            _mouseHovering = false;
            if (!_selected)
            {
                BackColor = _defaultBackColor;
                ForeColor = _defaultForeColor;
                Invalidate();
            }
        }

        private void onMouseEnter(object sender, EventArgs e)
        {
            _mouseHovering = true;
            if (!_selected)
            {
                _defaultBackColor = BackColor;
                BackColor = OnHoverColor != null ? _onHoverColor : BackColor;

                _defaultForeColor = ForeColor;
                ForeColor = OnHoverTextColor != null ? _onHoverTextColor : ForeColor;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (_drawText)
                drawString(pe.Graphics, Text, Font, _textAligment.ToString());
            if (_drawImage && _image != null)
            {
                float drawHeight = Height / 2 - _imageSize.Height / 2;
                pe.Graphics.DrawImage(_selected || (_mouseHovering && _useActiveImageWhileHovering) ? (_selectedImage ?? _image) : _image, drawHeight, drawHeight, _imageSize.Width, _imageSize.Height);
            }
        }

        private void drawString(Graphics g, string text, Font font, string textAligment)
        {
            SizeF stringSize = g.MeasureString(Text, Font);
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
            get { return _selected; }
            set
            {
                if (_selected = value)
                {
                    BackColor = _selectedBackColor != null ? _selectedBackColor : BackColor;
                    ForeColor = _selectedForeColor != null ? _selectedForeColor : ForeColor;
                }
                else
                {
                    BackColor = _defaultBackColor;
                    ForeColor = _defaultForeColor;
                }
            }
        }

        public Color DefaultForeColor
        {
            get { return _defaultForeColor; }
            set { _defaultForeColor = value; }
        }

        public Color DefaultBackColor
        {
            get { return _defaultBackColor; }
            set { _defaultBackColor = value; }
        }

        public Point TextOffset
        {
            get { return _offset; }
            set { _offset = value; Invalidate(); }
        }

        public bool UseActiveImageWhileHovering
        {
            get { return _useActiveImageWhileHovering; }
            set { _useActiveImageWhileHovering = value; }
        }

        public bool DrawText
        {
            get { return _drawText; }
            set { _drawText = value; Invalidate(); }
        }

        public bool IsTab
        {
            get { return _isTab; }
            set { _isTab = value; }
        }

        public bool DrawImage
        {
            get { return _drawImage; }
            set { _drawImage = value; }
        }

        public ContentAlignment TextAligment
        {
            get { return _textAligment; }
            set
            {
                _textAligment = value;
                Invalidate();
            }
        }

        public Image ActiveImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                Invalidate();
            }
        }

        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        public Color OnHoverColor
        {
            get { return _onHoverColor; }
            set
            {
                _onHoverColor = value;
                Invalidate();
            }
        }

        public Color OnHoverTextColor
        {
            get { return _onHoverTextColor; }
            set
            {
                _onHoverTextColor = value;
                Invalidate();
            }
        }

        public Color ActiveColor
        {
            get { return _selectedBackColor; }
            set
            {
                _selectedBackColor = value;
                Invalidate();
            }
        }

        public Color ActiveTextColor
        {
            get { return _selectedForeColor; }
            set
            {
                _selectedForeColor = value;
                Invalidate();
            }
        }

        public override string Text { get => base.Text; set { base.Text = value; Invalidate(); } }
        public SizeF ImageSize
        {
            get { return _imageSize; }
            set
            {
                _imageSize = value;
                Invalidate();
            }
        }
        #endregion
    }
}