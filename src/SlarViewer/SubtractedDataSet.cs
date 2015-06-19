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
                    data.Add(new Datum(firstBuckets[i].Average().Subtract(secondBuckets[i].Average()), i));
        }
    }
}
