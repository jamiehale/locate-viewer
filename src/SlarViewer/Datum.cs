using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class Datum
    {
        public Vector Data { get; set; }
        public float AxialPosition { get; set; }

        public Datum()
        {
            Data = new Vector();
        }

        public Datum(Vector data, float axialPosition)
        {
            Data = data;
            AxialPosition = axialPosition;
        }

        public Datum Apply(Calibration calibration)
        {
            return new Datum(Data.Apply(calibration), AxialPosition);
        }

        internal Datum Subtract(Datum datum)
        {
            return new Datum(Data.Subtract(datum.Data), AxialPosition);
        }

        internal Datum Shift(int i)
        {
            return new Datum(Data, AxialPosition + i);
        }

        internal Datum Dup()
        {
            return new Datum(Data, AxialPosition);
        }
    }
}
