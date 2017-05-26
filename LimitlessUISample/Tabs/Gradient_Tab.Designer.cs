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
            this.gradientPanel_WOC1 = new GradientPanel_WOC();
            this.materialTextBox_WOC1 = new LimitlessUI.MaterialTextBox_WOC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.animator_WOC1 = new Animator_WOC();
            this.test1 = new LimitlessUISample.Test();
            this.gradientPanel_WOC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel_WOC1
            // 
            this.gradientPanel_WOC1.Angle = 0F;
            this.gradientPanel_WOC1.Controls.Add(this.test1);
            this.gradientPanel_WOC1.Controls.Add(this.materialTextBox_WOC1);
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
            // materialTextBox_WOC1
            // 
            this.materialTextBox_WOC1.AnimationColor = System.Drawing.Color.Red;
            this.materialTextBox_WOC1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.materialTextBox_WOC1.Location = new System.Drawing.Point(344, 81);
            this.materialTextBox_WOC1.Name = "materialTextBox_WOC1";
            this.materialTextBox_WOC1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.materialTextBox_WOC1.Size = new System.Drawing.Size(35, 35);
            this.materialTextBox_WOC1.TabIndex = 2;
            this.materialTextBox_WOC1.Text = "";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(65, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 32);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // animator_WOC1
            // 
            this.animator_WOC1.Animation = Animator_WOC.Animations.ChangeWidth;
            this.animator_WOC1.Controls = this.panel1;
            this.animator_WOC1.Delay = 17;
            // 
            // test1
            // 
            this.test1.Location = new System.Drawing.Point(451, 184);
            this.test1.Name = "test1";
            this.test1.Size = new System.Drawing.Size(75, 66);
            this.test1.TabIndex = 3;
            this.test1.Text = "test1";
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
        private System.Windows.Forms.Panel panel1;
        private Animator_WOC animator_WOC1;
        private LimitlessUI.MaterialTextBox_WOC materialTextBox_WOC1;
        private Test test1;
    }
}
