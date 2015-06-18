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
        public delegate void DataSetChangedHandler(DataSet sender);

        public CalibratedDataSet(Calibration calibration, DataSet data)
        {
            this.calibration = calibration;
            this.rawData = data;

            this.calibration.CalibrationChanged += new Calibration.CalibrationChangedHandler(calibration_CalibrationChanged);

            RebuildCalibratedData();
        }

        void calibration_CalibrationChanged(Calibration sender)
        {
            RebuildCalibratedData();
            if (DataSetChanged != null)
                DataSetChanged(calibratedData);
        }

        private void RebuildCalibratedData()
        {
            calibratedData = new DataSet();
            foreach (Datum datum in rawData)
                calibratedData.Add(datum.Apply(calibration));
        }
    }
}
