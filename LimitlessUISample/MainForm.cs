using LimitlessUI;
using LimitlessUISample.Tabs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace LimitlessUISample
{
    public partial class MainForm : Form_WOC
    {
        public MainForm()
        {
            InitializeComponent();
            Utils_WOC._threadsForm = this;

            tabs_holder.Controls.Add(ArchProgressBar_Tab.getInstance());
            ArchProgressBar_Tab.getInstance().Dock = DockStyle.Fill;
            ArchProgressBar_Tab.getInstance().BringToFront();



            DrawLine(LinePositions.Left, Color.FromArgb(41, 53, 65), 65, Height);
            DrawLine(LinePositions.Left, Color.SeaGreen, 0, 65);
            DrawLine(LinePositions.Top, Color.SeaGreen, 0, 204);
            DrawLine(LinePositions.Bottom, Color.FromArgb(41, 53, 65), 0, 203);
            Invalidate();
            SetupNavigation();
        }


        private void SetupNavigation()
        {
            nav_adapter.AddTab(new ArchProgressBar_Tab(), true);
            nav_adapter.AddTab(new ProgressBar_Tab(), false);
            nav_adapter.AddTab(new DropDown_Tab(), false);
            nav_adapter.AddTab(new Gradient_Tab(), false);
            nav_adapter.AddTab(new Slider_Tab(), false);
            nav_adapter.AddTab(new Other_Tab(), false);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            DrawLine(LinePositions.Left, Color.FromArgb(41, 53, 65), 65, Height);
            Invalidate();
        }


        //-----------------------------------------[Form Handling]--------------------------------------------------//
        private void navigation_click(object sender, EventArgs e)
        {
            nav_adapter.ShowTab(((FlatButton_WOC)sender).TabIndex);
        }
        private void exitLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimiseLabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void maximiseLabel_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }
    }
}
