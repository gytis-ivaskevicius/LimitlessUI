using System;
using System.Drawing;
using System.Windows.Forms;

namespace LimitlessUI
{
    public partial class MaterialTextBox_WOC : UserControl
    {
        private Color _underlineColor = Color.Gray;
        private Color _animationColor = Color.Red;

        private int _interval = 17;
        private int _step = 19;
        private bool _focused = false;
        public MaterialTextBox_WOC()
        {
            InitializeComponent();
            textBox.GotFocus += textBox_GotFocus;
            textBox.LostFocus += textBox_LostFocus;
            seperator.LineColor = _underlineColor;
        }

        private void textBox_LostFocus(object sender, EventArgs e)
        {
            _focused = false;
            seperator.startAnimating(_interval, -_step, -1);
        }

        private void textBox_GotFocus(object sender, EventArgs e)
        {
            _focused = true;
            seperator.startAnimating(_interval, _step, -1);
        }

        private void textBox_MouseEnter(object sender, EventArgs e)
        {
            seperator.startAnimating(_interval, _step, -1);
            Underline.AnimationColor = _animationColor;
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            if (!_focused)
                seperator.startAnimating(_interval, -_step, -1);
            if (seperator.Val > seperator.Width - (Padding.Right + Padding.Left))
                seperator.Val = seperator.Width - (Padding.Right + Padding.Left);
        }

        public string TextBoxText
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public Color AnimationColor
        {
            get { return _animationColor; }
            set { _animationColor = value; }
        }

        public RichTextBox TextBox { get { return textBox; } }

        public Separator_WOC Underline { get { return seperator; } }
    }
}
