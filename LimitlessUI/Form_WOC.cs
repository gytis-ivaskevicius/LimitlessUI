using System;
using System.Drawing;
using System.Windows.Forms;


public class Form_WOC : Form
{
    private Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _gripSize); } }
    private Rectangle Left { get { return new Rectangle(0, 0, _gripSize, this.ClientSize.Height); } }
    private Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _gripSize, this.ClientSize.Width, _gripSize); } }
    private Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _gripSize, 0, _gripSize, this.ClientSize.Height); } }

    private Rectangle TopLeft { get { return new Rectangle(0, 0, _gripSize, _gripSize); } }
    private Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _gripSize, 0, _gripSize, _gripSize); } }
    private Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _gripSize, _gripSize, _gripSize); } }
    private Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _gripSize, this.ClientSize.Height - _gripSize, _gripSize, _gripSize); } }

    private int _gripSize = 10;
    private const int
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17;

    protected override void WndProc(ref Message message)
    {
        base.WndProc(ref message);
        if (message.Msg == 0x84) // WM_NCHITTEST
        {
            var cursor = this.PointToClient(Cursor.Position);

            if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
            else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
            else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
            else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

            else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
            else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
            else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
            else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
        }
    }

    public int GripSize
    {
        get { return _gripSize; }
        set { _gripSize = value; }
    }
}

