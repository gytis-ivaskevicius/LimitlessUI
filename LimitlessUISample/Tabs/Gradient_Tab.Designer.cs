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
            this.animator_WOC1 = new Animator_WOC();
            this.SuspendLayout();
            // 
            // gradientPanel_WOC1
            // 
            this.gradientPanel_WOC1.Angle = 0F;
            this.gradientPanel_WOC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel_WOC1.EndColor = System.Drawing.Color.White;
            this.gradientPanel_WOC1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel_WOC1.Name = "gradientPanel_WOC1";
            this.gradientPanel_WOC1.Size = new System.Drawing.Size(803, 507);
            this.gradientPanel_WOC1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.gradientPanel_WOC1.TabIndex = 0;
            this.gradientPanel_WOC1.Text = "gradientPanel_WOC1";
            // 
            // animator_WOC1
            // 
            this.animator_WOC1.Animation = Animator_WOC.Animations.ChangeWidth;
            this.animator_WOC1.Delay = 17;
            // 
            // Gradient_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gradientPanel_WOC1);
            this.Name = "Gradient_Tab";
            this.Size = new System.Drawing.Size(803, 507);
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel_WOC gradientPanel_WOC1;
        private Animator_WOC animator_WOC1;
    }
}
