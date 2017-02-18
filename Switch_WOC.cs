using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Switch_WOC : Control
{
    private bool _textEnabled = true;
    private bool _isOn = true;

    private Color _onColor = Color.SeaGreen;
    private Color _offColor = Color.DarkGray;

    private string _onText = "On";
    private string _offText = "Off";

    public Switch_WOC()
    {
        Click += click;
        BackColor = Color.FromArgb(64, 64, 64);
        ForeColor = Color.FromArgb(224, 224, 224);
        Width = 51;
        Height = 18;
        DoubleBuffered = true;
    }

    private void click(object sender, EventArgs e)
    {
        _isOn = !_isOn;
        Invalidate();
    }

    private void drawString(PaintEventArgs pe, bool isOn)
    {
        SizeF stringSize = pe.Graphics.MeasureString(isOn ? _onText : _offText, Font);
        float drawHeight = Height / 2 - stringSize.Height / 2;

        if (isOn)
        {
            float drawWidth = Width / 2 + (Width / 4) - stringSize.Width / 2;
            pe.Graphics.DrawString(_onText, Font, new SolidBrush(ForeColor), drawWidth, drawHeight);
        }
        else
        {
            float drawWidth = Width / 2 - (Width / 4) - stringSize.Width / 2;
            pe.Graphics.DrawString(_offText, Font, new SolidBrush(ForeColor), drawWidth, drawHeight);
        }
    }
    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        Pen pen1 = new Pen(BackColor, Height);
        Pen pen2 = new Pen(_isOn ? _onColor : _offColor, Height);

        pe.Graphics.DrawLine(pen1, 0, Height / 2, Width, Height / 2);
        if (_isOn)
            pe.Graphics.DrawLine(pen2, 0, Height / 2, Width / 2, Height / 2);
        else
            pe.Graphics.DrawLine(pen2, Width / 2, Height / 2, Width, Height / 2);

        if (_textEnabled)
            drawString(pe, _isOn);

        pen1.Dispose();
        pen2.Dispose();
    }

    public bool IsOn
    {
        get { return _isOn; }
        set
        {
            _isOn = value;
            Invalidate();
        }
    }

    public bool TextEnabled
    {
        get { return _textEnabled; }
        set
        {
            _textEnabled = value;
            Invalidate();
        }
    }

    public Color OnColor
    {
        get { return _onColor; }
        set
        {
            _onColor = value;
            Invalidate();
        }
    }

    public Color OffColor
    {
        get { return _offColor; }
        set
        {
            _offColor = value;
            Invalidate();
        }
    }

    public string OnText
    {
        get { return _onText; }
        set
        {
            _onText = value;
            Invalidate();
        }
    }

    public string OffText
    {
        get { return _offText; }
        set
        {
            _offText = value;
            Invalidate();
        }
    }
}

