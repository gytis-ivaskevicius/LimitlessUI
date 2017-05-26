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

            tabs_holder.Controls.Add(ArchProgressBar_Tab.getInstance());
            ArchProgressBar_Tab.getInstance().Dock = DockStyle.Fill;
            ArchProgressBar_Tab.getInstance().BringToFront();



            drawLine(LinePositions.LEFT, Color.FromArgb(41, 53, 65), 65, Height);
            drawLine(LinePositions.LEFT, Color.SeaGreen, 0, 65);
            drawLine(LinePositions.TOP, Color.SeaGreen, 0, 204);
            drawLine(LinePositions.BOTTOM, Color.FromArgb(41, 53, 65), 0, 203);
            Invalidate();
            setupNavigation();
        }


        private void setupNavigation()
        {
            nav_adapter.addTab(new ArchProgressBar_Tab(), true);
            nav_adapter.addTab(new ProgressBar_Tab(), false);
            nav_adapter.addTab(new DropDown_Tab(), false);
            nav_adapter.addTab(new Gradient_Tab(), false);
            nav_adapter.addTab(new Slider_Tab(), false);
            nav_adapter.addTab(new Other_Tab(), false);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            drawLine(LinePositions.LEFT, Color.FromArgb(41, 53, 65), 65, Height);
            Invalidate();
        }


        //-----------------------------------------[Form Handling]--------------------------------------------------//
        private void navigation_click(object sender, EventArgs e)
        {
            nav_adapter.showTab(((FlatButton_WOC)sender).TabIndex);
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
