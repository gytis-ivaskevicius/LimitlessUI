namespace LimitlessUISample.Childs
{
    partial class Chart_UC
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
            this.legend_WOC2 = new LimitlessUISample.Legend_WOC();
            this.chart_WOC2 = new LimitlessUISample.Chart_WOC();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // legend_WOC2
            // 
            this.legend_WOC2.AutoExpand = false;
            this.legend_WOC2.AutoScroll = true;
            this.legend_WOC2.Chart = this.chart_WOC2;
            this.legend_WOC2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.legend_WOC2.Location = new System.Drawing.Point(0, 293);
            this.legend_WOC2.Name = "legend_WOC2";
            this.legend_WOC2.Size = new System.Drawing.Size(801, 30);
            this.legend_WOC2.TabIndex = 1;
            this.legend_WOC2.Text = "legend_WOC2";
            this.legend_WOC2.TextColor = System.Drawing.Color.Empty;
            this.legend_WOC2.Vertical = false;
            // 
            // chart_WOC2
            // 
            this.chart_WOC2.ChartLength = 100;
            this.chart_WOC2.ChartLineThikness = 3;
            this.chart_WOC2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chart_WOC2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.chart_WOC2.LineThikness = 1;
            this.chart_WOC2.Location = new System.Drawing.Point(0, 0);
            this.chart_WOC2.MaxYValue = 100;
            this.chart_WOC2.MinYValue = 0;
            this.chart_WOC2.Name = "chart_WOC2";
            this.chart_WOC2.Padding = new System.Windows.Forms.Padding(30, 30, 30, 10);
            this.chart_WOC2.Size = new System.Drawing.Size(801, 293);
            this.chart_WOC2.TabIndex = 2;
            this.chart_WOC2.Text = "chart_WOC2";
            this.chart_WOC2.ValueInterval = 50;
            // 
            // Chart_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chart_WOC2);
            this.Controls.Add(this.legend_WOC2);
            this.Name = "Chart_UC";
            this.Size = new System.Drawing.Size(801, 323);
            this.ResumeLayout(false);

        }

        #endregion

        private Legend_WOC legend_WOC1;
        private Chart_WOC chart_WOC1;
        private System.Windows.Forms.Timer timer1;
        private Legend_WOC legend_WOC2;
        private Chart_WOC chart_WOC2;
    }
}
