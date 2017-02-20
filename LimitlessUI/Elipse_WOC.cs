using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public partial class Elipse_WOC : Component
{
    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn
     (
    int nLeftRect, // x-coordinate of upper-left corner
    int nTopRect, // y-coordinate of upper-left corner
    int nRightRect, // x-coordinate of lower-right corner
    int nBottomRect, // y-coordinate of lower-right corner
    int nWidthEllipse, // height of ellipse
    int nHeightEllipse // width of ellipse
    );

    private Control _control;
    private int _conerRadius = 20;

    private void ControlOnSizeChanged(object sender, EventArgs eventArgs)
    {
        if (_control != null)
            _control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _control.Width, _control.Height, _conerRadius, _conerRadius));
    }

    public Control TargetControl
    {
        get { return _control; }
        set
        {
            _control = value;
            _control.SizeChanged += ControlOnSizeChanged;
            _control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _control.Width, _control.Height, _conerRadius, _conerRadius));
        }
    }

    public int ConerRadius
    {
        get { return _conerRadius; }
        set
        {
            _conerRadius = value;
            if (_control != null)
                _control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _control.Width, _control.Height, _conerRadius, _conerRadius));
        }
    }
}

