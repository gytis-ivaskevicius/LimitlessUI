using LimitlessUI;

namespace LimitlessUISample.Tabs
{
    partial class Other_Tab
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
            this.listView_WOC1 = new ListView_WOC();
            this.SuspendLayout();
            // 
            // listView_WOC1
            // 
            this.listView_WOC1.AutoExpand = false;
            this.listView_WOC1.AutoScroll = true;
            this.listView_WOC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_WOC1.Location = new System.Drawing.Point(0, 0);
            this.listView_WOC1.Name = "listView_WOC1";
            this.listView_WOC1.Size = new System.Drawing.Size(803, 507);
            this.listView_WOC1.TabIndex = 0;
            this.listView_WOC1.Text = "listView_WOC1";
            this.listView_WOC1.Vertical = true;
            // 
            // Other_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.listView_WOC1);
            this.Name = "Other_Tab";
            this.Size = new System.Drawing.Size(803, 507);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView_WOC listView_WOC1;
    }
}
