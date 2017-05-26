using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LimitlessUISample
{
    public partial class TextBox_WOC : UserControl
    {
        private Color _borderColor = Color.Black;
        private int _borderThikness = 5;
        private bool _multiLine = true;
        private bool _drawBorder = false;


        public TextBox_WOC()
        {
            InitializeComponent();
            textBox.ContentsResized += richTextBox_ContentsResized;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            textBox.Width = Width - Padding.Left - Padding.Right;
            textBox.Left = Padding.Left;
            textBox.Top = (this.Height - textBox.Height) / 2;
            centerVertical(_multiLine);
        }

        private void richTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            var richTextBox = (RichTextBox)sender;
            textBox.Height = e.NewRectangle.Height;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_drawBorder)
            {
                Pen pen = new Pen(Color.Black, _borderThikness);
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            }
        }

        private void centerVertical(bool center)
        {
            if (center)
            {
                textBox.Dock = DockStyle.None;
                textBox.Location = new Point(Padding.Left, (Height - textBox.Height) / 2);
            }
            else textBox.Dock = DockStyle.Fill;
        }

        public bool Multiline
        {
            get { return _multiLine; }
            set
            {
                _multiLine = value;
                centerVertical(_multiLine);
                textBox.Multiline = !_multiLine;
            }
        }


        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value;  Invalidate(); }
        }


        public bool DrawBorder
        {
            get { return _drawBorder; }
            set { _drawBorder = value; Invalidate(); }
        }


        public int BorderThikness
        {
            get { return _borderThikness; }
            set
            {
                _borderThikness = value;
                Invalidate();
            }
        }

    }
}
