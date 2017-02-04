using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUI
{
    public partial class Elipse_WOC : Component
    {
        private Control control;
        private int conerRadius = 20;

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


        private void ControlOnSizeChanged(object sender, EventArgs eventArgs)
        {
            if (control != null)
                control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, conerRadius, conerRadius));
        }

        public Control TargetControl
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
                control.SizeChanged += ControlOnSizeChanged;
                control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, conerRadius, conerRadius));
            }
        }

        public int ConerRadius
        {
            get { return conerRadius; }
            set
            {
                conerRadius = value;
                if (control != null)
                    control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, conerRadius, conerRadius));
            }
        }
    }
}
