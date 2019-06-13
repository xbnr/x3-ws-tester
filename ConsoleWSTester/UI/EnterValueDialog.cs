using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTester.UI
{
    public partial class EnterValueDialog : Form
    {
        public EnterValueDialog()
        {
            InitializeComponent();
        }

        public string Label { get; set; }


        public void SetValue(string val)
        {
            textBoxEntry.Text = val;
        }

        public string GetEnteredValue()
        {
            return textBoxEntry.Text;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            // Close();
        }
    }
}
