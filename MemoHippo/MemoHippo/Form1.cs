using MemoHippo.Model;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using static MemoHippo.UCTipColumn;

namespace MemoHippo
{
    public partial class Form1 : Form
    {
        private UCCatalogItem lastSelect = null;
        private Model.MemoCatalogInfo nowCatalog = null;
        private Model.MemoItemInfo nowItem = null;
        private IRowItem nowRowCtr = null;
        private bool textChangeLock;

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
                var newItem = new UCCatalogItem();
                newItem.Id = catalog.Id;
                newItem.Title = catalog.Name;
                newItem.OnClickItem += MenuItem_Click;
                flowLayoutPanel1.Controls.Add(newItem);
            }
            flowLayoutPanel1.Controls.Add(ucMenuNew1);
            lastSelect = null;
        }

        private void MenuItem_Click(object sender, int type)
        {
            var mItem = sender as UCCatalogItem;

            textChangeLock = true;
            textBoxTitle.Text = mItem.Title;
            textChangeLock = false;

            if (lastSelect != null)
                lastSelect.SetSelect(false);
            lastSelect = mItem;
            mItem.SetSelect(true);

            RefreshCatalog(mItem.Id);
        }

        private void RefreshCatalog(int cid)
        {
            var ucIndex = 1;
            panel1.Visible = false;
            panel1.Controls.Clear();
            nowCatalog = MemoBook.Instance.GetCatalog(cid);
            foreach(var item in nowCatalog.Columns)
            {
                AddUCColumn(item.Id, ucIndex, item.Title, Color.FromArgb(item.BgColor));
                ucIndex++;
            }
            panel1.Controls.Add(ucTipAdd1);
            ucTipAdd1.Location = new System.Drawing.Point((ucIndex - 1) * 340, 0);
            panel1.Width = (ucIndex - 1) * 340+ ucTipAdd1.Width;
            panel1.Visible = true;
        }

        private void AddUCColumn(int itid, int ucIndex, string title, Color c)
        {
            var uctool = new UCTipColumn();

            uctool.Height = panel1.Height - 1;
            uctool.Name = "UCTipGroup" + ucIndex;
            panel1.Controls.Add(uctool);
            uctool.Location = new Point((ucIndex - 1) * 340, 0);
            uctool.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            uctool.Width = 340;
            uctool.ParentC = this;

            uctool.Init(nowCatalog.Id, itid, title, c);
            uctool.OnClickItem += Uctool_OnClickItem;

            panel1.Width = (ucIndex - 2) * 340;
        }

        private void Uctool_OnClickItem(object sender, EventItemClickArgs args)
        {
            if(args == null)
            {
                nowRowCtr = null;
                nowItem = null;
                ShowNotePad(false);
                return;
            }

            nowRowCtr = sender as IRowItem;
            nowItem = nowCatalog.GetColumn(args.ColumnId).GetItem(args.ItemId);
            ShowNotePad(true);
        }

        private void ShowNotePad(bool show)
        {
            if(show && nowItem != null)
            {
                textChangeLock = true;
                textBoxTitle2.Text = nowItem.Title;
                textChangeLock = false;
                dasayEditor1.LoadFile(nowItem.Id.ToString());
            }
            if (show)
                splitContainer2.SplitterDistance = System.Math.Max(0, splitContainer2.Width - 1000);
            else
                splitContainer2.SplitterDistance = splitContainer2.Width;
        }

        private void splitContainer2_Panel1_Click(object sender, System.EventArgs e)
        {
            ShowNotePad(false);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (File.Exists("a.yaml"))
            {
                var yaml = File.ReadAllText("a.yaml", Encoding.UTF8);

                var deserializer = new DeserializerBuilder().Build();
                MemoBook.Instance = deserializer.Deserialize<MemoBook>(yaml);
                RefreshMenu();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(MemoBook.Instance);
            File.WriteAllText("a.yaml", yaml, Encoding.UTF8);
        }

        private void textBoxTitle2_TextChanged(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowItem != null)
                    nowItem.Title = textBoxTitle2.Text;
                if (nowRowCtr != null)
                    nowRowCtr.SetTitile(textBoxTitle2.Text);
            }
        }

        private void textBoxTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowCatalog != null)
                    nowCatalog.Name = textBoxTitle.Text;
                if (lastSelect != null)
                    lastSelect.Title = textBoxTitle.Text;
            }
        }
    }
}
