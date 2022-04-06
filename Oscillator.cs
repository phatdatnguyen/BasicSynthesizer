using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicSynthesizer
{
    public class Oscillator
    {
        // Fields
        private float phase;

        // Enumerations
        public enum OscillatorWaveform { Sine, Square, Triangle, Sawtooth };

        // Properties
        public OscillatorWaveform Waveform { get; set; }
        public Single Frequency { get; set; }
        public Single Amplitude { get; set; }
        public Single Phase
        {
            get { return phase; }
            set { if (value == 360) phase = 0; else phase = value; }
        }
        public Single Ratio { get; set; }

        // Constructors
        public Oscillator(OscillatorWaveform waveform, float frequency, float amplitude, float phase, float ratio)
        {
            Waveform = waveform;
            Frequency = frequency;
            Amplitude = amplitude;
            Phase = phase;
            Ratio = ratio;
        }

        // Methods
        public float[] GenerateWaveDataPoints(int samplingRate, float duration)
        {
            int numberOfSamples = Convert.ToInt32(Math.Floor(duration * samplingRate));
            float[] data = new float[numberOfSamples];
            float interval = 1f / samplingRate; //s
            float period = 1f / Frequency;
            float phaseShift = Phase / 360f / Frequency;

            for (int i = 0; i < numberOfSamples; i++)
            {
                float t = i * interval + phaseShift;
                switch (Waveform)
                {
                    case OscillatorWaveform.Sine:
                        data[i] = Convert.ToSingle(Amplitude * Math.Sin(Math.PI * 2f * Frequency * t));
                        break;
                    case OscillatorWaveform.Square:
                        data[i] = Convert.ToSingle(Amplitude * Math.Sign(Math.Sin(Math.PI * 2f * Frequency * t)));
                        break;
                    case OscillatorWaveform.Triangle:
                        data[i] = Convert.ToSingle(Amplitude * 2f * Math.Abs(2f * (t / period - Math.Floor(0.5f + t / period))) - 1f);
                        break;
                    case OscillatorWaveform.Sawtooth:
                        data[i] = Convert.ToSingle(Amplitude * 2f * (t / period - Math.Floor(0.5f + t / period)));
                        break;
                    default:
                        break;
                }
            }

            return data;
        }

        public static List<DataPoint> MixOscillators(List<Oscillator> oscillators, int samplingRate, float duration)
        {
            int numberOfOscillators = oscillators.Count;
            int numberOfSamples = Convert.ToInt32(Math.Floor(duration * samplingRate));
            float interval = 1f / samplingRate; //s

            List<float[]> wavesData = new List<float[]>();
            foreach (Oscillator oscillator in oscillators)
                wavesData.Add(oscillator.GenerateWaveDataPoints(samplingRate, duration));

            float[] mixedWaveData = new float[numberOfSamples];
            List<DataPoint> dataPoints = new List<DataPoint>();
            for (int i = 0; i < numberOfSamples; i++)
            {
                float totalWeight = 0;
                for (int j = 0; j < numberOfOscillators; j++)
                {
                    mixedWaveData[i] += wavesData[j][i] * oscillators[j].Ratio;
                    totalWeight += oscillators[j].Ratio;
                }
                mixedWaveData[i] = mixedWaveData[i] / totalWeight;

                dataPoints.Add(new DataPoint((double)(interval * i), (double)mixedWaveData[i]));
            }

            return dataPoints;
        }
    }
}
