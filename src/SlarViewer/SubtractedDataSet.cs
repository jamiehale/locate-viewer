using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class SubtractedDataSet
    {
        private MixedCalibratedDataSet firstData;
        private MixedCalibratedDataSet secondData;

        private DataSet data;
        public DataSet Data
        {
            get
            {
                return data;
            }
        }

        public SubtractedDataSet(MixedCalibratedDataSet firstData, MixedCalibratedDataSet secondData)
        {
            this.firstData = firstData;
            this.secondData = secondData;

            data = new DataSet();

            firstData.DataSetChanged += new MixedCalibratedDataSet.DataSetChangedHandler(firstData_DataSetChanged);
            secondData.DataSetChanged += new MixedCalibratedDataSet.DataSetChangedHandler(secondData_DataSetChanged);

            RebuildData();
        }

        void secondData_DataSetChanged()
        {
            RebuildData();
        }

        void firstData_DataSetChanged()
        {
            RebuildData();
        }

        private void RebuildData()
        {
            data.Clear();

            VectorBucket[] firstBucket = new VectorBucket[6000];
            foreach (Datum datum in firstData.Data)
            {
                int index = Math.Max(0, (int)datum.AxialPosition);
                if (firstBucket[index] == null)
                    firstBucket[index] = new VectorBucket();
                firstBucket[index].Add(datum.Data);
            }

            VectorBucket[] secondBucket = new VectorBucket[6000];
            foreach (Datum datum in secondData.Data)
            {
                int index = Math.Max(0, (int)datum.AxialPosition);
                if (secondBucket[index] == null)
                    secondBucket[index] = new VectorBucket();
                secondBucket[index].Add(datum.Data);
            }

            for (int i = 0; i < 6000; ++i)
                if (firstBucket[i] != null && secondBucket[i] != null)
                    data.Add(new Datum(firstBucket[i].Average().Subtract(secondBucket[i].Average()), i));
        }
    }
}
