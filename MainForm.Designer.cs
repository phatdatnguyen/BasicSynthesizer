namespace BasicSynthesizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            audioToolStripMenuItem = new ToolStripMenuItem();
            playToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            oscillatorsGroupBox = new GroupBox();
            editButton = new Button();
            deleteButton = new Button();
            addButton = new Button();
            deleteAudioButton = new Button();
            oscillatorsListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            durationNumericUpDown = new NumericUpDown();
            samplingRateComboBox = new ComboBox();
            durationLabel = new Label();
            samplingRateLabel = new Label();
            filterGroupBox = new GroupBox();
            bandPassRadioButton = new RadioButton();
            resonanceValueLabel = new Label();
            filterFrequencyValueLabel = new Label();
            resonanceTrackBar = new TrackBar();
            filterFrequencyTrackBar = new TrackBar();
            resonanceLabel = new Label();
            filterFrequencyLabel = new Label();
            filterApplyCheckBox = new CheckBox();
            highPassRadioButton = new RadioButton();
            lowPassRadioButton = new RadioButton();
            adsrGroupBox = new GroupBox();
            releaseValueLabel = new Label();
            sustainValueLabel = new Label();
            decayValueLabel = new Label();
            attackValueLabel = new Label();
            attackTrackBar = new TrackBar();
            decayTrackBar = new TrackBar();
            sustainTrackBar = new TrackBar();
            releaseTrackBar = new TrackBar();
            adsrApplyCheckBox = new CheckBox();
            releaseLabel = new Label();
            sustainLabel = new Label();
            decayLabel = new Label();
            attackLabel = new Label();
            lfoGroupBox = new GroupBox();
            phaseValueLabel = new Label();
            phaseLabel = new Label();
            phaseTrackBar = new TrackBar();
            amplitudeValueLabel = new Label();
            amplitudeLabel = new Label();
            amplitudeTrackBar = new TrackBar();
            lfoFrequencyValueLabel = new Label();
            lfoFrequencyLabel = new Label();
            lfoFrequencyTrackBar = new TrackBar();
            lfoApplyCheckBox = new CheckBox();
            waveformComboBox = new ComboBox();
            waveformLabel = new Label();
            plotComboBox = new ComboBox();
            plotLabel = new Label();
            playButton = new Button();
            mainToolTip = new ToolTip(components);
            openAudioFileDialog = new OpenFileDialog();
            audioInfoLabel = new Label();
            saveAudioFileDialog = new SaveFileDialog();
            timeDomainPlotView = new OxyPlot.WindowsForms.PlotView();
            frequencyDomainPlotView = new OxyPlot.WindowsForms.PlotView();
            soundSignalGroupBox = new GroupBox();
            mainMenuStrip.SuspendLayout();
            oscillatorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)durationNumericUpDown).BeginInit();
            filterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resonanceTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filterFrequencyTrackBar).BeginInit();
            adsrGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)attackTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decayTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sustainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)releaseTrackBar).BeginInit();
            lfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)phaseTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amplitudeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lfoFrequencyTrackBar).BeginInit();
            soundSignalGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, audioToolStripMenuItem, helpToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(7, 2, 0, 2);
            mainMenuStrip.Size = new Size(1184, 24);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(135, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // audioToolStripMenuItem
            // 
            audioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { playToolStripMenuItem, toolStripMenuItem2, exportToolStripMenuItem, importToolStripMenuItem });
            audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            audioToolStripMenuItem.Size = new Size(51, 20);
            audioToolStripMenuItem.Text = "&Audio";
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            playToolStripMenuItem.Size = new Size(157, 22);
            playToolStripMenuItem.Text = "&Play";
            playToolStripMenuItem.Click += playToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(154, 6);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            exportToolStripMenuItem.Size = new Size(157, 22);
            exportToolStripMenuItem.Text = "&Export...";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            importToolStripMenuItem.Size = new Size(157, 22);
            importToolStripMenuItem.Text = "&Import...";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.ShortcutKeys = Keys.F1;
            aboutToolStripMenuItem.Size = new Size(227, 22);
            aboutToolStripMenuItem.Text = "&About Basic Synthesizer...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // oscillatorsGroupBox
            // 
            oscillatorsGroupBox.Controls.Add(editButton);
            oscillatorsGroupBox.Controls.Add(deleteButton);
            oscillatorsGroupBox.Controls.Add(addButton);
            oscillatorsGroupBox.Controls.Add(deleteAudioButton);
            oscillatorsGroupBox.Controls.Add(oscillatorsListView);
            oscillatorsGroupBox.Location = new Point(14, 31);
            oscillatorsGroupBox.Margin = new Padding(4, 3, 4, 3);
            oscillatorsGroupBox.Name = "oscillatorsGroupBox";
            oscillatorsGroupBox.Padding = new Padding(4, 3, 4, 3);
            oscillatorsGroupBox.Size = new Size(407, 341);
            oscillatorsGroupBox.TabIndex = 1;
            oscillatorsGroupBox.TabStop = false;
            oscillatorsGroupBox.Text = "Oscillators";
            // 
            // editButton
            // 
            editButton.Location = new Point(90, 22);
            editButton.Margin = new Padding(4, 3, 4, 3);
            editButton.Name = "editButton";
            editButton.Size = new Size(75, 23);
            editButton.TabIndex = 1;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(241, 22);
            deleteButton.Margin = new Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(7, 22);
            addButton.Margin = new Padding(4, 3, 4, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 0;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteAudioButton
            // 
            deleteAudioButton.Enabled = false;
            deleteAudioButton.Location = new Point(324, 22);
            deleteAudioButton.Margin = new Padding(4, 3, 4, 3);
            deleteAudioButton.Name = "deleteAudioButton";
            deleteAudioButton.Size = new Size(75, 23);
            deleteAudioButton.TabIndex = 7;
            deleteAudioButton.Text = "Delete all";
            deleteAudioButton.UseVisualStyleBackColor = true;
            deleteAudioButton.Click += deleteAudioButton_Click;
            // 
            // oscillatorsListView
            // 
            oscillatorsListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            oscillatorsListView.Dock = DockStyle.Bottom;
            oscillatorsListView.FullRowSelect = true;
            oscillatorsListView.Location = new Point(4, 51);
            oscillatorsListView.Margin = new Padding(4, 3, 4, 3);
            oscillatorsListView.Name = "oscillatorsListView";
            oscillatorsListView.Size = new Size(399, 287);
            oscillatorsListView.TabIndex = 3;
            oscillatorsListView.UseCompatibleStateImageBehavior = false;
            oscillatorsListView.View = View.Details;
            oscillatorsListView.KeyUp += oscillatorsListView_KeyUp;
            oscillatorsListView.MouseDoubleClick += oscillatorsListView_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Waveform";
            columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Frequency (Hz)";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Amplitude";
            columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Phase (°)";
            columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Ratio";
            // 
            // durationNumericUpDown
            // 
            durationNumericUpDown.DecimalPlaces = 2;
            durationNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            durationNumericUpDown.Location = new Point(339, 25);
            durationNumericUpDown.Margin = new Padding(4, 3, 4, 3);
            durationNumericUpDown.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            durationNumericUpDown.Name = "durationNumericUpDown";
            durationNumericUpDown.Size = new Size(100, 23);
            durationNumericUpDown.TabIndex = 3;
            durationNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            durationNumericUpDown.ValueChanged += durationNumericUpDown_ValueChanged;
            // 
            // samplingRateComboBox
            // 
            samplingRateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            samplingRateComboBox.FormattingEnabled = true;
            samplingRateComboBox.Items.AddRange(new object[] { "22050", "44100", "88200" });
            samplingRateComboBox.Location = new Point(129, 23);
            samplingRateComboBox.Margin = new Padding(4, 3, 4, 3);
            samplingRateComboBox.Name = "samplingRateComboBox";
            samplingRateComboBox.Size = new Size(100, 23);
            samplingRateComboBox.TabIndex = 2;
            samplingRateComboBox.SelectedIndexChanged += samplingRateComboBox_SelectedIndexChanged;
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Location = new Point(262, 29);
            durationLabel.Margin = new Padding(4, 0, 4, 0);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new Size(69, 15);
            durationLabel.TabIndex = 0;
            durationLabel.Text = "Duration (s)";
            // 
            // samplingRateLabel
            // 
            samplingRateLabel.AutoSize = true;
            samplingRateLabel.Location = new Point(13, 27);
            samplingRateLabel.Margin = new Padding(4, 0, 4, 0);
            samplingRateLabel.Name = "samplingRateLabel";
            samplingRateLabel.Size = new Size(105, 15);
            samplingRateLabel.TabIndex = 0;
            samplingRateLabel.Text = "Sampling rate (Hz)";
            // 
            // filterGroupBox
            // 
            filterGroupBox.Controls.Add(bandPassRadioButton);
            filterGroupBox.Controls.Add(resonanceValueLabel);
            filterGroupBox.Controls.Add(filterFrequencyValueLabel);
            filterGroupBox.Controls.Add(resonanceTrackBar);
            filterGroupBox.Controls.Add(filterFrequencyTrackBar);
            filterGroupBox.Controls.Add(resonanceLabel);
            filterGroupBox.Controls.Add(filterFrequencyLabel);
            filterGroupBox.Controls.Add(filterApplyCheckBox);
            filterGroupBox.Controls.Add(highPassRadioButton);
            filterGroupBox.Controls.Add(lowPassRadioButton);
            filterGroupBox.Enabled = false;
            filterGroupBox.Location = new Point(13, 378);
            filterGroupBox.Margin = new Padding(4, 3, 4, 3);
            filterGroupBox.Name = "filterGroupBox";
            filterGroupBox.Padding = new Padding(4, 3, 4, 3);
            filterGroupBox.Size = new Size(408, 251);
            filterGroupBox.TabIndex = 15;
            filterGroupBox.TabStop = false;
            filterGroupBox.Text = "Filter";
            // 
            // bandPassRadioButton
            // 
            bandPassRadioButton.AutoSize = true;
            bandPassRadioButton.Location = new Point(252, 66);
            bandPassRadioButton.Margin = new Padding(4, 3, 4, 3);
            bandPassRadioButton.Name = "bandPassRadioButton";
            bandPassRadioButton.Size = new Size(80, 19);
            bandPassRadioButton.TabIndex = 3;
            bandPassRadioButton.Text = "Band-pass";
            bandPassRadioButton.UseVisualStyleBackColor = true;
            bandPassRadioButton.CheckedChanged += filterModeRadioButton_CheckedChanged;
            // 
            // resonanceValueLabel
            // 
            resonanceValueLabel.AutoSize = true;
            resonanceValueLabel.Location = new Point(279, 180);
            resonanceValueLabel.Margin = new Padding(2, 0, 2, 0);
            resonanceValueLabel.Name = "resonanceValueLabel";
            resonanceValueLabel.Size = new Size(23, 15);
            resonanceValueLabel.TabIndex = 0;
            resonanceValueLabel.Text = "0%";
            // 
            // filterFrequencyValueLabel
            // 
            filterFrequencyValueLabel.AutoSize = true;
            filterFrequencyValueLabel.Location = new Point(279, 125);
            filterFrequencyValueLabel.Margin = new Padding(2, 0, 2, 0);
            filterFrequencyValueLabel.Name = "filterFrequencyValueLabel";
            filterFrequencyValueLabel.Size = new Size(42, 15);
            filterFrequencyValueLabel.TabIndex = 0;
            filterFrequencyValueLabel.Text = "500 Hz";
            // 
            // resonanceTrackBar
            // 
            resonanceTrackBar.Location = new Point(123, 180);
            resonanceTrackBar.Margin = new Padding(4, 3, 4, 3);
            resonanceTrackBar.Maximum = 100;
            resonanceTrackBar.Name = "resonanceTrackBar";
            resonanceTrackBar.Size = new Size(150, 45);
            resonanceTrackBar.TabIndex = 5;
            resonanceTrackBar.TickFrequency = 10;
            resonanceTrackBar.Scroll += resonanceTrackBar_Scroll;
            // 
            // filterFrequencyTrackBar
            // 
            filterFrequencyTrackBar.Location = new Point(123, 121);
            filterFrequencyTrackBar.Margin = new Padding(4, 3, 4, 3);
            filterFrequencyTrackBar.Maximum = 4000;
            filterFrequencyTrackBar.Minimum = 16;
            filterFrequencyTrackBar.Name = "filterFrequencyTrackBar";
            filterFrequencyTrackBar.Size = new Size(150, 45);
            filterFrequencyTrackBar.TabIndex = 4;
            filterFrequencyTrackBar.TickFrequency = 400;
            filterFrequencyTrackBar.Value = 500;
            filterFrequencyTrackBar.Scroll += filterFrequencyTrackBar_Scroll;
            // 
            // resonanceLabel
            // 
            resonanceLabel.AutoSize = true;
            resonanceLabel.Location = new Point(50, 180);
            resonanceLabel.Margin = new Padding(4, 0, 4, 0);
            resonanceLabel.Name = "resonanceLabel";
            resonanceLabel.Size = new Size(64, 15);
            resonanceLabel.TabIndex = 0;
            resonanceLabel.Text = "Resonance";
            // 
            // filterFrequencyLabel
            // 
            filterFrequencyLabel.AutoSize = true;
            filterFrequencyLabel.Location = new Point(56, 125);
            filterFrequencyLabel.Margin = new Padding(4, 0, 4, 0);
            filterFrequencyLabel.Name = "filterFrequencyLabel";
            filterFrequencyLabel.Size = new Size(62, 15);
            filterFrequencyLabel.TabIndex = 0;
            filterFrequencyLabel.Text = "Frequency";
            // 
            // filterApplyCheckBox
            // 
            filterApplyCheckBox.AutoSize = true;
            filterApplyCheckBox.Location = new Point(13, 27);
            filterApplyCheckBox.Margin = new Padding(4, 3, 4, 3);
            filterApplyCheckBox.Name = "filterApplyCheckBox";
            filterApplyCheckBox.Size = new Size(57, 19);
            filterApplyCheckBox.TabIndex = 0;
            filterApplyCheckBox.Text = "Apply";
            filterApplyCheckBox.UseVisualStyleBackColor = true;
            filterApplyCheckBox.CheckedChanged += filterApplyCheckBox_CheckedChanged;
            // 
            // highPassRadioButton
            // 
            highPassRadioButton.AutoSize = true;
            highPassRadioButton.Location = new Point(144, 66);
            highPassRadioButton.Margin = new Padding(4, 3, 4, 3);
            highPassRadioButton.Name = "highPassRadioButton";
            highPassRadioButton.Size = new Size(79, 19);
            highPassRadioButton.TabIndex = 2;
            highPassRadioButton.Text = "High-pass";
            highPassRadioButton.UseVisualStyleBackColor = true;
            highPassRadioButton.CheckedChanged += filterModeRadioButton_CheckedChanged;
            // 
            // lowPassRadioButton
            // 
            lowPassRadioButton.AutoSize = true;
            lowPassRadioButton.Checked = true;
            lowPassRadioButton.Location = new Point(39, 66);
            lowPassRadioButton.Margin = new Padding(4, 3, 4, 3);
            lowPassRadioButton.Name = "lowPassRadioButton";
            lowPassRadioButton.Size = new Size(75, 19);
            lowPassRadioButton.TabIndex = 1;
            lowPassRadioButton.TabStop = true;
            lowPassRadioButton.Text = "Low-pass";
            lowPassRadioButton.UseVisualStyleBackColor = true;
            lowPassRadioButton.CheckedChanged += filterModeRadioButton_CheckedChanged;
            // 
            // adsrGroupBox
            // 
            adsrGroupBox.Controls.Add(releaseValueLabel);
            adsrGroupBox.Controls.Add(sustainValueLabel);
            adsrGroupBox.Controls.Add(decayValueLabel);
            adsrGroupBox.Controls.Add(attackValueLabel);
            adsrGroupBox.Controls.Add(attackTrackBar);
            adsrGroupBox.Controls.Add(decayTrackBar);
            adsrGroupBox.Controls.Add(sustainTrackBar);
            adsrGroupBox.Controls.Add(releaseTrackBar);
            adsrGroupBox.Controls.Add(adsrApplyCheckBox);
            adsrGroupBox.Controls.Add(releaseLabel);
            adsrGroupBox.Controls.Add(sustainLabel);
            adsrGroupBox.Controls.Add(decayLabel);
            adsrGroupBox.Controls.Add(attackLabel);
            adsrGroupBox.Enabled = false;
            adsrGroupBox.Location = new Point(777, 378);
            adsrGroupBox.Margin = new Padding(4, 3, 4, 3);
            adsrGroupBox.Name = "adsrGroupBox";
            adsrGroupBox.Padding = new Padding(4, 3, 4, 3);
            adsrGroupBox.Size = new Size(400, 251);
            adsrGroupBox.TabIndex = 17;
            adsrGroupBox.TabStop = false;
            adsrGroupBox.Text = "Envelope (ADSR)";
            // 
            // releaseValueLabel
            // 
            releaseValueLabel.AutoSize = true;
            releaseValueLabel.Location = new Point(335, 204);
            releaseValueLabel.Margin = new Padding(2, 0, 2, 0);
            releaseValueLabel.Name = "releaseValueLabel";
            releaseValueLabel.Size = new Size(30, 15);
            releaseValueLabel.TabIndex = 0;
            releaseValueLabel.Text = "0.4 s";
            // 
            // sustainValueLabel
            // 
            sustainValueLabel.AutoSize = true;
            sustainValueLabel.Location = new Point(335, 149);
            sustainValueLabel.Margin = new Padding(2, 0, 2, 0);
            sustainValueLabel.Name = "sustainValueLabel";
            sustainValueLabel.Size = new Size(29, 15);
            sustainValueLabel.TabIndex = 0;
            sustainValueLabel.Text = "80%";
            // 
            // decayValueLabel
            // 
            decayValueLabel.AutoSize = true;
            decayValueLabel.Location = new Point(335, 87);
            decayValueLabel.Margin = new Padding(2, 0, 2, 0);
            decayValueLabel.Name = "decayValueLabel";
            decayValueLabel.Size = new Size(30, 15);
            decayValueLabel.TabIndex = 0;
            decayValueLabel.Text = "0.2 s";
            // 
            // attackValueLabel
            // 
            attackValueLabel.AutoSize = true;
            attackValueLabel.Location = new Point(335, 28);
            attackValueLabel.Margin = new Padding(2, 0, 2, 0);
            attackValueLabel.Name = "attackValueLabel";
            attackValueLabel.Size = new Size(30, 15);
            attackValueLabel.TabIndex = 0;
            attackValueLabel.Text = "0.2 s";
            // 
            // attackTrackBar
            // 
            attackTrackBar.Location = new Point(179, 24);
            attackTrackBar.Margin = new Padding(4, 3, 4, 3);
            attackTrackBar.Maximum = 100;
            attackTrackBar.Name = "attackTrackBar";
            attackTrackBar.Size = new Size(150, 45);
            attackTrackBar.TabIndex = 1;
            attackTrackBar.TickFrequency = 10;
            attackTrackBar.Value = 20;
            attackTrackBar.Scroll += attackTrackBar_Scroll;
            // 
            // decayTrackBar
            // 
            decayTrackBar.Location = new Point(179, 83);
            decayTrackBar.Margin = new Padding(4, 3, 4, 3);
            decayTrackBar.Maximum = 100;
            decayTrackBar.Name = "decayTrackBar";
            decayTrackBar.Size = new Size(150, 45);
            decayTrackBar.TabIndex = 2;
            decayTrackBar.TickFrequency = 10;
            decayTrackBar.Value = 20;
            decayTrackBar.Scroll += decayTrackBar_Scroll;
            // 
            // sustainTrackBar
            // 
            sustainTrackBar.Location = new Point(179, 141);
            sustainTrackBar.Margin = new Padding(4, 3, 4, 3);
            sustainTrackBar.Maximum = 100;
            sustainTrackBar.Name = "sustainTrackBar";
            sustainTrackBar.Size = new Size(150, 45);
            sustainTrackBar.TabIndex = 3;
            sustainTrackBar.TickFrequency = 10;
            sustainTrackBar.Value = 80;
            sustainTrackBar.Scroll += sustainTrackBar_Scroll;
            // 
            // releaseTrackBar
            // 
            releaseTrackBar.Location = new Point(179, 200);
            releaseTrackBar.Margin = new Padding(4, 3, 4, 3);
            releaseTrackBar.Maximum = 100;
            releaseTrackBar.Name = "releaseTrackBar";
            releaseTrackBar.Size = new Size(150, 45);
            releaseTrackBar.TabIndex = 4;
            releaseTrackBar.TickFrequency = 10;
            releaseTrackBar.Value = 40;
            releaseTrackBar.Scroll += releaseTrackBar_Scroll;
            // 
            // adsrApplyCheckBox
            // 
            adsrApplyCheckBox.AutoSize = true;
            adsrApplyCheckBox.Location = new Point(13, 27);
            adsrApplyCheckBox.Margin = new Padding(4, 3, 4, 3);
            adsrApplyCheckBox.Name = "adsrApplyCheckBox";
            adsrApplyCheckBox.Size = new Size(57, 19);
            adsrApplyCheckBox.TabIndex = 0;
            adsrApplyCheckBox.Text = "Apply";
            adsrApplyCheckBox.UseVisualStyleBackColor = true;
            adsrApplyCheckBox.CheckedChanged += adsrApplyCheckBox_CheckedChanged;
            // 
            // releaseLabel
            // 
            releaseLabel.AutoSize = true;
            releaseLabel.Location = new Point(102, 200);
            releaseLabel.Margin = new Padding(4, 0, 4, 0);
            releaseLabel.Name = "releaseLabel";
            releaseLabel.Size = new Size(62, 15);
            releaseLabel.TabIndex = 0;
            releaseLabel.Text = "Release (s)";
            // 
            // sustainLabel
            // 
            sustainLabel.AutoSize = true;
            sustainLabel.Location = new Point(103, 141);
            sustainLabel.Margin = new Padding(4, 0, 4, 0);
            sustainLabel.Name = "sustainLabel";
            sustainLabel.Size = new Size(66, 15);
            sustainLabel.TabIndex = 0;
            sustainLabel.Text = "Sustain (%)";
            // 
            // decayLabel
            // 
            decayLabel.AutoSize = true;
            decayLabel.Location = new Point(111, 83);
            decayLabel.Margin = new Padding(4, 0, 4, 0);
            decayLabel.Name = "decayLabel";
            decayLabel.Size = new Size(55, 15);
            decayLabel.TabIndex = 0;
            decayLabel.Text = "Decay (s)";
            // 
            // attackLabel
            // 
            attackLabel.AutoSize = true;
            attackLabel.Location = new Point(111, 24);
            attackLabel.Margin = new Padding(4, 0, 4, 0);
            attackLabel.Name = "attackLabel";
            attackLabel.Size = new Size(57, 15);
            attackLabel.TabIndex = 0;
            attackLabel.Text = "Attack (s)";
            // 
            // lfoGroupBox
            // 
            lfoGroupBox.Controls.Add(phaseValueLabel);
            lfoGroupBox.Controls.Add(phaseLabel);
            lfoGroupBox.Controls.Add(phaseTrackBar);
            lfoGroupBox.Controls.Add(amplitudeValueLabel);
            lfoGroupBox.Controls.Add(amplitudeLabel);
            lfoGroupBox.Controls.Add(amplitudeTrackBar);
            lfoGroupBox.Controls.Add(lfoFrequencyValueLabel);
            lfoGroupBox.Controls.Add(lfoFrequencyLabel);
            lfoGroupBox.Controls.Add(lfoFrequencyTrackBar);
            lfoGroupBox.Controls.Add(lfoApplyCheckBox);
            lfoGroupBox.Controls.Add(waveformComboBox);
            lfoGroupBox.Controls.Add(waveformLabel);
            lfoGroupBox.Enabled = false;
            lfoGroupBox.Location = new Point(429, 378);
            lfoGroupBox.Margin = new Padding(4, 3, 4, 3);
            lfoGroupBox.Name = "lfoGroupBox";
            lfoGroupBox.Padding = new Padding(4, 3, 4, 3);
            lfoGroupBox.Size = new Size(340, 251);
            lfoGroupBox.TabIndex = 16;
            lfoGroupBox.TabStop = false;
            lfoGroupBox.Text = "Low-frequency oscillator (LFO)";
            // 
            // phaseValueLabel
            // 
            phaseValueLabel.AutoSize = true;
            phaseValueLabel.Location = new Point(275, 194);
            phaseValueLabel.Margin = new Padding(2, 0, 2, 0);
            phaseValueLabel.Name = "phaseValueLabel";
            phaseValueLabel.Size = new Size(18, 15);
            phaseValueLabel.TabIndex = 0;
            phaseValueLabel.Text = "0°";
            // 
            // phaseLabel
            // 
            phaseLabel.AutoSize = true;
            phaseLabel.Location = new Point(69, 192);
            phaseLabel.Margin = new Padding(4, 0, 4, 0);
            phaseLabel.Name = "phaseLabel";
            phaseLabel.Size = new Size(38, 15);
            phaseLabel.TabIndex = 0;
            phaseLabel.Text = "Phase";
            // 
            // phaseTrackBar
            // 
            phaseTrackBar.Location = new Point(119, 192);
            phaseTrackBar.Margin = new Padding(4, 3, 4, 3);
            phaseTrackBar.Maximum = 360;
            phaseTrackBar.Name = "phaseTrackBar";
            phaseTrackBar.Size = new Size(150, 45);
            phaseTrackBar.TabIndex = 4;
            phaseTrackBar.TickFrequency = 36;
            phaseTrackBar.Scroll += phaseTrackBar_Scroll;
            // 
            // amplitudeValueLabel
            // 
            amplitudeValueLabel.AutoSize = true;
            amplitudeValueLabel.Location = new Point(275, 135);
            amplitudeValueLabel.Margin = new Padding(2, 0, 2, 0);
            amplitudeValueLabel.Name = "amplitudeValueLabel";
            amplitudeValueLabel.Size = new Size(13, 15);
            amplitudeValueLabel.TabIndex = 0;
            amplitudeValueLabel.Text = "1";
            // 
            // amplitudeLabel
            // 
            amplitudeLabel.AutoSize = true;
            amplitudeLabel.Location = new Point(50, 133);
            amplitudeLabel.Margin = new Padding(4, 0, 4, 0);
            amplitudeLabel.Name = "amplitudeLabel";
            amplitudeLabel.Size = new Size(63, 15);
            amplitudeLabel.TabIndex = 0;
            amplitudeLabel.Text = "Amplitude";
            // 
            // amplitudeTrackBar
            // 
            amplitudeTrackBar.Location = new Point(119, 133);
            amplitudeTrackBar.Margin = new Padding(4, 3, 4, 3);
            amplitudeTrackBar.Maximum = 100;
            amplitudeTrackBar.Name = "amplitudeTrackBar";
            amplitudeTrackBar.Size = new Size(150, 45);
            amplitudeTrackBar.TabIndex = 3;
            amplitudeTrackBar.TickFrequency = 10;
            amplitudeTrackBar.Value = 100;
            amplitudeTrackBar.Scroll += amplitudeTrackBar_Scroll;
            // 
            // lfoFrequencyValueLabel
            // 
            lfoFrequencyValueLabel.AutoSize = true;
            lfoFrequencyValueLabel.Location = new Point(275, 82);
            lfoFrequencyValueLabel.Margin = new Padding(2, 0, 2, 0);
            lfoFrequencyValueLabel.Name = "lfoFrequencyValueLabel";
            lfoFrequencyValueLabel.Size = new Size(36, 15);
            lfoFrequencyValueLabel.TabIndex = 0;
            lfoFrequencyValueLabel.Text = "10 Hz";
            // 
            // lfoFrequencyLabel
            // 
            lfoFrequencyLabel.AutoSize = true;
            lfoFrequencyLabel.Location = new Point(20, 80);
            lfoFrequencyLabel.Margin = new Padding(4, 0, 4, 0);
            lfoFrequencyLabel.Name = "lfoFrequencyLabel";
            lfoFrequencyLabel.Size = new Size(87, 15);
            lfoFrequencyLabel.TabIndex = 0;
            lfoFrequencyLabel.Text = "Frequency (Hz)";
            // 
            // lfoFrequencyTrackBar
            // 
            lfoFrequencyTrackBar.Location = new Point(119, 80);
            lfoFrequencyTrackBar.Margin = new Padding(4, 3, 4, 3);
            lfoFrequencyTrackBar.Maximum = 20;
            lfoFrequencyTrackBar.Minimum = 1;
            lfoFrequencyTrackBar.Name = "lfoFrequencyTrackBar";
            lfoFrequencyTrackBar.Size = new Size(150, 45);
            lfoFrequencyTrackBar.TabIndex = 2;
            lfoFrequencyTrackBar.TickFrequency = 2;
            lfoFrequencyTrackBar.Value = 10;
            lfoFrequencyTrackBar.Scroll += lfoFrequencyTrackBar_Scroll;
            // 
            // lfoApplyCheckBox
            // 
            lfoApplyCheckBox.AutoSize = true;
            lfoApplyCheckBox.Location = new Point(13, 27);
            lfoApplyCheckBox.Margin = new Padding(4, 3, 4, 3);
            lfoApplyCheckBox.Name = "lfoApplyCheckBox";
            lfoApplyCheckBox.Size = new Size(57, 19);
            lfoApplyCheckBox.TabIndex = 0;
            lfoApplyCheckBox.Text = "Apply";
            lfoApplyCheckBox.UseVisualStyleBackColor = true;
            lfoApplyCheckBox.CheckedChanged += lfoApplyCheckBox_CheckedChanged;
            // 
            // waveformComboBox
            // 
            waveformComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            waveformComboBox.FormattingEnabled = true;
            waveformComboBox.Items.AddRange(new object[] { "Sine", "Square", "Triangle", "Sawtooth" });
            waveformComboBox.Location = new Point(171, 25);
            waveformComboBox.Margin = new Padding(4, 3, 4, 3);
            waveformComboBox.Name = "waveformComboBox";
            waveformComboBox.Size = new Size(140, 23);
            waveformComboBox.TabIndex = 1;
            waveformComboBox.SelectedIndexChanged += waveformComboBox_SelectedIndexChanged;
            // 
            // waveformLabel
            // 
            waveformLabel.AutoSize = true;
            waveformLabel.Location = new Point(99, 29);
            waveformLabel.Margin = new Padding(4, 0, 4, 0);
            waveformLabel.Name = "waveformLabel";
            waveformLabel.Size = new Size(62, 15);
            waveformLabel.TabIndex = 0;
            waveformLabel.Text = "Waveform";
            // 
            // plotComboBox
            // 
            plotComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            plotComboBox.Enabled = false;
            plotComboBox.FormattingEnabled = true;
            plotComboBox.Items.AddRange(new object[] { "Magnitude", "Real", "Imaginary" });
            plotComboBox.Location = new Point(639, 23);
            plotComboBox.Margin = new Padding(2);
            plotComboBox.Name = "plotComboBox";
            plotComboBox.Size = new Size(100, 23);
            plotComboBox.TabIndex = 12;
            plotComboBox.SelectedIndexChanged += plotComboBox_SelectedIndexChanged;
            // 
            // plotLabel
            // 
            plotLabel.AutoSize = true;
            plotLabel.Location = new Point(503, 27);
            plotLabel.Margin = new Padding(4, 0, 4, 0);
            plotLabel.Name = "plotLabel";
            plotLabel.Size = new Size(130, 15);
            plotLabel.TabIndex = 0;
            plotLabel.Text = "Frequency domain plot";
            // 
            // playButton
            // 
            playButton.Enabled = false;
            playButton.Image = Properties.Resources.Audio_16x;
            playButton.ImageAlign = ContentAlignment.MiddleLeft;
            playButton.Location = new Point(460, 23);
            playButton.Margin = new Padding(2);
            playButton.Name = "playButton";
            playButton.Size = new Size(27, 27);
            playButton.TabIndex = 4;
            playButton.TextAlign = ContentAlignment.MiddleRight;
            mainToolTip.SetToolTip(playButton, "Some frequencies may not be supported by your audio device. ");
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // openAudioFileDialog
            // 
            openAudioFileDialog.Filter = "WAV file (*.wav)|*.wav";
            // 
            // audioInfoLabel
            // 
            audioInfoLabel.AutoSize = true;
            audioInfoLabel.Location = new Point(1106, 96);
            audioInfoLabel.Margin = new Padding(4, 0, 4, 0);
            audioInfoLabel.Name = "audioInfoLabel";
            audioInfoLabel.Size = new Size(0, 15);
            audioInfoLabel.TabIndex = 18;
            // 
            // saveAudioFileDialog
            // 
            saveAudioFileDialog.Filter = "WAV file (*.wav)|*.wav";
            // 
            // timeDomainPlotView
            // 
            timeDomainPlotView.Enabled = false;
            timeDomainPlotView.Location = new Point(7, 59);
            timeDomainPlotView.Margin = new Padding(4, 3, 4, 3);
            timeDomainPlotView.Name = "timeDomainPlotView";
            timeDomainPlotView.PanCursor = Cursors.Hand;
            timeDomainPlotView.Size = new Size(730, 135);
            timeDomainPlotView.TabIndex = 19;
            timeDomainPlotView.Text = "plotView1";
            timeDomainPlotView.ZoomHorizontalCursor = Cursors.SizeWE;
            timeDomainPlotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            timeDomainPlotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // frequencyDomainPlotView
            // 
            frequencyDomainPlotView.Enabled = false;
            frequencyDomainPlotView.Location = new Point(7, 200);
            frequencyDomainPlotView.Margin = new Padding(4, 3, 4, 3);
            frequencyDomainPlotView.Name = "frequencyDomainPlotView";
            frequencyDomainPlotView.PanCursor = Cursors.Hand;
            frequencyDomainPlotView.Size = new Size(730, 135);
            frequencyDomainPlotView.TabIndex = 20;
            frequencyDomainPlotView.Text = "plotView1";
            frequencyDomainPlotView.ZoomHorizontalCursor = Cursors.SizeWE;
            frequencyDomainPlotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            frequencyDomainPlotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // soundSignalGroupBox
            // 
            soundSignalGroupBox.Controls.Add(samplingRateLabel);
            soundSignalGroupBox.Controls.Add(frequencyDomainPlotView);
            soundSignalGroupBox.Controls.Add(durationLabel);
            soundSignalGroupBox.Controls.Add(timeDomainPlotView);
            soundSignalGroupBox.Controls.Add(samplingRateComboBox);
            soundSignalGroupBox.Controls.Add(durationNumericUpDown);
            soundSignalGroupBox.Controls.Add(playButton);
            soundSignalGroupBox.Controls.Add(plotLabel);
            soundSignalGroupBox.Controls.Add(plotComboBox);
            soundSignalGroupBox.Location = new Point(428, 31);
            soundSignalGroupBox.Name = "soundSignalGroupBox";
            soundSignalGroupBox.Size = new Size(744, 341);
            soundSignalGroupBox.TabIndex = 21;
            soundSignalGroupBox.TabStop = false;
            soundSignalGroupBox.Text = "Sound signal";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 641);
            Controls.Add(soundSignalGroupBox);
            Controls.Add(audioInfoLabel);
            Controls.Add(lfoGroupBox);
            Controls.Add(adsrGroupBox);
            Controls.Add(filterGroupBox);
            Controls.Add(oscillatorsGroupBox);
            Controls.Add(mainMenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = mainMenuStrip;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Basic Synthesizer";
            Load += MainForm_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            oscillatorsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)durationNumericUpDown).EndInit();
            filterGroupBox.ResumeLayout(false);
            filterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)resonanceTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)filterFrequencyTrackBar).EndInit();
            adsrGroupBox.ResumeLayout(false);
            adsrGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)attackTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)decayTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)sustainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)releaseTrackBar).EndInit();
            lfoGroupBox.ResumeLayout(false);
            lfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)phaseTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)amplitudeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)lfoFrequencyTrackBar).EndInit();
            soundSignalGroupBox.ResumeLayout(false);
            soundSignalGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private GroupBox oscillatorsGroupBox;
        private Button deleteButton;
        private Button addButton;
        private ListView oscillatorsListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private NumericUpDown durationNumericUpDown;
        private ComboBox samplingRateComboBox;
        private Label durationLabel;
        private Label samplingRateLabel;
        private Button playButton;
        private ColumnHeader columnHeader5;
        private GroupBox filterGroupBox;
        private Label resonanceLabel;
        private Label filterFrequencyLabel;
        private CheckBox filterApplyCheckBox;
        private RadioButton highPassRadioButton;
        private RadioButton lowPassRadioButton;
        private GroupBox adsrGroupBox;
        private CheckBox adsrApplyCheckBox;
        private Label releaseLabel;
        private Label sustainLabel;
        private Label decayLabel;
        private Label attackLabel;
        private GroupBox lfoGroupBox;
        private CheckBox lfoApplyCheckBox;
        private ComboBox waveformComboBox;
        private Label waveformLabel;
        private TrackBar resonanceTrackBar;
        private TrackBar filterFrequencyTrackBar;
        private TrackBar attackTrackBar;
        private TrackBar decayTrackBar;
        private TrackBar sustainTrackBar;
        private TrackBar releaseTrackBar;
        private Label lfoFrequencyLabel;
        private TrackBar lfoFrequencyTrackBar;
        private Label resonanceValueLabel;
        private Label filterFrequencyValueLabel;
        private Label releaseValueLabel;
        private Label sustainValueLabel;
        private Label decayValueLabel;
        private Label attackValueLabel;
        private Label lfoFrequencyValueLabel;
        private ComboBox plotComboBox;
        private Label plotLabel;
        private RadioButton bandPassRadioButton;
        private ToolTip mainToolTip;
        private Label amplitudeValueLabel;
        private Label amplitudeLabel;
        private TrackBar amplitudeTrackBar;
        private Label phaseValueLabel;
        private Label phaseLabel;
        private TrackBar phaseTrackBar;
        private OpenFileDialog openAudioFileDialog;
        private Button editButton;
        private Button deleteAudioButton;
        private Label audioInfoLabel;
        private SaveFileDialog saveAudioFileDialog;
        private ToolStripMenuItem audioToolStripMenuItem;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private OxyPlot.WindowsForms.PlotView timeDomainPlotView;
        private OxyPlot.WindowsForms.PlotView frequencyDomainPlotView;
        private GroupBox soundSignalGroupBox;
    }
}

