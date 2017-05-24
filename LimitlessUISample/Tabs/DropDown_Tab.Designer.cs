namespace LimitlessUISample.Tabs
{
    partial class DropDown_Tab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.dropDown_WOC1 = new DropDown_WOC();
            this.chart_UC1 = new LimitlessUISample.Childs.Chart_UC();
            this.animator_WOC1 = new Animator_WOC();
            this.listView_WOC1 = new ListView_WOC();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            // 
            // dropDown_WOC1
            // 
            this.dropDown_WOC1.ArrowSize = new System.Drawing.SizeF(12F, 12F);
            this.dropDown_WOC1.ArrowThinkness = 2F;
            this.dropDown_WOC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dropDown_WOC1.DownImage = null;
            this.dropDown_WOC1.Location = new System.Drawing.Point(0, 0);
            this.dropDown_WOC1.Name = "dropDown_WOC1";
            this.dropDown_WOC1.PointsDown = true;
            this.dropDown_WOC1.SetLayout = this.chart_UC1;
            this.dropDown_WOC1.Size = new System.Drawing.Size(803, 32);
            this.dropDown_WOC1.TabIndex = 0;
            this.dropDown_WOC1.Text = "This is dropdown thingy";
            this.dropDown_WOC1.TextDistance = 35F;
            this.dropDown_WOC1.UpImage = null;
            // 
            // chart_UC1
            // 
            this.chart_UC1.BackColor = System.Drawing.Color.White;
            this.chart_UC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart_UC1.Location = new System.Drawing.Point(0, 32);
            this.chart_UC1.Name = "chart_UC1";
            this.chart_UC1.Size = new System.Drawing.Size(803, 323);
            this.chart_UC1.TabIndex = 4;
            // 
            // animator_WOC1
            // 
            this.animator_WOC1.Controls = null;
            this.animator_WOC1.Delay = 17;
            // 
            // listView_WOC1
            // 
            this.listView_WOC1.AutoExpand = false;
            this.listView_WOC1.AutoScroll = true;
            this.listView_WOC1.Location = new System.Drawing.Point(0, 0);
            this.listView_WOC1.Name = "listView_WOC1";
            this.listView_WOC1.Size = new System.Drawing.Size(0, 0);
            this.listView_WOC1.TabIndex = 0;
            this.listView_WOC1.Vertical = true;
            // 
            // DropDown_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chart_UC1);
            this.Controls.Add(this.dropDown_WOC1);
            this.Name = "DropDown_Tab";
            this.Size = new System.Drawing.Size(803, 507);
            this.ResumeLayout(false);

        }

        #endregion

        private DropDown_WOC dropDown_WOC1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Animator_WOC animator_WOC1;
        private ListView_WOC listView_WOC1;
        private Childs.Chart_UC chart_UC1;
    }
}
