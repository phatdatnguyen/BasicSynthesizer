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
            set
            {
                if (!double.IsFinite(value))
                    throw new ArgumentOutOfRangeException(nameof(value), "Phase must be finite.");

                phase = value % 360;
                if (phase < 0)
                    phase += 360;
            }
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
            return GenerateSamples(samplingRate, GetSampleCount(samplingRate, duration));
        }

        protected double[] GenerateSamples(int samplingRate, int numberOfSamples)
        {
            if (samplingRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(samplingRate));
            if (numberOfSamples < 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfSamples));
            if (!double.IsFinite(Frequency) || Frequency < 0)
                throw new ArgumentOutOfRangeException(nameof(Frequency));
            if (!double.IsFinite(Amplitude) || Amplitude < 0)
                throw new ArgumentOutOfRangeException(nameof(Amplitude));
            if (!Enum.IsDefined(Waveform))
                throw new ArgumentOutOfRangeException(nameof(Waveform));

            double[] data = new double[numberOfSamples];
            // Work in cycles so zero frequency is valid and large frequencies cannot
            // overflow an intermediate time or phase calculation.
            double phaseIncrement = (Frequency % samplingRate) / samplingRate;
            double phaseOffset = Phase / 360.0;

            for (int i = 0; i < numberOfSamples; i++)
            {
                double cycle = (i * phaseIncrement + phaseOffset) % 1.0;
                switch (Waveform)
                {
                    case OscillatorWaveform.Sine:
                        data[i] = Amplitude * Math.Sin(2.0 * Math.PI * cycle);
                        break;
                    case OscillatorWaveform.Square:
                        data[i] = cycle < 0.5 ? Amplitude : -Amplitude;
                        break;
                    case OscillatorWaveform.Triangle:
                        data[i] = Amplitude * (4.0 * Math.Abs(cycle - Math.Floor(cycle + 0.5)) - 1.0);
                        break;
                    case OscillatorWaveform.Sawtooth:
                        data[i] = Amplitude * (2.0 * (cycle - Math.Floor(cycle + 0.5)));
                        break;
                }
            }

            return data;
        }

        public static List<(double, double)> MixOscillators(List<Oscillator> oscillators, int samplingRate, double duration)
        {
            ArgumentNullException.ThrowIfNull(oscillators);
            int numberOfSamples = GetSampleCount(samplingRate, duration);
            double largestWeight = 0;
            foreach (Oscillator oscillator in oscillators)
            {
                if (oscillator is null)
                    throw new ArgumentException("Oscillators must not contain null entries.", nameof(oscillators));
                if (!double.IsFinite(oscillator.Ratio) || oscillator.Ratio < 0)
                    throw new ArgumentOutOfRangeException(nameof(oscillators), "Mix ratios must be finite and non-negative.");
                largestWeight = Math.Max(largestWeight, oscillator.Ratio);
            }

            double[] mixedWaveData = new double[numberOfSamples];
            if (largestWeight > 0)
            {
                // Scaling the weights first also keeps their sum finite.
                double totalWeight = 0;
                foreach (Oscillator oscillator in oscillators)
                    totalWeight += oscillator.Ratio / largestWeight;

                foreach (Oscillator oscillator in oscillators)
                {
                    if (oscillator.Ratio == 0)
                        continue;

                    double weight = (oscillator.Ratio / largestWeight) / totalWeight;
                    double[] wave = oscillator.GenerateSamples(samplingRate, numberOfSamples);
                    for (int i = 0; i < numberOfSamples; i++)
                        mixedWaveData[i] += wave[i] * weight;
                }
            }

            List<(double, double)> dataPoints = new(numberOfSamples);
            for (int i = 0; i < numberOfSamples; i++)
                dataPoints.Add(((double)i / samplingRate, mixedWaveData[i]));

            return dataPoints;
        }

        private static int GetSampleCount(int samplingRate, double duration)
        {
            if (samplingRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(samplingRate));
            if (!double.IsFinite(duration) || duration < 0)
                throw new ArgumentOutOfRangeException(nameof(duration));

            double sampleCount = Math.Floor(duration * samplingRate);
            if (!double.IsFinite(sampleCount) || sampleCount > Array.MaxLength)
                throw new ArgumentOutOfRangeException(nameof(duration), "The requested signal is too long.");

            return (int)sampleCount;
        }
        #endregion
    }
}
