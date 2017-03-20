using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public partial class DropDown_WOC : Control
{
    private float _textDistance = 35;
    private float _thikness = 2;

    private Image _downImage;
    private Image _upImage;
    private SizeF _arrowSize = new SizeF(10, 10);
    private Control _panel;
    private int _expandedPanelHeight;
    private bool _pointsDown = true;

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        _pointsDown = !_pointsDown;
        if (!_pointsDown)
        {
            _expandedPanelHeight = _panel.Height;
            _panel.Height = 0;
        }
        else
            _panel.Height = _expandedPanelHeight;
        Invalidate();
    }

    private void drawArrow(PaintEventArgs pe, float x, float y, float height, float width, bool pointsDown)
    {
        y = y - height / 2;
        if (!pointsDown)
        {
            pe.Graphics.DrawLine(new Pen(ForeColor, _thikness), x, y + height / 2, x + width / 2, y + height);
            pe.Graphics.DrawLine(new Pen(ForeColor, _thikness), x + width / 2, y + height, x + width, y + height / 2);
        }
        else
        {
            pe.Graphics.DrawLine(new Pen(ForeColor, _thikness), x, y + height, x + width / 2, y + height / 2);
            pe.Graphics.DrawLine(new Pen(ForeColor, _thikness), x + width / 2, y + height / 2, x + width, y + height);
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        SizeF textSize = pe.Graphics.MeasureString(Text, Font);
        //float padding = (Height - textSize.Height) / 2;
        pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), _textDistance, Height / 2 - (textSize.Height / 2));
        if (_downImage != null && _upImage != null)
        {
            if (_pointsDown)
                pe.Graphics.DrawImage(_downImage, (Height - _arrowSize.Width) / 2, (Height - _arrowSize.Height) / 2, _arrowSize.Width, _arrowSize.Height);
            else
                pe.Graphics.DrawImage(_upImage, (Height - _arrowSize.Width) / 2, (Height - _arrowSize.Height) / 2, _arrowSize.Width, _arrowSize.Height);
        }
        else
            drawArrow(pe, (Height - _arrowSize.Width) / 2,       (Height - _arrowSize.Height/2) / 2      , _arrowSize.Height, _arrowSize.Width, _pointsDown);
    }


    public bool PointsDown { 
        get { return _pointsDown; }
        set { _pointsDown = value; Invalidate(); }
    }

    public Image DownImage
    {
        get { return _downImage; }
        set { _downImage = value; Invalidate(); }
    }

    public Image UpImage
    {
        get { return _upImage; }
        set { _upImage = value; Invalidate(); }
    }

    public SizeF ArrowSize
    {
        get
        {
            return _arrowSize;
        }
        set
        {
            _arrowSize = value;
            Invalidate();
        }
    }

    public float ArrowThinkness
    {
        get { return _thikness; }
        set
        {
            _thikness = value;
            Invalidate();
        }
    }

    public float TextDistance
    {
        get { return _textDistance; }
        set
        {
            _textDistance = value;
            Invalidate();
        }
    }

    public Control SetLayout
    {
        get { return _panel; }
        set
        {
            _panel = value;
            Invalidate();
        }
    }
}

