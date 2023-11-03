using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCCatalogItem : UserControl
    {
        public event System.EventHandler<int> OnClickItem;

        private string title;

        public int Id { get; set; }
        public string Title { get { return title; } set { title = value; label1.Text = value; } }

        public UCCatalogItem()
        {
            InitializeComponent();
        }

        public void SetSelect(bool sel)
        {
            BackColor = sel ? Color.FromArgb(70, 20, 20) : Color.FromArgb(24, 24, 24);
        }

        private void UCMenuItem_Click(object sender, System.EventArgs e)
        {
            if (OnClickItem != null)
                OnClickItem(this, 0);
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            if (OnClickItem != null)
                OnClickItem(this, 1);
        }
    }
}
