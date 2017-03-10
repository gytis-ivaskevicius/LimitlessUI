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

    private bool _changeSize_increase_width;
    private bool _changeSize_increase_height;
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
        _control.SuspendLayout();

        if (_changeWidth)
        {
            _control.Width += _changeSize_increase_width ? _changeSize_speed : -_changeSize_speed;
            if (_changeSize_increase_width && _control.Width > _changeSize_size.X)
            {
                _control.Width = _changeSize_size.X;
                _timer.Stop();
            }
            else if (!_changeSize_increase_width && _control.Width < _changeSize_size.X)
            {
                _control.Width = _changeSize_size.X;
                _timer.Stop();
            }
        }
        if (_changeHeight)
        {
            _control.Height += _changeSize_increase_height ? _changeSize_speed : -_changeSize_speed;
            if (_changeSize_increase_height && _control.Height > _changeSize_size.X)
            {
                _control.Height = _changeSize_size.X;
                _timer.Stop();
            }
            else if (!_changeSize_increase_height && _control.Height < _changeSize_size.X)
            {
                _control.Height = _changeSize_size.X;
                _timer.Stop();
            }
        }

        _control.ResumeLayout();
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

