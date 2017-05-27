using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


/*
End-User Licence Agreement (EULA) for WithoutCaps Software 

This version is current as of May 27, 2017. Please consult withoutcapsdev@gmail.com for new versions of this EULA.

You can only use software made by the WithoutCaps Team after you agree to this licence. By using this software, you agree to 
all of the clauses in the WithoutCaps Software EULA.

PLEASE READ CAREFULLY BEFORE USING THIS PRODUCT: This End-User Licence Agreement(EULA) is a legal agreement between you 
(either an individual or as a single entity) and the entity is known as the WithoutCaps Team.

(a) Introduction. This is the End-User Licence Agreement (EULA) for this software which is produced by the WithoutCaps Team. 
This EULA outlines the clauses of the licence that the WithoutCapsTeam is willing to grant you (the user) to use this software. 

(b) Licence. The entity known as the WithoutCaps Team will grant a free of charge, fully-revocable, non-exclusive, non-transferable 
licence to any person obtaining a copy of this software as well as the associated documentation. The aforementioned documentation 
consists of the End-User Licence Agreement (EULA) for products made by the WithoutCaps Team. This licence permits you to use, modify 
and re-distribute this software non-commercially so long as you (either an individual or as a single entity) has permission from the 
WithoutCaps Team to do so. If the user wants to re-distribute software made by the WithoutCaps Team this EULA must be included in the 
software package.

(c) Ownership. Software produced by the WithoutCaps Team is licenced, not sold, to you (either an individual or as a single entity) 
and as such the WithoutCaps Software Team reserves any rights not expressly granted to you (either an individual or as a single entity).

The WithoutCaps Team reserves the right to revoke any persons (either an individual or as a single entity) licence without previous notification or agreements.

Notwithstanding the terms and conditions of this EULA, any part of the software contained with product by the WithoutCaps Team which 
constitutes Third Party Software and as such now owned is licenced to you subject to the terms and conditions of the software licence 
agreement accompanying such Third Party Software. Whatever the form of the licence, whether it be in the form of a discrete agreement, 
shrink wrap licence or electronic licence terms are accepted at the time of download or purchase of any software made by the WithoutCaps Team.

(d) Limitation of Liability. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) 2017 WithoutCaps
*/


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
