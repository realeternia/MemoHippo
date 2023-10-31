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
            ucTipAdd1.button1.Click += Button1_Click;

            // 先隐藏面板
            ShowNotePad(false);
        }

        private void Tbutton1_Click(object sender, System.EventArgs e)
        {
            MemoBook.Instance.AddCatalog();

            RefreshMenu();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (nowCatalog == null)
                return;

            nowCatalog.AddColumn("新项");
            RefreshCatalog(nowCatalog.Id);
        }

        private void RefreshMenu()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Remove(ucMenuNew1);
         
            foreach(var catalog in MemoBook.Instance.CatalogInfos)
            {
                var newItem = new UCMenuItem();
                newItem.Id = catalog.Id;
                newItem.Title = catalog.Name;
                newItem.OnClickItem += MenuItem_Click;
                flowLayoutPanel1.Controls.Add(newItem);
            }
            flowLayoutPanel1.Controls.Add(ucMenuNew1);
            lastSelect = null;
        }

        UCMenuItem lastSelect = null;
        Model.MemoCatalogInfo nowCatalog = null;
        private void MenuItem_Click(object sender, int type)
        {
            var mItem = sender as UCMenuItem;

            textBoxTitle.Text = mItem.Title;
            if (lastSelect != null)
                lastSelect.SetSelect(false);
            lastSelect = mItem;
            mItem.SetSelect(true);

            RefreshCatalog(mItem.Id);
        }

        private void RefreshCatalog(int cid)
        {
            var ucIndex = 1;
            panel1.Controls.Clear();
            nowCatalog = MemoBook.Instance.GetCatalog(cid);
            foreach(var item in nowCatalog.Columns)
            {
                AddUCTool(item.Id, ucIndex, item.Title, item.BgColor);
                ucIndex++;
            }
            panel1.Controls.Add(ucTipAdd1);
            ucTipAdd1.Location = new System.Drawing.Point((ucIndex - 1) * 340, 0);
            panel1.Width = (ucIndex - 1) * 340+ ucTipAdd1.Width;
        }

        private void AddUCTool(int itid, int ucIndex, string title, Color c)
        {
            var uctool = new UCTipColumn();

            uctool.Height = panel1.Height - 1;
            uctool.Name = "UCTipGroup" + ucIndex;
            panel1.Controls.Add(uctool);
            uctool.Location = new System.Drawing.Point((ucIndex - 1) * 340, 0);
            uctool.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            uctool.Width = 340;
            uctool.ParentC = this;

            uctool.Init(nowCatalog.Id, itid, title, c);
            uctool.OnClickItem += Uctool_OnClickItem;

            panel1.Width = (ucIndex - 2) * 340;
        }

        private void Uctool_OnClickItem(object sender, int e)
        {
            ShowNotePad(e > 0);
        }

        private void ShowNotePad(bool show)
        {
            if (show)
                splitContainer2.SplitterDistance = System.Math.Max(0, splitContainer2.Width - 1000);
            else
                splitContainer2.SplitterDistance = splitContainer2.Width;
        }


    }
}
