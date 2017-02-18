using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public partial class ProgressBar_WOC : Control
{
    private Color _progressBackColor = Color.Silver;
    private int _progress = 50;

    private float _line1Thikness = 10;
    private float _line2Thikness = 20;
    private float _extraPadding = 0;

    private bool _rounded = true;
    private bool _smoothing = true;

    public ProgressBar_WOC()
    {
        this.DoubleBuffered = true;
        ForeColor = Color.Chartreuse;
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        if (_smoothing)
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        float progressWidth = this.Width;
        float progressToDraw = ((progressWidth - Padding.Left - Padding.Right) / 100) * _progress;
        float progressNotToDraw = (progressWidth - Padding.Left - Padding.Right) - progressToDraw;
        float drawHeight = this.Height / 2;

        Pen penOne = new Pen(_progressBackColor, _line1Thikness);
        Pen penTwo = new Pen(ForeColor, _line2Thikness);

        if (_rounded)
        {
            penTwo.StartCap = LineCap.Round;
            penTwo.EndCap = LineCap.Round;

            penOne.StartCap = LineCap.Round;
            penOne.EndCap = LineCap.Round;

            _extraPadding = _line2Thikness / 2;
        }
        else
            _extraPadding = 0;

        pe.Graphics.DrawLine(penOne, ((float)Padding.Left) + _extraPadding, drawHeight, ((float)this.Width - Padding.Right) - _extraPadding, drawHeight);
        if (Value != 0)
            pe.Graphics.DrawLine(penTwo, Padding.Left + _extraPadding, drawHeight, this.Width - ((float)Padding.Right) - progressNotToDraw - _extraPadding, drawHeight);

        penOne.Dispose();
        penTwo.Dispose();
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
        base.OnPaddingChanged(e);
        Invalidate();
    }

    public int Value
    {
        get { return _progress; }
        set
        {
            if (value != _progress)
            {
                _progress = value;
                Invalidate();
            }
        }
    }

    public Color ProgressBackColor
    {
        get { return _progressBackColor; }
        set
        {
            _progressBackColor = value;
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

    public bool Smooth
    {
        get { return _smoothing; }
        set
        {
            _smoothing = value;
            Invalidate();
        }
    }

    public float Line1Thikness
    {
        get { return _line1Thikness; }
        set
        {
            _line1Thikness = value;
            Invalidate();
        }
    }

    public float Line2Thikness
    {
        get { return _line2Thikness; }
        set
        {
            _line2Thikness = value;
            Invalidate();
        }
    }
}
