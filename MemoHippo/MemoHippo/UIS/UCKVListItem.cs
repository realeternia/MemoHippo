using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCKVListItem : UserControl
    {
        public UCKVListItem()
        {
            InitializeComponent();
        }

        public void SetData(string k, string v)
        {
            label1.Text = k;
            if (!string.IsNullOrEmpty(v))
                hintTextBox1.Text = v;
        }
    }
}
