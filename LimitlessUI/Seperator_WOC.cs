using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Separator_WOC : Control
{
    private int _thickness = 1;
    private bool _vertical = false;


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

        using (Pen pen = new Pen(ForeColor, _thickness))
            if (!_vertical)
                pe.Graphics.DrawLine(pen, -size + Padding.Left, 0, size - Padding.Right, 0);
            else pe.Graphics.DrawLine(pen, 0, -size + Padding.Top, 0, size - Padding.Bottom);

    }

    #region Getters and Setters
    public bool Vertical
    {
        get { return _vertical; }
        set { _vertical = value; Invalidate(); }
    }

    public int LineThickness
    {
        get { return _thickness; }
        set
        {
            _thickness = value;
            if (Height < _thickness)
                Height = _thickness;
            else
                Invalidate();
        }
    }
    #endregion
}

