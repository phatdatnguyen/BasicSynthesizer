using Accord.Audio;
using Accord.DirectSound;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;

namespace BasicSynthesizer
{
    public partial class MainForm : Form
    {
        #region Fields
        private int samplingRate = 44100;
        private double duration = 1f;
        private bool hasWaveData = false;
        private bool workingWithOscillators = false;
        private bool workingWithAudio = false;
        private byte bitDepth = 16;
        private List<Oscillator>? oscillators;
        private List<(double, double)>? timeDomainData;
        private List<(double, double)>? modifiedTimeDomainData;
        private List<(double, double[])>? frequencyDomainData;
        private List<(double, double[])>? modifiedFrequencyDomainData;
        private Filter? filter;
        private LowFrequencyOscillator? lfo;
        private Envelope? envelope;
        #endregion

        #region Events
        public delegate void SoundWaveClearedEventHandler(object sender, EventArgs e);
        public event SoundWaveClearedEventHandler? SoundWaveCleared;
        protected void OnSoundWaveCleared(object sender, EventArgs e)
        {
            hasWaveData = false;
            workingWithOscillators = false;
            workingWithAudio = false;
            bitDepth = 16;
            oscillators = null;
            timeDomainData = null;
            frequencyDomainData = null;
            filter = null;
            lfo = null;
            envelope = null;

            ResetControls();
        }

        public delegate void SoundWaveCreatedEventHandler(object sender, SoundWaveCreatedEventArgs e);
        public event SoundWaveCreatedEventHandler? SoundWaveCreated;
        protected void OnSoundWaveCreated(object sender, SoundWaveCreatedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            hasWaveData = true;

            if (workingWithOscillators)
            {
                oscillators = e.Oscillators;
                if (oscillators != null)
                    timeDomainData = Oscillator.MixOscillators(oscillators, samplingRate, duration);
            }

            if (workingWithAudio)
            {
                oscillatorsGroupBox.Enabled = false;
                samplingRateComboBox.Enabled = false;
                durationNumericUpDown.Enabled = false;
            }

            UpdateControls();

            if (timeDomainData != null)
                frequencyDomainData = Utils.FastFourierTransform(timeDomainData, samplingRate);

            if (filter != null || lfo != null || envelope != null)
            {
                SoundWaveModified?.Invoke(this, EventArgs.Empty);
                Cursor = Cursors.Default;
                return;
            }

            if (timeDomainData != null)
                UpdateTimeDomainChart(timeDomainData);
            if (frequencyDomainData != null)
                UpdateFrequencyDomainChart(frequencyDomainData);

            Cursor = Cursors.Default;
        }

        public delegate void SoundWaveModifiedEventHandler(object sender, EventArgs e);
        public event SoundWaveModifiedEventHandler? SoundWaveModified;
        protected void OnSoundWaveModified(object sender, EventArgs e)
        {
            if (timeDomainData == null)
                return;

            Cursor = Cursors.WaitCursor;

            modifiedTimeDomainData = timeDomainData;

            if (filter != null)
                modifiedTimeDomainData = filter.Apply(modifiedTimeDomainData, samplingRate);
            if (lfo != null)
                modifiedTimeDomainData = lfo.Apply(modifiedTimeDomainData, samplingRate, duration);
            if (envelope != null)
                modifiedTimeDomainData = envelope.Apply(modifiedTimeDomainData, samplingRate, duration);

            UpdateTimeDomainChart(modifiedTimeDomainData);

            modifiedFrequencyDomainData = Utils.FastFourierTransform(modifiedTimeDomainData, samplingRate);
            UpdateFrequencyDomainChart(modifiedFrequencyDomainData);

            Cursor = Cursors.Default;
        }
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            SoundWaveCleared += OnSoundWaveCleared;
            SoundWaveCreated += OnSoundWaveCreated;
            SoundWaveModified += OnSoundWaveModified;
        }
        #endregion

        #region Methods
        private void ResetControls()
        {
            oscillatorsGroupBox.Enabled = true;
            oscillatorsListView.Items.Clear();
            samplingRateComboBox.Enabled = true;
            samplingRateComboBox.SelectedIndex = 1;
            durationNumericUpDown.Enabled = true;
            durationNumericUpDown.Maximum = 2;
            durationNumericUpDown.Value = 1;
            playButton.Enabled = false;
            deleteAudioButton.Enabled = false;
            audioInfoLabel.Text = "";
            timeDomainPlotView.Model = null;
            timeDomainPlotView.Enabled = false;
            frequencyDomainPlotView.Model = null;
            frequencyDomainPlotView.Enabled = false;
            filterGroupBox.Enabled = false;
            filterApplyCheckBox.Checked = false;
            lfoGroupBox.Enabled = false;
            lfoApplyCheckBox.Checked = false;
            adsrGroupBox.Enabled = false;
            adsrApplyCheckBox.Checked = false;
        }

        private void UpdateControls()
        {
            playButton.Enabled = true;
            deleteAudioButton.Enabled = true;
            timeDomainPlotView.Enabled = true;
            frequencyDomainPlotView.Enabled = true;
            plotComboBox.Enabled = true;
            filterGroupBox.Enabled = true;
            lfoGroupBox.Enabled = true;
            adsrGroupBox.Enabled = true;
        }

        private void UpdateTimeDomainChart(List<(double, double)> timeDomainDataPoints)
        {
            PlotModel plotModel = new();

            LineSeries lineSeries = new()
            {
                Title = "Wave"
            };

            for (int rowIndex = 0; rowIndex < timeDomainDataPoints.Count; rowIndex++)
            {
                double x = timeDomainDataPoints[rowIndex].Item1;
                double y = timeDomainDataPoints[rowIndex].Item2;

                lineSeries.Points.Add(new DataPoint(x, y));
            }

            LinearAxis xAxis = new()
            {
                Position = AxisPosition.Bottom,
                Title = "Time (s)",
                MajorGridlineThickness = 1,
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = OxyColors.LightGray
            };
            LinearAxis yAxis = new()
            {
                Position = AxisPosition.Left,
                Title = "Intensity",
                MajorGridlineThickness = 1,
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = OxyColors.LightGray,
                IsPanEnabled = false,
                IsZoomEnabled = false
            };

            plotModel.Series.Add(lineSeries);

            if (lfoApplyCheckBox.Checked && lfo != null)
            {
                double interval = 1f / samplingRate; // s
                double[] lfoDataPoints = lfo.GenerateWaveDataPoints(samplingRate, duration);

                LineSeries lfoLineSeries = new()
                {
                    Title = "LFO"
                };
                for (int i = 0; i < lfoDataPoints.Length; i++)
                    lfoLineSeries.Points.Add(new DataPoint(i * interval, lfoDataPoints[i]));

                plotModel.Series.Add(lfoLineSeries);
            }

            if (adsrApplyCheckBox.Checked && envelope != null)
            {
                LineSeries adsrLineSeries = new()
                {
                    Title = "ADSR"
                };
                adsrLineSeries.Points.Add(new DataPoint(0, 0));
                adsrLineSeries.Points.Add(new DataPoint(envelope.Attack, 1));
                adsrLineSeries.Points.Add(new DataPoint(envelope.Attack + envelope.Decay, envelope.Sustain / 100));
                adsrLineSeries.Points.Add(new DataPoint(duration - envelope.Release, envelope.Sustain / 100));
                adsrLineSeries.Points.Add(new DataPoint(duration, 0));

                plotModel.Series.Add(adsrLineSeries);
            }

            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);
            plotModel.Legends.Add(new Legend() { LegendPlacement = LegendPlacement.Outside });

            timeDomainPlotView.Model = plotModel;
        }

        private void UpdateFrequencyDomainChart(List<(double, double[])> frequencyDomainData)
        {
            PlotModel plotModel = new();

            LineSeries lineSeries = new();

            switch (plotComboBox.SelectedIndex)
            {
                case 0: // magnitude
                    lineSeries.Title = "Magnitude";
                    for (int rowIndex = 0; rowIndex < frequencyDomainData.Count; rowIndex++)
                    {
                        double x = frequencyDomainData[rowIndex].Item1;
                        double y = frequencyDomainData[rowIndex].Item2[0];

                        lineSeries.Points.Add(new DataPoint(x, y));
                    }
                    break;
                case 1: // real
                    lineSeries.Title = "Real";
                    for (int rowIndex = 0; rowIndex < frequencyDomainData.Count; rowIndex++)
                    {
                        double x = frequencyDomainData[rowIndex].Item1;
                        double y = frequencyDomainData[rowIndex].Item2[1];

                        lineSeries.Points.Add(new DataPoint(x, y));
                    }
                    break;
                case 2: // imaginary
                    lineSeries.Title = "Imaginary";
                    for (int rowIndex = 0; rowIndex < frequencyDomainData.Count; rowIndex++)
                    {
                        double x = frequencyDomainData[rowIndex].Item1;
                        double y = frequencyDomainData[rowIndex].Item2[2];

                        lineSeries.Points.Add(new DataPoint(x, y));
                    }
                    break;
            }

            LinearAxis xAxis = new()
            {
                Position = AxisPosition.Bottom,
                Title = "Frequency (Hz)",
                MajorGridlineThickness = 1,
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = OxyColors.LightGray
            };
            LinearAxis yAxis = new()
            {
                Position = AxisPosition.Left,
                Title = "Intensity",
                MajorGridlineThickness = 1,
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = OxyColors.LightGray,
                IsPanEnabled = false,
                IsZoomEnabled = false
            };

            plotModel.Series.Add(lineSeries);

            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);
            plotModel.Legends.Add(new Legend() { LegendPlacement = LegendPlacement.Outside });

            frequencyDomainPlotView.Model = plotModel;
        }

        // Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playButton_Click(playButton, EventArgs.Empty);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timeDomainData == null)
                return;

            try
            {
                double[] waveDataPoints = new double[timeDomainData.Count];
                for (int i = 0; i < waveDataPoints.Length; i++)
                    waveDataPoints[i] = timeDomainData[i].Item2;

                if (filter != null)
                    waveDataPoints = filter.Apply(waveDataPoints, samplingRate);

                if (envelope != null)
                    waveDataPoints = envelope.Apply(waveDataPoints, samplingRate, duration);

                if (lfo != null)
                    waveDataPoints = lfo.Apply(waveDataPoints, samplingRate, duration);

                Signal signal = Utils.GenerateWaveSignal(waveDataPoints, samplingRate, duration, bitDepth);

                if (saveAudioFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Utils.ExportWavFile(signal, saveAudioFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hasWaveData)
            {
                if (MessageBox.Show(this, "You are working with some data, loading audio file will override your works. Do you want to continue?", "Import audio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            Signal signal;

            if (openAudioFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    signal = Utils.LoadWavFile(openAudioFileDialog.FileName);

                    if (signal.SampleRate != 22050 && signal.SampleRate != 44100 && signal.SampleRate != 88200)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Cannot load the selected file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;

            SoundWaveCleared?.Invoke(this, EventArgs.Empty);

            switch (signal.SampleRate)
            {
                case 22050:
                    samplingRateComboBox.SelectedIndex = 0;
                    break;
                case 44100:
                    samplingRateComboBox.SelectedIndex = 1;
                    break;
                case 88200:
                    samplingRateComboBox.SelectedIndex = 2;
                    break;
                default:
                    break;
            }

            string wavFileChannel = "Mono";
            if (signal.NumberOfChannels == 2) //mono
            //stereo
            {
                ChooseChannelDialog chooseChannelDialog = new();
                if (chooseChannelDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (chooseChannelDialog.ChannelName == "Left")
                        wavFileChannel = "Left";
                    else
                        wavFileChannel = "Right";
                }
                else
                    return;
            }
            timeDomainData = Utils.GenerateWaveData(signal, wavFileChannel);

            string format = "bit depth: ";
            switch (signal.SampleFormat)
            {
                case SampleFormat.Format8Bit:
                    bitDepth = 8;
                    format += "8 bit";
                    break;
                case SampleFormat.Format16Bit:
                    bitDepth = 16;
                    format += "16 bit";
                    break;
                case SampleFormat.Format32Bit:
                    bitDepth = 32;
                    format += "32 bit";
                    break;
                default:
                    break;
            }

            workingWithAudio = true;

            durationNumericUpDown.Maximum = (decimal)signal.Duration.TotalSeconds;
            durationNumericUpDown.Value = (decimal)signal.Duration.TotalSeconds;
            audioInfoLabel.Text = openAudioFileDialog.SafeFileName + "\n" + format;

            SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new();
            aboutBox.ShowDialog(this);
        }

        // Event handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            samplingRateComboBox.SelectedIndex = 1;
            plotComboBox.SelectedIndex = 0;
            waveformComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OscillatorForm oscillatorForm = new();
            if (oscillatorForm.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem listViewItem = new(new String[] { oscillatorForm.Oscillator.Waveform.ToString(), oscillatorForm.Oscillator.Frequency.ToString(), oscillatorForm.Oscillator.Amplitude.ToString(), oscillatorForm.Oscillator.Phase.ToString(), oscillatorForm.Oscillator.Ratio.ToString() });
                listViewItem.Tag = oscillatorForm.Oscillator;
                oscillatorsListView.Items.Add(listViewItem);
                listViewItem.Selected = true;

                List<Oscillator> oscillators = new();
                foreach (ListViewItem item in oscillatorsListView.Items)
                    oscillators.Add((Oscillator)item.Tag);

                workingWithOscillators = true;
                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs(oscillators));
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (oscillatorsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = oscillatorsListView.SelectedItems[0];
            OscillatorForm oscillatorForm = new((Oscillator)selectedItem.Tag);
            if (oscillatorForm.ShowDialog(this) == DialogResult.OK)
            {
                selectedItem.SubItems[0].Text = oscillatorForm.Oscillator.Waveform.ToString();
                selectedItem.SubItems[1].Text = oscillatorForm.Oscillator.Frequency.ToString();
                selectedItem.SubItems[2].Text = oscillatorForm.Oscillator.Amplitude.ToString();
                selectedItem.SubItems[3].Text = oscillatorForm.Oscillator.Phase.ToString();
                selectedItem.SubItems[4].Text = oscillatorForm.Oscillator.Ratio.ToString();
                selectedItem.Tag = oscillatorForm.Oscillator;

                List<Oscillator> oscillators = new();
                foreach (ListViewItem item in oscillatorsListView.Items)
                    oscillators.Add((Oscillator)item.Tag);

                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs(oscillators));
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (oscillatorsListView.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem selectedItem in oscillatorsListView.SelectedItems)
                selectedItem.Remove();

            if (oscillatorsListView.Items.Count == 0)
                SoundWaveCleared?.Invoke(this, EventArgs.Empty);
            else
            {
                List<Oscillator> oscillators = new();
                foreach (ListViewItem item in oscillatorsListView.Items)
                    oscillators.Add((Oscillator)item.Tag);

                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs(oscillators));
            }
        }

        private void oscillatorsListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteButton_Click(deleteButton, EventArgs.Empty);
        }

        private void oscillatorsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editButton_Click(editButton, EventArgs.Empty);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (Program.mainForm == null || timeDomainData == null)
                return;

            try
            {
                AudioOutputDevice audioOutputDevice = new(Program.mainForm.Handle, samplingRate, 1);

                double[] waveDataPoints = new double[timeDomainData.Count];
                for (int i = 0; i < waveDataPoints.Length; i++)
                    waveDataPoints[i] = timeDomainData[i].Item2;

                if (filter != null)
                    waveDataPoints = filter.Apply(waveDataPoints, samplingRate);

                if (envelope != null)
                    waveDataPoints = envelope.Apply(waveDataPoints, samplingRate, duration);

                if (lfo != null)
                    waveDataPoints = lfo.Apply(waveDataPoints, samplingRate, duration);

                Signal signal = Utils.GenerateWaveSignal(waveDataPoints, samplingRate, duration, bitDepth);
                audioOutputDevice.Play(signal.ToFloat());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cannot play sound!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteAudioButton_Click(object sender, EventArgs e)
        {
            SoundWaveCleared?.Invoke(this, EventArgs.Empty);
        }

        private void samplingRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            samplingRate = Convert.ToInt32(samplingRateComboBox.SelectedItem);

            if (hasWaveData && workingWithOscillators)
                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs(oscillators));
        }

        private void durationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            duration = (double)durationNumericUpDown.Value;

            attackValueLabel.Text = Math.Round(attackTrackBar.Value / 100f * duration, 3).ToString() + " s";
            decayValueLabel.Text = Math.Round(decayTrackBar.Value / 100f * duration, 3).ToString() + " s";
            releaseValueLabel.Text = Math.Round(releaseTrackBar.Value / 100f * duration, 3).ToString() + " s";

            if (adsrApplyCheckBox.Checked && hasWaveData)
            {
                double attack = attackTrackBar.Value / 100f * duration;
                double decay = decayTrackBar.Value / 100f * duration;
                double sustain = sustainTrackBar.Value;
                double release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);
            }
            else
                envelope = null;

            if (hasWaveData && workingWithOscillators)
                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs(oscillators));
        }

        private void plotComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plotComboBox.SelectedIndex < 0 || !hasWaveData || frequencyDomainData == null)
                return;

            UpdateFrequencyDomainChart(frequencyDomainData);
        }

        private void filterApplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (filterApplyCheckBox.Checked)
            {
                double cutoffFrequency = filterFrequencyTrackBar.Value;
                double resonance = resonanceTrackBar.Value;

                if (lowPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.LowPass, cutoffFrequency, resonance);
                else if (highPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.HighPass, cutoffFrequency, resonance);
                else
                    filter = new Filter(Filter.FilterMode.BandPass, cutoffFrequency, resonance);
            }
            else
                filter = null;

            SoundWaveModified?.Invoke(this, EventArgs.Empty);
        }

        private void filterModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (filterApplyCheckBox.Checked)
            {
                double cutoffFrequency = filterFrequencyTrackBar.Value;
                double resonance = resonanceTrackBar.Value;

                if (lowPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.LowPass, cutoffFrequency, resonance);
                else if (highPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.HighPass, cutoffFrequency, resonance);
                else
                    filter = new Filter(Filter.FilterMode.BandPass, cutoffFrequency, resonance);

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void filterFrequencyTrackBar_Scroll(object sender, EventArgs e)
        {
            filterFrequencyValueLabel.Text = filterFrequencyTrackBar.Value.ToString() + " Hz";

            if (!hasWaveData)
                return;

            if (filterApplyCheckBox.Checked)
            {
                double cutoffFrequency = filterFrequencyTrackBar.Value;
                double resonance = resonanceTrackBar.Value;

                if (lowPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.LowPass, cutoffFrequency, resonance);
                else if (highPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.HighPass, cutoffFrequency, resonance);
                else
                    filter = new Filter(Filter.FilterMode.BandPass, cutoffFrequency, resonance);

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void resonanceTrackBar_Scroll(object sender, EventArgs e)
        {
            resonanceValueLabel.Text = resonanceTrackBar.Value.ToString() + "%";

            if (!hasWaveData)
                return;

            if (filterApplyCheckBox.Checked)
            {
                double cutoffFrequency = filterFrequencyTrackBar.Value;
                double resonance = resonanceTrackBar.Value;

                if (lowPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.LowPass, cutoffFrequency, resonance);
                else if (highPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.HighPass, cutoffFrequency, resonance);
                else
                    filter = new Filter(Filter.FilterMode.BandPass, cutoffFrequency, resonance);

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void lfoApplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                double frequency = lfoFrequencyTrackBar.Value;
                double amplitude = amplitudeTrackBar.Value / 100f;
                double phase = phaseTrackBar.Value;

                switch (waveformComboBox.SelectedIndex)
                {
                    case 0:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sine, frequency, amplitude, phase);
                        break;
                    case 1:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Square, frequency, amplitude, phase);
                        break;
                    case 2:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Triangle, frequency, amplitude, phase);
                        break;
                    case 3:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sawtooth, frequency, amplitude, phase);
                        break;
                    default:
                        break;
                }
            }
            else
                lfo = null;

            SoundWaveModified?.Invoke(this, EventArgs.Empty);
        }

        private void waveformComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                double frequency = lfoFrequencyTrackBar.Value;
                double amplitude = amplitudeTrackBar.Value / 100f;
                double phase = phaseTrackBar.Value;

                switch (waveformComboBox.SelectedIndex)
                {
                    case 0:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sine, frequency, amplitude, phase);
                        break;
                    case 1:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Square, frequency, amplitude, phase);
                        break;
                    case 2:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Triangle, frequency, amplitude, phase);
                        break;
                    case 3:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sawtooth, frequency, amplitude, phase);
                        break;
                    default:
                        break;
                }

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void lfoFrequencyTrackBar_Scroll(object sender, EventArgs e)
        {
            lfoFrequencyValueLabel.Text = lfoFrequencyTrackBar.Value.ToString() + " Hz";

            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                double frequency = lfoFrequencyTrackBar.Value;
                double amplitude = amplitudeTrackBar.Value / 100f;
                double phase = phaseTrackBar.Value;

                switch (waveformComboBox.SelectedIndex)
                {
                    case 0:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sine, frequency, amplitude, phase);
                        break;
                    case 1:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Square, frequency, amplitude, phase);
                        break;
                    case 2:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Triangle, frequency, amplitude, phase);
                        break;
                    case 3:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sawtooth, frequency, amplitude, phase);
                        break;
                    default:
                        break;
                }

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void amplitudeTrackBar_Scroll(object sender, EventArgs e)
        {
            amplitudeValueLabel.Text = (amplitudeTrackBar.Value / 100f).ToString();

            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                double frequency = lfoFrequencyTrackBar.Value;
                double amplitude = amplitudeTrackBar.Value / 100f;
                double phase = phaseTrackBar.Value;

                switch (waveformComboBox.SelectedIndex)
                {
                    case 0:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sine, frequency, amplitude, phase);
                        break;
                    case 1:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Square, frequency, amplitude, phase);
                        break;
                    case 2:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Triangle, frequency, amplitude, phase);
                        break;
                    case 3:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sawtooth, frequency, amplitude, phase);
                        break;
                    default:
                        break;
                }

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void phaseTrackBar_Scroll(object sender, EventArgs e)
        {
            phaseValueLabel.Text = (phaseTrackBar.Value).ToString() + "°";

            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                double frequency = lfoFrequencyTrackBar.Value;
                double amplitude = amplitudeTrackBar.Value / 100f;
                double phase = phaseTrackBar.Value;

                switch (waveformComboBox.SelectedIndex)
                {
                    case 0:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sine, frequency, amplitude, phase);
                        break;
                    case 1:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Square, frequency, amplitude, phase);
                        break;
                    case 2:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Triangle, frequency, amplitude, phase);
                        break;
                    case 3:
                        lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sawtooth, frequency, amplitude, phase);
                        break;
                    default:
                        break;
                }

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void adsrApplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                double attack = attackTrackBar.Value / 100f * duration;
                double decay = decayTrackBar.Value / 100f * duration;
                double sustain = sustainTrackBar.Value;
                double release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);
            }
            else
                envelope = null;

            SoundWaveModified?.Invoke(this, EventArgs.Empty);
        }

        private void attackTrackBar_Scroll(object sender, EventArgs e)
        {
            attackValueLabel.Text = Math.Round(attackTrackBar.Value / 100f * duration, 3).ToString() + " s";

            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                double attack = attackTrackBar.Value / 100f * duration;
                double decay = decayTrackBar.Value / 100f * duration;
                double sustain = sustainTrackBar.Value;
                double release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void decayTrackBar_Scroll(object sender, EventArgs e)
        {
            decayValueLabel.Text = Math.Round(decayTrackBar.Value / 100f * duration, 3).ToString() + " s";

            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                double attack = attackTrackBar.Value / 100f * duration;
                double decay = decayTrackBar.Value / 100f * duration;
                double sustain = sustainTrackBar.Value;
                double release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void sustainTrackBar_Scroll(object sender, EventArgs e)
        {
            sustainValueLabel.Text = sustainTrackBar.Value.ToString() + "%";

            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                double attack = attackTrackBar.Value / 100f * duration;
                double decay = decayTrackBar.Value / 100f * duration;
                double sustain = sustainTrackBar.Value;
                double release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }

        private void releaseTrackBar_Scroll(object sender, EventArgs e)
        {
            releaseValueLabel.Text = Math.Round(releaseTrackBar.Value / 100f * duration, 3).ToString() + " s";

            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                double attack = attackTrackBar.Value / 100f * duration;
                double decay = decayTrackBar.Value / 100f * duration;
                double sustain = sustainTrackBar.Value;
                double release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}
