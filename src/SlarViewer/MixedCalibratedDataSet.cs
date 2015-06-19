using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class MixedCalibratedDataSet
    {
        private Calibration calibration;
        private CalibratedDataSet firstData;
        private CalibratedDataSet secondData;
        private int shift = 0;

        public int Shift
        {
            get
            {
                return shift;
            }
            set
            {
                shift = value;
                RebuildData();
                NotifyListeners();
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

        public MixedCalibratedDataSet(Calibration calibration, CalibratedDataSet firstData, CalibratedDataSet secondData)
        {
            this.calibration = calibration;
            this.firstData = firstData;
            this.secondData = secondData;

            calibratedData = new DataSet();

            RebuildData();

            this.calibration.CalibrationChanged += new Calibration.CalibrationChangedHandler(calibration_CalibrationChanged);
            this.firstData.DataSetChanged += new CalibratedDataSet.DataSetChangedHandler(firstData_DataSetChanged);
            this.secondData.DataSetChanged += new CalibratedDataSet.DataSetChangedHandler(secondData_DataSetChanged);
        }

        void secondData_DataSetChanged()
        {
            RebuildData();
            NotifyListeners();
        }

        void firstData_DataSetChanged()
        {
            RebuildData();
            NotifyListeners();
        }

        private void NotifyListeners()
        {
            if (DataSetChanged != null)
                DataSetChanged();
        }

        void calibration_CalibrationChanged()
        {
            RebuildData();
            NotifyListeners();
        }

        private void RebuildData()
        {
            calibratedData.Clear();
            for (int i = 0; i < Math.Min(firstData.Data.Count, secondData.Data.Count); ++i)
                calibratedData.Add(firstData.Data[i].Subtract(secondData.Data[i].Shift(shift)).Apply(calibration));
        }
    }
}
