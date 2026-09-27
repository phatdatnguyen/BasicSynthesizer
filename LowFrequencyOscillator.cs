namespace BasicSynthesizer
{
    public class LowFrequencyOscillator : Oscillator
    {
        #region Constructor
        public LowFrequencyOscillator(OscillatorWaveform waveform, double frequency, double amplitude, double phase) : base(waveform, frequency, amplitude, phase, 1)
        {
        }
        #endregion

        #region Methods
        public double[] Apply(double[] inputSignal, int samplingRate, double duration)
        {
            ArgumentNullException.ThrowIfNull(inputSignal);
            int numberOfSamples = inputSignal.Length;
            double[] outputSignal = new double[numberOfSamples];
            double[] lfoSignal = GenerateModulation(samplingRate, duration, numberOfSamples);

            for (int i = 0; i < numberOfSamples; i++)
                outputSignal[i] = inputSignal[i] * (1.0 - Amplitude / 2.0 + lfoSignal[i] / 2.0);

            return outputSignal;
        }

        public List<(double, double)> Apply(List<(double, double)> inputSignal, int samplingRate, double duration)
        {
            ArgumentNullException.ThrowIfNull(inputSignal);
            int numberOfSamples = inputSignal.Count;
            List<(double, double)> outputSignal = new(numberOfSamples);
            double[] lfoSignal = GenerateModulation(samplingRate, duration, numberOfSamples);

            for (int i = 0; i < numberOfSamples; i++)
                outputSignal.Add((inputSignal[i].Item1, inputSignal[i].Item2 * (1.0 - Amplitude / 2.0 + lfoSignal[i] / 2.0)));

            return outputSignal;
        }

        private double[] GenerateModulation(int samplingRate, double duration, int numberOfSamples)
        {
            if (!double.IsFinite(duration) || duration < 0)
                throw new ArgumentOutOfRangeException(nameof(duration));
            if (!double.IsFinite(Amplitude) || Amplitude < 0 || Amplitude > 1)
                throw new ArgumentOutOfRangeException(nameof(Amplitude), "Modulation depth must be between zero and one.");

            // Imported audio durations may have been rounded. The input sample count
            // is authoritative, so modulation must always cover the entire signal.
            return GenerateSamples(samplingRate, numberOfSamples);
        }
        #endregion
    }
}
