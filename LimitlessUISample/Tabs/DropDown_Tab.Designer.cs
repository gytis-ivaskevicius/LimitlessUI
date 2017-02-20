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
            this.dropDown_WOC1 = new DropDown_WOC();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dropDown_WOC1
            // 
            this.dropDown_WOC1.ArrowSize = new System.Drawing.SizeF(10F, 10F);
            this.dropDown_WOC1.ArrowThinkness = 2F;
            this.dropDown_WOC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dropDown_WOC1.Location = new System.Drawing.Point(0, 0);
            this.dropDown_WOC1.Name = "dropDown_WOC1";
            this.dropDown_WOC1.SetLayout = this.button1;
            this.dropDown_WOC1.Size = new System.Drawing.Size(803, 32);
            this.dropDown_WOC1.TabIndex = 0;
            this.dropDown_WOC1.Text = "This is dropdown thingy";
            this.dropDown_WOC1.TextDistance = 35F;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button1.Location = new System.Drawing.Point(0, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(803, 242);
            this.button1.TabIndex = 1;
            this.button1.Text = "Random Button";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DropDown_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dropDown_WOC1);
            this.Name = "DropDown_Tab";
            this.Size = new System.Drawing.Size(803, 507);
            this.ResumeLayout(false);

        }

        #endregion

        private DropDown_WOC dropDown_WOC1;
        private System.Windows.Forms.Button button1;
    }
}
