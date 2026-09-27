using Accord.Audio;
using Accord.DirectSound;

namespace BasicSynthesizer
{
    /// <summary>Streams mono samples through Accord's tracked playback thread.</summary>
    internal sealed class AudioPlayback : IDisposable
    {
        private readonly Control owner;
        private readonly AudioOutputDevice device;
        private readonly float[] samples;
        private readonly Action<string> reportError;
        private int nextSample;
        private bool started;
        private volatile bool disposed;

        public AudioPlayback(Control owner, int samplingRate, float[] samples, Action<string> reportError)
        {
            ArgumentNullException.ThrowIfNull(owner);
            ArgumentNullException.ThrowIfNull(samples);
            ArgumentNullException.ThrowIfNull(reportError);
            if (samples.Length == 0)
                throw new ArgumentException("There are no samples to play.", nameof(samples));

            this.owner = owner;
            this.samples = samples;
            this.reportError = reportError;
            device = new AudioOutputDevice(owner.Handle, samplingRate, 1);
            device.NewFrameRequested += FillBuffer;
            device.FramePlayingStarted += FramePlayingStarted;
            device.AudioOutputError += AudioOutputError;
        }

        public void Play()
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            if (started)
                return;

            started = true;
            // Play(float[]) starts an untracked worker in Accord 3.8.2-alpha.
            // The streaming overload can be signaled and joined before disposal.
            device.Play();
        }

        private void FillBuffer(object? sender, NewFrameRequestedEventArgs e)
        {
            FillBuffer(samples, ref nextSample, e);
        }

        internal static void FillBuffer(float[] samples, ref int nextSample, NewFrameRequestedEventArgs e)
        {
            Array.Clear(e.Buffer);
            int count = Math.Min(e.Frames, samples.Length - nextSample);
            Array.Copy(samples, nextSample, e.Buffer, 0, count);
            nextSample += count;
            // A partial final buffer still needs to play before requesting a stop.
            e.Stop = count == 0;
        }

        private void FramePlayingStarted(object? sender, PlayFrameEventArgs e)
        {
            // Accord uses an eight-second circular buffer. Stop after the actual
            // sample range instead of leaving short clips running in silence.
            if (e.FrameIndex >= samples.Length)
                device.SignalToStop();
        }

        private void AudioOutputError(object? sender, AudioOutputErrorEventArgs e)
        {
            if (disposed || owner.IsDisposed || !owner.IsHandleCreated)
                return;

            try
            {
                // Never synchronously invoke the UI from the worker: the UI may
                // already be waiting for this thread during playback shutdown.
                owner.BeginInvoke((Action)(() =>
                {
                    if (!disposed && !owner.IsDisposed)
                        reportError(e.Description);
                }));
            }
            catch (InvalidOperationException)
            {
                // The form can close between checking its handle and posting.
            }
        }

        public void Dispose()
        {
            if (disposed)
                return;

            disposed = true;
            try
            {
                device.SignalToStop();
                device.WaitForStop();
            }
            finally
            {
                device.NewFrameRequested -= FillBuffer;
                device.FramePlayingStarted -= FramePlayingStarted;
                device.AudioOutputError -= AudioOutputError;
                device.Dispose();
            }
        }
    }
}
