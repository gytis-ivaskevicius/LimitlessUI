using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Separator_WOC : Control
{
    private float _thikness = 1;
    private Color _lineColor = Color.DimGray;

    protected override void OnPaddingChanged(EventArgs e)
    {
        base.OnPaddingChanged(e);
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        pe.Graphics.DrawLine(new Pen(_lineColor, _thikness), Padding.Left, this.Height / 2, this.Width - Padding.Right, this.Height / 2);
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

