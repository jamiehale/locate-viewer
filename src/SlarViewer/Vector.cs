using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector() { }
        public Vector(float x, float y) { X = x; Y = y; }

        public Vector Apply(Calibration calibration)
        {
            float x = (float)(calibration.Gain * (X * Math.Cos(calibration.Phase) - Y * Math.Sin(calibration.Phase)));
            float y = (float)(calibration.Gain * (Y * Math.Cos(calibration.Phase) + X * Math.Sin(calibration.Phase)));

            return new Vector(x, y);
        }

        internal Vector Subtract(Vector vector)
        {
            return new Vector(X - vector.X, Y - vector.Y);
        }
    }
}
