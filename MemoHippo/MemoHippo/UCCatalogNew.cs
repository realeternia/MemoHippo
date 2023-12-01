using MemoHippo.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCCatalogNew : UserControl
    {
        public string Title { get; set; }
        public string PicPath { get; set; }

        public UCCatalogNew()
        {
            InitializeComponent();

            DoubleBuffered = true;
        }

        private void UCCatalogNew_Paint(object sender, PaintEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Title))
                e.Graphics.DrawString(Title, Font, System.Drawing.Brushes.White, 34, 5);

            e.Graphics.DrawImage(ResLoader.Read(PicPath), 5, 7, 24, 24);
        }

        private void UCCatalogNew_MouseEnter(object sender, System.EventArgs e)
        {
            BackColor = Color.FromArgb(64, 64, 64);
        }

        private void UCCatalogNew_MouseLeave(object sender, System.EventArgs e)
        {
            BackColor = Color.FromArgb(24, 24, 24);
        }
    }
}
