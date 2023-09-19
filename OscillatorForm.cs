namespace BasicSynthesizer
{
    public partial class OscillatorForm : Form
    {
        #region Field
        private readonly Dictionary<string, double> notes = new() {
            { "C0", 16.35f },
            { "C#0/Db0", 17.32f },
            { "D0", 18.35f },
            { "D#0/Eb0", 19.45f },
            { "E0", 20.6f },
            { "F0", 21.83f },
            { "F#0/Gb0", 23.12f },
            { "G0", 24.5f },
            { "G#0/Ab0", 25.96f },
            { "A0", 27.5f },
            { "A#0/Bb0", 29.14f },
            { "B0", 30.87f },

            { "C1", 32.7f },
            { "C#1/Db1", 34.65f },
            { "D1", 36.71f },
            { "D#1/Eb1", 38.89f },
            { "E1", 41.2f },
            { "F1", 43.65f },
            { "F#1/Gb1", 46.25f },
            { "G1", 49f },
            { "G#1/Ab1", 51.91f },
            { "A1", 55f },
            { "A#1/Bb1", 58.27f },
            { "B1", 61.74f },

            { "C2", 65.41f },
            { "C#2/Db2", 69.3f },
            { "D2", 73.42f },
            { "D#2/Eb2", 77.78f },
            { "E2", 82.41f },
            { "F2", 87.31f },
            { "F#2/Gb2", 92.5f },
            { "G2", 98f },
            { "G#2/Ab2", 103.83f },
            { "A2", 110f },
            { "A#2/Bb2", 116.54f },
            { "B2", 123.47f },

            { "C3", 130.81f },
            { "C#3/Db3", 138.59f },
            { "D3", 146.83f },
            { "D#3/Eb3", 155.56f },
            { "E3", 164.81f },
            { "F3", 174.61f },
            { "F#3/Gb3", 185f },
            { "G3", 196f },
            { "G#3/Ab3", 207.65f },
            { "A3", 220f },
            { "A#3/Bb3", 233.08f },
            { "B3", 246.94f },

            { "C4", 261.63f },
            { "C#4/Db4", 277.18f },
            { "D4", 293.66f },
            { "D#4/Eb4", 311.13f },
            { "E4", 329.63f },
            { "F4", 349.23f },
            { "F#4/Gb4", 369.99f },
            { "G4", 392f },
            { "G#4/Ab4", 415.3f },
            { "A4", 440f },
            { "A#4/Bb4", 466.16f },
            { "B4", 493.88f },

            { "C5", 523.25f },
            { "C#5/Db5", 554.37f },
            { "D5", 587.33f },
            { "D#5/Eb5", 622.25f },
            { "E5", 659.25f },
            { "F5", 698.46f },
            { "F#5/Gb5", 739.99f },
            { "G5", 783.99f },
            { "G#5/Ab5", 830.61f },
            { "A5", 880f },
            { "A#5/Bb5", 932.33f },
            { "B5", 987.77f },

            { "C6", 1046.5f },
            { "C#6/Db6", 1108.73f },
            { "D6", 1174.66f },
            { "D#6/Eb6", 1244.51f },
            { "E6", 1318.51f },
            { "F6", 1396.91f },
            { "F#6/Gb6", 1479.98f },
            { "G6", 1567.98f },
            { "G#6/Ab6", 1661.22f },
            { "A6", 1760f },
            { "A#6/Bb6", 1864.66f },
            { "B6", 1975.53f },

            { "C7", 2093f },
            { "C#7/D7", 2217.46f },
            { "D7", 2349.32f },
            { "D#7/Eb7", 2489.02f },
            { "E7", 2637.02f },
            { "F7", 2793.83f },
            { "F#7/Gb7", 2959.96f },
            { "G7", 3135.96f },
            { "G#7/Ab7", 3322.44f },
            { "A7", 3520f },
            { "A#7/Bb7", 3729.31f },
            { "B7", 3951.07f }
        };
        #endregion

        #region Property
        public Oscillator Oscillator { get; set; }
        #endregion

        #region Constructors
        public OscillatorForm()
        {
            InitializeComponent();

            waveformComboBox.SelectedIndex = 0;
            notesComboBox.Items.Clear();
            notesComboBox.Items.Add("(none)");
            foreach (string noteName in notes.Keys)
                notesComboBox.Items.Add(noteName);
            notesComboBox.SelectedIndex = 49;
            Oscillator = new Oscillator(Oscillator.OscillatorWaveform.Sine, 16, 1, 0, 1);
        }

        public OscillatorForm(Oscillator oscillator)
        {
            InitializeComponent();

            Oscillator = oscillator;
            switch (Oscillator.Waveform)
            {
                case Oscillator.OscillatorWaveform.Sine: waveformComboBox.SelectedIndex = 0; break;
                case Oscillator.OscillatorWaveform.Square: waveformComboBox.SelectedIndex = 1; break;
                case Oscillator.OscillatorWaveform.Triangle: waveformComboBox.SelectedIndex = 2; break;
                case Oscillator.OscillatorWaveform.Sawtooth: waveformComboBox.SelectedIndex = 3; break;
                default: break;
            }
            frequencyNumericUpDown.Value = (decimal)Oscillator.Frequency;
            amplitudeNumericUpDown.Value = (decimal)Oscillator.Amplitude;
            phaseNumericUpDown.Value = (decimal)Oscillator.Phase;
            ratioNumericUpDown.Value = (decimal)Oscillator.Ratio;
            notesComboBox.Items.Clear();
            notesComboBox.Items.Add("(none)");
            foreach (string noteName in notes.Keys)
            {
                notesComboBox.Items.Add(noteName);
            }
            foreach (double noteFrequency in notes.Values)
            {
                if (noteFrequency == (double)frequencyNumericUpDown.Value)
                {
                    notesComboBox.SelectedIndex = notes.Values.ToList().IndexOf(noteFrequency) + 1;
                    return;
                }
            }
            notesComboBox.SelectedIndex = 0;
        }
        #endregion

        #region Methods
        private void OscillatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                switch (waveformComboBox.SelectedIndex)
                {
                    case 0: Oscillator.Waveform = Oscillator.OscillatorWaveform.Sine; break;
                    case 1: Oscillator.Waveform = Oscillator.OscillatorWaveform.Square; break;
                    case 2: Oscillator.Waveform = Oscillator.OscillatorWaveform.Triangle; break;
                    case 3: Oscillator.Waveform = Oscillator.OscillatorWaveform.Sawtooth; break;
                    default: break;
                }
                Oscillator.Frequency = (double)Math.Round(frequencyNumericUpDown.Value, 2);
                Oscillator.Amplitude = (double)Math.Round(amplitudeNumericUpDown.Value, 2);
                Oscillator.Phase = (double)Math.Round(phaseNumericUpDown.Value, 2);
                Oscillator.Ratio = (double)Math.Round(ratioNumericUpDown.Value, 2);
            }
        }

        private void noteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (notesComboBox.SelectedIndex <= 1)
                return;

            foreach (KeyValuePair<string, double> note in notes)
            {
                if (note.Key == notesComboBox.SelectedItem.ToString() && frequencyNumericUpDown.Value != (decimal)note.Value)
                {
                    frequencyNumericUpDown.Value = (decimal)note.Value;
                    return;
                }
            }
        }
        #endregion
    }
}
