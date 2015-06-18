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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.yChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.aggregateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.xChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.slideRightButton = new System.Windows.Forms.Button();
            this.slideLeftButton = new System.Windows.Forms.Button();
            this.firstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.yChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggregateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // yChart
            // 
            this.yChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Interval = 1000D;
            chartArea1.AxisX.Maximum = 6000D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.CursorX.AutoScroll = false;
            chartArea1.Name = "Main";
            this.yChart.ChartAreas.Add(chartArea1);
            this.yChart.Location = new System.Drawing.Point(0, 0);
            this.yChart.Name = "yChart";
            this.yChart.Size = new System.Drawing.Size(666, 180);
            this.yChart.TabIndex = 0;
            this.yChart.Text = "chart1";
            this.yChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.firstChart_CursorPositionChanged);
            this.yChart.Click += new System.EventHandler(this.xyChart_Click);
            // 
            // aggregateChart
            // 
            this.aggregateChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "Main";
            this.aggregateChart.ChartAreas.Add(chartArea2);
            this.aggregateChart.Location = new System.Drawing.Point(0, -1);
            this.aggregateChart.Name = "aggregateChart";
            this.aggregateChart.Size = new System.Drawing.Size(666, 182);
            this.aggregateChart.TabIndex = 1;
            this.aggregateChart.Text = "chart1";
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.aggregateChart);
            this.splitContainer1.Size = new System.Drawing.Size(666, 548);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.yChart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.xChart);
            this.splitContainer2.Size = new System.Drawing.Size(666, 363);
            this.splitContainer2.SplitterDistance = 183;
            this.splitContainer2.TabIndex = 0;
            // 
            // xChart
            // 
            this.xChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.AxisX.Maximum = 6000D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.CursorX.AutoScroll = false;
            chartArea3.Name = "Main";
            this.xChart.ChartAreas.Add(chartArea3);
            this.xChart.Location = new System.Drawing.Point(0, -1);
            this.xChart.Name = "xChart";
            this.xChart.Size = new System.Drawing.Size(666, 177);
            this.xChart.TabIndex = 1;
            this.xChart.Text = "chart1";
            this.xChart.Click += new System.EventHandler(this.xyChart_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.slideRightButton);
            this.panel1.Controls.Add(this.slideLeftButton);
            this.panel1.Location = new System.Drawing.Point(684, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 548);
            this.panel1.TabIndex = 4;
            // 
            // chart1
            // 
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisY.LabelStyle.Enabled = false;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
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
            this.ClientSize = new System.Drawing.Size(938, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "SLAR Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggregateChart)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xChart)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart yChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart aggregateChart;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button slideRightButton;
        private System.Windows.Forms.Button slideLeftButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem firstToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart xChart;
    }
}

