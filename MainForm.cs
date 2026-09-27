using Accord.Audio;
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
        private Filter? filter;
        private LowFrequencyOscillator? lfo;
        private Envelope? envelope;
        private AudioPlayback? audioPlayback;
        private List<(double, double)>? CurrentWaveData => modifiedTimeDomainData;
        #endregion

        #region Events
        public delegate void SoundWaveClearedEventHandler(object sender, EventArgs e);
        public event SoundWaveClearedEventHandler? SoundWaveCleared;
        protected void OnSoundWaveCleared(object sender, EventArgs e)
        {
            StopPlayback();
            hasWaveData = false;
            workingWithOscillators = false;
            workingWithAudio = false;
            bitDepth = 16;
            oscillators = null;
            timeDomainData = null;
            modifiedTimeDomainData = null;
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
            try
            {
                if (workingWithOscillators)
                {
                    oscillators = e.Oscillators;
                    timeDomainData = oscillators == null ? null : Oscillator.MixOscillators(oscillators, samplingRate, duration);
                }

                if (timeDomainData == null || timeDomainData.Count == 0)
                {
                    SoundWaveCleared?.Invoke(this, EventArgs.Empty);
                    return;
                }

                hasWaveData = true;
                modifiedTimeDomainData = null;
                if (workingWithAudio)
                {
                    oscillatorsGroupBox.Enabled = false;
                    samplingRateComboBox.Enabled = false;
                    durationNumericUpDown.Enabled = false;
                }

                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Cannot create sound", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public delegate void SoundWaveModifiedEventHandler(object sender, EventArgs e);
        public event SoundWaveModifiedEventHandler? SoundWaveModified;
        protected void OnSoundWaveModified(object sender, EventArgs e)
        {
            if (timeDomainData == null)
                return;

            Cursor = Cursors.WaitCursor;
            try
            {
                List<(double, double)> processed = timeDomainData;
                if (filter != null)
                    processed = filter.Apply(processed, samplingRate);
                if (lfo != null)
                    processed = lfo.Apply(processed, samplingRate, duration);
                if (envelope != null)
                    processed = envelope.Apply(processed, samplingRate, duration);

                // Use the same final samples for the plots, playback and export.
                processed = processed.Select(point => (point.Item1, Math.Clamp(point.Item2, -1.0, 1.0))).ToList();
                var spectrum = Utils.FastFourierTransform(processed, samplingRate);
                StopPlayback();
                modifiedTimeDomainData = processed;
                frequencyDomainData = spectrum;
                UpdateTimeDomainChart(processed);
                UpdateFrequencyDomainChart(spectrum);
                UpdateControls();
            }
            catch (Exception ex)
            {
                StopPlayback();
                modifiedTimeDomainData = null;
                frequencyDomainData = null;
                timeDomainPlotView.Model = null;
                frequencyDomainPlotView.Model = null;
                playButton.Enabled = false;
                playToolStripMenuItem.Enabled = false;
                exportToolStripMenuItem.Enabled = false;
                MessageBox.Show(this, ex.Message, "Cannot process sound", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            SoundWaveCleared += OnSoundWaveCleared;
            SoundWaveCreated += OnSoundWaveCreated;
            SoundWaveModified += OnSoundWaveModified;
            ResetControls();
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
            durationNumericUpDown.Minimum = 0.01m;
            durationNumericUpDown.Maximum = 2;
            durationNumericUpDown.Value = 1;
            playButton.Enabled = false;
            playToolStripMenuItem.Enabled = false;
            exportToolStripMenuItem.Enabled = false;
            deleteAudioButton.Enabled = false;
            audioInfoLabel.Text = "";
            timeDomainPlotView.Model = null;
            timeDomainPlotView.Enabled = false;
            frequencyDomainPlotView.Model = null;
            frequencyDomainPlotView.Enabled = false;
            plotComboBox.Enabled = false;
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
            playToolStripMenuItem.Enabled = true;
            exportToolStripMenuItem.Enabled = true;
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
                double[] unity = new double[timeDomainDataPoints.Count];
                Array.Fill(unity, 1.0);
                double[] lfoDataPoints = lfo.Apply(unity, samplingRate, duration);

                LineSeries lfoLineSeries = new()
                {
                    Title = "LFO gain"
                };
                for (int i = 0; i < lfoDataPoints.Length; i++)
                    lfoLineSeries.Points.Add(new DataPoint(timeDomainDataPoints[i].Item1, lfoDataPoints[i]));

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
            if (CurrentWaveData == null || saveAudioFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                using Signal signal = Utils.GenerateWaveSignal(CurrentWaveData.Select(point => point.Item2).ToArray(), samplingRate, duration, bitDepth);
                Utils.ExportWavFile(signal, saveAudioFileDialog.FileName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hasWaveData)
            {
                if (MessageBox.Show(this, "Importing audio will replace the current sound. Do you want to continue?", "Import audio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            if (openAudioFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                using Signal signal = Utils.LoadWavFile(openAudioFileDialog.FileName);
                if (signal.NumberOfChannels is < 1 or > 2)
                    throw new NotSupportedException("Please choose a mono or stereo WAV file.");
                if (signal.NumberOfFrames == 0)
                    throw new InvalidDataException("The WAV file contains no audio samples.");

                string channel = "Mono";
                if (signal.NumberOfChannels == 2)
                {
                    using ChooseChannelDialog dialog = new();
                    if (dialog.ShowDialog(this) != DialogResult.OK)
                        return;
                    channel = dialog.ChannelName;
                }

                // Decode before replacing any existing sound; Cancel and malformed files preserve it.
                var importedData = Utils.GenerateWaveData(signal, channel);
                SoundWaveCleared?.Invoke(this, EventArgs.Empty);
                workingWithAudio = true;
                timeDomainData = importedData;
                string rate = signal.SampleRate.ToString();
                if (!samplingRateComboBox.Items.Contains(rate))
                    samplingRateComboBox.Items.Add(rate);
                samplingRateComboBox.SelectedItem = rate;
                bitDepth = signal.SampleFormat switch
                {
                    SampleFormat.Format8Bit or SampleFormat.Format8BitUnsigned => 8,
                    SampleFormat.Format16Bit => 16,
                    _ => 32
                };

                durationNumericUpDown.Minimum = 0;
                decimal importedDuration = (decimal)importedData.Count / signal.SampleRate;
                durationNumericUpDown.Maximum = importedDuration;
                durationNumericUpDown.Value = importedDuration;
                // Frame count is authoritative; Signal.Duration rounds to milliseconds.
                duration = (double)importedData.Count / signal.SampleRate;
                UpdateEnvelopeLabels();
                audioInfoLabel.Text = $"{openAudioFileDialog.SafeFileName}\n{signal.SampleRate} Hz, {bitDepth}-bit PCM export";

                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Cannot load the selected file: {ex.Message}", "Import audio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using AboutBox aboutBox = new();
            aboutBox.ShowDialog(this);
        }

        // Event handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            samplingRateComboBox.SelectedIndex = 1;
            plotComboBox.SelectedIndex = 0;
            waveformComboBox.SelectedIndex = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
                StopPlayback();
        }

        private void StopPlayback()
        {
            var playback = audioPlayback;
            audioPlayback = null;
            try
            {
                playback?.Dispose();
            }
            catch (Exception ex)
            {
                // A disconnected device must not prevent clearing or closing the form.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private bool TryApplyEnvelope()
        {
            double attack = attackTrackBar.Value / 100.0 * duration;
            double decay = decayTrackBar.Value / 100.0 * duration;
            double sustain = sustainTrackBar.Value;
            double release = releaseTrackBar.Value / 100.0 * duration;
            if (attackTrackBar.Value + decayTrackBar.Value + releaseTrackBar.Value > 100)
            {
                MessageBox.Show(this, "Attack, decay and release must total 100% or less of the sound duration.", "Invalid envelope", MessageBoxButtons.OK, MessageBoxIcon.Error);
                adsrApplyCheckBox.Checked = false;
                return false;
            }
            envelope = new Envelope(attack, decay, sustain, release);
            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using OscillatorForm oscillatorForm = new();
            if (oscillatorForm.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem listViewItem = new(new String[] { oscillatorForm.Oscillator.Waveform.ToString(), oscillatorForm.Oscillator.Frequency.ToString(), oscillatorForm.Oscillator.Amplitude.ToString(), oscillatorForm.Oscillator.Phase.ToString(), oscillatorForm.Oscillator.Ratio.ToString() });
                listViewItem.Tag = oscillatorForm.Oscillator;
                oscillatorsListView.Items.Add(listViewItem);
                listViewItem.Selected = true;

                List<Oscillator> oscillators = new();
                foreach (ListViewItem item in oscillatorsListView.Items)
                    if (item.Tag is Oscillator oscillator)
                        oscillators.Add(oscillator);

                workingWithOscillators = true;
                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs(oscillators));
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (oscillatorsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = oscillatorsListView.SelectedItems[0];
            if (selectedItem.Tag is not Oscillator selectedOscillator)
                return;
            using OscillatorForm oscillatorForm = new(selectedOscillator);
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
                    if (item.Tag is Oscillator oscillator)
                        oscillators.Add(oscillator);

                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs(oscillators));
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (oscillatorsListView.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem selectedItem in oscillatorsListView.SelectedItems.Cast<ListViewItem>().ToArray())
                selectedItem.Remove();

            if (oscillatorsListView.Items.Count == 0)
                SoundWaveCleared?.Invoke(this, EventArgs.Empty);
            else
            {
                List<Oscillator> oscillators = new();
                foreach (ListViewItem item in oscillatorsListView.Items)
                    if (item.Tag is Oscillator oscillator)
                        oscillators.Add(oscillator);

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
            if (CurrentWaveData == null)
                return;

            try
            {
                StopPlayback();
                audioPlayback = new AudioPlayback(this, samplingRate,
                    CurrentWaveData.Select(point => (float)point.Item2).ToArray(), message =>
                    {
                        StopPlayback();
                        MessageBox.Show(this, message, "Cannot play sound", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                audioPlayback.Play();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                StopPlayback();
                MessageBox.Show(this, $"Cannot play sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            UpdateEnvelopeLabels();

            if (adsrApplyCheckBox.Checked && hasWaveData)
            {
                TryApplyEnvelope();
            }
            else
                envelope = null;

            if (hasWaveData && workingWithOscillators)
                SoundWaveCreated?.Invoke(this, new SoundWaveCreatedEventArgs(oscillators));
        }

        private void UpdateEnvelopeLabels()
        {
            attackValueLabel.Text = Math.Round(attackTrackBar.Value / 100.0 * duration, 3) + " s";
            decayValueLabel.Text = Math.Round(decayTrackBar.Value / 100.0 * duration, 3) + " s";
            releaseValueLabel.Text = Math.Round(releaseTrackBar.Value / 100.0 * duration, 3) + " s";
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
            if (!hasWaveData || sender is RadioButton { Checked: false })
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
                if (!TryApplyEnvelope()) return;
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
                if (!TryApplyEnvelope()) return;
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
                if (!TryApplyEnvelope()) return;
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
                if (!TryApplyEnvelope()) return;
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
                if (!TryApplyEnvelope()) return;
                SoundWaveModified?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}
