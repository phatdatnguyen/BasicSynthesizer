namespace BasicSynthesizer
{
    partial class OscillatorForm
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
            this.waveformComboBox = new System.Windows.Forms.ComboBox();
            this.waveformLabel = new System.Windows.Forms.Label();
            this.phaseNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.amplitudeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.phaseLabel = new System.Windows.Forms.Label();
            this.frequencyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.amplitudeLabel = new System.Windows.Forms.Label();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.ratioNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.notesComboBox = new System.Windows.Forms.ComboBox();
            this.noteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.phaseNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratioNumericUpDown)).BeginInit();
            this.SuspendLayout();
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
            this.waveformComboBox.Location = new System.Drawing.Point(99, 12);
            this.waveformComboBox.Name = "waveformComboBox";
            this.waveformComboBox.Size = new System.Drawing.Size(121, 21);
            this.waveformComboBox.TabIndex = 0;
            // 
            // waveformLabel
            // 
            this.waveformLabel.AutoSize = true;
            this.waveformLabel.Location = new System.Drawing.Point(37, 15);
            this.waveformLabel.Name = "waveformLabel";
            this.waveformLabel.Size = new System.Drawing.Size(56, 13);
            this.waveformLabel.TabIndex = 0;
            this.waveformLabel.Text = "Waveform";
            // 
            // phaseNumericUpDown
            // 
            this.phaseNumericUpDown.Location = new System.Drawing.Point(98, 91);
            this.phaseNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.phaseNumericUpDown.Name = "phaseNumericUpDown";
            this.phaseNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.phaseNumericUpDown.TabIndex = 4;
            // 
            // amplitudeNumericUpDown
            // 
            this.amplitudeNumericUpDown.DecimalPlaces = 2;
            this.amplitudeNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.amplitudeNumericUpDown.Location = new System.Drawing.Point(99, 65);
            this.amplitudeNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amplitudeNumericUpDown.Name = "amplitudeNumericUpDown";
            this.amplitudeNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.amplitudeNumericUpDown.TabIndex = 3;
            this.amplitudeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // phaseLabel
            // 
            this.phaseLabel.AutoSize = true;
            this.phaseLabel.Location = new System.Drawing.Point(38, 92);
            this.phaseLabel.Name = "phaseLabel";
            this.phaseLabel.Size = new System.Drawing.Size(50, 13);
            this.phaseLabel.TabIndex = 0;
            this.phaseLabel.Text = "Phase (°)";
            // 
            // frequencyNumericUpDown
            // 
            this.frequencyNumericUpDown.DecimalPlaces = 2;
            this.frequencyNumericUpDown.Location = new System.Drawing.Point(99, 39);
            this.frequencyNumericUpDown.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.frequencyNumericUpDown.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.frequencyNumericUpDown.Name = "frequencyNumericUpDown";
            this.frequencyNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.frequencyNumericUpDown.TabIndex = 1;
            this.frequencyNumericUpDown.Value = new decimal(new int[] {
            26163,
            0,
            0,
            131072});
            // 
            // amplitudeLabel
            // 
            this.amplitudeLabel.AutoSize = true;
            this.amplitudeLabel.Location = new System.Drawing.Point(40, 67);
            this.amplitudeLabel.Name = "amplitudeLabel";
            this.amplitudeLabel.Size = new System.Drawing.Size(53, 13);
            this.amplitudeLabel.TabIndex = 0;
            this.amplitudeLabel.Text = "Amplitude";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(14, 41);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(79, 13);
            this.frequencyLabel.TabIndex = 0;
            this.frequencyLabel.Text = "Frequency (Hz)";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(277, 156);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(196, 156);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // ratioNumericUpDown
            // 
            this.ratioNumericUpDown.Location = new System.Drawing.Point(98, 117);
            this.ratioNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ratioNumericUpDown.Name = "ratioNumericUpDown";
            this.ratioNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.ratioNumericUpDown.TabIndex = 5;
            this.ratioNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ratioLabel
            // 
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.Location = new System.Drawing.Point(56, 119);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(32, 13);
            this.ratioLabel.TabIndex = 0;
            this.ratioLabel.Text = "Ratio";
            // 
            // notesComboBox
            // 
            this.notesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.notesComboBox.FormattingEnabled = true;
            this.notesComboBox.Location = new System.Drawing.Point(252, 38);
            this.notesComboBox.Name = "notesComboBox";
            this.notesComboBox.Size = new System.Drawing.Size(100, 21);
            this.notesComboBox.TabIndex = 2;
            this.notesComboBox.SelectedIndexChanged += new System.EventHandler(this.noteComboBox_SelectedIndexChanged);
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(179, 41);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(67, 13);
            this.noteLabel.TabIndex = 0;
            this.noteLabel.Text = "Musical note";
            // 
            // OscillatorForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(364, 191);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.notesComboBox);
            this.Controls.Add(this.ratioNumericUpDown);
            this.Controls.Add(this.ratioLabel);
            this.Controls.Add(this.waveformComboBox);
            this.Controls.Add(this.waveformLabel);
            this.Controls.Add(this.phaseNumericUpDown);
            this.Controls.Add(this.amplitudeNumericUpDown);
            this.Controls.Add(this.phaseLabel);
            this.Controls.Add(this.frequencyNumericUpDown);
            this.Controls.Add(this.amplitudeLabel);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OscillatorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Oscillator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OscillatorForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.phaseNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratioNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox waveformComboBox;
        private System.Windows.Forms.Label waveformLabel;
        private System.Windows.Forms.NumericUpDown phaseNumericUpDown;
        private System.Windows.Forms.NumericUpDown amplitudeNumericUpDown;
        private System.Windows.Forms.Label phaseLabel;
        private System.Windows.Forms.NumericUpDown frequencyNumericUpDown;
        private System.Windows.Forms.Label amplitudeLabel;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown ratioNumericUpDown;
        private System.Windows.Forms.Label ratioLabel;
        private System.Windows.Forms.ComboBox notesComboBox;
        private System.Windows.Forms.Label noteLabel;
    }
}