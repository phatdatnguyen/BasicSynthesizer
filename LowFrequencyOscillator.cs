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
            int numberOfSamples = inputSignal.Length;
            double[] outputSignal = new double[numberOfSamples];
            double[] lfoSignal = GenerateWaveDataPoints(samplingRate, duration);

            for (int i = 0; i < numberOfSamples; i++)
                outputSignal[i] = inputSignal[i] * lfoSignal[i];

            return outputSignal;
        }

        public List<(double, double)> Apply(List<(double, double)> inputSignal, int samplingRate, double duration)
        {
            int numberOfSamples = inputSignal.Count;
            double interval = 1f / samplingRate; //s
            List<(double, double)> outputSignal = new();
            double[] lfoSignal = GenerateWaveDataPoints(samplingRate, duration);

            for (int i = 0; i < numberOfSamples; i++)
                outputSignal.Add((i * interval, inputSignal[i].Item2 * lfoSignal[i]));

            return outputSignal;
        }
        #endregion
    }
}
