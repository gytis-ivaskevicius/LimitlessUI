namespace LimitlessUISample
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabs_holder = new System.Windows.Forms.Panel();
            this.nav_panel = new System.Windows.Forms.Panel();
            this.flatButton_WOC6 = new FlatButton_WOC();
            this.flatButton_WOC5 = new FlatButton_WOC();
            this.flatButton_WOC4 = new FlatButton_WOC();
            this.flatButton_WOC3 = new FlatButton_WOC();
            this.flatButton_WOC2 = new FlatButton_WOC();
            this.flatButton_WOC1 = new FlatButton_WOC();
            this.header = new System.Windows.Forms.Panel();
            this.tab_title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.maximiseLabel = new System.Windows.Forms.Label();
            this.minimiseLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.separator_WOC1 = new Separator_WOC();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dragControl_WOC1 = new DragControl_WOC();
            this.elipse_WOC1 = new Elipse_WOC();
            this.control1 = new System.Windows.Forms.Control();
            this.nav_adapter = new TabsAdapter_WOC();
            this.panel1.SuspendLayout();
            this.nav_panel.SuspendLayout();
            this.header.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tabs_holder);
            this.panel1.Controls.Add(this.nav_panel);
            this.panel1.Controls.Add(this.header);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 563);
            this.panel1.TabIndex = 0;
            // 
            // tabs_holder
            // 
            this.tabs_holder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_holder.Location = new System.Drawing.Point(200, 61);
            this.tabs_holder.Name = "tabs_holder";
            this.tabs_holder.Size = new System.Drawing.Size(799, 502);
            this.tabs_holder.TabIndex = 2;
            // 
            // nav_panel
            // 
            this.nav_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.nav_panel.Controls.Add(this.flatButton_WOC6);
            this.nav_panel.Controls.Add(this.flatButton_WOC5);
            this.nav_panel.Controls.Add(this.flatButton_WOC4);
            this.nav_panel.Controls.Add(this.flatButton_WOC3);
            this.nav_panel.Controls.Add(this.flatButton_WOC2);
            this.nav_panel.Controls.Add(this.flatButton_WOC1);
            this.nav_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.nav_panel.Location = new System.Drawing.Point(0, 61);
            this.nav_panel.Name = "nav_panel";
            this.nav_panel.Size = new System.Drawing.Size(200, 502);
            this.nav_panel.TabIndex = 1;
            // 
            // flatButton_WOC6
            // 
            this.flatButton_WOC6.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.flatButton_WOC6.ActiveImage = null;
            this.flatButton_WOC6.ActiveTextColor = System.Drawing.Color.White;
            this.flatButton_WOC6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.flatButton_WOC6.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatButton_WOC6.DrawImage = true;
            this.flatButton_WOC6.DrawText = true;
            this.flatButton_WOC6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flatButton_WOC6.ForeColor = System.Drawing.Color.White;
            this.flatButton_WOC6.Image = ((System.Drawing.Image)(resources.GetObject("flatButton_WOC6.Image")));
            this.flatButton_WOC6.ImageSize = new System.Drawing.SizeF(20F, 20F);
            this.flatButton_WOC6.Location = new System.Drawing.Point(0, 240);
            this.flatButton_WOC6.Name = "flatButton_WOC6";
            this.flatButton_WOC6.OnHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.flatButton_WOC6.OnHoverTextColor = System.Drawing.Color.SeaGreen;
            this.flatButton_WOC6.Selected = false;
            this.flatButton_WOC6.Size = new System.Drawing.Size(200, 48);
            this.flatButton_WOC6.TabIndex = 5;
            this.flatButton_WOC6.Text = "Other";
            this.flatButton_WOC6.TextAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton_WOC6.TextOffset = new System.Drawing.Point(0, 0);
            this.flatButton_WOC6.UseActiveImageWhileHovering = false;
            this.flatButton_WOC6.Click += new System.EventHandler(this.navigation_click);
            // 
            // flatButton_WOC5
            // 
            this.flatButton_WOC5.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.flatButton_WOC5.ActiveImage = null;
            this.flatButton_WOC5.ActiveTextColor = System.Drawing.Color.White;
            this.flatButton_WOC5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.flatButton_WOC5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatButton_WOC5.DrawImage = true;
            this.flatButton_WOC5.DrawText = true;
            this.flatButton_WOC5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flatButton_WOC5.ForeColor = System.Drawing.Color.White;
            this.flatButton_WOC5.Image = ((System.Drawing.Image)(resources.GetObject("flatButton_WOC5.Image")));
            this.flatButton_WOC5.ImageSize = new System.Drawing.SizeF(20F, 20F);
            this.flatButton_WOC5.Location = new System.Drawing.Point(0, 192);
            this.flatButton_WOC5.Name = "flatButton_WOC5";
            this.flatButton_WOC5.OnHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.flatButton_WOC5.OnHoverTextColor = System.Drawing.Color.SeaGreen;
            this.flatButton_WOC5.Selected = false;
            this.flatButton_WOC5.Size = new System.Drawing.Size(200, 48);
            this.flatButton_WOC5.TabIndex = 4;
            this.flatButton_WOC5.Text = "Slider";
            this.flatButton_WOC5.TextAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton_WOC5.TextOffset = new System.Drawing.Point(0, 0);
            this.flatButton_WOC5.UseActiveImageWhileHovering = false;
            this.flatButton_WOC5.Click += new System.EventHandler(this.navigation_click);
            // 
            // flatButton_WOC4
            // 
            this.flatButton_WOC4.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.flatButton_WOC4.ActiveImage = null;
            this.flatButton_WOC4.ActiveTextColor = System.Drawing.Color.White;
            this.flatButton_WOC4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.flatButton_WOC4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatButton_WOC4.DrawImage = true;
            this.flatButton_WOC4.DrawText = true;
            this.flatButton_WOC4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flatButton_WOC4.ForeColor = System.Drawing.Color.White;
            this.flatButton_WOC4.Image = ((System.Drawing.Image)(resources.GetObject("flatButton_WOC4.Image")));
            this.flatButton_WOC4.ImageSize = new System.Drawing.SizeF(20F, 20F);
            this.flatButton_WOC4.Location = new System.Drawing.Point(0, 144);
            this.flatButton_WOC4.Name = "flatButton_WOC4";
            this.flatButton_WOC4.OnHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.flatButton_WOC4.OnHoverTextColor = System.Drawing.Color.SeaGreen;
            this.flatButton_WOC4.Selected = false;
            this.flatButton_WOC4.Size = new System.Drawing.Size(200, 48);
            this.flatButton_WOC4.TabIndex = 3;
            this.flatButton_WOC4.Text = "Gradient";
            this.flatButton_WOC4.TextAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton_WOC4.TextOffset = new System.Drawing.Point(0, 0);
            this.flatButton_WOC4.UseActiveImageWhileHovering = false;
            this.flatButton_WOC4.Click += new System.EventHandler(this.navigation_click);
            // 
            // flatButton_WOC3
            // 
            this.flatButton_WOC3.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.flatButton_WOC3.ActiveImage = null;
            this.flatButton_WOC3.ActiveTextColor = System.Drawing.Color.White;
            this.flatButton_WOC3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.flatButton_WOC3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatButton_WOC3.DrawImage = true;
            this.flatButton_WOC3.DrawText = true;
            this.flatButton_WOC3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flatButton_WOC3.ForeColor = System.Drawing.Color.White;
            this.flatButton_WOC3.Image = ((System.Drawing.Image)(resources.GetObject("flatButton_WOC3.Image")));
            this.flatButton_WOC3.ImageSize = new System.Drawing.SizeF(20F, 20F);
            this.flatButton_WOC3.Location = new System.Drawing.Point(0, 96);
            this.flatButton_WOC3.Name = "flatButton_WOC3";
            this.flatButton_WOC3.OnHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.flatButton_WOC3.OnHoverTextColor = System.Drawing.Color.SeaGreen;
            this.flatButton_WOC3.Selected = false;
            this.flatButton_WOC3.Size = new System.Drawing.Size(200, 48);
            this.flatButton_WOC3.TabIndex = 2;
            this.flatButton_WOC3.Text = "DropDown";
            this.flatButton_WOC3.TextAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton_WOC3.TextOffset = new System.Drawing.Point(0, 0);
            this.flatButton_WOC3.UseActiveImageWhileHovering = false;
            this.flatButton_WOC3.Click += new System.EventHandler(this.navigation_click);
            // 
            // flatButton_WOC2
            // 
            this.flatButton_WOC2.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.flatButton_WOC2.ActiveImage = null;
            this.flatButton_WOC2.ActiveTextColor = System.Drawing.Color.White;
            this.flatButton_WOC2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.flatButton_WOC2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatButton_WOC2.DrawImage = true;
            this.flatButton_WOC2.DrawText = true;
            this.flatButton_WOC2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flatButton_WOC2.ForeColor = System.Drawing.Color.White;
            this.flatButton_WOC2.Image = ((System.Drawing.Image)(resources.GetObject("flatButton_WOC2.Image")));
            this.flatButton_WOC2.ImageSize = new System.Drawing.SizeF(20F, 20F);
            this.flatButton_WOC2.Location = new System.Drawing.Point(0, 48);
            this.flatButton_WOC2.Name = "flatButton_WOC2";
            this.flatButton_WOC2.OnHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.flatButton_WOC2.OnHoverTextColor = System.Drawing.Color.SeaGreen;
            this.flatButton_WOC2.Selected = false;
            this.flatButton_WOC2.Size = new System.Drawing.Size(200, 48);
            this.flatButton_WOC2.TabIndex = 1;
            this.flatButton_WOC2.Text = "ProgressBar";
            this.flatButton_WOC2.TextAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton_WOC2.TextOffset = new System.Drawing.Point(0, 0);
            this.flatButton_WOC2.UseActiveImageWhileHovering = false;
            this.flatButton_WOC2.Click += new System.EventHandler(this.navigation_click);
            // 
            // flatButton_WOC1
            // 
            this.flatButton_WOC1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.flatButton_WOC1.ActiveImage = null;
            this.flatButton_WOC1.ActiveTextColor = System.Drawing.Color.White;
            this.flatButton_WOC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.flatButton_WOC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatButton_WOC1.DrawImage = true;
            this.flatButton_WOC1.DrawText = true;
            this.flatButton_WOC1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flatButton_WOC1.ForeColor = System.Drawing.Color.White;
            this.flatButton_WOC1.Image = ((System.Drawing.Image)(resources.GetObject("flatButton_WOC1.Image")));
            this.flatButton_WOC1.ImageSize = new System.Drawing.SizeF(20F, 20F);
            this.flatButton_WOC1.Location = new System.Drawing.Point(0, 0);
            this.flatButton_WOC1.Name = "flatButton_WOC1";
            this.flatButton_WOC1.OnHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.flatButton_WOC1.OnHoverTextColor = System.Drawing.Color.SeaGreen;
            this.flatButton_WOC1.Selected = true;
            this.flatButton_WOC1.Size = new System.Drawing.Size(200, 48);
            this.flatButton_WOC1.TabIndex = 0;
            this.flatButton_WOC1.Text = "ArchProgressBar";
            this.flatButton_WOC1.TextAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton_WOC1.TextOffset = new System.Drawing.Point(0, 0);
            this.flatButton_WOC1.UseActiveImageWhileHovering = false;
            this.flatButton_WOC1.Click += new System.EventHandler(this.navigation_click);
            // 
            // header
            // 
            this.header.Controls.Add(this.tab_title);
            this.header.Controls.Add(this.panel2);
            this.header.Controls.Add(this.separator_WOC1);
            this.header.Controls.Add(this.panel4);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(999, 61);
            this.header.TabIndex = 0;
            // 
            // tab_title
            // 
            this.tab_title.AutoSize = true;
            this.tab_title.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.tab_title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tab_title.Location = new System.Drawing.Point(233, 13);
            this.tab_title.Name = "tab_title";
            this.tab_title.Size = new System.Drawing.Size(125, 31);
            this.tab_title.TabIndex = 3;
            this.tab_title.Text = "LimitlessUI";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.maximiseLabel);
            this.panel2.Controls.Add(this.minimiseLabel);
            this.panel2.Controls.Add(this.exitLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(848, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 60);
            this.panel2.TabIndex = 2;
            // 
            // maximiseLabel
            // 
            this.maximiseLabel.AutoSize = true;
            this.maximiseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximiseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.maximiseLabel.Location = new System.Drawing.Point(85, 13);
            this.maximiseLabel.Name = "maximiseLabel";
            this.maximiseLabel.Size = new System.Drawing.Size(29, 25);
            this.maximiseLabel.TabIndex = 6;
            this.maximiseLabel.Text = "▭";
            this.maximiseLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.maximiseLabel.Click += new System.EventHandler(this.maximiseLabel_Click);
            // 
            // minimiseLabel
            // 
            this.minimiseLabel.AutoSize = true;
            this.minimiseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimiseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.minimiseLabel.Location = new System.Drawing.Point(59, 9);
            this.minimiseLabel.Name = "minimiseLabel";
            this.minimiseLabel.Size = new System.Drawing.Size(24, 25);
            this.minimiseLabel.TabIndex = 5;
            this.minimiseLabel.Text = "_";
            this.minimiseLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.minimiseLabel.Click += new System.EventHandler(this.minimiseLabel_Click);
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.exitLabel.Location = new System.Drawing.Point(114, 13);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(26, 25);
            this.exitLabel.TabIndex = 4;
            this.exitLabel.Text = "X";
            this.exitLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // separator_WOC1
            // 
            this.separator_WOC1.AnimationColor = System.Drawing.Color.SeaGreen;
            this.separator_WOC1.AnimationEnabled = false;
            this.separator_WOC1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator_WOC1.LineColor = System.Drawing.Color.DimGray;
            this.separator_WOC1.LineThikness = 1F;
            this.separator_WOC1.Location = new System.Drawing.Point(200, 60);
            this.separator_WOC1.Name = "separator_WOC1";
            this.separator_WOC1.Size = new System.Drawing.Size(799, 1);
            this.separator_WOC1.TabIndex = 1;
            this.separator_WOC1.Text = "separator_WOC1";
            this.separator_WOC1.Val = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaGreen;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 61);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "LimitlessUI";
            // 
            // dragControl_WOC1
            // 
            this.dragControl_WOC1.Fixed = true;
            this.dragControl_WOC1.MaximiseOnDoubleClick = true;
            this.dragControl_WOC1.TargetControl = this.header;
            // 
            // elipse_WOC1
            // 
            this.elipse_WOC1.ConerRadius = 20;
            this.elipse_WOC1.TargetControl = this;
            // 
            // control1
            // 
            this.control1.Location = new System.Drawing.Point(0, 0);
            this.control1.Name = "control1";
            this.control1.Size = new System.Drawing.Size(0, 0);
            this.control1.TabIndex = 0;
            this.control1.Text = "control1";
            // 
            // nav_adapter
            // 
            this.nav_adapter.Control = this.tabs_holder;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 571);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.nav_panel.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel nav_panel;
        private FlatButton_WOC flatButton_WOC1;
        private System.Windows.Forms.Panel header;
        private Separator_WOC separator_WOC1;
        private System.Windows.Forms.Panel panel4;
        private DragControl_WOC dragControl_WOC1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label maximiseLabel;
        private System.Windows.Forms.Label minimiseLabel;
        private System.Windows.Forms.Label exitLabel;
        private FlatButton_WOC flatButton_WOC2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tab_title;
        private System.Windows.Forms.Panel tabs_holder;
        private Elipse_WOC elipse_WOC1;
        private FlatButton_WOC flatButton_WOC3;
        private FlatButton_WOC flatButton_WOC4;
        private FlatButton_WOC flatButton_WOC5;
        private FlatButton_WOC flatButton_WOC6;
        private System.Windows.Forms.Control control1;
        private TabsAdapter_WOC nav_adapter;
    }
}

