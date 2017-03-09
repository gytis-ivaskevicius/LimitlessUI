using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public partial class ArchProgressBar_WOC : Control
{
    public enum styleEnum
    {
        Style1,
        Style2,
        Style3,
        Style4,
        None
    }
    private styleEnum _style = styleEnum.Style1;
    private Font _font1, _font2, _font3;
    private int _angle = 360;
    private Point offset = new Point(0, 0);

    private string _text1 = "CPU";
    private string _text2 = "99%";
    private string _text3 = "55C";

    private float _progress = 50;
    private float _line1Thinkness = 5;
    private float _line2Thinkness = 9;

    private Color _color1 = Color.Silver;
    private Color _color2 = Color.Lime;
    private Color _text1Color = DefaultForeColor;
    private Color _text2Color = DefaultForeColor;
    private Color _text3Color = DefaultForeColor;



    public ArchProgressBar_WOC()
    {
        DoubleBuffered = true;
        _font1 = Font;
        _font2 = Font;
        _font3 = Font;
    }

    private void drawContent(PaintEventArgs e, int angle)
    {
        e.Graphics.RotateTransform(-angle);
        SizeF string1Size = e.Graphics.MeasureString(_text1, _font1);
        SizeF string2Size = e.Graphics.MeasureString(_text2, _font2);
        SizeF string3Size = e.Graphics.MeasureString(_text3, _font3);

        float radiusByTwo = (Width - ProgressLineThikness) / 2;
        int widthByTwo = Width / 2;
        e.Graphics.TranslateTransform(-(_line2Thinkness / 2F + radiusByTwo), -(_line2Thinkness / 2F + radiusByTwo));

        switch (_style)
        {
            case styleEnum.Style1:
                e.Graphics.DrawString(_text1, _font1, new SolidBrush(_text1Color), widthByTwo - string1Size.Width / 2 + offset.X, widthByTwo - string1Size.Height / 2 + offset.Y);
                break;
            case styleEnum.Style2:
                e.Graphics.DrawString(_text1, _font1, new SolidBrush(_text1Color), widthByTwo - string1Size.Width / 2 + offset.X, widthByTwo - string1Size.Height + offset.Y);
                e.Graphics.DrawString(_text2, _font2, new SolidBrush(_text2Color), widthByTwo - string2Size.Width / 2 + offset.X, widthByTwo + offset.Y);
                break;
            case styleEnum.Style3:
                e.Graphics.DrawString(_text1, _font1, new SolidBrush(_text1Color), widthByTwo - string1Size.Width / 2 + offset.X, widthByTwo - string1Size.Height + offset.Y);
                e.Graphics.DrawString(_text2, _font2, new SolidBrush(_text2Color), widthByTwo - string2Size.Width + offset.X, widthByTwo + offset.Y);
                e.Graphics.DrawString(_text3, _font3, new SolidBrush(_text3Color), widthByTwo + offset.X, widthByTwo + offset.Y);
                break;
            case styleEnum.Style4:
                e.Graphics.DrawString(_text1, _font1, new SolidBrush(_text1Color), widthByTwo - string1Size.Width / 2, widthByTwo - string1Size.Height / 2 + offset.Y);
                e.Graphics.DrawString(_text2, _font2, new SolidBrush(_text2Color), _line2Thinkness / 2 - (string2Size.Width / 2) + offset.X, widthByTwo + offset.Y);
                e.Graphics.DrawString(_text3, _font3, new SolidBrush(_text3Color), Width - (_line2Thinkness / 2) - (string3Size.Width / 2) - offset.X, widthByTwo + offset.Y);
                break;
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        Pen pen1 = new Pen(_color1, _line1Thinkness);
        Pen pen2 = new Pen(_color2, _line2Thinkness);
        float radiusByTwo = (Width - this.ProgressLineThikness) / 2F;


        float progressEndAngle = (_angle - 0) / 100F;
        pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        pe.Graphics.TranslateTransform(_line2Thinkness / 2F + radiusByTwo, _line2Thinkness / 2F + radiusByTwo);

        pe.Graphics.RotateTransform((360 - _angle) / 2 + 90);

        pe.Graphics.DrawArc(pen1, -radiusByTwo, -radiusByTwo, Width - ProgressLineThikness, Width - ProgressLineThikness, 0, _angle);
        pe.Graphics.DrawArc(pen2, -radiusByTwo, -radiusByTwo, Width - ProgressLineThikness, Width - ProgressLineThikness, 0, progressEndAngle * _progress);

        if (_style != styleEnum.None)
            drawContent(pe, (360 - _angle) / 2 + 90);

        pen1.Dispose();
        pen2.Dispose();
    }

    public Point Offset
    {
        get { return offset; }
        set { offset = value; Invalidate(); }
    }

    public styleEnum Style
    {
        get { return _style; }
        set
        {
            _style = value;
            Invalidate();
        }
    }

    public Font Font1
    {
        get { return _font1; }
        set
        {
            _font1 = value;
            Invalidate();
        }
    }
    public Font Font2
    {
        get { return _font2; }
        set
        {
            _font2 = value;
            Invalidate();
        }
    }
    public Font Font3
    {
        get { return _font3; }
        set
        {
            _font3 = value;
            Invalidate();
        }
    }

    public int Angle
    {
        get { return _angle; }
        set
        {
            _angle = value;
            Invalidate();
        }
    }

    public float Value
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

    public float BackLineThikness
    {
        get { return _line1Thinkness; }
        set
        {
            _line1Thinkness = value;
            Invalidate();
        }
    }

    public float ProgressLineThikness
    {
        get { return _line2Thinkness; }
        set
        {
            _line2Thinkness = value;
            Invalidate();
        }
    }

    public Color ProgressBackColor
    {
        get { return _color1; }
        set
        {
            _color1 = value;
            Invalidate();
        }
    }

    public Color ProgressColor
    {
        get { return _color2; }
        set
        {
            _color2 = value;
            Invalidate();
        }
    }

    public Color Text1Color
    {
        get { return _text1Color; }
        set
        {
            _text1Color = value;
            Invalidate();
        }
    }

    public Color Text2Color
    {
        get { return _text2Color; }
        set
        {
            _text2Color = value;
            Invalidate();
        }
    }

    public Color Text3Color
    {
        get { return _text3Color; }
        set
        {
            _text3Color = value;
            Invalidate();
        }
    }
    public string Text1
    {
        get { return _text1; }
        set
        {
            _text1 = value;
            Invalidate();
        }
    }

    public string Text2
    {
        get { return _text2; }
        set
        {
            _text2 = value;
            Invalidate();
        }
    }

    public string Text3
    {
        get { return _text3; }
        set
        {
            _text3 = value;
            Invalidate();
        }
    }

    public void updateText(string text1, string text2, string text3)
    {
        this._text1 = text1;
        this._text2 = text2;
        this._text3 = text3;
        Invalidate();
    }

    public void updateText(string text1, string text2)
    {
        this._text1 = text1;
        this._text2 = text2;
        Invalidate();
    }
}

