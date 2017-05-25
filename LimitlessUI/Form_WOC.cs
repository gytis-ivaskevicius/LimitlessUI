using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


public class Form_WOC : Form
{
    public enum LinePositions
    {
        TOP,
        BOTTOM,
        LEFT,
        RIGHT
    }
    private Rectangle TopGrip { get { return new Rectangle(0, 0, this.ClientSize.Width, _gripSize); } }
    private Rectangle LeftGrip { get { return new Rectangle(0, 0, _gripSize, this.ClientSize.Height); } }
    private Rectangle BottomGrip { get { return new Rectangle(0, this.ClientSize.Height - _gripSize, this.ClientSize.Width, _gripSize); } }
    private Rectangle RightGrip { get { return new Rectangle(this.ClientSize.Width - _gripSize, 0, _gripSize, this.ClientSize.Height); } }

    private Rectangle TopLeftGrip { get { return new Rectangle(0, 0, _gripSize, _gripSize); } }
    private Rectangle TopRightGrip { get { return new Rectangle(this.ClientSize.Width - _gripSize, 0, _gripSize, _gripSize); } }
    private Rectangle BottomLeftGrip { get { return new Rectangle(0, this.ClientSize.Height - _gripSize, _gripSize, _gripSize); } }
    private Rectangle BottomRightGrip { get { return new Rectangle(this.ClientSize.Width - _gripSize, this.ClientSize.Height - _gripSize, _gripSize, _gripSize); } }

    private List<Line> _lines = new List<Line>();
    private int _gripSize = 10;     // Thickness of form grip which allows you to resize it
    private bool _drawShadow = true;

    private const int
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17;



    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            if (_drawShadow)
            {
                const int CS_DROPSHADOW = 0x20000;
                cp.ClassStyle |= CS_DROPSHADOW;
            }
            return cp;
        }
    }



    protected override void WndProc(ref Message message)
    {
        base.WndProc(ref message);
        if (message.Msg == 0x84)    // WM_NCHITTEST
        {
            var cursor = this.PointToClient(Cursor.Position);

            if (TopLeftGrip.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
            else if (TopRightGrip.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
            else if (BottomLeftGrip.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
            else if (BottomRightGrip.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

            else if (TopGrip.Contains(cursor)) message.Result = (IntPtr)HTTOP;
            else if (LeftGrip.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
            else if (RightGrip.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
            else if (BottomGrip.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
        }
    }
    public void drawLine(LinePositions pos, Color color, int point1, int point2)
    {
        _lines.Add(new Line(pos, color, point1, point2));
    }

    public void clearLines()
    {
        _lines.Clear();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Pen pen = new Pen(Color.Red, 10);
        foreach (Line line in _lines)
        {
            pen.Color = line.Color;

            if (line.LinePosition == LinePositions.BOTTOM)
                e.Graphics.DrawLine(pen, line.X1, Height, line.X2, Height);
            else if (line.LinePosition == LinePositions.TOP)
                e.Graphics.DrawLine(pen, line.X1, 0, line.X2, 0);
            else if (line.LinePosition == LinePositions.RIGHT)
                e.Graphics.DrawLine(pen, Width, line.Y1, Width, line.Y2);
            else
                e.Graphics.DrawLine(pen, 0, line.Y1, 0, line.Y2);
        }
    }

    public int GripSize
    {
        get { return _gripSize; }
        set { _gripSize = value; }
    }

    public bool DrawShadow
    {
        get { return _drawShadow; }
        set { _drawShadow = value; }
    }


    class Line
    {
        private int _x1;
        private int _x2;
        private int _y1;
        private int _y2;
        private Color _color;
        private LinePositions _position;

        public Line(LinePositions position, Color color, int point1, int point2)
        {
            if (position == LinePositions.TOP || position == LinePositions.BOTTOM)
            {
                _x1 = point1;
                _x2 = point2;
            }
            else
            {
                _y1 = point1;
                _y2 = point2;
            }
            _color = color;
            _position = position;
        }

        public Color Color { get { return _color; } }
        public int X1 { get { return _x1; } }
        public int X2 { get { return _x2; } }
        public int Y1 { get { return _y1; } }
        public int Y2 { get { return _y2; } }
        public LinePositions LinePosition { get { return _position; } }
    }
}

