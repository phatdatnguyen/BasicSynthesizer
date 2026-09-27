namespace BasicSynthesizer
{
    public class Filter
    {
        #region Enum
        public enum FilterMode { LowPass, HighPass, BandPass }
        #endregion

        #region Properties
        public double CutoffFrequency { get; set; }
        public double Resonance { get; set; }
        public FilterMode Mode { get; set; }
        #endregion

        #region Contructor
        public Filter(FilterMode filterMode, double cutoffFrequency, double resonance)
        {
            Mode = filterMode;
            CutoffFrequency = cutoffFrequency;
            Resonance = resonance;
        }
        #endregion

        #region Methods
        public double[] Apply(double[] inputSignal, int samplingRate)
        {
            ArgumentNullException.ThrowIfNull(inputSignal);
            (double alpha, double feedbackAmount) = GetCoefficients(samplingRate);
            int numberOfSamples = inputSignal.Length;
            double[] filteredSignal = new double[numberOfSamples];
            double buffer1 = 0;
            double buffer2 = 0;

            for (int i = 0; i < numberOfSamples; i++)
                filteredSignal[i] = ProcessSample(inputSignal[i], alpha, feedbackAmount, ref buffer1, ref buffer2);

            return filteredSignal;
        }

        public List<(double, double)> Apply(List<(double, double)> inputSignal, int samplingRate)
        {
            ArgumentNullException.ThrowIfNull(inputSignal);
            (double alpha, double feedbackAmount) = GetCoefficients(samplingRate);
            int numberOfSamples = inputSignal.Count;
            List<(double, double)> filteredSignal = new(numberOfSamples);
            double buffer1 = 0;
            double buffer2 = 0;

            for (int i = 0; i < numberOfSamples; i++)
            {
                double sample = ProcessSample(inputSignal[i].Item2, alpha, feedbackAmount, ref buffer1, ref buffer2);
                filteredSignal.Add((inputSignal[i].Item1, sample));
            }

            return filteredSignal;
        }

        private (double Alpha, double FeedbackAmount) GetCoefficients(int samplingRate)
        {
            if (samplingRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(samplingRate));
            if (!double.IsFinite(CutoffFrequency) || CutoffFrequency < 0)
                throw new ArgumentOutOfRangeException(nameof(CutoffFrequency));
            if (!double.IsFinite(Resonance) || Resonance < 0 || Resonance > 100)
                throw new ArgumentOutOfRangeException(nameof(Resonance));
            if (!Enum.IsDefined(Mode))
                throw new ArgumentOutOfRangeException(nameof(Mode));

            // This form avoids overflowing 2*pi*cutoff and has a defined limit at
            // zero cutoff. Keep feedback below the self-oscillation threshold.
            double alpha = CutoffFrequency == 0 ? 0 : 1.0 / (1.0 + samplingRate / CutoffFrequency / (2.0 * Math.PI));
            alpha = Math.Min(alpha, 0.9999);
            double resonance = Resonance / 101.0;
            double feedbackAmount = resonance + resonance / (1.0 - alpha);
            return (alpha, feedbackAmount);
        }

        private double ProcessSample(double input, double alpha, double feedbackAmount, ref double buffer1, ref double buffer2)
        {
            buffer1 += alpha * (input - buffer1 + feedbackAmount * (buffer1 - buffer2));
            buffer2 += alpha * (buffer1 - buffer2);

            // Leave headroom intact in both overloads. Clipping belongs at the
            // final audio output, after the remaining effects have been applied.
            return Mode switch
            {
                FilterMode.LowPass => buffer2,
                FilterMode.HighPass => input - buffer1,
                FilterMode.BandPass => buffer1 - buffer2,
                _ => throw new InvalidOperationException("Unknown filter mode.")
            };
        }
        #endregion
    }
}
