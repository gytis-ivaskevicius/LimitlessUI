using LimitlessUI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


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
        _animatorTimer = new AnimatorTimer_WOC();
        _animatorTimer.onAnimationTimerTick += animationTimer_Tick;

    }
    private void animationTimer_Tick(int progress)
    {
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
        get { return(int) _animatorTimer.Interval; }
        set { _animatorTimer.Interval = value; }
    }
}

