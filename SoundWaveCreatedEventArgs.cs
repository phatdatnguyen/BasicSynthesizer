namespace BasicSynthesizer
{
    public class SoundWaveCreatedEventArgs : EventArgs
    {
        #region Property
        public List<Oscillator>? Oscillators { get; set; }
        #endregion

        #region Constructor
        public SoundWaveCreatedEventArgs(List<Oscillator>? oscillators = null)
        {
            Oscillators = oscillators;
        }
        #endregion
    }
}
