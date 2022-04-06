using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicSynthesizer
{
    public partial class ChooseChannelDialog : Form
    {
        // Properties
        public string ChannelName { get; set; }

        // Constructors
        public ChooseChannelDialog()
        {
            InitializeComponent();
        }

        // Methods
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
    }
}
