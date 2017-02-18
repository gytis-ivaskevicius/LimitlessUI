using System;
using System.Drawing;
using System.Windows.Forms;


public partial class FlatButton_WOC : Control
{
    ContentAlignment _textAligment = ContentAlignment.MiddleLeft;
    private Image _image;
    private SizeF _imageSize = new SizeF(20, 20);
    public bool _selected = false;

    private Color _selectedBackColor = Color.DarkSeaGreen;
    private Color _selectedForeColor = Color.White;
    private Color _onHoverColor = Color.MediumSeaGreen;
    private Color _onHoverTextColor = Color.White;
    private Color _defaultBackColor;
    private Color _defaultForeColor;

    public FlatButton_WOC()
    {
        BackColor = Color.SeaGreen;
        ForeColor = Color.White;
        Height = 48;
        Width = 241;

        MouseEnter += onMouseEnter;
        MouseLeave += onMouseExit;
        MouseClick += onClick;
    }

    private void onClick(object sender, MouseEventArgs e)
    {
        BackColor = _selectedBackColor;
        ForeColor = _selectedForeColor;

        foreach (Control control in Parent.Controls)
            if (control is FlatButton_WOC)
                ((FlatButton_WOC)control).unselect();
        _selected = true;
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
        if (!_selected)
        {
            BackColor = _defaultBackColor;
            ForeColor = _defaultForeColor;
        }
    }

    private void onMouseEnter(object sender, EventArgs e)
    {
        if (!_selected)
        {
            _defaultBackColor = BackColor;
            _defaultForeColor = ForeColor;

            BackColor = OnHoverColor;
            ForeColor = OnHoverTextColor;
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        drawString(pe.Graphics, Text, Font, ForeColor, _textAligment.ToString());
        if (_image != null)
        {
            float drawHeight = Height / 2 - _imageSize.Height / 2;
            pe.Graphics.DrawImage(_image, drawHeight, drawHeight, _imageSize.Width, _imageSize.Height);
        }
    }

    private void drawString(Graphics g, string text, Font font, Color color, string textAligment)
    {
        SizeF stringSize = g.MeasureString(Text, Font);
        float drawX = Height;
        float drawY = 0;

        if (textAligment.Contains("Middle"))
            drawY = Height / 2 - stringSize.Height / 2;
        else if (textAligment.Contains("Bottom"))
            drawY = Height - stringSize.Height;

        if (textAligment.Contains("Center"))
            drawX = Width / 2 - stringSize.Width / 2;
        else if (textAligment.Contains("Right"))
            drawX = Width - stringSize.Width;

        g.DrawString(Text, Font, new SolidBrush(ForeColor), drawX, drawY);
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

