using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class SubtractedDataSet
    {
        private DataSet firstData;
        public DataSet FirstData
        {
            get
            {
                return firstData;
            }
        }

        private DataSet secondData;
        public DataSet SecondData
        {
            get
            {
                return secondData;
            }
        }

        private DataSet data;
        public DataSet Data
        {
            get
            {
                return data;
            }
        }

        public SubtractedDataSet(DataSet firstData, DataSet secondData)
        {
            this.firstData = firstData;
            this.secondData = secondData;

            RebuildData();
        }

        private void RebuildData()
        {
            data = new DataSet();
            for (int i = 0; i < Math.Min(firstData.Count, secondData.Count); ++i)
                data.Add(firstData[i].Subtract(secondData[i]));
        }
    }
}
