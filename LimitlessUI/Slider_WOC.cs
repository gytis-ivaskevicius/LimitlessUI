using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


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
}

