using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


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
    private bool _neverChangeBackColor = false;

    private Color _selectedBackColor = Color.DarkSeaGreen;
    private Color _selectedForeColor = Color.White;
    private Color _onHoverColor = Color.MediumSeaGreen;
    private Color _onHoverTextColor = Color.White;
    private Color _defaultBackColor;
    public Color _defaultForeColor;

    public FlatButton_WOC()
    {
        BackColor = Color.SeaGreen;
        ForeColor = Color.White;
        Height = 48;
        Width = 241;

        MouseEnter += onMouseEnter;
        MouseLeave += onMouseExit;
        MouseClick += onClick;
        _defaultForeColor = ForeColor;
    }

    private void onClick(object sender, MouseEventArgs e)
    {
        if (!_selected && _isTab)
        {
            if (_neverChangeBackColor)
                BackColor = _selectedBackColor;
            ForeColor = _selectedForeColor;

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
            if (_neverChangeBackColor)
            {
                _defaultBackColor = BackColor;
                BackColor = OnHoverColor;
            }
            _defaultForeColor = ForeColor;
            ForeColor = OnHoverTextColor;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        if (_drawText)
            drawString(pe.Graphics, Text, Font, ForeColor, _textAligment.ToString());
        if (_drawImage && _image != null)
        {
            float drawHeight = Height / 2 - _imageSize.Height / 2;
            pe.Graphics.DrawImage(_selected || (_mouseHovering && _useActiveImageWhileHovering) ? (_selectedImage != null ? _selectedImage : _image) : _image, drawHeight, drawHeight, _imageSize.Width, _imageSize.Height);
        }
    }

    private void drawString(Graphics g, string text, Font font, Color color, string textAligment)
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



    public bool NeverChangeBG
    {
        get { return _neverChangeBackColor; }
        set { _neverChangeBackColor = value; }
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

    public bool Selected
    {
        get { return _selected; }
        set
        {
            _selected = value;
            if (_selected)
            {
                BackColor = _selectedBackColor;
                ForeColor = _selectedForeColor;
            }
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

    public SizeF ImageSize
    {
        get { return _imageSize; }
        set
        {
            _imageSize = value;
            Invalidate();
        }
    }
}

