using System;
using System.Collections.Generic;

namespace BasicSynthesizer
{
    public class Oscillator
    {
        #region Field
        private double phase;
        #endregion

        #region Enum
        public enum OscillatorWaveform { Sine, Square, Triangle, Sawtooth };
        #endregion

        #region Properties
        public OscillatorWaveform Waveform { get; set; }
        public double Frequency { get; set; }
        public double Amplitude { get; set; }
        public double Phase
        {
            get { return phase; }
            set { if (value == 360) phase = 0; else phase = value; }
        }
        public double Ratio { get; set; }
        #endregion

        #region Constructor
        public Oscillator(OscillatorWaveform waveform, double frequency, double amplitude, double phase, double ratio)
        {
            Waveform = waveform;
            Frequency = frequency;
            Amplitude = amplitude;
            Phase = phase;
            Ratio = ratio;
        }
        #endregion

        #region Methods
        public double[] GenerateWaveDataPoints(int samplingRate, double duration)
        {
            int numberOfSamples = Convert.ToInt32(Math.Floor(duration * samplingRate));
            double[] data = new double[numberOfSamples];
            double interval = 1f / samplingRate; //s
            double period = 1f / Frequency;
            double phaseShift = Phase / 360f / Frequency;

            for (int i = 0; i < numberOfSamples; i++)
            {
                double t = i * interval + phaseShift;
                switch (Waveform)
                {
                    case OscillatorWaveform.Sine:
                        data[i] = Convert.ToDouble(Amplitude * Math.Sin(Math.PI * 2f * Frequency * t));
                        break;
                    case OscillatorWaveform.Square:
                        data[i] = Convert.ToDouble(Amplitude * Math.Sign(Math.Sin(Math.PI * 2f * Frequency * t)));
                        break;
                    case OscillatorWaveform.Triangle:
                        data[i] = Convert.ToDouble(Amplitude * 2f * Math.Abs(2f * (t / period - Math.Floor(0.5f + t / period))) - 1f);
                        break;
                    case OscillatorWaveform.Sawtooth:
                        data[i] = Convert.ToDouble(Amplitude * 2f * (t / period - Math.Floor(0.5f + t / period)));
                        break;
                    default:
                        break;
                }
            }

            return data;
        }

        public static List<(double, double)> MixOscillators(List<Oscillator> oscillators, int samplingRate, double duration)
        {
            int numberOfOscillators = oscillators.Count;
            int numberOfSamples = Convert.ToInt32(Math.Floor(duration * samplingRate));
            double interval = 1f / samplingRate; //s

            List<double[]> wavesData = new();
            foreach (Oscillator oscillator in oscillators)
                wavesData.Add(oscillator.GenerateWaveDataPoints(samplingRate, duration));

            double[] mixedWaveData = new double[numberOfSamples];
            List<(double, double)> dataPoints = new();
            for (int i = 0; i < numberOfSamples; i++)
            {
                double totalWeight = 0;
                for (int j = 0; j < numberOfOscillators; j++)
                {
                    mixedWaveData[i] += wavesData[j][i] * oscillators[j].Ratio;
                    totalWeight += oscillators[j].Ratio;
                }
                mixedWaveData[i] = mixedWaveData[i] / totalWeight;

                dataPoints.Add(((double)(interval * i), mixedWaveData[i]));
            }

            return dataPoints;
        }
        #endregion
    }
}
