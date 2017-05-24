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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.separator_WOC1 = new Separator_WOC();
            this.textBox_WOC1 = new LimitlessUI.MaterialTextBox_WOC();
            this.switch_WOC1 = new Switch_WOC();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_WOC1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 50);
            this.panel2.TabIndex = 4;
            // 
            // separator_WOC1
            // 
            this.separator_WOC1.AnimationColor = System.Drawing.Color.SeaGreen;
            this.separator_WOC1.AnimationEnabled = false;
            this.separator_WOC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.separator_WOC1.LineColor = System.Drawing.Color.DimGray;
            this.separator_WOC1.LineThikness = 1F;
            this.separator_WOC1.Location = new System.Drawing.Point(259, 0);
            this.separator_WOC1.Name = "separator_WOC1";
            this.separator_WOC1.Size = new System.Drawing.Size(463, 50);
            this.separator_WOC1.TabIndex = 5;
            this.separator_WOC1.Text = "separator_WOC1";
            this.separator_WOC1.Val = 0;
            // 
            // textBox_WOC1
            // 
            this.textBox_WOC1.AnimationColor = System.Drawing.Color.Purple;
            this.textBox_WOC1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.textBox_WOC1.Location = new System.Drawing.Point(20, 12);
            this.textBox_WOC1.Name = "textBox_WOC1";
            this.textBox_WOC1.Size = new System.Drawing.Size(172, 27);
            this.textBox_WOC1.TabIndex = 0;
            this.textBox_WOC1.TextBoxText = "Awsome EditText 100";
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
            this.ResumeLayout(false);

        }

        #endregion

        private Switch_WOC switch_WOC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Separator_WOC separator_WOC1;
        private LimitlessUI.MaterialTextBox_WOC textBox_WOC1;
    }
}
