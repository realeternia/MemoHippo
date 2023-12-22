using System;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCDocStringItem : UserControl, IDocComp
    {
        public Action<string> OnModify { get; set; } //todo 未实现

        public UCDocStringItem()
        {
            InitializeComponent();
        }

        public void SetData(string k, string v)
        {
            label1.Text = k;
            if (!string.IsNullOrEmpty(v))
                textBox1.Text = v;
        }
    }
}
