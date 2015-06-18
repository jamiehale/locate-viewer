namespace SlarViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.firstChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.secondChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.slideRightButton = new System.Windows.Forms.Button();
            this.slideLeftButton = new System.Windows.Forms.Button();
            this.firstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.firstChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // firstChart
            // 
            this.firstChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.CursorX.AutoScroll = false;
            chartArea1.Name = "Main";
            this.firstChart.ChartAreas.Add(chartArea1);
            this.firstChart.Location = new System.Drawing.Point(0, 0);
            this.firstChart.Name = "firstChart";
            this.firstChart.Size = new System.Drawing.Size(564, 253);
            this.firstChart.TabIndex = 0;
            this.firstChart.Text = "chart1";
            this.firstChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.firstChart_CursorPositionChanged);
            this.firstChart.Click += new System.EventHandler(this.firstChart_Click);
            // 
            // secondChart
            // 
            this.secondChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "Main";
            this.secondChart.ChartAreas.Add(chartArea2);
            this.secondChart.Location = new System.Drawing.Point(0, -1);
            this.secondChart.Name = "secondChart";
            this.secondChart.Size = new System.Drawing.Size(564, 276);
            this.secondChart.TabIndex = 1;
            this.secondChart.Text = "chart1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.firstChart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.secondChart);
            this.splitContainer1.Size = new System.Drawing.Size(564, 535);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.slideRightButton);
            this.panel1.Controls.Add(this.slideLeftButton);
            this.panel1.Location = new System.Drawing.Point(582, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 535);
            this.panel1.TabIndex = 4;
            // 
            // chart1
            // 
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(236, 202);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // slideRightButton
            // 
            this.slideRightButton.Location = new System.Drawing.Point(145, 250);
            this.slideRightButton.Name = "slideRightButton";
            this.slideRightButton.Size = new System.Drawing.Size(75, 23);
            this.slideRightButton.TabIndex = 6;
            this.slideRightButton.Text = "Right";
            this.slideRightButton.UseVisualStyleBackColor = true;
            this.slideRightButton.Click += new System.EventHandler(this.slideRightButton_Click);
            // 
            // slideLeftButton
            // 
            this.slideLeftButton.Location = new System.Drawing.Point(64, 250);
            this.slideLeftButton.Name = "slideLeftButton";
            this.slideLeftButton.Size = new System.Drawing.Size(75, 23);
            this.slideLeftButton.TabIndex = 5;
            this.slideLeftButton.Text = "Left";
            this.slideLeftButton.UseVisualStyleBackColor = true;
            this.slideLeftButton.Click += new System.EventHandler(this.slideLeftButton_Click);
            // 
            // firstToolStripMenuItem
            // 
            this.firstToolStripMenuItem.Name = "firstToolStripMenuItem";
            this.firstToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.firstToolStripMenuItem.Text = "First";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 559);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "SLAR Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.firstChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChart)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart firstChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart secondChart;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button slideRightButton;
        private System.Windows.Forms.Button slideLeftButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem firstToolStripMenuItem;
    }
}

