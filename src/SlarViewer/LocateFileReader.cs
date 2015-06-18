using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class LocateFileReader
    {
        private System.IO.StreamReader streamReader;

        public LocateFileReader(System.IO.StreamReader streamReader)
        {
            this.streamReader = streamReader;
        }

        internal LocateFile Read()
        {
            LocateFile file = new LocateFile();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.Length == 0)
                    continue;

                string[] tokens = Tokenize(trimmedLine);

                if (tokens[0] == "!Encoder Resolution")
                    System.Windows.Forms.MessageBox.Show("Found encoder resolution");
                if (tokens[0].StartsWith( "!Data"))
                    LoadAllData(file);
                if (tokens[0] == "InitialAxial")
                    file.InitialAxial = Convert.ToInt32(tokens[1]);
                if (tokens[0] == "Gain3Khz")
                    file.Calibration3KHz.Gain = Convert.ToSingle(tokens[1]);
                if (tokens[0] == "Phase3Khz")
                    file.Calibration3KHz.Phase = Convert.ToSingle(tokens[1]);
                if (tokens[0] == "Gain24Khz")
                    file.Calibration24KHz.Gain = Convert.ToSingle(tokens[1]);
                if (tokens[0] == "Phase24Khz")
                    file.Calibration24KHz.Phase = Convert.ToSingle(tokens[1]);
                if (tokens[0] == "GainMixed")
                    file.CalibrationMixed.Gain = Convert.ToSingle(tokens[1]);
                if (tokens[0] == "PhaseMixed")
                    file.CalibrationMixed.Phase = Convert.ToSingle(tokens[1]);
                if (tokens[0].StartsWith("!Encoder Resolution"))
                    file.EncoderResolution = Convert.ToSingle(tokens[1]);
            }

            ApplyCalibrations(file);

            return file;
        }

        private void ApplyCalibrations(LocateFile file)
        {
            for (int i = 0; i < file.Channel1Data.Count; ++i)
            {
                file.Channel1CalibratedData.Add(file.Channel1Data[i].Apply(file.Calibration3KHz));
                file.Channel2CalibratedData.Add(file.Channel2Data[i].Apply(file.Calibration24KHz));
                file.MixedCalibratedData.Add(file.Channel1CalibratedData[i].Subtract(file.Channel2CalibratedData[i]).Apply(file.CalibrationMixed));
            }
        }

        private void LoadAllData(LocateFile file)
        {
            List<Datum> channel1Data = new List<Datum>();
            List<Datum> channel2Data = new List<Datum>();

            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.Length == 0)
                    continue;

                int[] tokens = TokenizeData(trimmedLine);

                if (tokens.Length != 8)
                    throw new Exception("Invalid number of data entries");

                channel1Data.Add(new Datum(new Vector(tokens[0], tokens[1]), CalculateAxialPosition(tokens[6], file)));
                channel2Data.Add(new Datum(new Vector(tokens[2], tokens[3]), CalculateAxialPosition(tokens[6], file)));
            }

            file.Channel1Data = channel1Data;
            file.Channel2Data = channel2Data;
        }

        private float CalculateAxialPosition(int rawPosition, LocateFile file)
        {
            return file.InitialAxial + file.EncoderResolution * rawPosition;
        }

        private int[] TokenizeData(string trimmedLine)
        {
            List<int> results = new List<int>();

            string[] tokens = trimmedLine.Split(',');

            foreach (string token in tokens)
                results.Add(Convert.ToInt32(token));

            return results.ToArray();
        }

        private string[] Tokenize(string trimmedLine)
        {
            List<string> tokens = new List<string>();
            bool inQuote = false;
            string currentToken = "";

            for (int i = 0; i < trimmedLine.Length; ++i)
            {
                if (inQuote)
                {
                    if (trimmedLine[i] == '"')
                    {
                        inQuote = false;
                        tokens.Add(currentToken);
                        currentToken = "";
                    }
                    else
                        currentToken += trimmedLine[i];
                }
                else
                {
                    if (trimmedLine[i] == '"')
                    {
                        inQuote = true;
                    }
                    else if (trimmedLine[i] == ',')
                    {
                        if (currentToken.Length > 0)
                        {
                            tokens.Add(currentToken);
                            currentToken = "";
                        }
                    }
                    else
                        currentToken += trimmedLine[i];
                }
            }

            if (currentToken.Length > 0)
                tokens.Add(currentToken);

            return tokens.ToArray();
        }
    }
}
