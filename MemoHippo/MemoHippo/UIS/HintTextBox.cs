using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    class HintTextBox : TextBox
    {
        private string defaultText;

        public string DefaultText
        {
            get { return defaultText; }
            set { defaultText = value; }
        }

        public void OnLoad()
        {
            Text = defaultText; ForeColor = SystemColors.GrayText;
            this.Enter += new System.EventHandler(this.HintTextBox_Enter);
            this.Leave += new System.EventHandler(this.HintTextBox_Leave);
        }

        private void HintTextBox_Enter(object sender, EventArgs e)
        {
            if (Text == defaultText)
            {
                Text = "";
                ForeColor = Color.White;
            }
        }

        private void HintTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                Text = defaultText;
                ForeColor = SystemColors.GrayText;
            }
        }
    }
}
