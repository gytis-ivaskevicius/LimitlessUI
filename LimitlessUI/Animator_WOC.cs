using LimitlessUI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
    public partial class Animator_WOC : Component
    {
        public AnimatorTimer_WOC _animatorTimer;
        private Control _control;
        private Animations _animation = Animations.ChangeWidth;

        public delegate void onWidthChanged(Control control, int change);
        public delegate void onHeightChanged(Control control, int change);
        public delegate void onAnimationTick(Control control);

        public event onWidthChanged _onWidthChanged_del;
        public event onHeightChanged _onHeightChanged_del;
        public event onAnimationTick _onAnimationTick_del;



        public enum Animations
        {
            ChangeWidth,
            ChangeHeight
        }

        public Animator_WOC()
        {
            _animatorTimer = new AnimatorTimer_WOC(Utils_WOC.getFormForThreading());
            _animatorTimer.onAnimationTimerTick += animationTimer_Tick;

        }
        private void animationTimer_Tick(int progress)
        {
            if (_control != null)
                switch (_animation)
                {
                    case Animations.ChangeWidth:
                        _control.Width = progress;
                        if (_onWidthChanged_del != null)
                            _onWidthChanged_del.Invoke(_control, progress);
                        break;
                    case Animations.ChangeHeight:
                        _control.Height = progress;
                        if (_onHeightChanged_del != null)
                            _onHeightChanged_del.Invoke(_control, progress);
                        break;
                }
            else Debug.WriteLine("Animator_WOC CONTROL IS EQUAL NULL!!!!!!!!!!!!!!!!!!!!!!");
            if (_onAnimationTick_del != null)
                _onAnimationTick_del.Invoke(_control);
        }


        public void animate(int animationLength, int value)
        {
            _animatorTimer.setValueRange(value, _animation == Animations.ChangeWidth ? _control.Width : _control.Height, animationLength, true);
        }


        public Animations Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }


        public Control Controls
        {
            get { return _control; }
            set { _control = value; }
        }

        public int Delay
        {
            get { return (int)_animatorTimer.Interval; }
        }
    }
}

