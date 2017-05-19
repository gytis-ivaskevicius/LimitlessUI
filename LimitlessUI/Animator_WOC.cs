using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


public partial class Animator_WOC : Component
{
    private Timer _timer;
    private Control _control;
    private Point _changeSize_size;
    private int _changeSize_speed;

    public delegate void onWidthChanged(Control control, int change, bool isExpanding);
    public delegate void onHeightChanged(Control control, int change, bool isExpanding);
    public delegate void onAnimationTick(Control control);

    public event onWidthChanged _onWidthChanged_del;
    public event onHeightChanged _onHeightChanged_del;
    public event onAnimationTick _onAnimationEnd_del;
    public event onAnimationTick _onAnimationStart_del;

    private bool _changeSize_increase_width = false;
    private bool _changeSize_increase_height = false;
    private bool _changeWidth = false;
    private bool _changeHeight = false;

    public void reset()                     //This method will be accualy usefull once ill add more animations, so ya... JUST WAIT! ("power cut", sadly there is only one guy that gets this joke, i hope u enjoied it Ivan :D)
    {
        _changeWidth = false;
        _changeHeight = false;
    }

    public Animator_WOC()
    {
        _timer = new Timer();
        _timer.Tick += animationTimer_Tick;
        _timer.Interval = 17;
    }

    private void animationTimer_Tick(object sender, EventArgs e)
    {
        if (_control == null)
            throw new Exception("HI!!! I'm a developer of LimitlessUI and I hacked into your system!!! So, I thought that Ill help ya debug this crap - Okay, lets see... It seems that you forgot to add a control which you want to animate... Give it a shot, I'm sure that that's the issue!!  ...OH SHIT!!! Some shit went down, see ya later!");
        if (_onAnimationStart_del != null)
            _onAnimationStart_del.Invoke(_control);

        if (_changeWidth)
        {
            _control.Width += _changeSize_increase_width ? _changeSize_speed : -_changeSize_speed;
            if ((_changeSize_increase_width && _control.Width >= _changeSize_size.X) || (!_changeSize_increase_width && _control.Width <= _changeSize_size.X + _changeSize_speed))
            {
                _control.Width = _changeSize_size.X;
                _timer.Stop();
            }
            if (_onWidthChanged_del != null)
                _onWidthChanged_del.Invoke(_control, _changeSize_increase_width ? _changeSize_speed : -_changeSize_speed, _changeSize_increase_width);
        }
        if (_changeHeight)
        {
            _control.Height += _changeSize_increase_height ? _changeSize_speed : -_changeSize_speed;
            if ((_changeSize_increase_height && _control.Height >= _changeSize_size.Y) || (!_changeSize_increase_height && _control.Height <= _changeSize_size.Y + _changeSize_speed))
            {
                _control.Height = _changeSize_size.Y;
                _timer.Stop();
            }
            if (_onHeightChanged_del != null)
                _onHeightChanged_del.Invoke(_control, _changeSize_increase_height ? _changeSize_speed : -_changeSize_speed, _changeSize_increase_height);
        }

        if (_onAnimationEnd_del != null)
            _onAnimationEnd_del.Invoke(_control);
    }

    public void startAnimation()
    {
        if (!_timer.Enabled)
            _timer.Start();
    }

    public void changeSize(int speed, int x, int y)
    {
        changeSize(speed, new Point(x, y));
    }

    public void changeSize(int speed, Point size)
    {
        if (_control == null)
            return;

        _changeSize_speed = speed;
        _changeSize_increase_width = _control.Width < size.X;
        _changeSize_increase_height = _control.Height < size.Y;
        _changeSize_size = size;

        _changeWidth = _control.Width != size.X;
        _changeHeight = _control.Height != size.Y;
    }



    public Control Controls
    {
        get { return _control; }
        set { _control = value; }
    }

    public int Delay
    {
        get { return _timer.Interval; }
        set { _timer.Interval = value; }
    }
}

