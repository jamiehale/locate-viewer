using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class CalibratedDataSet
    {
        private Calibration calibration;
        public Calibration Calibration
        {
            get
            {
                return calibration;
            }
        }

        private DataSet rawData;
        public DataSet RawData
        {
            get
            {
                return rawData;
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
        public delegate void DataSetChangedHandler();

        public CalibratedDataSet(Calibration calibration, DataSet rawData)
        {
            this.calibration = calibration;
            this.rawData = rawData;

            calibratedData = new DataSet();
            RebuildCalibratedData();

            this.calibration.CalibrationChanged += new Calibration.CalibrationChangedHandler(calibration_CalibrationChanged);
        }

        void calibration_CalibrationChanged()
        {
            RebuildCalibratedData();
            if (DataSetChanged != null)
                DataSetChanged();
        }

        private void RebuildCalibratedData()
        {
            calibratedData.Clear();
            foreach (Datum datum in rawData)
                calibratedData.Add(datum.Apply(calibration));
        }
    }
}
