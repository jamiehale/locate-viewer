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
        private LocateFile[] loadedFiles = new LocateFile[2];

        private DataSet[] rawData3KHz = new DataSet[2];
        private Calibration[] calibration3KHz = new Calibration[2];
        private CalibratedDataSet[] calibratedData3KHz = new CalibratedDataSet[2];
        private bool[] show3KHzRaw = new bool[2];
        private bool[] show3KHzCalibrated = new bool[2];

        private DataSet[] rawData24KHz = new DataSet[2];
        private Calibration[] calibration24KHz = new Calibration[2];
        private CalibratedDataSet[] calibratedData24KHz = new CalibratedDataSet[2];
        private bool[] show24KHzRaw = new bool[2];
        private bool[] show24KHzCalibrated = new bool[2];

        private Calibration[] mixedCalibration = new Calibration[2];
        private MixedCalibratedDataSet[] mixedCalibratedData = new MixedCalibratedDataSet[2];
        private bool[] showMixedCalibrated = new bool[2];

        DataSet aggregateMixedSet;

        public MainForm()
        {
            InitializeComponent();

            //aggregateChart.Series.Add(CreateSeries(firstMixedSet.Subtract(secondMixedSet), "Test"));

            /*
            foreach (Datum datum in loadedFiles[0].Channel1Data)
                chart1.Series[0].Points.AddXY(datum.Data.X, datum.Data.Y);
             * */

            /*
            yChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            yChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
             * */
        }

        private void RebuildCharts()
        {
            yChart.Series.Clear();
            xChart.Series.Clear();
            for (int i = 0; i < 2; ++i)
            {
                if (show3KHzRaw[i])
                {
                    yChart.Series.Add(CreateSeries(rawData3KHz[i], "", new GetValueDelegate(GetY)));
                    xChart.Series.Add(CreateSeries(rawData3KHz[i], "", new GetValueDelegate(GetX)));
                }
                if (show3KHzCalibrated[i])
                {
                    yChart.Series.Add(CreateSeries(calibratedData3KHz[i].Data, "", new GetValueDelegate(GetY)));
                    xChart.Series.Add(CreateSeries(calibratedData3KHz[i].Data, "", new GetValueDelegate(GetX)));
                }
                if (show24KHzRaw[i])
                {
                    yChart.Series.Add(CreateSeries(rawData24KHz[i], "", new GetValueDelegate(GetY)));
                    xChart.Series.Add(CreateSeries(rawData24KHz[i], "", new GetValueDelegate(GetX)));
                }
                if (show24KHzCalibrated[i])
                {
                    yChart.Series.Add(CreateSeries(calibratedData24KHz[i].Data, "", new GetValueDelegate(GetY)));
                    xChart.Series.Add(CreateSeries(calibratedData24KHz[i].Data, "", new GetValueDelegate(GetX)));
                }
                if (showMixedCalibrated[i])
                {
                    yChart.Series.Add(CreateSeries(mixedCalibratedData[i].Data, "", new GetValueDelegate(GetY)));
                    xChart.Series.Add(CreateSeries(mixedCalibratedData[i].Data, "", new GetValueDelegate(GetX)));
                }
            }
        }

        private void LoadFile(int index, string filename)
        {
            System.IO.StreamReader streamReader = new System.IO.StreamReader(filename);
            LocateFileReader locateFileReader = new LocateFileReader(streamReader);
            loadedFiles[index] = locateFileReader.Read();

            rawData3KHz[index] = loadedFiles[index].Channel1Data;
            calibration3KHz[index] = new Calibration(loadedFiles[index].Calibration3KHz);
            calibratedData3KHz[index] = new CalibratedDataSet(calibration3KHz[index], rawData3KHz[index]);

            rawData24KHz[index] = loadedFiles[index].Channel2Data;
            calibration24KHz[index] = new Calibration(loadedFiles[index].Calibration24KHz);
            calibratedData24KHz[index] = new CalibratedDataSet(calibration24KHz[index], rawData24KHz[index]);

            mixedCalibration[index] = loadedFiles[index].CalibrationMixed;
            mixedCalibratedData[index] = new MixedCalibratedDataSet(mixedCalibration[index], calibratedData3KHz[index].Data, calibratedData24KHz[index].Data);
        }

        private delegate float GetValueDelegate(Datum datum);

        private float GetY(Datum datum)
        {
            return datum.Data.Y;
        }

        private float GetX(Datum datum)
        {
            return datum.Data.X;
        }

        private static Series CreateSeries(DataSet data, string name, GetValueDelegate getValue )
        {
            Series series = new Series();
            foreach (Datum datum in data)
                series.Points.AddXY(datum.AxialPosition, getValue(datum));
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
            /*
            secondMixedSet = secondMixedSet.Shift(-1);
            yChart.Series[1] = CreateSeries(secondMixedSet, "Y2 Mixed");
            aggregateChart.Series[0] = CreateSeries(firstMixedSet.Subtract(secondMixedSet), "Test");
             * */
        }

        private void slideRightButton_Click(object sender, EventArgs e)
        {
            /*
            secondMixedSet = secondMixedSet.Shift(1);
            yChart.Series[1] = CreateSeries(secondMixedSet, "Y2 Mixed");
            aggregateChart.Series[0] = CreateSeries(firstMixedSet.Subtract(secondMixedSet), "Test");
             * */
        }

        private delegate void MenuAction(object sender, EventArgs e);

        private void xyChart_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            if (args.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu menu = new ContextMenu();

                MenuItem firstTopItem = new MenuItem("First File");
                AddSubMenuItem(firstTopItem, "Open...", false, firstOpen_Click);
                AddSubMenuItem(firstTopItem, "3KHz X-Y", show3KHzRaw[0], first3KHzRaw_Click);
                AddSubMenuItem(firstTopItem, "3KHz Calibrated X-Y", show3KHzCalibrated[0], first3KHzCal_Click);
                AddSubMenuItem(firstTopItem, "24KHz X-Y", show24KHzRaw[0], first24KHzRaw_Click);
                AddSubMenuItem(firstTopItem, "24KHz Calibrated X-Y", show24KHzCalibrated[0], first24KHzCal_Click);
                AddSubMenuItem(firstTopItem, "Mixed X-Y", showMixedCalibrated[0], firstMixedCal_Click);

                MenuItem secondTopItem = new MenuItem("Second File");
                AddSubMenuItem(secondTopItem, "Open...", false, secondOpen_Click);
                AddSubMenuItem(secondTopItem, "3KHz X-Y", show3KHzRaw[1], second3KHzRaw_Click);
                AddSubMenuItem(secondTopItem, "3KHz Calibrated X-Y", show3KHzCalibrated[1], second3KHzCal_Click);
                AddSubMenuItem(secondTopItem, "24KHz X-Y", show24KHzRaw[1], second24KHzRaw_Click);
                AddSubMenuItem(secondTopItem, "24KHz Calibrated X-Y", show24KHzCalibrated[1], second24KHzCal_Click);
                AddSubMenuItem(secondTopItem, "Mixed X-Y", showMixedCalibrated[1], secondMixedCal_Click);

                menu.MenuItems.Add(firstTopItem);
                menu.MenuItems.Add(secondTopItem);
                menu.Show((Chart)sender, args.Location);
            }
        }

        private void AddSubMenuItem(MenuItem parent, string name, bool isChecked, MenuAction action)
        {
            MenuItem item = new MenuItem(name);
            item.Checked = isChecked;
            item.Click += new EventHandler(action);
            parent.MenuItems.Add(item);
        }

        void firstMixedCal_Click(object sender, EventArgs e)
        {
            showMixedCalibrated[0] = !showMixedCalibrated[0];
            RebuildCharts();
        }

        void first24KHzCal_Click(object sender, EventArgs e)
        {
            show24KHzCalibrated[0] = !show24KHzCalibrated[0];
            RebuildCharts();
        }

        void first24KHzRaw_Click(object sender, EventArgs e)
        {
            show24KHzRaw[0] = !show24KHzRaw[0];
            RebuildCharts();
        }

        void first3KHzCal_Click(object sender, EventArgs e)
        {
            show3KHzCalibrated[0] = !show3KHzCalibrated[0];
            RebuildCharts();
        }

        void first3KHzRaw_Click(object sender, EventArgs e)
        {
            show3KHzRaw[0] = !show3KHzRaw[0];
            RebuildCharts();
        }

        void firstOpen_Click(object sender, EventArgs e)
        {
            OpenFile(0);
        }

        void secondMixedCal_Click(object sender, EventArgs e)
        {
            showMixedCalibrated[1] = !showMixedCalibrated[1];
            RebuildCharts();
        }

        void second24KHzCal_Click(object sender, EventArgs e)
        {
            show24KHzCalibrated[1] = !show24KHzCalibrated[1];
            RebuildCharts();
        }

        void second24KHzRaw_Click(object sender, EventArgs e)
        {
            show24KHzRaw[1] = !show24KHzRaw[1];
            RebuildCharts();
        }

        void second3KHzCal_Click(object sender, EventArgs e)
        {
            show3KHzCalibrated[1] = !show3KHzCalibrated[1];
            RebuildCharts();
        }

        void second3KHzRaw_Click(object sender, EventArgs e)
        {
            show3KHzRaw[1] = !show3KHzRaw[1];
            RebuildCharts();
        }

        void secondOpen_Click(object sender, EventArgs e)
        {
            OpenFile(2);
        }

        private void OpenFile(int index)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Locate/Gap Files (*.dat)|*.dat";
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                LoadFile(index, dialog.FileName);
                RebuildCharts();
            }
        }

        /*
        private void UpdateDisplay(Chart chart, List<DisplaySet> displaySets)
        {
            foreach (DisplaySet set in displaySets)
            {
            }
        }
         * */

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadFile(0, "..\\..\\..\\..\\data\\now.dat");
            LoadFile(1, "..\\..\\..\\..\\data\\minus1.dat");

            RebuildCharts();
        }

        void firstChart_CursorPositionChanged(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            double min = Math.Min(yChart.ChartAreas[0].CursorX.SelectionStart, yChart.ChartAreas[0].CursorX.SelectionEnd);
            double max = Math.Max(yChart.ChartAreas[0].CursorX.SelectionStart, yChart.ChartAreas[0].CursorX.SelectionEnd);
            UpdateXY(min, max);
        }

        private void UpdateXY(double start, double end)
        {
            chart1.Series[0] = new Series();
            chart1.Series[0].ChartType = SeriesChartType.FastLine;
            foreach (Datum datum in loadedFiles[0].Channel1Data)
                if(datum.AxialPosition > start && datum.AxialPosition < end)
                    chart1.Series[0].Points.AddXY(datum.Data.X, datum.Data.Y);
        }


    }
}
