using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCCatalogItem : UserControl
    {
        public int Id { get; set; }
        public string Title { get; set; }

        private bool isSelected;
        private bool isMouseOn;


        public UCCatalogItem()
        {
            InitializeComponent();
        }

        public void SetSelect(bool sel)
        {
            isSelected = sel;
            UpdateBG();
        }

        private void UCCatalogItem_Paint(object sender, PaintEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Title))
                e.Graphics.DrawString(Title, Font, System.Drawing.Brushes.White, 34, 5);

            e.Graphics.DrawImage(ResLoader.Read("Icon/res6.PNG"), 5, 7, 24, 24);
        }

        private void UCCatalogItem_MouseEnter(object sender, System.EventArgs e)
        {
            isMouseOn = true;
            UpdateBG();
        }

        private void UCCatalogItem_MouseLeave(object sender, System.EventArgs e)
        {
            isMouseOn = false;
            UpdateBG();
        }

        private void UpdateBG()
        {
            if (isMouseOn)
            {
                BackColor = isSelected ? Color.FromArgb(90, 40, 40) : Color.FromArgb(64, 64, 64);
            }
            else
            {
                BackColor = isSelected ? Color.FromArgb(70, 20, 20) : Color.FromArgb(24, 24, 24);
            }
        }
    }
}
