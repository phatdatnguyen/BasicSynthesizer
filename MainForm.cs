using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Accord.Audio;
using Accord.DirectSound;

namespace BasicSynthesizer
{
    public partial class MainForm : Form
    {
        // Fields
        private int samplingRate = 44100;
        private float duration = 1f;
        private bool hasWaveData = false;
        private bool workingWithOscillators = false;
        private bool workingWithAudio = false;
        private byte bitDepth = 16;
        private bool zooming = false;
        private double maxFrequency = 4000;
        private List<Oscillator> oscillators = null;
        private List<DataPoint> timeDomainData = null;
        private List<DataPoint> modifiedTimeDomainData = null;
        private List<DataPoint> frequencyDomainData = null;
        private List<DataPoint> modifiedFrequencyDomainData = null;
        private Filter filter = null;
        private LowFrequencyOscillator lfo = null;
        private Envelope envelope = null;

        // Events
        public delegate void SoundWaveClearedEventHandler(object sender, EventArgs e);
        public event SoundWaveClearedEventHandler SoundWaveCleared;
        protected void OnSoundWaveCleared(object sender, EventArgs e)
        {
            hasWaveData = false;
            workingWithOscillators = false;
            workingWithAudio = false;
            bitDepth = 16;
            maxFrequency = 4000;
            oscillators = null;
            timeDomainData = null;
            frequencyDomainData = null;
            filter = null;
            lfo = null;
            envelope = null;

            ResetControls();
        }

        public delegate void SoundWaveCreatedEventHandler(object sender, SoundWaveCreatedEventArgs e);
        public event SoundWaveCreatedEventHandler SoundWaveCreated;
        protected void OnSoundWaveCreated(object sender, SoundWaveCreatedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            hasWaveData = true;

            if (workingWithOscillators)
            {
                oscillators = e.Oscillators;
                timeDomainData = Oscillator.MixOscillators(oscillators, samplingRate, duration);
            }

            if (workingWithAudio)
            {
                oscillatorsGroupBox.Enabled = false;
                samplingRateComboBox.Enabled = false;
                durationNumericUpDown.Enabled = false;

            }

            UpdateControls();

            frequencyDomainData = Program.FastFourierTransform(timeDomainData, samplingRate);
            maxFrequency = frequencyDomainData.Last().XValue;

            if (filter != null || lfo != null || envelope != null)
            {
                SoundWaveModified(this, EventArgs.Empty);
                this.Cursor = Cursors.Default;
                return;
            }

            UpdateTimeDomainChart(timeDomainData);
            UpdateFrequencyDomainChart(frequencyDomainData);

            this.Cursor = Cursors.Default;
        }

        public delegate void SoundWaveModifiedEventHandler(object sender, EventArgs e);
        public event SoundWaveModifiedEventHandler SoundWaveModified;
        protected void OnSoundWaveModified(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            modifiedTimeDomainData = timeDomainData;

            if (filter != null)
                modifiedTimeDomainData = filter.Apply(modifiedTimeDomainData, samplingRate);
            if (lfo != null)
                modifiedTimeDomainData = lfo.Apply(modifiedTimeDomainData, samplingRate, duration);
            if (envelope != null)
                modifiedTimeDomainData = envelope.Apply(modifiedTimeDomainData, samplingRate, duration);

            UpdateTimeDomainChart(modifiedTimeDomainData);

            modifiedFrequencyDomainData = Program.FastFourierTransform(modifiedTimeDomainData, samplingRate);
            UpdateFrequencyDomainChart(modifiedFrequencyDomainData);

            this.Cursor = Cursors.Default;
        }

        // Methods
        private void UpdateControls()
        {
            playButton.Enabled = true;
            exportButton.Enabled = true;
            deleteAudioButton.Enabled = true;
            timeDomainZoomTrackBar.Enabled = true;
            timeDomainPanTrackBar.Enabled = true;
            plotComboBox.Enabled = true;
            frequencyDomainZoomTrackBar.Enabled = true;
            frequencyDomainPanTrackBar.Enabled = true;
            filterGroupBox.Enabled = true;
            lfoGroupBox.Enabled = true;
            adsrGroupBox.Enabled = true;
        }

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
            timeDomainChart.Series[0].Points.Clear();
            timeDomainChart.Series[1].Points.Clear();
            timeDomainChart.Series[1].Enabled = false;
            timeDomainChart.Series[2].Enabled = false;
            timeDomainZoomTrackBar.Enabled = false;
            timeDomainZoomTrackBar.Value = 100;
            timeDomainZoomValueLabel.Text = "100%";
            timeDomainPanTrackBar.Enabled = false;
            timeDomainPanTrackBar.Maximum = 0;
            timeDomainPanValueLabel.Text = "0%";
            frequencyDomainChart.Series[0].Points.Clear();
            frequencyDomainChart.Series[1].Points.Clear();
            frequencyDomainChart.Series[1].Enabled = false;
            plotComboBox.Enabled = false;
            frequencyDomainZoomTrackBar.Enabled = false;
            frequencyDomainZoomTrackBar.Value = 100;
            frequencyDomainZoomValueLabel.Text = "100%";
            frequencyDomainPanTrackBar.Enabled = false;
            frequencyDomainPanTrackBar.Maximum = 0;
            frequencyDomainPanValueLabel.Text = "0%";
            filterGroupBox.Enabled = false;
            filterApplyCheckBox.Checked = false;
            lfoGroupBox.Enabled = false;
            lfoApplyCheckBox.Checked = false;
            adsrGroupBox.Enabled = false;
            adsrApplyCheckBox.Checked = false;
        }

        private void UpdateTimeDomainChart(List<DataPoint> dataPoints)
        {
            timeDomainChart.Series[0].Points.Clear();
            foreach (DataPoint dataPoint in dataPoints)
                timeDomainChart.Series[0].Points.Add(dataPoint);

            double mininum = Convert.ToDouble(durationNumericUpDown.Value * timeDomainPanTrackBar.Value / 100);
            double maxinum = Convert.ToDouble(durationNumericUpDown.Value * timeDomainZoomTrackBar.Value / 100) + mininum;
            timeDomainChart.ChartAreas[0].AxisX.Minimum = mininum;
            timeDomainChart.ChartAreas[0].AxisX.Maximum = maxinum;

            if (lfo != null)
            {
                float interval = 1f / samplingRate; // s
                float[] lfoDataPoints = lfo.GenerateWaveDataPoints(samplingRate, duration);

                timeDomainChart.Series[1].Points.Clear();
                for (int i = 0; i < lfoDataPoints.Length; i++)
                    timeDomainChart.Series[1].Points.Add(new DataPoint(i * interval, lfoDataPoints[i]));

                timeDomainChart.Series[1].Enabled = true;
            }
            else
                timeDomainChart.Series[1].Enabled = false;

            if (adsrApplyCheckBox.Checked && envelope != null)
            {
                timeDomainChart.Series[2].Points[0] = new DataPoint(0, 0);
                timeDomainChart.Series[2].Points[1] = new DataPoint(envelope.Attack, 1);
                timeDomainChart.Series[2].Points[2] = new DataPoint(envelope.Attack + envelope.Decay, envelope.Sustain / 100);
                timeDomainChart.Series[2].Points[3] = new DataPoint(duration - envelope.Release, envelope.Sustain / 100);
                timeDomainChart.Series[2].Points[4] = new DataPoint(duration, 0);

                timeDomainChart.Series[2].Enabled = true;
            }
            else
                timeDomainChart.Series[2].Enabled = false;
        }

        private void UpdateFrequencyDomainChart(List<DataPoint> frequencyDomainData)
        {
            switch (plotComboBox.SelectedIndex)
            {
                case 0: // magnitude
                    frequencyDomainChart.Series[0].Enabled = true;
                    frequencyDomainChart.Series[1].Enabled = false;
                    frequencyDomainChart.Series[2].Enabled = false;
                    break;
                case 1: // real
                    frequencyDomainChart.Series[0].Enabled = false;
                    frequencyDomainChart.Series[1].Enabled = true;
                    frequencyDomainChart.Series[2].Enabled = false;
                    break;
                case 2: // imaginary
                    frequencyDomainChart.Series[0].Enabled = false;
                    frequencyDomainChart.Series[1].Enabled = false;
                    frequencyDomainChart.Series[2].Enabled = true;
                    break;
            }

            frequencyDomainChart.Series[0].Points.Clear();
            frequencyDomainChart.Series[1].Points.Clear();
            frequencyDomainChart.Series[2].Points.Clear();
            foreach (DataPoint dataPoint in frequencyDomainData)
            {
                frequencyDomainChart.Series[0].Points.Add(new DataPoint(dataPoint.XValue, dataPoint.YValues[2])); // magnitude
                frequencyDomainChart.Series[1].Points.Add(new DataPoint(dataPoint.XValue, dataPoint.YValues[0])); // real
                frequencyDomainChart.Series[2].Points.Add(new DataPoint(dataPoint.XValue, dataPoint.YValues[1])); // imaginary
            }
        }

        // Constructors
        public MainForm()
        {
            InitializeComponent();
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
            exportButton_Click(exportButton, EventArgs.Empty);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importButton_Click(importButton, EventArgs.Empty);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            samplingRateComboBox.SelectedIndex = 1;
            plotComboBox.SelectedIndex = 0;
            waveformComboBox.SelectedIndex = 0;

            SoundWaveCleared += OnSoundWaveCleared;
            SoundWaveCreated += OnSoundWaveCreated;
            SoundWaveModified += OnSoundWaveModified;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OscillatorForm oscillatorForm = new OscillatorForm();
            if (oscillatorForm.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem listViewItem = new ListViewItem(new String[] { oscillatorForm.Oscillator.Waveform.ToString(), oscillatorForm.Oscillator.Frequency.ToString(), oscillatorForm.Oscillator.Amplitude.ToString(), oscillatorForm.Oscillator.Phase.ToString(), oscillatorForm.Oscillator.Ratio.ToString() });
                listViewItem.Tag = oscillatorForm.Oscillator;
                oscillatorsListView.Items.Add(listViewItem);
                listViewItem.Selected = true;

                SoundWaveCreatedEventArgs args = new SoundWaveCreatedEventArgs();
                args.Oscillators = new List<Oscillator>();
                foreach (ListViewItem item in oscillatorsListView.Items)
                    args.Oscillators.Add((Oscillator)item.Tag);

                workingWithOscillators = true;
                SoundWaveCreated(this, args);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (oscillatorsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = oscillatorsListView.SelectedItems[0];
            OscillatorForm oscillatorForm = new OscillatorForm((Oscillator)selectedItem.Tag);
            if (oscillatorForm.ShowDialog(this) == DialogResult.OK)
            {
                selectedItem.SubItems[0].Text = oscillatorForm.Oscillator.Waveform.ToString();
                selectedItem.SubItems[1].Text = oscillatorForm.Oscillator.Frequency.ToString();
                selectedItem.SubItems[2].Text = oscillatorForm.Oscillator.Amplitude.ToString();
                selectedItem.SubItems[3].Text = oscillatorForm.Oscillator.Phase.ToString();
                selectedItem.SubItems[4].Text = oscillatorForm.Oscillator.Ratio.ToString();
                selectedItem.Tag = oscillatorForm.Oscillator;

                SoundWaveCreatedEventArgs args = new SoundWaveCreatedEventArgs();
                args.Oscillators = new List<Oscillator>();
                foreach (ListViewItem item in oscillatorsListView.Items)
                    args.Oscillators.Add((Oscillator)item.Tag);
                SoundWaveCreated(this, args);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (oscillatorsListView.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem selectedItem in oscillatorsListView.SelectedItems)
                selectedItem.Remove();

            if (oscillatorsListView.Items.Count == 0)
                SoundWaveCleared(this, EventArgs.Empty);
            else
            {
                SoundWaveCreatedEventArgs args = new SoundWaveCreatedEventArgs();
                args.Oscillators = new List<Oscillator>();
                foreach (ListViewItem item in oscillatorsListView.Items)
                    args.Oscillators.Add((Oscillator)item.Tag);
                SoundWaveCreated(this, args);
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
            try
            {
                AudioOutputDevice audioOutputDevice = new AudioOutputDevice(Program.mainForm.Handle, samplingRate, 1);

                float[] waveDataPoints = new float[timeDomainData.Count];
                for (int i = 0; i < waveDataPoints.Length; i++)
                    waveDataPoints[i] = (float)timeDomainData[i].YValues[0];

                if (filter != null)
                    waveDataPoints = filter.Apply(waveDataPoints, samplingRate);

                if (envelope != null)
                    waveDataPoints = envelope.Apply(waveDataPoints, samplingRate, duration);

                if (lfo != null)
                    waveDataPoints = lfo.Apply(waveDataPoints, samplingRate, duration);

                Signal signal = Program.GenerateWaveSignal(waveDataPoints, samplingRate, duration, bitDepth);
                audioOutputDevice.Play(signal.ToFloat());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cannot play sound!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                float[] waveDataPoints = new float[timeDomainData.Count];
                for (int i = 0; i < waveDataPoints.Length; i++)
                    waveDataPoints[i] = (float)timeDomainData[i].YValues[0];

                if (filter != null)
                    waveDataPoints = filter.Apply(waveDataPoints, samplingRate);

                if (envelope != null)
                    waveDataPoints = envelope.Apply(waveDataPoints, samplingRate, duration);

                if (lfo != null)
                    waveDataPoints = lfo.Apply(waveDataPoints, samplingRate, duration);

                Signal signal = Program.GenerateWaveSignal(waveDataPoints, samplingRate, duration, bitDepth);

                if (saveAudioFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Program.ExportWavFile(signal, saveAudioFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (hasWaveData)
            {
                if (MessageBox.Show(this, "You are working with some data, loading audio file will override your works. Do you want to continue?", "Import audio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            Signal signal = null;

            if (openAudioFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    signal = Program.LoadWavFile(openAudioFileDialog.FileName);

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

            SoundWaveCleared(this, EventArgs.Empty);

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
                ChooseChannelDialog chooseChannelDialog = new ChooseChannelDialog();
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
            timeDomainData = Program.GenerateWaveData(signal, wavFileChannel);

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

            SoundWaveCreated(this, new SoundWaveCreatedEventArgs());
        }

        private void deleteAudioButton_Click(object sender, EventArgs e)
        {
            SoundWaveCleared(this, EventArgs.Empty);
        }

        private void samplingRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            samplingRate = Convert.ToInt32(samplingRateComboBox.SelectedItem);

            if (hasWaveData && workingWithOscillators)
            {
                SoundWaveCreatedEventArgs args = new SoundWaveCreatedEventArgs();
                args.Oscillators = oscillators;
                SoundWaveCreated(this, args);
            }
        }

        private void durationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            duration = (float)durationNumericUpDown.Value;

            attackValueLabel.Text = Math.Round(attackTrackBar.Value / 100f * duration, 3).ToString() + " s";
            decayValueLabel.Text = Math.Round(decayTrackBar.Value / 100f * duration, 3).ToString() + " s";
            releaseValueLabel.Text = Math.Round(releaseTrackBar.Value / 100f * duration, 3).ToString() + " s";

            if (adsrApplyCheckBox.Checked && hasWaveData)
            {
                float attack = attackTrackBar.Value / 100f * duration;
                float decay = decayTrackBar.Value / 100f * duration;
                float sustain = sustainTrackBar.Value;
                float release = releaseTrackBar.Value / 100f * duration;
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
            {
                SoundWaveCreatedEventArgs args = new SoundWaveCreatedEventArgs();
                args.Oscillators = oscillators;
                SoundWaveCreated(this, args);
            }
        }

        private void timeDomainZoomTrackBar_Scroll(object sender, EventArgs e)
        {
            zooming = true;
            timeDomainZoomValueLabel.Text = timeDomainZoomTrackBar.Value.ToString() + "%";
            timeDomainPanTrackBar.Enabled = !(timeDomainZoomTrackBar.Value == 100);
            timeDomainPanTrackBar.Maximum = 100 - timeDomainZoomTrackBar.Value;
            if (timeDomainPanTrackBar.Value == timeDomainPanTrackBar.Maximum)
                timeDomainPanValueLabel.Text = timeDomainPanTrackBar.Value.ToString() + "%";

            if (hasWaveData)
            {
                double mininum = Convert.ToDouble(durationNumericUpDown.Value * timeDomainPanTrackBar.Value / 100);
                double maxinum = Convert.ToDouble(durationNumericUpDown.Value * timeDomainZoomTrackBar.Value / 100) + mininum;
                timeDomainChart.ChartAreas[0].AxisX.Minimum = mininum;
                timeDomainChart.ChartAreas[0].AxisX.Maximum = maxinum;
            }
            zooming = false;
        }

        private void timeDomainPanTrackBar_Scroll(object sender, EventArgs e)
        {
            timeDomainPanValueLabel.Text = timeDomainPanTrackBar.Value.ToString() + "%";

            if (hasWaveData && !zooming)
            {
                double mininum = Convert.ToDouble(durationNumericUpDown.Value * timeDomainPanTrackBar.Value / 100);
                double maxinum = Convert.ToDouble(durationNumericUpDown.Value * timeDomainZoomTrackBar.Value / 100) + mininum;
                timeDomainChart.ChartAreas[0].AxisX.Minimum = mininum;
                timeDomainChart.ChartAreas[0].AxisX.Maximum = maxinum;
            }
        }

        private void plotComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plotComboBox.SelectedIndex < 0 || !hasWaveData)
                return;

            UpdateFrequencyDomainChart(frequencyDomainData);
        }

        private void frequencyDomainZoomTrackBar_Scroll(object sender, EventArgs e)
        {
            zooming = true;
            frequencyDomainZoomValueLabel.Text = frequencyDomainZoomTrackBar.Value.ToString() + "%";
            frequencyDomainPanTrackBar.Enabled = !(frequencyDomainZoomTrackBar.Value == 100);
            frequencyDomainPanTrackBar.Maximum = 100 - frequencyDomainZoomTrackBar.Value;
            if (frequencyDomainPanTrackBar.Value == frequencyDomainPanTrackBar.Maximum)
                frequencyDomainPanValueLabel.Text = frequencyDomainPanTrackBar.Value.ToString() + "%";

            if (hasWaveData)
            {
                double mininum = maxFrequency * frequencyDomainPanTrackBar.Value / 100;
                double maxinum = maxFrequency * frequencyDomainZoomTrackBar.Value / 100 + mininum;
                frequencyDomainChart.ChartAreas[0].AxisX.Minimum = mininum;
                frequencyDomainChart.ChartAreas[0].AxisX.Maximum = maxinum;
            }
            zooming = false;
        }

        private void frequencyDomainPanTrackBar_Scroll(object sender, EventArgs e)
        {
            frequencyDomainPanValueLabel.Text = frequencyDomainPanTrackBar.Value.ToString() + "%";

            if (hasWaveData && !zooming)
            {
                double mininum = maxFrequency * frequencyDomainPanTrackBar.Value / 100;
                double maxinum = maxFrequency * frequencyDomainZoomTrackBar.Value / 100 + mininum;
                frequencyDomainChart.ChartAreas[0].AxisX.Minimum = mininum;
                frequencyDomainChart.ChartAreas[0].AxisX.Maximum = maxinum;
            }
        }

        private void filterApplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (filterApplyCheckBox.Checked)
            {
                float cutoffFrequency = filterFrequencyTrackBar.Value;
                float resonance = resonanceTrackBar.Value;

                if (lowPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.LowPass, cutoffFrequency, resonance);
                else if (highPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.HighPass, cutoffFrequency, resonance);
                else
                    filter = new Filter(Filter.FilterMode.BandPass, cutoffFrequency, resonance);
            }
            else
                filter = null;

            SoundWaveModified(this, EventArgs.Empty);
        }

        private void filterModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (filterApplyCheckBox.Checked)
            {
                float cutoffFrequency = filterFrequencyTrackBar.Value;
                float resonance = resonanceTrackBar.Value;

                if (lowPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.LowPass, cutoffFrequency, resonance);
                else if (highPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.HighPass, cutoffFrequency, resonance);
                else
                    filter = new Filter(Filter.FilterMode.BandPass, cutoffFrequency, resonance);

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void filterFrequencyTrackBar_Scroll(object sender, EventArgs e)
        {
            filterFrequencyValueLabel.Text = filterFrequencyTrackBar.Value.ToString() + " Hz";

            if (!hasWaveData)
                return;

            if (filterApplyCheckBox.Checked)
            {
                float cutoffFrequency = filterFrequencyTrackBar.Value;
                float resonance = resonanceTrackBar.Value;

                if (lowPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.LowPass, cutoffFrequency, resonance);
                else if (highPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.HighPass, cutoffFrequency, resonance);
                else
                    filter = new Filter(Filter.FilterMode.BandPass, cutoffFrequency, resonance);

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void resonanceTrackBar_Scroll(object sender, EventArgs e)
        {
            resonanceValueLabel.Text = resonanceTrackBar.Value.ToString() + "%";

            if (!hasWaveData)
                return;

            if (filterApplyCheckBox.Checked)
            {
                float cutoffFrequency = filterFrequencyTrackBar.Value;
                float resonance = resonanceTrackBar.Value;

                if (lowPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.LowPass, cutoffFrequency, resonance);
                else if (highPassRadioButton.Checked)
                    filter = new Filter(Filter.FilterMode.HighPass, cutoffFrequency, resonance);
                else
                    filter = new Filter(Filter.FilterMode.BandPass, cutoffFrequency, resonance);

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void lfoApplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                float frequency = lfoFrequencyTrackBar.Value;
                float amplitude = amplitudeTrackBar.Value / 100f;
                float phase = phaseTrackBar.Value;

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

            SoundWaveModified(this, EventArgs.Empty);
        }

        private void lfoFrequencyTrackBar_Scroll(object sender, EventArgs e)
        {
            lfoFrequencyValueLabel.Text = lfoFrequencyTrackBar.Value.ToString() + " Hz";

            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                float frequency = lfoFrequencyTrackBar.Value;
                float amplitude = amplitudeTrackBar.Value / 100f;
                float phase = phaseTrackBar.Value;

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

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void amplitudeTrackBar_Scroll(object sender, EventArgs e)
        {
            amplitudeValueLabel.Text = (amplitudeTrackBar.Value / 100f).ToString();

            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                float frequency = lfoFrequencyTrackBar.Value;
                float amplitude = amplitudeTrackBar.Value / 100f;
                float phase = phaseTrackBar.Value;

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

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void phaseTrackBar_Scroll(object sender, EventArgs e)
        {
            phaseValueLabel.Text = (phaseTrackBar.Value).ToString() + "°";

            if (!hasWaveData)
                return;

            if (lfoApplyCheckBox.Checked)
            {
                float frequency = lfoFrequencyTrackBar.Value;
                float amplitude = amplitudeTrackBar.Value / 100f;
                float phase = phaseTrackBar.Value;

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

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void adsrApplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                float attack = attackTrackBar.Value / 100f * duration;
                float decay = decayTrackBar.Value / 100f * duration;
                float sustain = sustainTrackBar.Value;
                float release = releaseTrackBar.Value / 100f * duration;
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

            SoundWaveModified(this, EventArgs.Empty);
        }

        private void attackTrackBar_Scroll(object sender, EventArgs e)
        {
            attackValueLabel.Text = Math.Round(attackTrackBar.Value / 100f * duration, 3).ToString() + " s";

            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                float attack = attackTrackBar.Value / 100f * duration;
                float decay = decayTrackBar.Value / 100f * duration;
                float sustain = sustainTrackBar.Value;
                float release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void decayTrackBar_Scroll(object sender, EventArgs e)
        {
            decayValueLabel.Text = Math.Round(decayTrackBar.Value / 100f * duration, 3).ToString() + " s";

            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                float attack = attackTrackBar.Value / 100f * duration;
                float decay = decayTrackBar.Value / 100f * duration;
                float sustain = sustainTrackBar.Value;
                float release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void sustainTrackBar_Scroll(object sender, EventArgs e)
        {
            sustainValueLabel.Text = sustainTrackBar.Value.ToString() + "%";

            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                float attack = attackTrackBar.Value / 100f * duration;
                float decay = decayTrackBar.Value / 100f * duration;
                float sustain = sustainTrackBar.Value;
                float release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void releaseTrackBar_Scroll(object sender, EventArgs e)
        {
            releaseValueLabel.Text = Math.Round(releaseTrackBar.Value / 100f * duration, 3).ToString() + " s";

            if (!hasWaveData)
                return;

            if (adsrApplyCheckBox.Checked)
            {
                float attack = attackTrackBar.Value / 100f * duration;
                float decay = decayTrackBar.Value / 100f * duration;
                float sustain = sustainTrackBar.Value;
                float release = releaseTrackBar.Value / 100f * duration;
                if (attack + decay + release > duration)
                {
                    MessageBox.Show(this, "Invalid envelope!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adsrApplyCheckBox.Checked = false;
                    return;
                }

                envelope = new Envelope(attack, decay, sustain, release);

                SoundWaveModified(this, EventArgs.Empty);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasWaveData)
            {
                switch (MessageBox.Show(this, "Do you want to export the current audio?", "Basic synthesizer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        exportButton_Click(exportButton, EventArgs.Empty);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }
        }
    }

    public class SoundWaveCreatedEventArgs : EventArgs
    {
        public List<Oscillator> Oscillators { get; set; }
    }
}
