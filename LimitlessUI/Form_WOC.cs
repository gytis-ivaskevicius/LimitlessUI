using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


/*
End-User Licence Agreement (EULA) for WithoutCaps Software 

This version is current as of May 27, 2017. Please consult withoutcapsdev@gmail.com for any new versions of this EULA.

You can only use the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team after you agree to this licence. By using this software, you agree to all of the clauses in the WithoutCaps Software EULA.

PLEASE READ CAREFULLY BEFORE USING THIS PRODUCT: This End-User Licence Agreement(EULA) is a legal agreement between you (either an individual or as a single entity) and the entity that is known as the WithoutCaps Team.

(a) Introduction. This is the End-User Licence Agreement (EULA) for the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team. This EULA outlines the clauses of the licence that the WithoutCaps Team is willing to grant you (either as an individual or as a single entity) to use this software.

(b) Licence. The entity known as the WithoutCaps Team will grant a free of charge, fully-revocable, non-exclusive, non-transferable licence to any person obtaining a copy of the software known as "LimitlessUI" as well as the associated documentation. The aforementioned documentation consists of the End-User Licence Agreement (EULA) for the product known as "LimitlessUI" which is currently maintained by the WithoutCaps Team. This licence permits you to use, modify and re-distribute this software non-commercially so long as you (either an individual or as a single entity) has permission from the WithoutCaps Team to do so. If the user wants to re-distribute software made by the WithoutCaps Team this EULA must be included in the software package.

(c) Ownership. The software known as "LimitlessUI" and produced by the WithoutCaps Team is licenced, not sold, to you (either an individual or as a single entity) and as such the WithoutCaps Software Team reserves any rights not explicitly granted to you (either an individual or as a single entity).

The WithoutCaps Team also reserves the right to revoke any persons (either an individual or as a single entity) licence without previous notification or agreements as long as said the person (either an individual or as a single entity) didn't adhere to the End-User Licence Agreement (EULA) distributed with this software.

Notwithstanding the terms and conditions of this EULA, any part of the software contained within the product known as "LimitlessUI" which is currently maintained by the WithoutCaps Team which constitutes Third Party Software and as such now is licenced to you subject to the terms and conditions of the software licence agreement accompanying such Third Party Software. Whatever the form of the licence, whether it be in the form of a discrete agreement, shrink wrap licence or electronic licence terms are accepted at the time of acceptance of the End-User Licence Agreement for the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team.

(d) Limitation of Liability. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) 2017 WithoutCaps
*/


namespace LimitlessUI
{
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
        private bool _formLevelBuffering = true;

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
                    cp.ClassStyle |= 0x20000;
                if (_formLevelBuffering && !DesignMode)
                    cp.ExStyle |= 0x02000000;
                
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


        public bool BufferApplication
        {
            get { return _formLevelBuffering; }
            set { _formLevelBuffering = value; }
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
}

