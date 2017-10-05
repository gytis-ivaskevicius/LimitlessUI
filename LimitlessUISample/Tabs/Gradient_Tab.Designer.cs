using LimitlessUI;

namespace LimitlessUISample.Tabs
{
    partial class Gradient_Tab
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
            this.gradientPanel_WOC1 = new LimitlessUI.GradientPanel_WOC();
            this.button_WOC1 = new LimitlessUI.Button_WOC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.animator_WOC1 = new LimitlessUI.Animator_WOC();
            this.gradientPanel_WOC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel_WOC1
            // 
            this.gradientPanel_WOC1.Angle = 0F;
            this.gradientPanel_WOC1.Controls.Add(this.button_WOC1);
            this.gradientPanel_WOC1.Controls.Add(this.panel1);
            this.gradientPanel_WOC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel_WOC1.EndColor = System.Drawing.Color.White;
            this.gradientPanel_WOC1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel_WOC1.Name = "gradientPanel_WOC1";
            this.gradientPanel_WOC1.Size = new System.Drawing.Size(803, 507);
            this.gradientPanel_WOC1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.gradientPanel_WOC1.TabIndex = 0;
            this.gradientPanel_WOC1.Text = "gradientPanel_WOC1";
            // 
            // button_WOC1
            // 
            this.button_WOC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC1.Location = new System.Drawing.Point(67, 35);
            this.button_WOC1.Name = "button_WOC1";
            this.button_WOC1.Size = new System.Drawing.Size(373, 120);
            this.button_WOC1.TabIndex = 1;
            this.button_WOC1.Text = "Ugly button";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(446, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 501);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click_1);
            // 
            // animator_WOC1
            // 
            this.animator_WOC1.Animation = LimitlessUI.Animator_WOC.Animations.ChangeWidth;
            this.animator_WOC1.Control = this.panel1;
            // 
            // Gradient_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gradientPanel_WOC1);
            this.Name = "Gradient_Tab";
            this.Size = new System.Drawing.Size(803, 507);
            this.gradientPanel_WOC1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel_WOC gradientPanel_WOC1;
        private Animator_WOC animator_WOC1;
        private System.Windows.Forms.Panel panel1;
        private Button_WOC button_WOC1;
    }
}
