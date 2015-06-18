using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class LocateFile
    {
        public LocateFile()
        {
            Calibration3KHz = new Calibration();
            Calibration24KHz = new Calibration();
            CalibrationMixed = new Calibration();
            Channel1CalibratedData = new DataSet();
            Channel2CalibratedData = new DataSet();
            MixedCalibratedData = new DataSet();
        }

        public DataSet Channel1Data { get; set; }
        public DataSet Channel2Data { get; set; }
        public DataSet Channel1CalibratedData { get; set; }
        public DataSet Channel2CalibratedData { get; set; }
        public DataSet MixedCalibratedData { get; set; }

        public Calibration Calibration3KHz { get; set; }
        public Calibration Calibration24KHz { get; set; }
        public Calibration CalibrationMixed { get; set; }
        public int InitialAxial { get; set; }
        public float EncoderResolution { get; set; }
    }
}
