using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicSynthesizer
{
    public class LowFrequencyOscillator : Oscillator
    {
        // Constructors
        public LowFrequencyOscillator(OscillatorWaveform waveform, float frequency, float amplitude, float phase) : base(waveform, frequency, amplitude, phase, 1)
        {
        }

        // Methods
        public float[] Apply(float[] inputSignal, int samplingRate, float duration)
        {
            int numberOfSamples = inputSignal.Length;
            float[] outputSignal = new float[numberOfSamples];
            float[] lfoSignal = GenerateWaveDataPoints(samplingRate, duration);

            for (int i = 0; i < numberOfSamples; i++)
                outputSignal[i] = inputSignal[i] * lfoSignal[i];

            return outputSignal;
        }

        public List<DataPoint> Apply(List<DataPoint> inputSignal, int samplingRate, float duration)
        {
            int numberOfSamples = inputSignal.Count;
            float interval = 1f / samplingRate; //s
            List<DataPoint> outputSignal = new List<DataPoint>();
            float[] lfoSignal = GenerateWaveDataPoints(samplingRate, duration);

            for (int i = 0; i < numberOfSamples; i++)
                outputSignal.Add(new DataPoint(i * interval, inputSignal[i].YValues[0] * lfoSignal[i]));

            return outputSignal;
        }
    }
}
