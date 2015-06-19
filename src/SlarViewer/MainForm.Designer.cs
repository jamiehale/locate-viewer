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
            this.secondMixedCheckbox = new System.Windows.Forms.CheckBox();
            this.second24KHzCalibratedCheckbox = new System.Windows.Forms.CheckBox();
            this.second24KHzCheckbox = new System.Windows.Forms.CheckBox();
            this.second3KHzCalibratedCheckbox = new System.Windows.Forms.CheckBox();
            this.second3KHzCheckbox = new System.Windows.Forms.CheckBox();
            this.firstMixedCheckbox = new System.Windows.Forms.CheckBox();
            this.first24KHzCalibratedCheckbox = new System.Windows.Forms.CheckBox();
            this.first24KHzCheckbox = new System.Windows.Forms.CheckBox();
            this.first3KHzCalibratedCheckbox = new System.Windows.Forms.CheckBox();
            this.first3KHzCheckbox = new System.Windows.Forms.CheckBox();
            this.calibrationDropList = new System.Windows.Forms.ComboBox();
            this.phaseLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.phaseTrackbar = new System.Windows.Forms.TrackBar();
            this.slideRightButton = new System.Windows.Forms.Button();
            this.gainLabel = new System.Windows.Forms.Label();
            this.slideLeftButton = new System.Windows.Forms.Button();
            this.gainTrackbar = new System.Windows.Forms.TrackBar();
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
            ((System.ComponentModel.ISupportInitialize)(this.phaseTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainTrackbar)).BeginInit();
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
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.CursorX.AutoScroll = false;
            chartArea1.Name = "Main";
            this.yChart.ChartAreas.Add(chartArea1);
            this.yChart.Location = new System.Drawing.Point(0, 0);
            this.yChart.Name = "yChart";
            this.yChart.Size = new System.Drawing.Size(564, 180);
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
            chartArea2.AxisX.Interval = 1000D;
            chartArea2.AxisX.Maximum = 6000D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.Name = "Main";
            this.aggregateChart.ChartAreas.Add(chartArea2);
            this.aggregateChart.Location = new System.Drawing.Point(0, -1);
            this.aggregateChart.Name = "aggregateChart";
            this.aggregateChart.Size = new System.Drawing.Size(564, 182);
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
            this.splitContainer1.Size = new System.Drawing.Size(564, 548);
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
            this.splitContainer2.Size = new System.Drawing.Size(564, 363);
            this.splitContainer2.SplitterDistance = 183;
            this.splitContainer2.TabIndex = 0;
            // 
            // xChart
            // 
            this.xChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.AxisX.Interval = 1000D;
            chartArea3.AxisX.Maximum = 6000D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.CursorX.AutoScroll = false;
            chartArea3.Name = "Main";
            this.xChart.ChartAreas.Add(chartArea3);
            this.xChart.Location = new System.Drawing.Point(0, -1);
            this.xChart.Name = "xChart";
            this.xChart.Size = new System.Drawing.Size(564, 177);
            this.xChart.TabIndex = 1;
            this.xChart.Text = "chart1";
            this.xChart.Click += new System.EventHandler(this.xyChart_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.secondMixedCheckbox);
            this.panel1.Controls.Add(this.second24KHzCalibratedCheckbox);
            this.panel1.Controls.Add(this.second24KHzCheckbox);
            this.panel1.Controls.Add(this.second3KHzCalibratedCheckbox);
            this.panel1.Controls.Add(this.second3KHzCheckbox);
            this.panel1.Controls.Add(this.firstMixedCheckbox);
            this.panel1.Controls.Add(this.first24KHzCalibratedCheckbox);
            this.panel1.Controls.Add(this.first24KHzCheckbox);
            this.panel1.Controls.Add(this.first3KHzCalibratedCheckbox);
            this.panel1.Controls.Add(this.first3KHzCheckbox);
            this.panel1.Controls.Add(this.calibrationDropList);
            this.panel1.Controls.Add(this.phaseLabel);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.phaseTrackbar);
            this.panel1.Controls.Add(this.slideRightButton);
            this.panel1.Controls.Add(this.gainLabel);
            this.panel1.Controls.Add(this.slideLeftButton);
            this.panel1.Controls.Add(this.gainTrackbar);
            this.panel1.Location = new System.Drawing.Point(582, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 548);
            this.panel1.TabIndex = 4;
            // 
            // secondMixedCheckbox
            // 
            this.secondMixedCheckbox.AutoSize = true;
            this.secondMixedCheckbox.Location = new System.Drawing.Point(155, 458);
            this.secondMixedCheckbox.Name = "secondMixedCheckbox";
            this.secondMixedCheckbox.Size = new System.Drawing.Size(94, 17);
            this.secondMixedCheckbox.TabIndex = 22;
            this.secondMixedCheckbox.Text = "Second Mixed";
            this.secondMixedCheckbox.UseVisualStyleBackColor = true;
            this.secondMixedCheckbox.CheckedChanged += new System.EventHandler(this.secondMixedCheckbox_CheckedChanged);
            // 
            // second24KHzCalibratedCheckbox
            // 
            this.second24KHzCalibratedCheckbox.AutoSize = true;
            this.second24KHzCalibratedCheckbox.Location = new System.Drawing.Point(155, 435);
            this.second24KHzCalibratedCheckbox.Name = "second24KHzCalibratedCheckbox";
            this.second24KHzCalibratedCheckbox.Size = new System.Drawing.Size(148, 17);
            this.second24KHzCalibratedCheckbox.TabIndex = 21;
            this.second24KHzCalibratedCheckbox.Text = "Second 24KHz Calibrated";
            this.second24KHzCalibratedCheckbox.UseVisualStyleBackColor = true;
            this.second24KHzCalibratedCheckbox.CheckedChanged += new System.EventHandler(this.second24KHzCalibratedCheckbox_CheckedChanged);
            // 
            // second24KHzCheckbox
            // 
            this.second24KHzCheckbox.AutoSize = true;
            this.second24KHzCheckbox.Location = new System.Drawing.Point(155, 412);
            this.second24KHzCheckbox.Name = "second24KHzCheckbox";
            this.second24KHzCheckbox.Size = new System.Drawing.Size(98, 17);
            this.second24KHzCheckbox.TabIndex = 20;
            this.second24KHzCheckbox.Text = "Second 24KHz";
            this.second24KHzCheckbox.UseVisualStyleBackColor = true;
            this.second24KHzCheckbox.CheckedChanged += new System.EventHandler(this.second24KHzCheckbox_CheckedChanged);
            // 
            // second3KHzCalibratedCheckbox
            // 
            this.second3KHzCalibratedCheckbox.AutoSize = true;
            this.second3KHzCalibratedCheckbox.Location = new System.Drawing.Point(155, 389);
            this.second3KHzCalibratedCheckbox.Name = "second3KHzCalibratedCheckbox";
            this.second3KHzCalibratedCheckbox.Size = new System.Drawing.Size(142, 17);
            this.second3KHzCalibratedCheckbox.TabIndex = 19;
            this.second3KHzCalibratedCheckbox.Text = "Second 3KHz Calibrated";
            this.second3KHzCalibratedCheckbox.UseVisualStyleBackColor = true;
            this.second3KHzCalibratedCheckbox.CheckedChanged += new System.EventHandler(this.second3KHzCalibratedCheckbox_CheckedChanged);
            // 
            // second3KHzCheckbox
            // 
            this.second3KHzCheckbox.AutoSize = true;
            this.second3KHzCheckbox.Location = new System.Drawing.Point(155, 366);
            this.second3KHzCheckbox.Name = "second3KHzCheckbox";
            this.second3KHzCheckbox.Size = new System.Drawing.Size(92, 17);
            this.second3KHzCheckbox.TabIndex = 18;
            this.second3KHzCheckbox.Text = "Second 3KHz";
            this.second3KHzCheckbox.UseVisualStyleBackColor = true;
            this.second3KHzCheckbox.CheckedChanged += new System.EventHandler(this.second3KHzCheckbox_CheckedChanged);
            // 
            // firstMixedCheckbox
            // 
            this.firstMixedCheckbox.AutoSize = true;
            this.firstMixedCheckbox.Location = new System.Drawing.Point(13, 458);
            this.firstMixedCheckbox.Name = "firstMixedCheckbox";
            this.firstMixedCheckbox.Size = new System.Drawing.Size(76, 17);
            this.firstMixedCheckbox.TabIndex = 17;
            this.firstMixedCheckbox.Text = "First Mixed";
            this.firstMixedCheckbox.UseVisualStyleBackColor = true;
            this.firstMixedCheckbox.CheckedChanged += new System.EventHandler(this.firstMixedCheckbox_CheckedChanged);
            // 
            // first24KHzCalibratedCheckbox
            // 
            this.first24KHzCalibratedCheckbox.AutoSize = true;
            this.first24KHzCalibratedCheckbox.Location = new System.Drawing.Point(13, 435);
            this.first24KHzCalibratedCheckbox.Name = "first24KHzCalibratedCheckbox";
            this.first24KHzCalibratedCheckbox.Size = new System.Drawing.Size(130, 17);
            this.first24KHzCalibratedCheckbox.TabIndex = 16;
            this.first24KHzCalibratedCheckbox.Text = "First 24KHz Calibrated";
            this.first24KHzCalibratedCheckbox.UseVisualStyleBackColor = true;
            this.first24KHzCalibratedCheckbox.CheckedChanged += new System.EventHandler(this.first24KHzCalibratedCheckbox_CheckedChanged);
            // 
            // first24KHzCheckbox
            // 
            this.first24KHzCheckbox.AutoSize = true;
            this.first24KHzCheckbox.Location = new System.Drawing.Point(13, 412);
            this.first24KHzCheckbox.Name = "first24KHzCheckbox";
            this.first24KHzCheckbox.Size = new System.Drawing.Size(80, 17);
            this.first24KHzCheckbox.TabIndex = 15;
            this.first24KHzCheckbox.Text = "First 24KHz";
            this.first24KHzCheckbox.UseVisualStyleBackColor = true;
            this.first24KHzCheckbox.CheckedChanged += new System.EventHandler(this.first24KHzCheckbox_CheckedChanged);
            // 
            // first3KHzCalibratedCheckbox
            // 
            this.first3KHzCalibratedCheckbox.AutoSize = true;
            this.first3KHzCalibratedCheckbox.Location = new System.Drawing.Point(13, 389);
            this.first3KHzCalibratedCheckbox.Name = "first3KHzCalibratedCheckbox";
            this.first3KHzCalibratedCheckbox.Size = new System.Drawing.Size(124, 17);
            this.first3KHzCalibratedCheckbox.TabIndex = 14;
            this.first3KHzCalibratedCheckbox.Text = "First 3KHz Calibrated";
            this.first3KHzCalibratedCheckbox.UseVisualStyleBackColor = true;
            this.first3KHzCalibratedCheckbox.CheckedChanged += new System.EventHandler(this.first3KHzCalibratedCheckbox_CheckedChanged);
            // 
            // first3KHzCheckbox
            // 
            this.first3KHzCheckbox.AutoSize = true;
            this.first3KHzCheckbox.Location = new System.Drawing.Point(13, 366);
            this.first3KHzCheckbox.Name = "first3KHzCheckbox";
            this.first3KHzCheckbox.Size = new System.Drawing.Size(74, 17);
            this.first3KHzCheckbox.TabIndex = 13;
            this.first3KHzCheckbox.Text = "First 3KHz";
            this.first3KHzCheckbox.UseVisualStyleBackColor = true;
            this.first3KHzCheckbox.CheckedChanged += new System.EventHandler(this.first3KHzCheckbox_CheckedChanged);
            // 
            // calibrationDropList
            // 
            this.calibrationDropList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calibrationDropList.FormattingEnabled = true;
            this.calibrationDropList.Location = new System.Drawing.Point(63, 319);
            this.calibrationDropList.Name = "calibrationDropList";
            this.calibrationDropList.Size = new System.Drawing.Size(121, 21);
            this.calibrationDropList.TabIndex = 12;
            this.calibrationDropList.SelectedIndexChanged += new System.EventHandler(this.calibrationDropList_SelectedIndexChanged);
            // 
            // phaseLabel
            // 
            this.phaseLabel.AutoSize = true;
            this.phaseLabel.Location = new System.Drawing.Point(161, 291);
            this.phaseLabel.Name = "phaseLabel";
            this.phaseLabel.Size = new System.Drawing.Size(35, 13);
            this.phaseLabel.TabIndex = 11;
            this.phaseLabel.Text = "label1";
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
            this.chart1.Size = new System.Drawing.Size(299, 223);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // phaseTrackbar
            // 
            this.phaseTrackbar.Location = new System.Drawing.Point(130, 243);
            this.phaseTrackbar.Maximum = 100;
            this.phaseTrackbar.Minimum = -100;
            this.phaseTrackbar.Name = "phaseTrackbar";
            this.phaseTrackbar.Size = new System.Drawing.Size(104, 45);
            this.phaseTrackbar.TabIndex = 9;
            this.phaseTrackbar.TickFrequency = 25;
            this.phaseTrackbar.Scroll += new System.EventHandler(this.phaseTrackbar_Scroll);
            // 
            // slideRightButton
            // 
            this.slideRightButton.Location = new System.Drawing.Point(130, 522);
            this.slideRightButton.Name = "slideRightButton";
            this.slideRightButton.Size = new System.Drawing.Size(75, 23);
            this.slideRightButton.TabIndex = 6;
            this.slideRightButton.Text = "Right";
            this.slideRightButton.UseVisualStyleBackColor = true;
            this.slideRightButton.Click += new System.EventHandler(this.slideRightButton_Click);
            // 
            // gainLabel
            // 
            this.gainLabel.AutoSize = true;
            this.gainLabel.Location = new System.Drawing.Point(37, 291);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(35, 13);
            this.gainLabel.TabIndex = 10;
            this.gainLabel.Text = "label1";
            // 
            // slideLeftButton
            // 
            this.slideLeftButton.Location = new System.Drawing.Point(49, 522);
            this.slideLeftButton.Name = "slideLeftButton";
            this.slideLeftButton.Size = new System.Drawing.Size(75, 23);
            this.slideLeftButton.TabIndex = 5;
            this.slideLeftButton.Text = "Left";
            this.slideLeftButton.UseVisualStyleBackColor = true;
            this.slideLeftButton.Click += new System.EventHandler(this.slideLeftButton_Click);
            // 
            // gainTrackbar
            // 
            this.gainTrackbar.Location = new System.Drawing.Point(3, 243);
            this.gainTrackbar.Maximum = 100;
            this.gainTrackbar.Minimum = -100;
            this.gainTrackbar.Name = "gainTrackbar";
            this.gainTrackbar.Size = new System.Drawing.Size(104, 45);
            this.gainTrackbar.TabIndex = 8;
            this.gainTrackbar.TickFrequency = 25;
            this.gainTrackbar.Scroll += new System.EventHandler(this.gainTrackbar_Scroll);
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
            this.ClientSize = new System.Drawing.Size(899, 572);
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
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainTrackbar)).EndInit();
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
        private System.Windows.Forms.TrackBar phaseTrackbar;
        private System.Windows.Forms.TrackBar gainTrackbar;
        private System.Windows.Forms.Label phaseLabel;
        private System.Windows.Forms.Label gainLabel;
        private System.Windows.Forms.ComboBox calibrationDropList;
        private System.Windows.Forms.CheckBox secondMixedCheckbox;
        private System.Windows.Forms.CheckBox second24KHzCalibratedCheckbox;
        private System.Windows.Forms.CheckBox second24KHzCheckbox;
        private System.Windows.Forms.CheckBox second3KHzCalibratedCheckbox;
        private System.Windows.Forms.CheckBox second3KHzCheckbox;
        private System.Windows.Forms.CheckBox firstMixedCheckbox;
        private System.Windows.Forms.CheckBox first24KHzCalibratedCheckbox;
        private System.Windows.Forms.CheckBox first24KHzCheckbox;
        private System.Windows.Forms.CheckBox first3KHzCalibratedCheckbox;
        private System.Windows.Forms.CheckBox first3KHzCheckbox;
    }
}

