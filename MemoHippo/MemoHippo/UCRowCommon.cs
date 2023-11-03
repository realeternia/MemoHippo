using MemoHippo.Model;
using System;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCRowCommon : UserControl, IRowItem
    {
        public int ItemId { get; set; }
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

        public virtual void AfterInit()
        {
        }

        public void SetTitle(string str)
        {
            label1.Text = str;
        }

        public void SetIcon(string icon)
        {
            if (string.IsNullOrEmpty(icon))
                pictureBox1.Image = ResLoader.Read("Icon/atr0.PNG");
            else
                pictureBox1.Image = ResLoader.Read(icon);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ResLoader.Read("Icon/atr0.PNG");
        }

    }
}
