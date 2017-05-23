namespace LimitlessUI
{
    partial class MaterialTextBox_WOC
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.seperator = new Separator_WOC();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panel2.Size = new System.Drawing.Size(172, 27);
            this.panel2.TabIndex = 0;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(4, 0);
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textBox.Size = new System.Drawing.Size(164, 27);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            this.textBox.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.textBox.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // seperator
            // 
            this.seperator.AnimationEnabled = true;
            this.seperator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.seperator.LineColor = System.Drawing.Color.DimGray;
            this.seperator.LineThikness = 3F;
            this.seperator.Location = new System.Drawing.Point(0, 24);
            this.seperator.Name = "seperator";
            this.seperator.Size = new System.Drawing.Size(172, 3);
            this.seperator.TabIndex = 1;
            this.seperator.Text = "separator_WOC2";
            // 
            // TextBox_WOC
            // 
            this.Controls.Add(this.seperator);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Name = "TextBox_WOC";
            this.Size = new System.Drawing.Size(172, 27);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private Separator_WOC seperator;
        private System.Windows.Forms.RichTextBox textBox;
    }
}
