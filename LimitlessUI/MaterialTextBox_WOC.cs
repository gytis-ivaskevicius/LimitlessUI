using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LimitlessUI
{
    public partial class MaterialTextBox_WOC : UserControl
    {
        private Color _underlineColor = Color.Gray;
        private Color _animationColor = Color.Red;

        private AnimatorTimer_WOC _animationTimer;
        private bool _focused = false;

        private int _animationLength = 300;
        private int _animationProgress;
        private int _lineThickness = 3;

        public MaterialTextBox_WOC()
        {
            InitializeComponent();

            DoubleBuffered = true;
            _animationTimer = new AnimatorTimer_WOC();

            _animationTimer.onAnimationTimerTick += (int progress) =>
            {
                _animationProgress = progress;
                Invalidate();
            };
            textBox.GotFocus += (object sender, EventArgs e) => _focused = true;
            textBox.LostFocus += (object sender, EventArgs e) =>
            {
                _focused = false;
                _animationTimer.setValueRange(0, _animationLength, true);
            };
            textBox.MouseEnter += (object sender, EventArgs e) => _animationTimer.setValueRange(Width / 2, _animationLength, true);
            textBox.MouseLeave += (object sender, EventArgs e) =>
            {
                if (!_focused)
                    _animationTimer.setValueRange(0, _animationLength, true);
            };
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Silver, 10))
            {
                float halfLinethickness = _lineThickness / 2;
                e.Graphics.DrawLine(pen, Padding.Left, Height - halfLinethickness, Width - Padding.Right, Height - halfLinethickness);

                e.Graphics.TranslateTransform(Width / 2, Height - halfLinethickness);

                pen.Color = _animationColor;
                e.Graphics.DrawLine(pen, Padding.Left + (-_animationProgress), 0, (_animationProgress), 0);
            }
        }


        #region Getters and Setters

        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public Color AnimationColor
        {
            get { return _animationColor; }
            set { _animationColor = value; Invalidate(); }
        }

        public int LineThickness
        {
            get { return _lineThickness; }
            set
            {
                _lineThickness = value;
                Padding = new Padding(Padding.Left, Padding.Top, Padding.Right, Padding.Bottom);
                Invalidate();
            }
        }


        public int AnimationLength
        {
            get { return _animationLength; }
            set { _animationLength = value; }
        }


        public RichTextBox TextBox { get { return textBox; } }
        #endregion

    }
}
