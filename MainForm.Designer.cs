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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.oscillatorsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.importButton = new System.Windows.Forms.Button();
            this.timeDomainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.durationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.samplingRateComboBox = new System.Windows.Forms.ComboBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.samplingRateLabel = new System.Windows.Forms.Label();
            this.frequencyDomainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.timeDomainPanValueLabel = new System.Windows.Forms.Label();
            this.timeDomainPanLabel = new System.Windows.Forms.Label();
            this.timeDomainPanTrackBar = new System.Windows.Forms.TrackBar();
            this.timeDomainZoomValueLabel = new System.Windows.Forms.Label();
            this.timeDomainZoomLabel = new System.Windows.Forms.Label();
            this.timeDomainZoomTrackBar = new System.Windows.Forms.TrackBar();
            this.frequencyDomainPanValueLabel = new System.Windows.Forms.Label();
            this.frequencyDomainPanLabel = new System.Windows.Forms.Label();
            this.frequencyDomainZoomValueLabel = new System.Windows.Forms.Label();
            this.frequencyDomainZoomLabel = new System.Windows.Forms.Label();
            this.frequencyDomainZoomTrackBar = new System.Windows.Forms.TrackBar();
            this.frequencyDomainPanTrackBar = new System.Windows.Forms.TrackBar();
            this.plotComboBox = new System.Windows.Forms.ComboBox();
            this.plotLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openAudioFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.deleteAudioButton = new System.Windows.Forms.Button();
            this.audioInfoLabel = new System.Windows.Forms.Label();
            this.saveAudioFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainMenuStrip.SuspendLayout();
            this.oscillatorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeDomainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyDomainChart)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.timeDomainPanTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeDomainZoomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyDomainZoomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyDomainPanTrackBar)).BeginInit();
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
            this.oscillatorsGroupBox.Controls.Add(this.oscillatorsListView);
            this.oscillatorsGroupBox.Location = new System.Drawing.Point(12, 27);
            this.oscillatorsGroupBox.Name = "oscillatorsGroupBox";
            this.oscillatorsGroupBox.Size = new System.Drawing.Size(416, 406);
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
            this.deleteButton.Location = new System.Drawing.Point(335, 17);
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
            this.oscillatorsListView.Size = new System.Drawing.Size(404, 352);
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
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(948, 46);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(120, 23);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Import audio (*.wav)";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // timeDomainChart
            // 
            chartArea1.AxisX.LabelStyle.Format = "{0.000}";
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.Title = "Time (s)";
            chartArea1.AxisY.LabelStyle.Format = "{0.00}";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Title = "Intensity";
            chartArea1.Name = "ChartArea1";
            this.timeDomainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.timeDomainChart.Legends.Add(legend1);
            this.timeDomainChart.Location = new System.Drawing.Point(433, 83);
            this.timeDomainChart.Margin = new System.Windows.Forms.Padding(2);
            this.timeDomainChart.Name = "timeDomainChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Wave";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Silver;
            series2.Enabled = false;
            series2.Legend = "Legend1";
            series2.Name = "LFO";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Enabled = false;
            series3.Legend = "Legend1";
            series3.Name = "ADSR";
            series3.Points.Add(dataPoint1);
            series3.Points.Add(dataPoint2);
            series3.Points.Add(dataPoint3);
            series3.Points.Add(dataPoint4);
            series3.Points.Add(dataPoint5);
            this.timeDomainChart.Series.Add(series1);
            this.timeDomainChart.Series.Add(series2);
            this.timeDomainChart.Series.Add(series3);
            this.timeDomainChart.Size = new System.Drawing.Size(500, 170);
            this.timeDomainChart.TabIndex = 8;
            this.timeDomainChart.TabStop = false;
            this.timeDomainChart.Text = "Time Domain";
            title1.Name = "Title1";
            title1.Text = "Time Domain";
            this.timeDomainChart.Titles.Add(title1);
            // 
            // durationNumericUpDown
            // 
            this.durationNumericUpDown.DecimalPlaces = 2;
            this.durationNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.durationNumericUpDown.Location = new System.Drawing.Point(744, 47);
            this.durationNumericUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.durationNumericUpDown.Name = "durationNumericUpDown";
            this.durationNumericUpDown.Size = new System.Drawing.Size(60, 20);
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
            this.durationLabel.Location = new System.Drawing.Point(677, 49);
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
            // frequencyDomainChart
            // 
            chartArea2.AxisX.LabelStyle.Format = "{0}";
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.Title = "Frequency (Hz)";
            chartArea2.AxisY.LabelStyle.Format = "{0.00}";
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.Title = "Intensity";
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.Name = "ChartArea1";
            this.frequencyDomainChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.frequencyDomainChart.Legends.Add(legend2);
            this.frequencyDomainChart.Location = new System.Drawing.Point(433, 257);
            this.frequencyDomainChart.Margin = new System.Windows.Forms.Padding(2);
            this.frequencyDomainChart.Name = "frequencyDomainChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.Legend = "Legend1";
            series4.Name = "Magnitude";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Blue;
            series5.Enabled = false;
            series5.Legend = "Legend1";
            series5.Name = "Real";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Blue;
            series6.Enabled = false;
            series6.Legend = "Legend1";
            series6.Name = "Imaginary";
            this.frequencyDomainChart.Series.Add(series4);
            this.frequencyDomainChart.Series.Add(series5);
            this.frequencyDomainChart.Series.Add(series6);
            this.frequencyDomainChart.Size = new System.Drawing.Size(500, 170);
            this.frequencyDomainChart.TabIndex = 11;
            this.frequencyDomainChart.TabStop = false;
            this.frequencyDomainChart.Text = "Frequency Domain";
            title2.Name = "Title1";
            title2.Text = "Frequency Domain";
            this.frequencyDomainChart.Titles.Add(title2);
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
            this.filterGroupBox.Location = new System.Drawing.Point(12, 439);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(350, 250);
            this.filterGroupBox.TabIndex = 15;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filter";
            // 
            // bandPassRadioButton
            // 
            this.bandPassRadioButton.AutoSize = true;
            this.bandPassRadioButton.Location = new System.Drawing.Point(226, 85);
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
            this.resonanceValueLabel.Location = new System.Drawing.Point(292, 189);
            this.resonanceValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resonanceValueLabel.Name = "resonanceValueLabel";
            this.resonanceValueLabel.Size = new System.Drawing.Size(21, 13);
            this.resonanceValueLabel.TabIndex = 0;
            this.resonanceValueLabel.Text = "0%";
            // 
            // filterFrequencyValueLabel
            // 
            this.filterFrequencyValueLabel.AutoSize = true;
            this.filterFrequencyValueLabel.Location = new System.Drawing.Point(292, 141);
            this.filterFrequencyValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filterFrequencyValueLabel.Name = "filterFrequencyValueLabel";
            this.filterFrequencyValueLabel.Size = new System.Drawing.Size(41, 13);
            this.filterFrequencyValueLabel.TabIndex = 0;
            this.filterFrequencyValueLabel.Text = "500 Hz";
            // 
            // resonanceTrackBar
            // 
            this.resonanceTrackBar.Location = new System.Drawing.Point(87, 189);
            this.resonanceTrackBar.Maximum = 100;
            this.resonanceTrackBar.Name = "resonanceTrackBar";
            this.resonanceTrackBar.Size = new System.Drawing.Size(200, 45);
            this.resonanceTrackBar.TabIndex = 5;
            this.resonanceTrackBar.TickFrequency = 10;
            this.resonanceTrackBar.Scroll += new System.EventHandler(this.resonanceTrackBar_Scroll);
            // 
            // filterFrequencyTrackBar
            // 
            this.filterFrequencyTrackBar.Location = new System.Drawing.Point(87, 138);
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
            this.resonanceLabel.Location = new System.Drawing.Point(25, 189);
            this.resonanceLabel.Name = "resonanceLabel";
            this.resonanceLabel.Size = new System.Drawing.Size(62, 13);
            this.resonanceLabel.TabIndex = 0;
            this.resonanceLabel.Text = "Resonance";
            // 
            // filterFrequencyLabel
            // 
            this.filterFrequencyLabel.AutoSize = true;
            this.filterFrequencyLabel.Location = new System.Drawing.Point(30, 141);
            this.filterFrequencyLabel.Name = "filterFrequencyLabel";
            this.filterFrequencyLabel.Size = new System.Drawing.Size(57, 13);
            this.filterFrequencyLabel.TabIndex = 0;
            this.filterFrequencyLabel.Text = "Frequency";
            // 
            // filterApplyCheckBox
            // 
            this.filterApplyCheckBox.AutoSize = true;
            this.filterApplyCheckBox.Location = new System.Drawing.Point(28, 35);
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
            this.highPassRadioButton.Location = new System.Drawing.Point(134, 85);
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
            this.lowPassRadioButton.Location = new System.Drawing.Point(44, 85);
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
            this.adsrGroupBox.Location = new System.Drawing.Point(744, 439);
            this.adsrGroupBox.Name = "adsrGroupBox";
            this.adsrGroupBox.Size = new System.Drawing.Size(428, 250);
            this.adsrGroupBox.TabIndex = 17;
            this.adsrGroupBox.TabStop = false;
            this.adsrGroupBox.Text = "Envelope (ADSR)";
            // 
            // releaseValueLabel
            // 
            this.releaseValueLabel.AutoSize = true;
            this.releaseValueLabel.Location = new System.Drawing.Point(374, 189);
            this.releaseValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.releaseValueLabel.Name = "releaseValueLabel";
            this.releaseValueLabel.Size = new System.Drawing.Size(30, 13);
            this.releaseValueLabel.TabIndex = 0;
            this.releaseValueLabel.Text = "0.4 s";
            // 
            // sustainValueLabel
            // 
            this.sustainValueLabel.AutoSize = true;
            this.sustainValueLabel.Location = new System.Drawing.Point(374, 141);
            this.sustainValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sustainValueLabel.Name = "sustainValueLabel";
            this.sustainValueLabel.Size = new System.Drawing.Size(27, 13);
            this.sustainValueLabel.TabIndex = 0;
            this.sustainValueLabel.Text = "80%";
            // 
            // decayValueLabel
            // 
            this.decayValueLabel.AutoSize = true;
            this.decayValueLabel.Location = new System.Drawing.Point(374, 87);
            this.decayValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.decayValueLabel.Name = "decayValueLabel";
            this.decayValueLabel.Size = new System.Drawing.Size(30, 13);
            this.decayValueLabel.TabIndex = 0;
            this.decayValueLabel.Text = "0.2 s";
            // 
            // attackValueLabel
            // 
            this.attackValueLabel.AutoSize = true;
            this.attackValueLabel.Location = new System.Drawing.Point(374, 36);
            this.attackValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.attackValueLabel.Name = "attackValueLabel";
            this.attackValueLabel.Size = new System.Drawing.Size(30, 13);
            this.attackValueLabel.TabIndex = 0;
            this.attackValueLabel.Text = "0.2 s";
            // 
            // attackTrackBar
            // 
            this.attackTrackBar.Location = new System.Drawing.Point(169, 36);
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
            this.decayTrackBar.Location = new System.Drawing.Point(169, 87);
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
            this.sustainTrackBar.Location = new System.Drawing.Point(169, 138);
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
            this.releaseTrackBar.Location = new System.Drawing.Point(169, 189);
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
            this.adsrApplyCheckBox.Location = new System.Drawing.Point(28, 35);
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
            this.releaseLabel.Location = new System.Drawing.Point(103, 189);
            this.releaseLabel.Name = "releaseLabel";
            this.releaseLabel.Size = new System.Drawing.Size(60, 13);
            this.releaseLabel.TabIndex = 0;
            this.releaseLabel.Text = "Release (s)";
            // 
            // sustainLabel
            // 
            this.sustainLabel.AutoSize = true;
            this.sustainLabel.Location = new System.Drawing.Point(104, 138);
            this.sustainLabel.Name = "sustainLabel";
            this.sustainLabel.Size = new System.Drawing.Size(59, 13);
            this.sustainLabel.TabIndex = 0;
            this.sustainLabel.Text = "Sustain (%)";
            // 
            // decayLabel
            // 
            this.decayLabel.AutoSize = true;
            this.decayLabel.Location = new System.Drawing.Point(111, 87);
            this.decayLabel.Name = "decayLabel";
            this.decayLabel.Size = new System.Drawing.Size(52, 13);
            this.decayLabel.TabIndex = 0;
            this.decayLabel.Text = "Decay (s)";
            // 
            // attackLabel
            // 
            this.attackLabel.AutoSize = true;
            this.attackLabel.Location = new System.Drawing.Point(111, 36);
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
            this.lfoGroupBox.Location = new System.Drawing.Point(368, 439);
            this.lfoGroupBox.Name = "lfoGroupBox";
            this.lfoGroupBox.Size = new System.Drawing.Size(370, 250);
            this.lfoGroupBox.TabIndex = 16;
            this.lfoGroupBox.TabStop = false;
            this.lfoGroupBox.Text = "Low-frequency Oscillator (LFO)";
            // 
            // phaseValueLabel
            // 
            this.phaseValueLabel.AutoSize = true;
            this.phaseValueLabel.Location = new System.Drawing.Point(307, 189);
            this.phaseValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phaseValueLabel.Name = "phaseValueLabel";
            this.phaseValueLabel.Size = new System.Drawing.Size(17, 13);
            this.phaseValueLabel.TabIndex = 0;
            this.phaseValueLabel.Text = "0°";
            // 
            // phaseLabel
            // 
            this.phaseLabel.AutoSize = true;
            this.phaseLabel.Location = new System.Drawing.Point(59, 189);
            this.phaseLabel.Name = "phaseLabel";
            this.phaseLabel.Size = new System.Drawing.Size(37, 13);
            this.phaseLabel.TabIndex = 0;
            this.phaseLabel.Text = "Phase";
            // 
            // phaseTrackBar
            // 
            this.phaseTrackBar.Location = new System.Drawing.Point(102, 189);
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
            this.amplitudeValueLabel.Location = new System.Drawing.Point(307, 138);
            this.amplitudeValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.amplitudeValueLabel.Name = "amplitudeValueLabel";
            this.amplitudeValueLabel.Size = new System.Drawing.Size(13, 13);
            this.amplitudeValueLabel.TabIndex = 0;
            this.amplitudeValueLabel.Text = "1";
            // 
            // amplitudeLabel
            // 
            this.amplitudeLabel.AutoSize = true;
            this.amplitudeLabel.Location = new System.Drawing.Point(43, 138);
            this.amplitudeLabel.Name = "amplitudeLabel";
            this.amplitudeLabel.Size = new System.Drawing.Size(53, 13);
            this.amplitudeLabel.TabIndex = 0;
            this.amplitudeLabel.Text = "Amplitude";
            // 
            // amplitudeTrackBar
            // 
            this.amplitudeTrackBar.Location = new System.Drawing.Point(102, 138);
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
            this.lfoFrequencyValueLabel.Location = new System.Drawing.Point(307, 87);
            this.lfoFrequencyValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lfoFrequencyValueLabel.Name = "lfoFrequencyValueLabel";
            this.lfoFrequencyValueLabel.Size = new System.Drawing.Size(35, 13);
            this.lfoFrequencyValueLabel.TabIndex = 0;
            this.lfoFrequencyValueLabel.Text = "10 Hz";
            // 
            // lfoFrequencyLabel
            // 
            this.lfoFrequencyLabel.AutoSize = true;
            this.lfoFrequencyLabel.Location = new System.Drawing.Point(17, 87);
            this.lfoFrequencyLabel.Name = "lfoFrequencyLabel";
            this.lfoFrequencyLabel.Size = new System.Drawing.Size(79, 13);
            this.lfoFrequencyLabel.TabIndex = 0;
            this.lfoFrequencyLabel.Text = "Frequency (Hz)";
            // 
            // lfoFrequencyTrackBar
            // 
            this.lfoFrequencyTrackBar.Location = new System.Drawing.Point(102, 87);
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
            this.lfoApplyCheckBox.Location = new System.Drawing.Point(29, 35);
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
            this.waveformComboBox.Location = new System.Drawing.Point(181, 33);
            this.waveformComboBox.Name = "waveformComboBox";
            this.waveformComboBox.Size = new System.Drawing.Size(121, 21);
            this.waveformComboBox.TabIndex = 1;
            // 
            // waveformLabel
            // 
            this.waveformLabel.AutoSize = true;
            this.waveformLabel.Location = new System.Drawing.Point(119, 36);
            this.waveformLabel.Name = "waveformLabel";
            this.waveformLabel.Size = new System.Drawing.Size(56, 13);
            this.waveformLabel.TabIndex = 0;
            this.waveformLabel.Text = "Waveform";
            // 
            // timeDomainPanValueLabel
            // 
            this.timeDomainPanValueLabel.AutoSize = true;
            this.timeDomainPanValueLabel.Location = new System.Drawing.Point(1140, 199);
            this.timeDomainPanValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeDomainPanValueLabel.Name = "timeDomainPanValueLabel";
            this.timeDomainPanValueLabel.Size = new System.Drawing.Size(21, 13);
            this.timeDomainPanValueLabel.TabIndex = 0;
            this.timeDomainPanValueLabel.Text = "0%";
            // 
            // timeDomainPanLabel
            // 
            this.timeDomainPanLabel.AutoSize = true;
            this.timeDomainPanLabel.Location = new System.Drawing.Point(953, 199);
            this.timeDomainPanLabel.Name = "timeDomainPanLabel";
            this.timeDomainPanLabel.Size = new System.Drawing.Size(26, 13);
            this.timeDomainPanLabel.TabIndex = 0;
            this.timeDomainPanLabel.Text = "Pan";
            // 
            // timeDomainPanTrackBar
            // 
            this.timeDomainPanTrackBar.Enabled = false;
            this.timeDomainPanTrackBar.Location = new System.Drawing.Point(985, 199);
            this.timeDomainPanTrackBar.Maximum = 0;
            this.timeDomainPanTrackBar.Name = "timeDomainPanTrackBar";
            this.timeDomainPanTrackBar.Size = new System.Drawing.Size(150, 45);
            this.timeDomainPanTrackBar.TabIndex = 10;
            this.timeDomainPanTrackBar.TickFrequency = 10;
            this.timeDomainPanTrackBar.Scroll += new System.EventHandler(this.timeDomainPanTrackBar_Scroll);
            // 
            // timeDomainZoomValueLabel
            // 
            this.timeDomainZoomValueLabel.AutoSize = true;
            this.timeDomainZoomValueLabel.Location = new System.Drawing.Point(1139, 148);
            this.timeDomainZoomValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeDomainZoomValueLabel.Name = "timeDomainZoomValueLabel";
            this.timeDomainZoomValueLabel.Size = new System.Drawing.Size(33, 13);
            this.timeDomainZoomValueLabel.TabIndex = 0;
            this.timeDomainZoomValueLabel.Text = "100%";
            // 
            // timeDomainZoomLabel
            // 
            this.timeDomainZoomLabel.AutoSize = true;
            this.timeDomainZoomLabel.Location = new System.Drawing.Point(945, 148);
            this.timeDomainZoomLabel.Name = "timeDomainZoomLabel";
            this.timeDomainZoomLabel.Size = new System.Drawing.Size(34, 13);
            this.timeDomainZoomLabel.TabIndex = 0;
            this.timeDomainZoomLabel.Text = "Zoom";
            // 
            // timeDomainZoomTrackBar
            // 
            this.timeDomainZoomTrackBar.Enabled = false;
            this.timeDomainZoomTrackBar.Location = new System.Drawing.Point(985, 148);
            this.timeDomainZoomTrackBar.Maximum = 100;
            this.timeDomainZoomTrackBar.Minimum = 1;
            this.timeDomainZoomTrackBar.Name = "timeDomainZoomTrackBar";
            this.timeDomainZoomTrackBar.Size = new System.Drawing.Size(150, 45);
            this.timeDomainZoomTrackBar.TabIndex = 9;
            this.timeDomainZoomTrackBar.TickFrequency = 10;
            this.timeDomainZoomTrackBar.Value = 100;
            this.timeDomainZoomTrackBar.Scroll += new System.EventHandler(this.timeDomainZoomTrackBar_Scroll);
            // 
            // frequencyDomainPanValueLabel
            // 
            this.frequencyDomainPanValueLabel.AutoSize = true;
            this.frequencyDomainPanValueLabel.Location = new System.Drawing.Point(1140, 376);
            this.frequencyDomainPanValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.frequencyDomainPanValueLabel.Name = "frequencyDomainPanValueLabel";
            this.frequencyDomainPanValueLabel.Size = new System.Drawing.Size(21, 13);
            this.frequencyDomainPanValueLabel.TabIndex = 0;
            this.frequencyDomainPanValueLabel.Text = "0%";
            // 
            // frequencyDomainPanLabel
            // 
            this.frequencyDomainPanLabel.AutoSize = true;
            this.frequencyDomainPanLabel.Location = new System.Drawing.Point(953, 376);
            this.frequencyDomainPanLabel.Name = "frequencyDomainPanLabel";
            this.frequencyDomainPanLabel.Size = new System.Drawing.Size(26, 13);
            this.frequencyDomainPanLabel.TabIndex = 0;
            this.frequencyDomainPanLabel.Text = "Pan";
            // 
            // frequencyDomainZoomValueLabel
            // 
            this.frequencyDomainZoomValueLabel.AutoSize = true;
            this.frequencyDomainZoomValueLabel.Location = new System.Drawing.Point(1139, 325);
            this.frequencyDomainZoomValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.frequencyDomainZoomValueLabel.Name = "frequencyDomainZoomValueLabel";
            this.frequencyDomainZoomValueLabel.Size = new System.Drawing.Size(33, 13);
            this.frequencyDomainZoomValueLabel.TabIndex = 0;
            this.frequencyDomainZoomValueLabel.Text = "100%";
            // 
            // frequencyDomainZoomLabel
            // 
            this.frequencyDomainZoomLabel.AutoSize = true;
            this.frequencyDomainZoomLabel.Location = new System.Drawing.Point(945, 325);
            this.frequencyDomainZoomLabel.Name = "frequencyDomainZoomLabel";
            this.frequencyDomainZoomLabel.Size = new System.Drawing.Size(34, 13);
            this.frequencyDomainZoomLabel.TabIndex = 0;
            this.frequencyDomainZoomLabel.Text = "Zoom";
            // 
            // frequencyDomainZoomTrackBar
            // 
            this.frequencyDomainZoomTrackBar.Enabled = false;
            this.frequencyDomainZoomTrackBar.Location = new System.Drawing.Point(985, 325);
            this.frequencyDomainZoomTrackBar.Maximum = 100;
            this.frequencyDomainZoomTrackBar.Minimum = 1;
            this.frequencyDomainZoomTrackBar.Name = "frequencyDomainZoomTrackBar";
            this.frequencyDomainZoomTrackBar.Size = new System.Drawing.Size(150, 45);
            this.frequencyDomainZoomTrackBar.TabIndex = 13;
            this.frequencyDomainZoomTrackBar.TickFrequency = 10;
            this.frequencyDomainZoomTrackBar.Value = 100;
            this.frequencyDomainZoomTrackBar.Scroll += new System.EventHandler(this.frequencyDomainZoomTrackBar_Scroll);
            // 
            // frequencyDomainPanTrackBar
            // 
            this.frequencyDomainPanTrackBar.Enabled = false;
            this.frequencyDomainPanTrackBar.Location = new System.Drawing.Point(985, 376);
            this.frequencyDomainPanTrackBar.Maximum = 0;
            this.frequencyDomainPanTrackBar.Name = "frequencyDomainPanTrackBar";
            this.frequencyDomainPanTrackBar.Size = new System.Drawing.Size(150, 45);
            this.frequencyDomainPanTrackBar.TabIndex = 17;
            this.frequencyDomainPanTrackBar.TickFrequency = 10;
            this.frequencyDomainPanTrackBar.Scroll += new System.EventHandler(this.frequencyDomainPanTrackBar_Scroll);
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
            this.plotComboBox.Location = new System.Drawing.Point(985, 267);
            this.plotComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.plotComboBox.Name = "plotComboBox";
            this.plotComboBox.Size = new System.Drawing.Size(121, 21);
            this.plotComboBox.TabIndex = 12;
            this.plotComboBox.SelectedIndexChanged += new System.EventHandler(this.plotComboBox_SelectedIndexChanged);
            // 
            // plotLabel
            // 
            this.plotLabel.AutoSize = true;
            this.plotLabel.Location = new System.Drawing.Point(954, 270);
            this.plotLabel.Name = "plotLabel";
            this.plotLabel.Size = new System.Drawing.Size(25, 13);
            this.plotLabel.TabIndex = 0;
            this.plotLabel.Text = "Plot";
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.Image = global::BasicSynthesizer.Properties.Resources.Audio_16x;
            this.playButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playButton.Location = new System.Drawing.Point(815, 46);
            this.playButton.Margin = new System.Windows.Forms.Padding(2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(23, 23);
            this.playButton.TabIndex = 4;
            this.playButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mainToolTip.SetToolTip(this.playButton, "Some frequencies may not be supported by your audio device. ");
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(843, 46);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(90, 23);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export (*.wav)";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // openAudioFileDialog
            // 
            this.openAudioFileDialog.Filter = "WAV file (*.wav)|*.wav";
            // 
            // deleteAudioButton
            // 
            this.deleteAudioButton.Enabled = false;
            this.deleteAudioButton.Location = new System.Drawing.Point(1074, 46);
            this.deleteAudioButton.Name = "deleteAudioButton";
            this.deleteAudioButton.Size = new System.Drawing.Size(98, 23);
            this.deleteAudioButton.TabIndex = 7;
            this.deleteAudioButton.Text = "Delete audio";
            this.deleteAudioButton.UseVisualStyleBackColor = true;
            this.deleteAudioButton.Click += new System.EventHandler(this.deleteAudioButton_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 701);
            this.Controls.Add(this.audioInfoLabel);
            this.Controls.Add(this.deleteAudioButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.plotLabel);
            this.Controls.Add(this.plotComboBox);
            this.Controls.Add(this.frequencyDomainPanTrackBar);
            this.Controls.Add(this.frequencyDomainPanValueLabel);
            this.Controls.Add(this.frequencyDomainPanLabel);
            this.Controls.Add(this.frequencyDomainZoomValueLabel);
            this.Controls.Add(this.frequencyDomainZoomLabel);
            this.Controls.Add(this.frequencyDomainZoomTrackBar);
            this.Controls.Add(this.timeDomainPanValueLabel);
            this.Controls.Add(this.timeDomainPanLabel);
            this.Controls.Add(this.timeDomainPanTrackBar);
            this.Controls.Add(this.timeDomainZoomValueLabel);
            this.Controls.Add(this.timeDomainZoomLabel);
            this.Controls.Add(this.timeDomainZoomTrackBar);
            this.Controls.Add(this.lfoGroupBox);
            this.Controls.Add(this.adsrGroupBox);
            this.Controls.Add(this.filterGroupBox);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.frequencyDomainChart);
            this.Controls.Add(this.durationNumericUpDown);
            this.Controls.Add(this.samplingRateComboBox);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.samplingRateLabel);
            this.Controls.Add(this.timeDomainChart);
            this.Controls.Add(this.oscillatorsGroupBox);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Basic Synthesizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.oscillatorsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeDomainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyDomainChart)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.timeDomainPanTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeDomainZoomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyDomainZoomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyDomainPanTrackBar)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart timeDomainChart;
        private System.Windows.Forms.NumericUpDown durationNumericUpDown;
        private System.Windows.Forms.ComboBox samplingRateComboBox;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label samplingRateLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart frequencyDomainChart;
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
        private System.Windows.Forms.Label timeDomainPanValueLabel;
        private System.Windows.Forms.Label timeDomainPanLabel;
        private System.Windows.Forms.TrackBar timeDomainPanTrackBar;
        private System.Windows.Forms.Label timeDomainZoomValueLabel;
        private System.Windows.Forms.Label timeDomainZoomLabel;
        private System.Windows.Forms.TrackBar timeDomainZoomTrackBar;
        private System.Windows.Forms.Label frequencyDomainPanValueLabel;
        private System.Windows.Forms.Label frequencyDomainPanLabel;
        private System.Windows.Forms.Label frequencyDomainZoomValueLabel;
        private System.Windows.Forms.Label frequencyDomainZoomLabel;
        private System.Windows.Forms.TrackBar frequencyDomainZoomTrackBar;
        private System.Windows.Forms.TrackBar frequencyDomainPanTrackBar;
        private System.Windows.Forms.ComboBox plotComboBox;
        private System.Windows.Forms.Label plotLabel;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
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
    }
}

