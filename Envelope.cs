namespace BasicSynthesizer
{
    public class Envelope
    {
        #region Properties
        public double Attack { get; set; }
        public double Decay { get; set; }
        public double Sustain { get; set; }
        public double Release { get; set; }
        #endregion

        #region Constructor
        public Envelope(double attack, double decay, double sustain, double release)
        {
            Attack = attack;
            Decay = decay;
            Sustain = sustain;
            Release = release;
        }
        #endregion

        #region Methods
        public double[] Apply(double[] inputDataPoints, int samplingRate, double duration)
        {
            int numberOfSamples = inputDataPoints.Length;
            double[] outputDataPoints = new double[numberOfSamples];

            double[] envelopeDataPoints = new double[numberOfSamples];
            double interval = 1f / samplingRate;

            for (int i = 0; i < numberOfSamples; i++)
            {
                double time = i * interval;
                if (time < Attack) // attack phase
                {
                    envelopeDataPoints[i] = time / Attack;
                    outputDataPoints[i] = inputDataPoints[i] * envelopeDataPoints[i];
                }
                else if (i * interval < Attack + Decay) // decay phase
                {
                    envelopeDataPoints[i] = 1 - (1 - Sustain / 100) * (time - Attack) / Decay;
                    outputDataPoints[i] = inputDataPoints[i] * envelopeDataPoints[i];
                }
                else if (i * interval < duration - Release) // sustain phase
                {
                    envelopeDataPoints[i] = Sustain / 100;
                    outputDataPoints[i] = inputDataPoints[i] * envelopeDataPoints[i]; ;
                }
                else // release phase
                {
                    envelopeDataPoints[i] = Sustain / 100 * (duration - time) / Release;
                    outputDataPoints[i] = inputDataPoints[i] * envelopeDataPoints[i];
                }
            }

            return outputDataPoints;
        }

        public List<(double, double)> Apply(List<(double, double)> inputDataPoints, int samplingRate, double duration)
        {
            int numberOfSamples = inputDataPoints.Count;
            List<(double, double)> outputDataPoints = new();

            double[] envelopeDataPoints = new double[numberOfSamples];
            double interval = 1f / samplingRate;

            for (int i = 0; i < numberOfSamples; i++)
            {
                double time = i * interval;
                if (time < Attack) // attack phase
                {
                    envelopeDataPoints[i] = time / Attack;
                    outputDataPoints.Add((time, inputDataPoints[i].Item2 * envelopeDataPoints[i]));
                }
                else if (i * interval < Attack + Decay) // decay phase
                {
                    envelopeDataPoints[i] = 1 - (1 - Sustain / 100) * (time - Attack) / Decay;
                    outputDataPoints.Add((time, inputDataPoints[i].Item2 * envelopeDataPoints[i]));
                }
                else if (i * interval < duration - Release) // sustain phase
                {
                    envelopeDataPoints[i] = Sustain / 100;
                    outputDataPoints.Add((time, inputDataPoints[i].Item2 * envelopeDataPoints[i]));
                }
                else // release phase
                {
                    envelopeDataPoints[i] = Sustain / 100 * (duration - time) / Release;
                    outputDataPoints.Add((time, inputDataPoints[i].Item2 * envelopeDataPoints[i]));
                }
            }

            return outputDataPoints;
        }
        #endregion
    }
}
