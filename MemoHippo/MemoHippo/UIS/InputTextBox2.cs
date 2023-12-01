using System;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class InputTextBox2 : UserControl
    {
        public event System.EventHandler<EventArgs> OnCustomTextChanged;

        public override string Text
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                    return "未命名";
                return textBox1.Text;
            }
            set { textBox1.Text = value; }
        }

        public Form1 Form1 { get; set; }

        public InputTextBox2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (OnCustomTextChanged != null)
                OnCustomTextChanged(this, e);

            Form1.HideBlackPanel();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (OnCustomTextChanged != null)
                    OnCustomTextChanged(this, e);
                e.Handled = true;

                Form1.HideBlackPanel();
            }
        }
    }
}
