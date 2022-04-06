using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicSynthesizer
{
    public class Filter
    {
        // Enumerations
        public enum FilterMode { LowPass, HighPass, BandPass }

        // Properties
        public Single CutoffFrequency { get; set; }
        public Single Resonance { get; set; }
        public FilterMode Mode { get; set; }

        // Contructors
        public Filter(FilterMode filterMode, float cutoffFrequency, float resonance)
        {
            Mode = filterMode;
            CutoffFrequency = cutoffFrequency;
            Resonance = resonance;
        }

        // Methods
        public float[] Apply(float[] inputSignal, int samplingRate)
        {
            int numberOfSamples = inputSignal.Length;
            float interval = 1f / samplingRate;
            float rc = Convert.ToSingle(1f / (Math.PI * 2 * CutoffFrequency));
            float alpha = interval / (rc + interval);
            float feedbackAmount = (Resonance + Resonance / (1f - alpha)) / 101f;

            float[] filteredSignal = new float[numberOfSamples];
            float[] buffer1 = new float[numberOfSamples];
            float[] buffer2 = new float[numberOfSamples];

            buffer1[0] = alpha * inputSignal[0];
            buffer2[0] = alpha * buffer1[0];
            for (int i = 1; i < numberOfSamples; i++)
            {
                buffer1[i] = buffer1[i - 1] + alpha * (inputSignal[i] - buffer1[i - 1] + feedbackAmount * (buffer1[i - 1] - buffer2[i - 1]));
                buffer2[i] = buffer2[i - 1] + alpha * (buffer1[i] - buffer2[i - 1]);
            }
                
            switch (Mode)
            {
                case FilterMode.LowPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal[i] = buffer2[i];

                    return filteredSignal;
                case FilterMode.HighPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal[i] = inputSignal[i] - buffer1[i];

                    return filteredSignal;
                case FilterMode.BandPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal[i] = buffer1[i] - buffer2[i];

                    return filteredSignal;
                default:
                    return null;
            }
        }

        public List<DataPoint> Apply(List<DataPoint> inputSignal, int samplingRate)
        {
            int numberOfSamples = inputSignal.Count;
            float interval = 1f / samplingRate;
            float rc = Convert.ToSingle(1f / (Math.PI * 2 * CutoffFrequency));
            float alpha = interval / (rc + interval);
            float feedbackAmount = (Resonance + Resonance / (1f - alpha)) / 101f;

            List<DataPoint> filteredSignal = new List<DataPoint>();
            float[] buffer1 = new float[numberOfSamples];
            float[] buffer2 = new float[numberOfSamples];

            buffer1[0] = (float)(alpha * inputSignal[0].YValues[0]);
            buffer2[0] = alpha * buffer1[0];
            for (int i = 1; i < numberOfSamples; i++)
            {
                buffer1[i] = (float)(buffer1[i - 1] + alpha * (inputSignal[i].YValues[0] - buffer1[i - 1] + feedbackAmount * (buffer1[i - 1] - buffer2[i - 1])));
                buffer2[i] = buffer2[i - 1] + alpha * (buffer1[i] - buffer2[i - 1]);
            }

            switch (Mode)
            {
                case FilterMode.LowPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal.Add(new DataPoint(i * interval, buffer2[i]));

                    return filteredSignal;
                case FilterMode.HighPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal.Add(new DataPoint(i * interval, inputSignal[i].YValues[0] - buffer1[i]));

                    return filteredSignal;
                case FilterMode.BandPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal.Add(new DataPoint(i * interval, buffer1[i] - buffer2[i]));

                    return filteredSignal;
                default:
                    return null;
            }
        }
    }
}
