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

        private SubtractedDataSet subtractedData;

        private double selectedMin = 0.0;
        private double selectedMax = 6000.0;

        private Calibration selectedCalibration;

        private int shift = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void RebuildAllCharts()
        {
            ResizeCharts();

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
                    if ( calibratedData3KHz[ i ] != null )
                    {
                        yChart.Series.Add( CreateSeries( calibratedData3KHz[ i ].Data, "", new GetValueDelegate( GetY ) ) );
                        xChart.Series.Add( CreateSeries( calibratedData3KHz[ i ].Data, "", new GetValueDelegate( GetX ) ) );
                    }
                }
                if (show24KHzRaw[i])
                {
                    yChart.Series.Add(CreateSeries(rawData24KHz[i], "", new GetValueDelegate(GetY)));
                    xChart.Series.Add(CreateSeries(rawData24KHz[i], "", new GetValueDelegate(GetX)));
                }
                if (show24KHzCalibrated[i])
                {
                    if ( calibratedData24KHz[ i ] != null )
                    {
                        yChart.Series.Add( CreateSeries( calibratedData24KHz[ i ].Data, "", new GetValueDelegate( GetY ) ) );
                        xChart.Series.Add( CreateSeries( calibratedData24KHz[ i ].Data, "", new GetValueDelegate( GetX ) ) );
                    }
                }
                if (showMixedCalibrated[i])
                {
                    if ( mixedCalibratedData[ i ] != null )
                    {
                        yChart.Series.Add( CreateSeries( mixedCalibratedData[ i ].Data, "", new GetValueDelegate( GetY ) ) );
                        xChart.Series.Add( CreateSeries( mixedCalibratedData[ i ].Data, "", new GetValueDelegate( GetX ) ) );
                    }
                }
            }

            aggregateChart.Series.Clear();
            if ( subtractedData != null )
                aggregateChart.Series.Add( CreateSeries( subtractedData.Data, "", new GetValueDelegate( GetY ) ) );

            RebuildXYCharts();
        }

        private void ResizeCharts()
        {
            int chartMinimum;
            int chartMaximum;
            CalculateChartRange( out chartMinimum, out chartMaximum );

            yChart.ChartAreas[ 0 ].Axes[ 0 ].Minimum = chartMinimum;
            yChart.ChartAreas[ 0 ].Axes[ 0 ].Maximum = chartMaximum;

            xChart.ChartAreas[ 0 ].Axes[ 0 ].Minimum = chartMinimum;
            xChart.ChartAreas[ 0 ].Axes[ 0 ].Maximum = chartMaximum;

            aggregateChart.ChartAreas[ 0 ].Axes[ 0 ].Minimum = chartMinimum;
            aggregateChart.ChartAreas[ 0 ].Axes[ 0 ].Maximum = chartMaximum;
        }

        private void CalculateChartRange( out int chartMinimum, out int chartMaximum )
        {
            float minimumPosition = 0;
            float maximumPosition = 0;

            for ( int i = 0; i < 2; ++i )
            {
                if ( rawData3KHz[ i ] != null )
                {
                    foreach ( Datum datum in rawData3KHz[ i ] )
                    {
                        if ( datum.AxialPosition < minimumPosition )
                            minimumPosition = datum.AxialPosition;
                        if ( datum.AxialPosition > maximumPosition )
                            maximumPosition = datum.AxialPosition;
                    }
                }
            }

            chartMinimum = ( ( int ) ( minimumPosition - 1000 ) ) / 1000 * 1000;
            chartMaximum = ( ( int ) ( maximumPosition + 1000 ) ) / 1000 * 1000;
        }

        private void RebuildXYCharts()
        {
            chart1.Series.Clear();
            for (int i = 0; i < 2; ++i)
            {
                if (show3KHzRaw[i])
                {
                    chart1.Series.Add(CreateXYSeries(rawData3KHz[i], selectedMin, selectedMax));
                }
                if (show3KHzCalibrated[i])
                {
                    if ( calibratedData3KHz[ i ] != null )
                        chart1.Series.Add( CreateXYSeries( calibratedData3KHz[ i ].Data, selectedMin, selectedMax ) );
                }
                if (show24KHzRaw[i])
                {
                    chart1.Series.Add(CreateXYSeries(rawData24KHz[i], selectedMin, selectedMax));
                }
                if (show24KHzCalibrated[i])
                {
                    if ( calibratedData24KHz[ i ] != null )
                        chart1.Series.Add( CreateXYSeries( calibratedData24KHz[ i ].Data, selectedMin, selectedMax ) );
                }
                if (showMixedCalibrated[i])
                {
                    if ( mixedCalibratedData[ i ] != null )
                        chart1.Series.Add( CreateXYSeries( mixedCalibratedData[ i ].Data, selectedMin, selectedMax ) );
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
            mixedCalibratedData[index] = new MixedCalibratedDataSet(mixedCalibration[index], calibratedData3KHz[index], calibratedData24KHz[index]);

            UpdateTrackBarsFromSelectedCalibration();
            UpdateCalibrationLabels();

            if (mixedCalibratedData[0] != null && mixedCalibratedData[1] != null)
                subtractedData = new SubtractedDataSet(mixedCalibratedData[0], mixedCalibratedData[1]);
        }

        private void UpdateTrackBarsFromSelectedCalibration()
        {
            if (selectedCalibration != null)
            {
                gainTrackbar.Value = GainToTrackBarValue(selectedCalibration.Gain);
                phaseTrackbar.Value = PhaseToTrackBarValue(selectedCalibration.Phase);
            }
        }

        private void UpdateCalibrationLabels()
        {
            if (selectedCalibration != null)
            {
                gainLabel.Text = selectedCalibration.Gain.ToString("0.0000");
                phaseLabel.Text = selectedCalibration.Phase.ToString("0.0000");
            }
        }

        private int PhaseToTrackBarValue(float p)
        {
            return (int)(((p + 2 * Math.PI) / (4 * Math.PI)) * 2000 - 1000);
        }

        private float TrackBarValueToPhase(int p)
        {
            return (float)(((p + 1000) / 2000.0) * 4 * Math.PI - 2 * Math.PI);
        }

        private int GainToTrackBarValue(float g)
        {
            return (int)(((g + 3) / 6) * 2000 - 1000);
        }

        private float TrackBarValueToGain(int g)
        {
            return (float)(((g + 1000) / 2000.0) * 6 - 3);
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
            if ( data != null )
                foreach ( Datum datum in data )
                    series.Points.AddXY( datum.AxialPosition, getValue( datum ) );
            series.ChartType = SeriesChartType.FastLine;
            series.LegendText = name;
            return series;
        }

        private void slideLeftButton_Click(object sender, EventArgs e)
        {
            shift -= 1;
            ShiftData();
            RebuildAllCharts();
        }

        private void ShiftData()
        {
            calibratedData3KHz[1].Shift = shift;
            calibratedData24KHz[1].Shift = shift;
        }

        private void slideRightButton_Click(object sender, EventArgs e)
        {
            shift += 1;
            ShiftData();
            RebuildAllCharts();
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
            RebuildAllCharts();
        }

        void first24KHzCal_Click(object sender, EventArgs e)
        {
            show24KHzCalibrated[0] = !show24KHzCalibrated[0];
            RebuildAllCharts();
        }

        void first24KHzRaw_Click(object sender, EventArgs e)
        {
            show24KHzRaw[0] = !show24KHzRaw[0];
            RebuildAllCharts();
        }

        void first3KHzCal_Click(object sender, EventArgs e)
        {
            show3KHzCalibrated[0] = !show3KHzCalibrated[0];
            RebuildAllCharts();
        }

        void first3KHzRaw_Click(object sender, EventArgs e)
        {
            show3KHzRaw[0] = !show3KHzRaw[0];
            RebuildAllCharts();
        }

        void firstOpen_Click(object sender, EventArgs e)
        {
            OpenFile(0);
        }

        void secondMixedCal_Click(object sender, EventArgs e)
        {
            showMixedCalibrated[1] = !showMixedCalibrated[1];
            RebuildAllCharts();
        }

        void second24KHzCal_Click(object sender, EventArgs e)
        {
            show24KHzCalibrated[1] = !show24KHzCalibrated[1];
            RebuildAllCharts();
        }

        void second24KHzRaw_Click(object sender, EventArgs e)
        {
            show24KHzRaw[1] = !show24KHzRaw[1];
            RebuildAllCharts();
        }

        void second3KHzCal_Click(object sender, EventArgs e)
        {
            show3KHzCalibrated[1] = !show3KHzCalibrated[1];
            RebuildAllCharts();
        }

        void second3KHzRaw_Click(object sender, EventArgs e)
        {
            show3KHzRaw[1] = !show3KHzRaw[1];
            RebuildAllCharts();
        }

        void secondOpen_Click(object sender, EventArgs e)
        {
            OpenFile(1);
        }

        private void OpenFile(int index)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Locate/Gap Files (*.dat)|*.dat";
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                LoadFile(index, dialog.FileName);
                RebuildAllCharts();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //LoadFile(0, "..\\..\\..\\..\\data\\u6good.dat");
            //LoadFile(1, "..\\..\\..\\..\\data\\u4bad.dat");

            //show3KHzRaw[0] = true;
            //show3KHzCalibrated[0] = true;
            first3KHzCheckbox.Checked = true;
            first3KHzCalibratedCheckbox.Checked = true;

            yChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            yChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            calibrationDropList.Items.Add("First 3KHz");
            calibrationDropList.Items.Add("First 24KHz");
            calibrationDropList.Items.Add("First Mixed");
            calibrationDropList.Items.Add("Second 3KHz");
            calibrationDropList.Items.Add("Second 24KHz");
            calibrationDropList.Items.Add("Second Mixed");
            calibrationDropList.SelectedIndex = 0;

            selectedCalibration = calibration3KHz[0];

            /*
            yChart.ChartAreas[0].Axes[1].Minimum = -10000;
            yChart.ChartAreas[0].Axes[1].Maximum= 10000;
            xChart.ChartAreas[0].Axes[1].Minimum = -10000;
            xChart.ChartAreas[0].Axes[1].Maximum = 10000;
            aggregateChart.ChartAreas[0].Axes[1].Minimum = -10000;
            aggregateChart.ChartAreas[0].Axes[1].Maximum= 10000;
             * */

            RebuildAllCharts();
        }

        void firstChart_CursorPositionChanged(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            selectedMin = Math.Min(yChart.ChartAreas[0].CursorX.SelectionStart, yChart.ChartAreas[0].CursorX.SelectionEnd);
            selectedMax = Math.Max(yChart.ChartAreas[0].CursorX.SelectionStart, yChart.ChartAreas[0].CursorX.SelectionEnd);

            SetAllSelectionsFromYChartSelection();

            RebuildXYCharts();
        }

        void yChart_CursorPositionChanging(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            SetAllSelectionsFromYChartSelection();
        }

        private void SetAllSelectionsFromYChartSelection()
        {
            xChart.ChartAreas[0].CursorX.SelectionStart = yChart.ChartAreas[0].CursorX.SelectionStart;
            xChart.ChartAreas[0].CursorX.SelectionEnd = yChart.ChartAreas[0].CursorX.SelectionEnd;

            aggregateChart.ChartAreas[0].CursorX.SelectionStart = yChart.ChartAreas[0].CursorX.SelectionStart;
            aggregateChart.ChartAreas[0].CursorX.SelectionEnd = yChart.ChartAreas[0].CursorX.SelectionEnd;
        }

        private Series CreateXYSeries(DataSet dataSet, double start, double end)
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.FastLine;
            if ( dataSet != null )
                foreach ( Datum datum in dataSet )
                    if ( datum.AxialPosition > start && datum.AxialPosition < end )
                        series.Points.AddXY( datum.Data.X, datum.Data.Y );
            return series;
        }

        private void gainTrackbar_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            selectedCalibration.Gain = TrackBarValueToGain(trackBar.Value);
            UpdateCalibrationLabels();
            RebuildAllCharts();
        }

        private void phaseTrackbar_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            selectedCalibration.Phase = TrackBarValueToPhase(trackBar.Value);
            UpdateCalibrationLabels();
            RebuildAllCharts();
        }

        private void calibrationDropList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (calibrationDropList.SelectedIndex)
            {
                case 0:
                    selectedCalibration = calibration3KHz[0];
                    break;
                case 1:
                    selectedCalibration = calibration24KHz[0];
                    break;
                case 2:
                    selectedCalibration = mixedCalibration[0];
                    break;
                case 3:
                    selectedCalibration = calibration3KHz[1];
                    break;
                case 4:
                    selectedCalibration = calibration24KHz[1];
                    break;
                case 5:
                    selectedCalibration = mixedCalibration[1];
                    break;
            }
            UpdateTrackBarsFromSelectedCalibration();
            UpdateCalibrationLabels();
        }

        private void first3KHzCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            show3KHzRaw[0] = !show3KHzRaw[0];
            RebuildAllCharts();
        }

        private void first3KHzCalibratedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            show3KHzCalibrated[0] = !show3KHzCalibrated[0];
            RebuildAllCharts();
        }

        private void first24KHzCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            show24KHzRaw[0] = !show24KHzRaw[0];
            RebuildAllCharts();
        }

        private void first24KHzCalibratedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            show24KHzCalibrated[0] = !show24KHzCalibrated[0];
            RebuildAllCharts();
        }

        private void firstMixedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            showMixedCalibrated[0] = !showMixedCalibrated[0];
            RebuildAllCharts();
        }

        private void second3KHzCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            show3KHzRaw[1] = !show3KHzRaw[1];
            RebuildAllCharts();
        }

        private void second3KHzCalibratedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            show3KHzCalibrated[1] = !show3KHzCalibrated[1];
            RebuildAllCharts();
        }

        private void second24KHzCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            show24KHzRaw[1] = !show24KHzRaw[1];
            RebuildAllCharts();
        }

        private void second24KHzCalibratedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            show24KHzCalibrated[1] = !show24KHzCalibrated[1];
            RebuildAllCharts();
        }

        private void secondMixedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            showMixedCalibrated[1] = !showMixedCalibrated[1];
            RebuildAllCharts();
        }

    }
}
