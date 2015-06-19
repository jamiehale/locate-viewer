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

            VectorBucket[] firstBuckets = new VectorBucket[6000];
            foreach (Datum datum in firstData.Data)
            {
                int index = Math.Max(0, (int)datum.AxialPosition);
                if (firstBuckets[index] == null)
                    firstBuckets[index] = new VectorBucket();
                firstBuckets[index].Add(datum.Data);
            }

            VectorBucket[] secondBuckets = new VectorBucket[6000];
            foreach (Datum datum in secondData.Data)
            {
                int index = Math.Max(0, (int)datum.AxialPosition);
                if (secondBuckets[index] == null)
                    secondBuckets[index] = new VectorBucket();
                secondBuckets[index].Add(datum.Data);
            }

            for (int i = 0; i < 6000; ++i)
                if (firstBuckets[i] != null && secondBuckets[i] != null)
                    calibratedData.Add(new Datum(firstBuckets[i].Average().Subtract(secondBuckets[i].Average()).Apply(calibration), i + shift));
        }
    }
}
