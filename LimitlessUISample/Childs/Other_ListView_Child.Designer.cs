namespace LimitlessUISample.Childs
{
    partial class Other_ListView_Child
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
            this.switch_WOC1 = new Switch_WOC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.separator_WOC1 = new Separator_WOC();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // switch_WOC1
            // 
            this.switch_WOC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.switch_WOC1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.switch_WOC1.IsOn = true;
            this.switch_WOC1.Location = new System.Drawing.Point(13, 15);
            this.switch_WOC1.Name = "switch_WOC1";
            this.switch_WOC1.OffColor = System.Drawing.Color.DarkGray;
            this.switch_WOC1.OffText = "Off";
            this.switch_WOC1.OnColor = System.Drawing.Color.SeaGreen;
            this.switch_WOC1.OnText = "On";
            this.switch_WOC1.Size = new System.Drawing.Size(51, 18);
            this.switch_WOC1.TabIndex = 0;
            this.switch_WOC1.Text = "switch_WOC1";
            this.switch_WOC1.TextEnabled = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.switch_WOC1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(722, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 50);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "The Most Awsome ListView Child 100";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 50);
            this.panel2.TabIndex = 4;
            // 
            // separator_WOC1
            // 
            this.separator_WOC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.separator_WOC1.LineColor = System.Drawing.Color.DimGray;
            this.separator_WOC1.LineThikness = 1F;
            this.separator_WOC1.Location = new System.Drawing.Point(259, 0);
            this.separator_WOC1.Name = "separator_WOC1";
            this.separator_WOC1.Size = new System.Drawing.Size(463, 50);
            this.separator_WOC1.TabIndex = 5;
            this.separator_WOC1.Text = "separator_WOC1";
            // 
            // Other_ListView_Child
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.separator_WOC1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Other_ListView_Child";
            this.Size = new System.Drawing.Size(803, 50);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Switch_WOC switch_WOC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Separator_WOC separator_WOC1;
    }
}
