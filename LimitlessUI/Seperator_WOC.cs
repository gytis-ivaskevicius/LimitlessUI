using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Separator_WOC : Control
{
    private float _thikness = 1;
    private Color _lineColor = Color.DimGray;
    private Timer _timer;
    private bool _animationEnabled = false;
    private int _val = 0;
    private int _progress = 3;

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
        pe.Graphics.DrawLine(new Pen(_lineColor, _thikness), Padding.Left, this.Height / 2, this.Width - Padding.Right, this.Height / 2);
        if (_animationEnabled)
            pe.Graphics.DrawLine(new Pen(Color.Red, _thikness), Padding.Left + (Width - _val) / 2, this.Height / 2, (Width + _val) / 2, this.Height / 2);
    }

    public bool AnimationEnabled
    {
        get { return _animationEnabled; }
        set { _animationEnabled = value; }
    }

    public int Val
    {
        get { return _val; }
        set { _val = value; Invalidate(); }
    }

    public float LineThikness
    {
        get { return _thikness; }
        set
        {
            _thikness = value;
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
}

