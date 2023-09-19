using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicSynthesizer
{
    public class Envelope
    {
        // Properties
        public Single Attack { get; set; }
        public Single Decay { get; set; }
        public Single Sustain { get; set; }
        public Single Release { get; set; }

        // Constructors
        public Envelope(float attack, float decay, float sustain, float release)
        {
            Attack = attack;
            Decay = decay;
            Sustain = sustain;
            Release = release;
        }

        // Method
        public float[] Apply(float[] inputDataPoints, int samplingRate, float duration)
        {
            int numberOfSamples = inputDataPoints.Length;
            float[] outputDataPoints = new float[numberOfSamples];

            float[] envelopeDataPoints = new float[numberOfSamples];
            float interval = 1f / samplingRate;

            for (int i = 0; i < numberOfSamples; i++)
            {
                float time = i * interval;
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

        public List<(double, double)> Apply(List<(double, double)> inputDataPoints, int samplingRate, float duration)
        {
            int numberOfSamples = inputDataPoints.Count;
            List<(double, double)> outputDataPoints = new List<(double, double)>();

            float[] envelopeDataPoints = new float[numberOfSamples];
            float interval = 1f / samplingRate;

            for (int i = 0; i < numberOfSamples; i++)
            {
                float time = i * interval;
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
    }
}
