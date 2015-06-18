using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class MixedCalibratedDataSet
    {
        private Calibration calibration;
        public Calibration Calibration
        {
            get
            {
                return calibration;
            }
        }

        private DataSet firstRawData;
        public DataSet FirstRawData
        {
            get
            {
                return firstRawData;
            }
        }

        private DataSet secondRawData;
        public DataSet SecondRawData
        {
            get
            {
                return secondRawData;
            }
        }

        private DataSet calibratedData;
        public DataSet Data
        {
            get
            {
                return calibratedData;
            }
        }

        public event DataSetChangedHandler DataSetChanged;
        public delegate void DataSetChangedHandler(DataSet sender);

        public MixedCalibratedDataSet(Calibration calibration, DataSet firstData, DataSet secondData)
        {
            this.calibration = calibration;
            this.firstRawData = firstData;
            this.secondRawData = secondData;

            this.calibration.CalibrationChanged += new Calibration.CalibrationChangedHandler(calibration_CalibrationChanged);

            RebuildData();
        }

        void calibration_CalibrationChanged(Calibration sender)
        {
            RebuildData();
            DataSetChanged(calibratedData);
        }

        private void RebuildData()
        {
            calibratedData = new DataSet();
            for (int i = 0; i < Math.Min(firstRawData.Count, secondRawData.Count); ++i)
                calibratedData.Add(firstRawData[i].Subtract(secondRawData[i]).Apply(calibration));
        }
    }
}
