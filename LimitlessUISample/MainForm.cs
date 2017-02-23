using LimitlessUISample.Tabs;
using System;
using System.Drawing;
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

            
            drawLine(LinePositions.LEFT, Color.FromArgb(41, 53, 65), 64, Height);
            drawLine(LinePositions.LEFT, Color.SeaGreen, 0, 64);
            drawLine(LinePositions.TOP, Color.SeaGreen, 0, 203);
            drawLine(LinePositions.BOTTOM, Color.FromArgb(41, 53, 65), 0, 203);
            Invalidate();
        }
        //-----------------------------------------[Form Handling]--------------------------------------------------//
        private void navigation_click(object sender, EventArgs e)
        {
            switch (((FlatButton_WOC)sender).TabIndex)
            {
                case 0:
                    ArchProgressBar_Tab.getInstance().BringToFront();
                    tab_title.Text = "ArchProgressBar Sample";
                    break;
                case 1:
                    if (!tabs_holder.Controls.Contains(ProgressBar_Tab.getInstance()))
                    {
                        tabs_holder.Controls.Add(ProgressBar_Tab.getInstance());
                        ProgressBar_Tab.getInstance().Dock = DockStyle.Fill;
                        ProgressBar_Tab.getInstance().BringToFront();
                    }
                    else
                        ProgressBar_Tab.getInstance().BringToFront();
                    tab_title.Text = "ProgressBar Sample";
                    break;
                case 2:
                    if (!tabs_holder.Controls.Contains(DropDown_Tab.getInstance()))
                    {
                        tabs_holder.Controls.Add(DropDown_Tab.getInstance());
                        DropDown_Tab.getInstance().Dock = DockStyle.Fill;
                        DropDown_Tab.getInstance().BringToFront();
                    }
                    else
                        DropDown_Tab.getInstance().BringToFront();
                    tab_title.Text = "DropDown Sample";
                    break;
                case 3:
                    if (!tabs_holder.Controls.Contains(Gradient_Tab.getInstance()))
                    {
                        tabs_holder.Controls.Add(Gradient_Tab.getInstance());
                        Gradient_Tab.getInstance().Dock = DockStyle.Fill;
                        Gradient_Tab.getInstance().BringToFront();
                    }
                    else
                        Gradient_Tab.getInstance().BringToFront();
                    tab_title.Text = "Gradient Sample";
                    break;
                case 4:
                    if (!tabs_holder.Controls.Contains(Slider_Tab.getInstance()))
                    {
                        tabs_holder.Controls.Add(Slider_Tab.getInstance());
                        Slider_Tab.getInstance().Dock = DockStyle.Fill;
                        Slider_Tab.getInstance().BringToFront();
                    }
                    else
                        Slider_Tab.getInstance().BringToFront();
                    tab_title.Text = "Slider Sample";
                    break;
                case 5:
                    if (!tabs_holder.Controls.Contains(Other_Tab.getInstance()))
                    {
                        tabs_holder.Controls.Add(Other_Tab.getInstance());
                        Other_Tab.getInstance().Dock = DockStyle.Fill;
                        Other_Tab.getInstance().BringToFront();
                    }
                    else
                        Other_Tab.getInstance().BringToFront();
                    tab_title.Text = "Other";
                    break;
            }
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
