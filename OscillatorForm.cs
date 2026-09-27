namespace BasicSynthesizer
{
    public partial class OscillatorForm : Form
    {
        #region Field
        private readonly Dictionary<string, decimal> notes = new() {
            { "C0", 16.35m },
            { "C#0/Db0", 17.32m },
            { "D0", 18.35m },
            { "D#0/Eb0", 19.45m },
            { "E0", 20.6m },
            { "F0", 21.83m },
            { "F#0/Gb0", 23.12m },
            { "G0", 24.5m },
            { "G#0/Ab0", 25.96m },
            { "A0", 27.5m },
            { "A#0/Bb0", 29.14m },
            { "B0", 30.87m },

            { "C1", 32.7m },
            { "C#1/Db1", 34.65m },
            { "D1", 36.71m },
            { "D#1/Eb1", 38.89m },
            { "E1", 41.2m },
            { "F1", 43.65m },
            { "F#1/Gb1", 46.25m },
            { "G1", 49m },
            { "G#1/Ab1", 51.91m },
            { "A1", 55m },
            { "A#1/Bb1", 58.27m },
            { "B1", 61.74m },

            { "C2", 65.41m },
            { "C#2/Db2", 69.3m },
            { "D2", 73.42m },
            { "D#2/Eb2", 77.78m },
            { "E2", 82.41m },
            { "F2", 87.31m },
            { "F#2/Gb2", 92.5m },
            { "G2", 98m },
            { "G#2/Ab2", 103.83m },
            { "A2", 110m },
            { "A#2/Bb2", 116.54m },
            { "B2", 123.47m },

            { "C3", 130.81m },
            { "C#3/Db3", 138.59m },
            { "D3", 146.83m },
            { "D#3/Eb3", 155.56m },
            { "E3", 164.81m },
            { "F3", 174.61m },
            { "F#3/Gb3", 185m },
            { "G3", 196m },
            { "G#3/Ab3", 207.65m },
            { "A3", 220m },
            { "A#3/Bb3", 233.08m },
            { "B3", 246.94m },

            { "C4", 261.63m },
            { "C#4/Db4", 277.18m },
            { "D4", 293.66m },
            { "D#4/Eb4", 311.13m },
            { "E4", 329.63m },
            { "F4", 349.23m },
            { "F#4/Gb4", 369.99m },
            { "G4", 392m },
            { "G#4/Ab4", 415.3m },
            { "A4", 440m },
            { "A#4/Bb4", 466.16m },
            { "B4", 493.88m },

            { "C5", 523.25m },
            { "C#5/Db5", 554.37m },
            { "D5", 587.33m },
            { "D#5/Eb5", 622.25m },
            { "E5", 659.25m },
            { "F5", 698.46m },
            { "F#5/Gb5", 739.99m },
            { "G5", 783.99m },
            { "G#5/Ab5", 830.61m },
            { "A5", 880m },
            { "A#5/Bb5", 932.33m },
            { "B5", 987.77m },

            { "C6", 1046.5m },
            { "C#6/Db6", 1108.73m },
            { "D6", 1174.66m },
            { "D#6/Eb6", 1244.51m },
            { "E6", 1318.51m },
            { "F6", 1396.91m },
            { "F#6/Gb6", 1479.98m },
            { "G6", 1567.98m },
            { "G#6/Ab6", 1661.22m },
            { "A6", 1760m },
            { "A#6/Bb6", 1864.66m },
            { "B6", 1975.53m },

            { "C7", 2093m },
            { "C#7/Db7", 2217.46m },
            { "D7", 2349.32m },
            { "D#7/Eb7", 2489.02m },
            { "E7", 2637.02m },
            { "F7", 2793.83m },
            { "F#7/Gb7", 2959.96m },
            { "G7", 3135.96m },
            { "G#7/Ab7", 3322.44m },
            { "A7", 3520m },
            { "A#7/Bb7", 3729.31m },
            { "B7", 3951.07m }
        };
        private bool updatingNoteSelection;
        #endregion

        #region Property
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Oscillator Oscillator { get; set; }
        #endregion

        #region Constructors
        public OscillatorForm()
            : this(new Oscillator(Oscillator.OscillatorWaveform.Sine, 261.63, 1, 0, 1))
        {
        }

        public OscillatorForm(Oscillator oscillator)
        {
            ArgumentNullException.ThrowIfNull(oscillator);
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
            UpdateSelectedNote();
            frequencyNumericUpDown.ValueChanged += frequencyNumericUpDown_ValueChanged;
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
            if (updatingNoteSelection || notesComboBox.SelectedItem is not string noteName)
                return;

            if (notes.TryGetValue(noteName, out decimal frequency))
                frequencyNumericUpDown.Value = frequency;
        }

        private void frequencyNumericUpDown_ValueChanged(object? sender, EventArgs e)
        {
            UpdateSelectedNote();
        }

        private void UpdateSelectedNote()
        {
            // Match the displayed precision, without single-precision rounding errors.
            decimal frequency = Math.Round(frequencyNumericUpDown.Value, frequencyNumericUpDown.DecimalPlaces);
            int selectedIndex = 0;
            int noteIndex = 1;
            foreach (decimal noteFrequency in notes.Values)
            {
                if (noteFrequency == frequency)
                {
                    selectedIndex = noteIndex;
                    break;
                }
                noteIndex++;
            }

            updatingNoteSelection = true;
            try
            {
                notesComboBox.SelectedIndex = selectedIndex;
            }
            finally
            {
                updatingNoteSelection = false;
            }
        }
        #endregion
    }
}
