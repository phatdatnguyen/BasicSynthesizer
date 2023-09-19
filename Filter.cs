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
            int numberOfSamples = inputSignal.Length;
            double interval = 1f / samplingRate;
            double rc = Convert.ToDouble(1f / (Math.PI * 2 * CutoffFrequency));
            double alpha = interval / (rc + interval);
            double feedbackAmount = (Resonance + Resonance / (1f - alpha)) / 101f;

            double[] filteredSignal = new double[numberOfSamples];
            double[] buffer1 = new double[numberOfSamples];
            double[] buffer2 = new double[numberOfSamples];

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
                    return inputSignal;
            }
        }

        public List<(double, double)> Apply(List<(double, double)> inputSignal, int samplingRate)
        {
            int numberOfSamples = inputSignal.Count;
            double interval = 1f / samplingRate;
            double rc = Convert.ToDouble(1f / (Math.PI * 2 * CutoffFrequency));
            double alpha = interval / (rc + interval);
            double feedbackAmount = (Resonance + Resonance / (1f - alpha)) / 101f;

            List<(double, double)> filteredSignal = new();
            double[] buffer1 = new double[numberOfSamples];
            double[] buffer2 = new double[numberOfSamples];

            buffer1[0] = (alpha * inputSignal[0].Item2);
            buffer2[0] = alpha * buffer1[0];
            for (int i = 1; i < numberOfSamples; i++)
            {
                buffer1[i] = (buffer1[i - 1] + alpha * (inputSignal[i].Item2 - buffer1[i - 1] + feedbackAmount * (buffer1[i - 1] - buffer2[i - 1])));
                buffer2[i] = buffer2[i - 1] + alpha * (buffer1[i] - buffer2[i - 1]);
            }

            switch (Mode)
            {
                case FilterMode.LowPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal.Add((i * interval, buffer2[i]));
                    break;
                case FilterMode.HighPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal.Add((i * interval, inputSignal[i].Item2 - buffer1[i]));
                    break;
                case FilterMode.BandPass:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal.Add((i * interval, buffer1[i] - buffer2[i]));
                    break;
                default:
                    for (int i = 0; i < numberOfSamples; i++)
                        filteredSignal.Add((i * interval, inputSignal[i].Item2));
                    break;
            }

            for (int i = 0; i < numberOfSamples; i++)
            {
                if (filteredSignal[i].Item2 < -1f)
                    filteredSignal[i] = (filteredSignal[i].Item1, - 1f);
                if (filteredSignal[i].Item2 > 1f)
                    filteredSignal[i] = (filteredSignal[i].Item1, 1f);
            }

            return filteredSignal;
        }
        #endregion
    }
}
