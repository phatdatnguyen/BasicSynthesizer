namespace BasicSynthesizer
{
    public partial class ChooseChannelDialog : Form
    {
        #region Property
        public string ChannelName { get; set; }
        #endregion

        #region Constructor
        public ChooseChannelDialog()
        {
            InitializeComponent();

            ChannelName = "Left";
        }
        #endregion

        #region Method
        private void ChooseChannelDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (leftRadioButton.Checked)
                    ChannelName = "Left";
                else
                    ChannelName = "Right";
            }
        }
        #endregion
    }
}
