using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ucMenuNew1.tbutton1.Click += Tbutton1_Click;

            TestInit();
        }

        private void Tbutton1_Click(object sender, System.EventArgs e)
        {
            MemoBook.Instance.AddCatalog();

            RefreshMenu();

            var newItem = new UCMenuItem();
            flowLayoutPanel1.Controls.Add(newItem);
            flowLayoutPanel1.Controls.SetChildIndex(ucMenuNew1, flowLayoutPanel1.Controls.Count-1);
        }

        private void RefreshMenu()
        {

        }

        private void TestInit()
        {
            AddUCTool("学习", Color.FromArgb(0x40, 0x33, 0x24));
            AddUCTool("工作", Color.FromArgb(0x1b, 0x2d, 0x38));
            AddUCTool("计划", Color.FromArgb(0x3e, 0x28, 0x25));
        }

        private void AddUCTool(string title, Color c)
        {
            var uctool = new UCTipGroup();
         //   
            uctool.Height = panel1.Height - 1;
            uctool.Name = "UCTipGroup" + ucIndex++;
            panel1.Controls.Add(uctool);
            uctool.Location = new System.Drawing.Point((ucIndex - 2) * 340, 0);
            uctool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            uctool.Width = 340;
            uctool.ParentC = this;

            uctool.Init(title, c);
            uctool.OnClickItem += Uctool_OnClickItem;

            panel1.Width = (ucIndex - 1) * 340;
        }

        private void Uctool_OnClickItem(object sender, int e)
        {
            if (e > 0)
                splitContainer2.SplitterDistance = System.Math.Max(0,splitContainer2.Width - 1000);
            else
                splitContainer2.SplitterDistance = splitContainer2.Width;
        }

        private int ucIndex = 1;

    }
}
