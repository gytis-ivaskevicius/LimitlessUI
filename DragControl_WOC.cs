using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUI
{
    public partial class DragControl_WOC : Component
    {
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        private Control control;
        private Form controForm;

        private bool dragType = true;
        private bool maximiseOnDoubleClick = true;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        public Control TargetControl
        {
            get { return control; }
            set
            {
                control = value;
                if (value != null)
                    control.MouseDown += onControlMouseDown;
            }
        }

        public bool Fixed
        {
            get { return dragType; }
            set { dragType = value; }
        }

        public bool MaximiseOnDoubleClick
        {
            get { return maximiseOnDoubleClick; }
            set { maximiseOnDoubleClick = value; }
        }

        private void onControlMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                if (dragType)
                    SendMessage(control.FindForm().Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                else
                    SendMessage(control.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            if (e.Button == MouseButtons.Left && e.Clicks == 2 && maximiseOnDoubleClick)
            {
                if (control.FindForm().WindowState == FormWindowState.Normal)
                    control.FindForm().WindowState = FormWindowState.Maximized;
                else
                    control.FindForm().WindowState = FormWindowState.Normal;
            }
        }
    }
}
