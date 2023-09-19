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
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oscillatorsGroupBox = new System.Windows.Forms.GroupBox();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteAudioButton = new System.Windows.Forms.Button();
            this.oscillatorsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.samplingRateComboBox = new System.Windows.Forms.ComboBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.samplingRateLabel = new System.Windows.Forms.Label();
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.bandPassRadioButton = new System.Windows.Forms.RadioButton();
            this.resonanceValueLabel = new System.Windows.Forms.Label();
            this.filterFrequencyValueLabel = new System.Windows.Forms.Label();
            this.resonanceTrackBar = new System.Windows.Forms.TrackBar();
            this.filterFrequencyTrackBar = new System.Windows.Forms.TrackBar();
            this.resonanceLabel = new System.Windows.Forms.Label();
            this.filterFrequencyLabel = new System.Windows.Forms.Label();
            this.filterApplyCheckBox = new System.Windows.Forms.CheckBox();
            this.highPassRadioButton = new System.Windows.Forms.RadioButton();
            this.lowPassRadioButton = new System.Windows.Forms.RadioButton();
            this.adsrGroupBox = new System.Windows.Forms.GroupBox();
            this.releaseValueLabel = new System.Windows.Forms.Label();
            this.sustainValueLabel = new System.Windows.Forms.Label();
            this.decayValueLabel = new System.Windows.Forms.Label();
            this.attackValueLabel = new System.Windows.Forms.Label();
            this.attackTrackBar = new System.Windows.Forms.TrackBar();
            this.decayTrackBar = new System.Windows.Forms.TrackBar();
            this.sustainTrackBar = new System.Windows.Forms.TrackBar();
            this.releaseTrackBar = new System.Windows.Forms.TrackBar();
            this.adsrApplyCheckBox = new System.Windows.Forms.CheckBox();
            this.releaseLabel = new System.Windows.Forms.Label();
            this.sustainLabel = new System.Windows.Forms.Label();
            this.decayLabel = new System.Windows.Forms.Label();
            this.attackLabel = new System.Windows.Forms.Label();
            this.lfoGroupBox = new System.Windows.Forms.GroupBox();
            this.phaseValueLabel = new System.Windows.Forms.Label();
            this.phaseLabel = new System.Windows.Forms.Label();
            this.phaseTrackBar = new System.Windows.Forms.TrackBar();
            this.amplitudeValueLabel = new System.Windows.Forms.Label();
            this.amplitudeLabel = new System.Windows.Forms.Label();
            this.amplitudeTrackBar = new System.Windows.Forms.TrackBar();
            this.lfoFrequencyValueLabel = new System.Windows.Forms.Label();
            this.lfoFrequencyLabel = new System.Windows.Forms.Label();
            this.lfoFrequencyTrackBar = new System.Windows.Forms.TrackBar();
            this.lfoApplyCheckBox = new System.Windows.Forms.CheckBox();
            this.waveformComboBox = new System.Windows.Forms.ComboBox();
            this.waveformLabel = new System.Windows.Forms.Label();
            this.plotComboBox = new System.Windows.Forms.ComboBox();
            this.plotLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openAudioFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.audioInfoLabel = new System.Windows.Forms.Label();
            this.saveAudioFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.timeDomainPlotView = new OxyPlot.WindowsForms.PlotView();
            this.frequencyDomainPlotView = new OxyPlot.WindowsForms.PlotView();
            this.mainMenuStrip.SuspendLayout();
            this.oscillatorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).BeginInit();
            this.filterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resonanceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterFrequencyTrackBar)).BeginInit();
            this.adsrGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attackTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decayTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sustainTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.releaseTrackBar)).BeginInit();
            this.lfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phaseTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lfoFrequencyTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.audioToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1184, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.audioToolStripMenuItem.Text = "&Audio";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.playToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.playToolStripMenuItem.Text = "&Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exportToolStripMenuItem.Text = "&Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.importToolStripMenuItem.Text = "&Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.aboutToolStripMenuItem.Text = "&About Basic Synthesizer...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // oscillatorsGroupBox
            // 
            this.oscillatorsGroupBox.Controls.Add(this.editButton);
            this.oscillatorsGroupBox.Controls.Add(this.deleteButton);
            this.oscillatorsGroupBox.Controls.Add(this.addButton);
            this.oscillatorsGroupBox.Controls.Add(this.deleteAudioButton);
            this.oscillatorsGroupBox.Controls.Add(this.oscillatorsListView);
            this.oscillatorsGroupBox.Location = new System.Drawing.Point(12, 27);
            this.oscillatorsGroupBox.Name = "oscillatorsGroupBox";
            this.oscillatorsGroupBox.Size = new System.Drawing.Size(416, 362);
            this.oscillatorsGroupBox.TabIndex = 1;
            this.oscillatorsGroupBox.TabStop = false;
            this.oscillatorsGroupBox.Text = "Oscillators";
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(87, 19);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(254, 19);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteAudioButton
            // 
            this.deleteAudioButton.Enabled = false;
            this.deleteAudioButton.Location = new System.Drawing.Point(335, 19);
            this.deleteAudioButton.Name = "deleteAudioButton";
            this.deleteAudioButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAudioButton.TabIndex = 7;
            this.deleteAudioButton.Text = "Delete all";
            this.deleteAudioButton.UseVisualStyleBackColor = true;
            this.deleteAudioButton.Click += new System.EventHandler(this.deleteAudioButton_Click);
            // 
            // oscillatorsListView
            // 
            this.oscillatorsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.oscillatorsListView.FullRowSelect = true;
            this.oscillatorsListView.HideSelection = false;
            this.oscillatorsListView.Location = new System.Drawing.Point(6, 48);
            this.oscillatorsListView.Name = "oscillatorsListView";
            this.oscillatorsListView.Size = new System.Drawing.Size(404, 308);
            this.oscillatorsListView.TabIndex = 3;
            this.oscillatorsListView.UseCompatibleStateImageBehavior = false;
            this.oscillatorsListView.View = System.Windows.Forms.View.Details;
            this.oscillatorsListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.oscillatorsListView_KeyUp);
            this.oscillatorsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.oscillatorsListView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Waveform";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Frequency (Hz)";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Amplitude";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Phase (°)";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ratio";
            // 
            // durationNumericUpDown
            // 
            this.durationNumericUpDown.DecimalPlaces = 2;
            this.durationNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.durationNumericUpDown.Location = new System.Drawing.Point(763, 49);
            this.durationNumericUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.durationNumericUpDown.Name = "durationNumericUpDown";
            this.durationNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.durationNumericUpDown.TabIndex = 3;
            this.durationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.durationNumericUpDown.ValueChanged += new System.EventHandler(this.durationNumericUpDown_ValueChanged);
            // 
            // samplingRateComboBox
            // 
            this.samplingRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.samplingRateComboBox.FormattingEnabled = true;
            this.samplingRateComboBox.Items.AddRange(new object[] {
            "22050",
            "44100",
            "88200"});
            this.samplingRateComboBox.Location = new System.Drawing.Point(543, 46);
            this.samplingRateComboBox.Name = "samplingRateComboBox";
            this.samplingRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.samplingRateComboBox.TabIndex = 2;
            this.samplingRateComboBox.SelectedIndexChanged += new System.EventHandler(this.samplingRateComboBox_SelectedIndexChanged);
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(696, 51);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(61, 13);
            this.durationLabel.TabIndex = 0;
            this.durationLabel.Text = "Duration (s)";
            // 
            // samplingRateLabel
            // 
            this.samplingRateLabel.AutoSize = true;
            this.samplingRateLabel.Location = new System.Drawing.Point(434, 49);
            this.samplingRateLabel.Name = "samplingRateLabel";
            this.samplingRateLabel.Size = new System.Drawing.Size(98, 13);
            this.samplingRateLabel.TabIndex = 0;
            this.samplingRateLabel.Text = "Sampling Rate (Hz)";
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Controls.Add(this.bandPassRadioButton);
            this.filterGroupBox.Controls.Add(this.resonanceValueLabel);
            this.filterGroupBox.Controls.Add(this.filterFrequencyValueLabel);
            this.filterGroupBox.Controls.Add(this.resonanceTrackBar);
            this.filterGroupBox.Controls.Add(this.filterFrequencyTrackBar);
            this.filterGroupBox.Controls.Add(this.resonanceLabel);
            this.filterGroupBox.Controls.Add(this.filterFrequencyLabel);
            this.filterGroupBox.Controls.Add(this.filterApplyCheckBox);
            this.filterGroupBox.Controls.Add(this.highPassRadioButton);
            this.filterGroupBox.Controls.Add(this.lowPassRadioButton);
            this.filterGroupBox.Enabled = false;
            this.filterGroupBox.Location = new System.Drawing.Point(12, 395);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(350, 234);
            this.filterGroupBox.TabIndex = 15;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filter";
            // 
            // bandPassRadioButton
            // 
            this.bandPassRadioButton.AutoSize = true;
            this.bandPassRadioButton.Location = new System.Drawing.Point(226, 79);
            this.bandPassRadioButton.Name = "bandPassRadioButton";
            this.bandPassRadioButton.Size = new System.Drawing.Size(75, 17);
            this.bandPassRadioButton.TabIndex = 3;
            this.bandPassRadioButton.Text = "Band-pass";
            this.bandPassRadioButton.UseVisualStyleBackColor = true;
            this.bandPassRadioButton.CheckedChanged += new System.EventHandler(this.filterModeRadioButton_CheckedChanged);
            // 
            // resonanceValueLabel
            // 
            this.resonanceValueLabel.AutoSize = true;
            this.resonanceValueLabel.Location = new System.Drawing.Point(292, 183);
            this.resonanceValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resonanceValueLabel.Name = "resonanceValueLabel";
            this.resonanceValueLabel.Size = new System.Drawing.Size(21, 13);
            this.resonanceValueLabel.TabIndex = 0;
            this.resonanceValueLabel.Text = "0%";
            // 
            // filterFrequencyValueLabel
            // 
            this.filterFrequencyValueLabel.AutoSize = true;
            this.filterFrequencyValueLabel.Location = new System.Drawing.Point(292, 135);
            this.filterFrequencyValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filterFrequencyValueLabel.Name = "filterFrequencyValueLabel";
            this.filterFrequencyValueLabel.Size = new System.Drawing.Size(41, 13);
            this.filterFrequencyValueLabel.TabIndex = 0;
            this.filterFrequencyValueLabel.Text = "500 Hz";
            // 
            // resonanceTrackBar
            // 
            this.resonanceTrackBar.Location = new System.Drawing.Point(87, 183);
            this.resonanceTrackBar.Maximum = 100;
            this.resonanceTrackBar.Name = "resonanceTrackBar";
            this.resonanceTrackBar.Size = new System.Drawing.Size(200, 45);
            this.resonanceTrackBar.TabIndex = 5;
            this.resonanceTrackBar.TickFrequency = 10;
            this.resonanceTrackBar.Scroll += new System.EventHandler(this.resonanceTrackBar_Scroll);
            // 
            // filterFrequencyTrackBar
            // 
            this.filterFrequencyTrackBar.Location = new System.Drawing.Point(87, 132);
            this.filterFrequencyTrackBar.Maximum = 4000;
            this.filterFrequencyTrackBar.Minimum = 16;
            this.filterFrequencyTrackBar.Name = "filterFrequencyTrackBar";
            this.filterFrequencyTrackBar.Size = new System.Drawing.Size(200, 45);
            this.filterFrequencyTrackBar.TabIndex = 4;
            this.filterFrequencyTrackBar.TickFrequency = 400;
            this.filterFrequencyTrackBar.Value = 500;
            this.filterFrequencyTrackBar.Scroll += new System.EventHandler(this.filterFrequencyTrackBar_Scroll);
            // 
            // resonanceLabel
            // 
            this.resonanceLabel.AutoSize = true;
            this.resonanceLabel.Location = new System.Drawing.Point(25, 183);
            this.resonanceLabel.Name = "resonanceLabel";
            this.resonanceLabel.Size = new System.Drawing.Size(62, 13);
            this.resonanceLabel.TabIndex = 0;
            this.resonanceLabel.Text = "Resonance";
            // 
            // filterFrequencyLabel
            // 
            this.filterFrequencyLabel.AutoSize = true;
            this.filterFrequencyLabel.Location = new System.Drawing.Point(30, 135);
            this.filterFrequencyLabel.Name = "filterFrequencyLabel";
            this.filterFrequencyLabel.Size = new System.Drawing.Size(57, 13);
            this.filterFrequencyLabel.TabIndex = 0;
            this.filterFrequencyLabel.Text = "Frequency";
            // 
            // filterApplyCheckBox
            // 
            this.filterApplyCheckBox.AutoSize = true;
            this.filterApplyCheckBox.Location = new System.Drawing.Point(28, 31);
            this.filterApplyCheckBox.Name = "filterApplyCheckBox";
            this.filterApplyCheckBox.Size = new System.Drawing.Size(52, 17);
            this.filterApplyCheckBox.TabIndex = 0;
            this.filterApplyCheckBox.Text = "Apply";
            this.filterApplyCheckBox.UseVisualStyleBackColor = true;
            this.filterApplyCheckBox.CheckedChanged += new System.EventHandler(this.filterApplyCheckBox_CheckedChanged);
            // 
            // highPassRadioButton
            // 
            this.highPassRadioButton.AutoSize = true;
            this.highPassRadioButton.Location = new System.Drawing.Point(134, 79);
            this.highPassRadioButton.Name = "highPassRadioButton";
            this.highPassRadioButton.Size = new System.Drawing.Size(72, 17);
            this.highPassRadioButton.TabIndex = 2;
            this.highPassRadioButton.Text = "High-pass";
            this.highPassRadioButton.UseVisualStyleBackColor = true;
            this.highPassRadioButton.CheckedChanged += new System.EventHandler(this.filterModeRadioButton_CheckedChanged);
            // 
            // lowPassRadioButton
            // 
            this.lowPassRadioButton.AutoSize = true;
            this.lowPassRadioButton.Checked = true;
            this.lowPassRadioButton.Location = new System.Drawing.Point(44, 79);
            this.lowPassRadioButton.Name = "lowPassRadioButton";
            this.lowPassRadioButton.Size = new System.Drawing.Size(70, 17);
            this.lowPassRadioButton.TabIndex = 1;
            this.lowPassRadioButton.TabStop = true;
            this.lowPassRadioButton.Text = "Low-pass";
            this.lowPassRadioButton.UseVisualStyleBackColor = true;
            this.lowPassRadioButton.CheckedChanged += new System.EventHandler(this.filterModeRadioButton_CheckedChanged);
            // 
            // adsrGroupBox
            // 
            this.adsrGroupBox.Controls.Add(this.releaseValueLabel);
            this.adsrGroupBox.Controls.Add(this.sustainValueLabel);
            this.adsrGroupBox.Controls.Add(this.decayValueLabel);
            this.adsrGroupBox.Controls.Add(this.attackValueLabel);
            this.adsrGroupBox.Controls.Add(this.attackTrackBar);
            this.adsrGroupBox.Controls.Add(this.decayTrackBar);
            this.adsrGroupBox.Controls.Add(this.sustainTrackBar);
            this.adsrGroupBox.Controls.Add(this.releaseTrackBar);
            this.adsrGroupBox.Controls.Add(this.adsrApplyCheckBox);
            this.adsrGroupBox.Controls.Add(this.releaseLabel);
            this.adsrGroupBox.Controls.Add(this.sustainLabel);
            this.adsrGroupBox.Controls.Add(this.decayLabel);
            this.adsrGroupBox.Controls.Add(this.attackLabel);
            this.adsrGroupBox.Enabled = false;
            this.adsrGroupBox.Location = new System.Drawing.Point(744, 394);
            this.adsrGroupBox.Name = "adsrGroupBox";
            this.adsrGroupBox.Size = new System.Drawing.Size(428, 235);
            this.adsrGroupBox.TabIndex = 17;
            this.adsrGroupBox.TabStop = false;
            this.adsrGroupBox.Text = "Envelope (ADSR)";
            // 
            // releaseValueLabel
            // 
            this.releaseValueLabel.AutoSize = true;
            this.releaseValueLabel.Location = new System.Drawing.Point(367, 184);
            this.releaseValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.releaseValueLabel.Name = "releaseValueLabel";
            this.releaseValueLabel.Size = new System.Drawing.Size(30, 13);
            this.releaseValueLabel.TabIndex = 0;
            this.releaseValueLabel.Text = "0.4 s";
            // 
            // sustainValueLabel
            // 
            this.sustainValueLabel.AutoSize = true;
            this.sustainValueLabel.Location = new System.Drawing.Point(367, 136);
            this.sustainValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sustainValueLabel.Name = "sustainValueLabel";
            this.sustainValueLabel.Size = new System.Drawing.Size(27, 13);
            this.sustainValueLabel.TabIndex = 0;
            this.sustainValueLabel.Text = "80%";
            // 
            // decayValueLabel
            // 
            this.decayValueLabel.AutoSize = true;
            this.decayValueLabel.Location = new System.Drawing.Point(367, 82);
            this.decayValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.decayValueLabel.Name = "decayValueLabel";
            this.decayValueLabel.Size = new System.Drawing.Size(30, 13);
            this.decayValueLabel.TabIndex = 0;
            this.decayValueLabel.Text = "0.2 s";
            // 
            // attackValueLabel
            // 
            this.attackValueLabel.AutoSize = true;
            this.attackValueLabel.Location = new System.Drawing.Point(367, 31);
            this.attackValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.attackValueLabel.Name = "attackValueLabel";
            this.attackValueLabel.Size = new System.Drawing.Size(30, 13);
            this.attackValueLabel.TabIndex = 0;
            this.attackValueLabel.Text = "0.2 s";
            // 
            // attackTrackBar
            // 
            this.attackTrackBar.Location = new System.Drawing.Point(162, 31);
            this.attackTrackBar.Maximum = 100;
            this.attackTrackBar.Name = "attackTrackBar";
            this.attackTrackBar.Size = new System.Drawing.Size(200, 45);
            this.attackTrackBar.TabIndex = 1;
            this.attackTrackBar.TickFrequency = 10;
            this.attackTrackBar.Value = 20;
            this.attackTrackBar.Scroll += new System.EventHandler(this.attackTrackBar_Scroll);
            // 
            // decayTrackBar
            // 
            this.decayTrackBar.Location = new System.Drawing.Point(162, 82);
            this.decayTrackBar.Maximum = 100;
            this.decayTrackBar.Name = "decayTrackBar";
            this.decayTrackBar.Size = new System.Drawing.Size(200, 45);
            this.decayTrackBar.TabIndex = 2;
            this.decayTrackBar.TickFrequency = 10;
            this.decayTrackBar.Value = 20;
            this.decayTrackBar.Scroll += new System.EventHandler(this.decayTrackBar_Scroll);
            // 
            // sustainTrackBar
            // 
            this.sustainTrackBar.Location = new System.Drawing.Point(162, 133);
            this.sustainTrackBar.Maximum = 100;
            this.sustainTrackBar.Name = "sustainTrackBar";
            this.sustainTrackBar.Size = new System.Drawing.Size(200, 45);
            this.sustainTrackBar.TabIndex = 3;
            this.sustainTrackBar.TickFrequency = 10;
            this.sustainTrackBar.Value = 80;
            this.sustainTrackBar.Scroll += new System.EventHandler(this.sustainTrackBar_Scroll);
            // 
            // releaseTrackBar
            // 
            this.releaseTrackBar.Location = new System.Drawing.Point(162, 184);
            this.releaseTrackBar.Maximum = 100;
            this.releaseTrackBar.Name = "releaseTrackBar";
            this.releaseTrackBar.Size = new System.Drawing.Size(200, 45);
            this.releaseTrackBar.TabIndex = 4;
            this.releaseTrackBar.TickFrequency = 10;
            this.releaseTrackBar.Value = 40;
            this.releaseTrackBar.Scroll += new System.EventHandler(this.releaseTrackBar_Scroll);
            // 
            // adsrApplyCheckBox
            // 
            this.adsrApplyCheckBox.AutoSize = true;
            this.adsrApplyCheckBox.Location = new System.Drawing.Point(21, 30);
            this.adsrApplyCheckBox.Name = "adsrApplyCheckBox";
            this.adsrApplyCheckBox.Size = new System.Drawing.Size(52, 17);
            this.adsrApplyCheckBox.TabIndex = 0;
            this.adsrApplyCheckBox.Text = "Apply";
            this.adsrApplyCheckBox.UseVisualStyleBackColor = true;
            this.adsrApplyCheckBox.CheckedChanged += new System.EventHandler(this.adsrApplyCheckBox_CheckedChanged);
            // 
            // releaseLabel
            // 
            this.releaseLabel.AutoSize = true;
            this.releaseLabel.Location = new System.Drawing.Point(96, 184);
            this.releaseLabel.Name = "releaseLabel";
            this.releaseLabel.Size = new System.Drawing.Size(60, 13);
            this.releaseLabel.TabIndex = 0;
            this.releaseLabel.Text = "Release (s)";
            // 
            // sustainLabel
            // 
            this.sustainLabel.AutoSize = true;
            this.sustainLabel.Location = new System.Drawing.Point(97, 133);
            this.sustainLabel.Name = "sustainLabel";
            this.sustainLabel.Size = new System.Drawing.Size(59, 13);
            this.sustainLabel.TabIndex = 0;
            this.sustainLabel.Text = "Sustain (%)";
            // 
            // decayLabel
            // 
            this.decayLabel.AutoSize = true;
            this.decayLabel.Location = new System.Drawing.Point(104, 82);
            this.decayLabel.Name = "decayLabel";
            this.decayLabel.Size = new System.Drawing.Size(52, 13);
            this.decayLabel.TabIndex = 0;
            this.decayLabel.Text = "Decay (s)";
            // 
            // attackLabel
            // 
            this.attackLabel.AutoSize = true;
            this.attackLabel.Location = new System.Drawing.Point(104, 31);
            this.attackLabel.Name = "attackLabel";
            this.attackLabel.Size = new System.Drawing.Size(52, 13);
            this.attackLabel.TabIndex = 0;
            this.attackLabel.Text = "Attack (s)";
            // 
            // lfoGroupBox
            // 
            this.lfoGroupBox.Controls.Add(this.phaseValueLabel);
            this.lfoGroupBox.Controls.Add(this.phaseLabel);
            this.lfoGroupBox.Controls.Add(this.phaseTrackBar);
            this.lfoGroupBox.Controls.Add(this.amplitudeValueLabel);
            this.lfoGroupBox.Controls.Add(this.amplitudeLabel);
            this.lfoGroupBox.Controls.Add(this.amplitudeTrackBar);
            this.lfoGroupBox.Controls.Add(this.lfoFrequencyValueLabel);
            this.lfoGroupBox.Controls.Add(this.lfoFrequencyLabel);
            this.lfoGroupBox.Controls.Add(this.lfoFrequencyTrackBar);
            this.lfoGroupBox.Controls.Add(this.lfoApplyCheckBox);
            this.lfoGroupBox.Controls.Add(this.waveformComboBox);
            this.lfoGroupBox.Controls.Add(this.waveformLabel);
            this.lfoGroupBox.Enabled = false;
            this.lfoGroupBox.Location = new System.Drawing.Point(368, 395);
            this.lfoGroupBox.Name = "lfoGroupBox";
            this.lfoGroupBox.Size = new System.Drawing.Size(370, 234);
            this.lfoGroupBox.TabIndex = 16;
            this.lfoGroupBox.TabStop = false;
            this.lfoGroupBox.Text = "Low-frequency Oscillator (LFO)";
            // 
            // phaseValueLabel
            // 
            this.phaseValueLabel.AutoSize = true;
            this.phaseValueLabel.Location = new System.Drawing.Point(307, 183);
            this.phaseValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phaseValueLabel.Name = "phaseValueLabel";
            this.phaseValueLabel.Size = new System.Drawing.Size(17, 13);
            this.phaseValueLabel.TabIndex = 0;
            this.phaseValueLabel.Text = "0°";
            // 
            // phaseLabel
            // 
            this.phaseLabel.AutoSize = true;
            this.phaseLabel.Location = new System.Drawing.Point(59, 183);
            this.phaseLabel.Name = "phaseLabel";
            this.phaseLabel.Size = new System.Drawing.Size(37, 13);
            this.phaseLabel.TabIndex = 0;
            this.phaseLabel.Text = "Phase";
            // 
            // phaseTrackBar
            // 
            this.phaseTrackBar.Location = new System.Drawing.Point(102, 183);
            this.phaseTrackBar.Maximum = 360;
            this.phaseTrackBar.Name = "phaseTrackBar";
            this.phaseTrackBar.Size = new System.Drawing.Size(200, 45);
            this.phaseTrackBar.TabIndex = 4;
            this.phaseTrackBar.TickFrequency = 36;
            this.phaseTrackBar.Scroll += new System.EventHandler(this.phaseTrackBar_Scroll);
            // 
            // amplitudeValueLabel
            // 
            this.amplitudeValueLabel.AutoSize = true;
            this.amplitudeValueLabel.Location = new System.Drawing.Point(307, 132);
            this.amplitudeValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.amplitudeValueLabel.Name = "amplitudeValueLabel";
            this.amplitudeValueLabel.Size = new System.Drawing.Size(13, 13);
            this.amplitudeValueLabel.TabIndex = 0;
            this.amplitudeValueLabel.Text = "1";
            // 
            // amplitudeLabel
            // 
            this.amplitudeLabel.AutoSize = true;
            this.amplitudeLabel.Location = new System.Drawing.Point(43, 132);
            this.amplitudeLabel.Name = "amplitudeLabel";
            this.amplitudeLabel.Size = new System.Drawing.Size(53, 13);
            this.amplitudeLabel.TabIndex = 0;
            this.amplitudeLabel.Text = "Amplitude";
            // 
            // amplitudeTrackBar
            // 
            this.amplitudeTrackBar.Location = new System.Drawing.Point(102, 132);
            this.amplitudeTrackBar.Maximum = 100;
            this.amplitudeTrackBar.Name = "amplitudeTrackBar";
            this.amplitudeTrackBar.Size = new System.Drawing.Size(200, 45);
            this.amplitudeTrackBar.TabIndex = 3;
            this.amplitudeTrackBar.TickFrequency = 10;
            this.amplitudeTrackBar.Value = 100;
            this.amplitudeTrackBar.Scroll += new System.EventHandler(this.amplitudeTrackBar_Scroll);
            // 
            // lfoFrequencyValueLabel
            // 
            this.lfoFrequencyValueLabel.AutoSize = true;
            this.lfoFrequencyValueLabel.Location = new System.Drawing.Point(307, 81);
            this.lfoFrequencyValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lfoFrequencyValueLabel.Name = "lfoFrequencyValueLabel";
            this.lfoFrequencyValueLabel.Size = new System.Drawing.Size(35, 13);
            this.lfoFrequencyValueLabel.TabIndex = 0;
            this.lfoFrequencyValueLabel.Text = "10 Hz";
            // 
            // lfoFrequencyLabel
            // 
            this.lfoFrequencyLabel.AutoSize = true;
            this.lfoFrequencyLabel.Location = new System.Drawing.Point(17, 81);
            this.lfoFrequencyLabel.Name = "lfoFrequencyLabel";
            this.lfoFrequencyLabel.Size = new System.Drawing.Size(79, 13);
            this.lfoFrequencyLabel.TabIndex = 0;
            this.lfoFrequencyLabel.Text = "Frequency (Hz)";
            // 
            // lfoFrequencyTrackBar
            // 
            this.lfoFrequencyTrackBar.Location = new System.Drawing.Point(102, 81);
            this.lfoFrequencyTrackBar.Maximum = 20;
            this.lfoFrequencyTrackBar.Minimum = 1;
            this.lfoFrequencyTrackBar.Name = "lfoFrequencyTrackBar";
            this.lfoFrequencyTrackBar.Size = new System.Drawing.Size(200, 45);
            this.lfoFrequencyTrackBar.TabIndex = 2;
            this.lfoFrequencyTrackBar.TickFrequency = 2;
            this.lfoFrequencyTrackBar.Value = 10;
            this.lfoFrequencyTrackBar.Scroll += new System.EventHandler(this.lfoFrequencyTrackBar_Scroll);
            // 
            // lfoApplyCheckBox
            // 
            this.lfoApplyCheckBox.AutoSize = true;
            this.lfoApplyCheckBox.Location = new System.Drawing.Point(29, 29);
            this.lfoApplyCheckBox.Name = "lfoApplyCheckBox";
            this.lfoApplyCheckBox.Size = new System.Drawing.Size(52, 17);
            this.lfoApplyCheckBox.TabIndex = 0;
            this.lfoApplyCheckBox.Text = "Apply";
            this.lfoApplyCheckBox.UseVisualStyleBackColor = true;
            this.lfoApplyCheckBox.CheckedChanged += new System.EventHandler(this.lfoApplyCheckBox_CheckedChanged);
            // 
            // waveformComboBox
            // 
            this.waveformComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waveformComboBox.FormattingEnabled = true;
            this.waveformComboBox.Items.AddRange(new object[] {
            "Sine",
            "Square",
            "Triangle",
            "Sawtooth"});
            this.waveformComboBox.Location = new System.Drawing.Point(181, 27);
            this.waveformComboBox.Name = "waveformComboBox";
            this.waveformComboBox.Size = new System.Drawing.Size(121, 21);
            this.waveformComboBox.TabIndex = 1;
            this.waveformComboBox.SelectedIndexChanged += new System.EventHandler(this.waveformComboBox_SelectedIndexChanged);
            // 
            // waveformLabel
            // 
            this.waveformLabel.AutoSize = true;
            this.waveformLabel.Location = new System.Drawing.Point(119, 30);
            this.waveformLabel.Name = "waveformLabel";
            this.waveformLabel.Size = new System.Drawing.Size(56, 13);
            this.waveformLabel.TabIndex = 0;
            this.waveformLabel.Text = "Waveform";
            // 
            // plotComboBox
            // 
            this.plotComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plotComboBox.Enabled = false;
            this.plotComboBox.FormattingEnabled = true;
            this.plotComboBox.Items.AddRange(new object[] {
            "Magnitude",
            "Real",
            "Imaginary"});
            this.plotComboBox.Location = new System.Drawing.Point(1073, 48);
            this.plotComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.plotComboBox.Name = "plotComboBox";
            this.plotComboBox.Size = new System.Drawing.Size(100, 21);
            this.plotComboBox.TabIndex = 12;
            this.plotComboBox.SelectedIndexChanged += new System.EventHandler(this.plotComboBox_SelectedIndexChanged);
            // 
            // plotLabel
            // 
            this.plotLabel.AutoSize = true;
            this.plotLabel.Location = new System.Drawing.Point(954, 51);
            this.plotLabel.Name = "plotLabel";
            this.plotLabel.Size = new System.Drawing.Size(114, 13);
            this.plotLabel.TabIndex = 0;
            this.plotLabel.Text = "Frequency domain plot";
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.Image = global::BasicSynthesizer.Properties.Resources.Audio_16x;
            this.playButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playButton.Location = new System.Drawing.Point(897, 46);
            this.playButton.Margin = new System.Windows.Forms.Padding(2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(23, 23);
            this.playButton.TabIndex = 4;
            this.playButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mainToolTip.SetToolTip(this.playButton, "Some frequencies may not be supported by your audio device. ");
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // openAudioFileDialog
            // 
            this.openAudioFileDialog.Filter = "WAV file (*.wav)|*.wav";
            // 
            // audioInfoLabel
            // 
            this.audioInfoLabel.AutoSize = true;
            this.audioInfoLabel.Location = new System.Drawing.Point(948, 83);
            this.audioInfoLabel.Name = "audioInfoLabel";
            this.audioInfoLabel.Size = new System.Drawing.Size(0, 13);
            this.audioInfoLabel.TabIndex = 18;
            // 
            // saveAudioFileDialog
            // 
            this.saveAudioFileDialog.Filter = "WAV file (*.wav)|*.wav";
            // 
            // timeDomainPlotView
            // 
            this.timeDomainPlotView.Enabled = false;
            this.timeDomainPlotView.Location = new System.Drawing.Point(434, 83);
            this.timeDomainPlotView.Name = "timeDomainPlotView";
            this.timeDomainPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.timeDomainPlotView.Size = new System.Drawing.Size(738, 150);
            this.timeDomainPlotView.TabIndex = 19;
            this.timeDomainPlotView.Text = "plotView1";
            this.timeDomainPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.timeDomainPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.timeDomainPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // frequencyDomainPlotView
            // 
            this.frequencyDomainPlotView.Enabled = false;
            this.frequencyDomainPlotView.Location = new System.Drawing.Point(434, 239);
            this.frequencyDomainPlotView.Name = "frequencyDomainPlotView";
            this.frequencyDomainPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.frequencyDomainPlotView.Size = new System.Drawing.Size(738, 150);
            this.frequencyDomainPlotView.TabIndex = 20;
            this.frequencyDomainPlotView.Text = "plotView1";
            this.frequencyDomainPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.frequencyDomainPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.frequencyDomainPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.frequencyDomainPlotView);
            this.Controls.Add(this.timeDomainPlotView);
            this.Controls.Add(this.audioInfoLabel);
            this.Controls.Add(this.lfoGroupBox);
            this.Controls.Add(this.plotLabel);
            this.Controls.Add(this.plotComboBox);
            this.Controls.Add(this.adsrGroupBox);
            this.Controls.Add(this.filterGroupBox);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.durationNumericUpDown);
            this.Controls.Add(this.samplingRateComboBox);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.samplingRateLabel);
            this.Controls.Add(this.oscillatorsGroupBox);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Basic Synthesizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.oscillatorsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).EndInit();
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resonanceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterFrequencyTrackBar)).EndInit();
            this.adsrGroupBox.ResumeLayout(false);
            this.adsrGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attackTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decayTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sustainTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.releaseTrackBar)).EndInit();
            this.lfoGroupBox.ResumeLayout(false);
            this.lfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phaseTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lfoFrequencyTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox oscillatorsGroupBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView oscillatorsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.NumericUpDown durationNumericUpDown;
        private System.Windows.Forms.ComboBox samplingRateComboBox;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label samplingRateLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.Label resonanceLabel;
        private System.Windows.Forms.Label filterFrequencyLabel;
        private System.Windows.Forms.CheckBox filterApplyCheckBox;
        private System.Windows.Forms.RadioButton highPassRadioButton;
        private System.Windows.Forms.RadioButton lowPassRadioButton;
        private System.Windows.Forms.GroupBox adsrGroupBox;
        private System.Windows.Forms.CheckBox adsrApplyCheckBox;
        private System.Windows.Forms.Label releaseLabel;
        private System.Windows.Forms.Label sustainLabel;
        private System.Windows.Forms.Label decayLabel;
        private System.Windows.Forms.Label attackLabel;
        private System.Windows.Forms.GroupBox lfoGroupBox;
        private System.Windows.Forms.CheckBox lfoApplyCheckBox;
        private System.Windows.Forms.ComboBox waveformComboBox;
        private System.Windows.Forms.Label waveformLabel;
        private System.Windows.Forms.TrackBar resonanceTrackBar;
        private System.Windows.Forms.TrackBar filterFrequencyTrackBar;
        private System.Windows.Forms.TrackBar attackTrackBar;
        private System.Windows.Forms.TrackBar decayTrackBar;
        private System.Windows.Forms.TrackBar sustainTrackBar;
        private System.Windows.Forms.TrackBar releaseTrackBar;
        private System.Windows.Forms.Label lfoFrequencyLabel;
        private System.Windows.Forms.TrackBar lfoFrequencyTrackBar;
        private System.Windows.Forms.Label resonanceValueLabel;
        private System.Windows.Forms.Label filterFrequencyValueLabel;
        private System.Windows.Forms.Label releaseValueLabel;
        private System.Windows.Forms.Label sustainValueLabel;
        private System.Windows.Forms.Label decayValueLabel;
        private System.Windows.Forms.Label attackValueLabel;
        private System.Windows.Forms.Label lfoFrequencyValueLabel;
        private System.Windows.Forms.ComboBox plotComboBox;
        private System.Windows.Forms.Label plotLabel;
        private System.Windows.Forms.RadioButton bandPassRadioButton;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.Label amplitudeValueLabel;
        private System.Windows.Forms.Label amplitudeLabel;
        private System.Windows.Forms.TrackBar amplitudeTrackBar;
        private System.Windows.Forms.Label phaseValueLabel;
        private System.Windows.Forms.Label phaseLabel;
        private System.Windows.Forms.TrackBar phaseTrackBar;
        private System.Windows.Forms.OpenFileDialog openAudioFileDialog;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteAudioButton;
        private System.Windows.Forms.Label audioInfoLabel;
        private System.Windows.Forms.SaveFileDialog saveAudioFileDialog;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private OxyPlot.WindowsForms.PlotView timeDomainPlotView;
        private OxyPlot.WindowsForms.PlotView frequencyDomainPlotView;
    }
}

