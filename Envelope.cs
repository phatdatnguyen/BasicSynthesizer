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
            ArgumentNullException.ThrowIfNull(inputDataPoints);
            ValidateParameters(samplingRate, duration);
            int numberOfSamples = inputDataPoints.Length;
            double[] outputDataPoints = new double[numberOfSamples];

            for (int i = 0; i < numberOfSamples; i++)
                outputDataPoints[i] = inputDataPoints[i] * GetGain((double)i / samplingRate, duration);

            return outputDataPoints;
        }

        public List<(double, double)> Apply(List<(double, double)> inputDataPoints, int samplingRate, double duration)
        {
            ArgumentNullException.ThrowIfNull(inputDataPoints);
            ValidateParameters(samplingRate, duration);
            int numberOfSamples = inputDataPoints.Count;
            List<(double, double)> outputDataPoints = new(numberOfSamples);

            for (int i = 0; i < numberOfSamples; i++)
                outputDataPoints.Add((inputDataPoints[i].Item1, inputDataPoints[i].Item2 * GetGain((double)i / samplingRate, duration)));

            return outputDataPoints;
        }

        private double GetGain(double time, double duration)
        {
            if (time >= duration)
                return 0;

            double releaseStart = Math.Max(0, duration - Release);
            if (Release > 0 && time >= releaseStart)
            {
                // A short note can end during attack or decay. Release smoothly
                // from the level reached at note-off instead of jumping to sustain.
                double releaseLevel = GetHeldGain(releaseStart);
                return releaseLevel * ((duration - time) / (duration - releaseStart));
            }

            return GetHeldGain(time);
        }

        private double GetHeldGain(double time)
        {
            if (Attack > 0 && time < Attack)
                return time / Attack;
            if (Decay > 0 && time - Attack < Decay)
                return 1.0 - (1.0 - Sustain / 100.0) * ((time - Attack) / Decay);

            return Sustain / 100.0;
        }

        private void ValidateParameters(int samplingRate, double duration)
        {
            if (samplingRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(samplingRate));
            if (!double.IsFinite(duration) || duration < 0)
                throw new ArgumentOutOfRangeException(nameof(duration));
            if (!double.IsFinite(Attack) || Attack < 0)
                throw new ArgumentOutOfRangeException(nameof(Attack));
            if (!double.IsFinite(Decay) || Decay < 0)
                throw new ArgumentOutOfRangeException(nameof(Decay));
            if (!double.IsFinite(Sustain) || Sustain < 0 || Sustain > 100)
                throw new ArgumentOutOfRangeException(nameof(Sustain));
            if (!double.IsFinite(Release) || Release < 0)
                throw new ArgumentOutOfRangeException(nameof(Release));
        }
        #endregion
    }
}
