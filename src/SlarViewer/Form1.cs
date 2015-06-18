using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SlarViewer
{
    public partial class MainForm : Form
    {
        private LocateFile firstFile;
        private LocateFile secondFile;

        DataSet firstMixedSet;
        DataSet secondMixedSet;
        DataSet aggregateMixedSet;

        public MainForm()
        {
            InitializeComponent();

            firstFile = LoadFile("..\\..\\..\\now.dat");
            firstMixedSet = firstFile.MixedCalibratedData;

            secondFile = LoadFile("..\\..\\..\\minus1.dat");
            secondMixedSet = secondFile.MixedCalibratedData;

            firstChart.Series.Add(CreateSeries(firstMixedSet, "Y1 Mixed"));
            firstChart.Series.Add(CreateSeries(secondMixedSet, "Y2 Mixed"));
            secondChart.Series.Add(CreateSeries(firstMixedSet.Subtract(secondMixedSet), "Test"));

            //firstChart.ChartAreas[0].AxisY.Maximum = 10000;
            //firstChart.ChartAreas[0].AxisY.Minimum = -10000;
            //secondChart.ChartAreas[0].AxisY.Maximum = 10000;
            //secondChart.ChartAreas[0].AxisY.Minimum = -10000;

            foreach (Datum datum in firstFile.Channel1Data)
                chart1.Series[0].Points.AddXY(datum.Data.X, datum.Data.Y);

            firstChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            firstChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        }

        private static LocateFile LoadFile(string filename)
        {
            System.IO.StreamReader streamReader = new System.IO.StreamReader(filename);
            LocateFileReader locateFileReader = new LocateFileReader(streamReader);
            LocateFile locateFile = locateFileReader.Read();
            return locateFile;
        }

        private static Series CreateSeries(List<Datum> data, string name)
        {
            Series series = new Series();
            foreach (Datum datum in data)
                series.Points.AddXY(datum.AxialPosition, datum.Data.Y);
            series.ChartType = SeriesChartType.FastLine;
            series.LegendText = name;
            return series;
        }

        private void secondFileAxialSlider_Scroll(object sender, EventArgs e)
        {
            TrackBar slider = (TrackBar)sender;

        }

        private void slideLeftButton_Click(object sender, EventArgs e)
        {
            secondMixedSet = secondMixedSet.Shift(-1);
            firstChart.Series[1] = CreateSeries(secondMixedSet, "Y2 Mixed");
            secondChart.Series[0] = CreateSeries(firstMixedSet.Subtract(secondMixedSet), "Test");
        }

        private void slideRightButton_Click(object sender, EventArgs e)
        {
            secondMixedSet = secondMixedSet.Shift(1);
            firstChart.Series[1] = CreateSeries(secondMixedSet, "Y2 Mixed");
            secondChart.Series[0] = CreateSeries(firstMixedSet.Subtract(secondMixedSet), "Test");
        }

        private delegate void MenuAction(object sender, EventArgs e);

        private void firstChart_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            if (args.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu menu = new ContextMenu();

                MenuItem firstTopItem = new MenuItem("First File");

                AddSubMenuItem(firstTopItem, "Open...", firstOpen_Click);
                AddSubMenuItem(firstTopItem, "3Khz X", firstRawX_Click);
                AddSubMenuItem(firstTopItem, "3Khz Y", firstRawY_Click);
                AddSubMenuItem(firstTopItem, "3KHz Calibrated X", firstCalX_Click);

                menu.MenuItems.Add(firstTopItem);
                menu.Show((Chart)sender, args.Location);
            }
        }

        private void AddSubMenuItem(MenuItem parent, string name, MenuAction action)
        {
            MenuItem item = new MenuItem(name);
            item.Click += new EventHandler(action);
            parent.MenuItems.Add(item);
        }

        void firstCalX_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void firstRawY_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void firstRawX_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void firstOpen_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        void firstChart_CursorPositionChanged(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            double min = Math.Min(firstChart.ChartAreas[0].CursorX.SelectionStart, firstChart.ChartAreas[0].CursorX.SelectionEnd);
            double max = Math.Max(firstChart.ChartAreas[0].CursorX.SelectionStart, firstChart.ChartAreas[0].CursorX.SelectionEnd);
            UpdateXY(min, max);
        }

        private void UpdateXY(double start, double end)
        {
            chart1.Series[0] = new Series();
            chart1.Series[0].ChartType = SeriesChartType.FastLine;
            foreach (Datum datum in firstFile.Channel1Data)
                if(datum.AxialPosition > start && datum.AxialPosition < end)
                    chart1.Series[0].Points.AddXY(datum.Data.X, datum.Data.Y);
        }

    }
}
