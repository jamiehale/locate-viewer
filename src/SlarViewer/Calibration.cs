using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class Calibration
    {
        private float gain;
        public float Gain
        {
            get
            {
                return gain;
            }
            set
            {
                gain = value;
                NotifyListeners();
            }
        }

        private float phase;
        public float Phase
        {
            get
            {
                return phase;
            }
            set
            {
                phase = value;
                NotifyListeners();
            }
        }

        public event CalibrationChangedHandler CalibrationChanged;
        public delegate void CalibrationChangedHandler(Calibration sender);

        public Calibration()
        {
        }

        public Calibration(Calibration calibration)
        {
            gain = calibration.Gain;
            phase = calibration.Phase;
        }

        public Calibration(float gain, float phase)
        {
            this.gain = gain;
            this.phase = phase;
        }

        private void NotifyListeners()
        {
            if (CalibrationChanged != null)
                CalibrationChanged(this);
        }
    }
}
