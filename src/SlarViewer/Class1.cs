using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class DataSet : List<Datum>
    {
        public DataSet Subtract(DataSet dataSet)
        {
            DataSet result = new DataSet();
            for (int i = 0; i < Math.Min(Count,dataSet.Count); ++i)
                result.Add(this[i].Subtract(dataSet[i]));
            return result;
        }

        public DataSet Shift(int i)
        {
            DataSet result = new DataSet();
            if (i < 0)
            {
                foreach (Datum datum in this)
                    if (i++ > 0)
                        result.Add(datum.Dup());
            }
            else
            {
                for (; i > 0; --i)
                    result.Add(new Datum());
                foreach (Datum datum in this)
                    result.Add(datum.Dup());
            }
            return result;
        }
    }
}
