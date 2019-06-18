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

        public string Label
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }


        public void SetValue(string val)
        {
            textBoxEntry.Text = val;
            enteredValue = val;
        }

        public string GetEnteredValue()
        {
            return enteredValue;
        }

        private string enteredValue = null;
        private void btOK_Click(object sender, EventArgs e)
        {
            enteredValue = textBoxEntry.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
