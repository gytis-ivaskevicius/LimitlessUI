using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public partial class Separator_WOC : Control
{
    private float _thikness = 1;
    private Timer _timer;

    private bool _animationEnabled = false;
    private bool _vertical = false;

    private int _angle = 0;
    private int _val = 0;
    private int _progress = 3;

    private Color _lineColor = Color.DimGray;
    private Color _animationColor = Color.SeaGreen;

    public Separator_WOC()
    {
        DoubleBuffered = true;
        _timer = new Timer();
        _timer.Tick += timerTick;
    }

    public void startAnimating(int interval, int progress, int startValue)
    {
        _timer.Interval = interval;
        _progress = progress;
        if (startValue >= 0)
            _val = startValue;
        if (!_timer.Enabled)
            _timer.Start();
    }

    public void stopAnimating(int value)
    {
        _timer.Stop();
        _val = value;
        Invalidate();
    }

    private void timerTick(object sender, EventArgs e)
    {
        _val += _progress;
        if (_val > Width - (Padding.Right + Padding.Left) || _val < 0)
        {
            _timer.Stop();
            if (_val < 0)
                _val = 0;
        }
        else if (_val > Width - (Padding.Right + Padding.Left))
            _val = Width - (Padding.Right + Padding.Left);
        Invalidate();
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
        base.OnPaddingChanged(e);
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        int size = _vertical ? Height / 2 : Width / 2;
        pe.Graphics.TranslateTransform(Width / 2, Height / 2);
        pe.Graphics.RotateTransform(_angle);
        Pen pen = new Pen(_lineColor, _thikness);
        pe.Graphics.DrawLine(pen, -size + Padding.Left, 0, size - Padding.Right, 0);
        if (_animationEnabled)
        {
            pen.Color = _animationColor;
            pe.Graphics.DrawLine(pen, Padding.Left + (-_val) / 2, 0, (_val) / 2, 0);
        }
        pen.Dispose();
    }

    public bool AnimationEnabled
    {
        get { return _animationEnabled; }
        set { _animationEnabled = value; }
    }

    public bool Vertical
    {
        get { return _vertical; }
        set { _vertical = value; Invalidate(); }
    }

    public int Val
    {
        get { return _val; }
        set { _val = value; Invalidate(); }
    }

    public int Angle
    {
        get { return _angle; }
        set { _angle = value; Invalidate(); }
    }

    public float LineThikness
    {
        get { return _thikness; }
        set
        {
            _thikness = value;
            if (Height < _thikness)
                Height = (int) _thikness;
            else
                Invalidate();
        }
    }

    public Color LineColor
    {
        get { return _lineColor; }
        set
        {
            _lineColor = value;
            Invalidate();
        }
    }

    public Color AnimationColor
    {
        get { return _animationColor; }
        set
        {
            _animationColor = value;
            Invalidate();
        }
    }
}

