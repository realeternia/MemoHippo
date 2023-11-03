using MemoHippo.Model;
using System;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCRowCommon : UserControl, IRowItem
    {
        public event MouseEventHandler NLMouseClick;
        public event MouseEventHandler NLMouseDown;

        public UCRowCommon()
        {
            InitializeComponent();

            MouseClick += UCRowCommon_MouseClick;
            label1.MouseClick += UCRowCommon_MouseClick;
            pictureBox1.MouseClick += UCRowCommon_MouseClick;

            MouseDown += UCRowCommon_MouseDown;
            label1.MouseDown += UCRowCommon_MouseDown;
            pictureBox1.MouseDown += UCRowCommon_MouseDown;
        }


        public void SetTitile(string str)
        {
            label1.Text = str;
        }

        private void UCRowCommon_MouseClick(object sender, MouseEventArgs e)
        {
            if (NLMouseClick != null)
                NLMouseClick(this, e);
        }
        private void UCRowCommon_MouseDown(object sender, MouseEventArgs e)
        {
            if (NLMouseDown != null)
                NLMouseDown(this, e);
        }
    }
}
