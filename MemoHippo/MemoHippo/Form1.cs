using MemoHippo.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using static MemoHippo.UCTipColumn;

namespace MemoHippo
{
    public partial class Form1 : Form
    {
        private UCCatalogItem nowCatalogCtr = null;
        private MemoCatalogInfo nowCatalog = null;

        private List<UCTipColumn> columnCtrs = new List<UCTipColumn>();

        private IRowItem nowRowItemCtr = null; //当前选择row
        private MemoItemInfo nowRowItem = null;
        
        private bool textChangeLock;
        

        public Form1()
        {
            InitializeComponent();

            ucTipAdd1.button1.Click += columnNew_Click;

            // 先隐藏面板
            HidePaperPad();

            panelBlack.BackColor = Color.FromArgb(128, Color.Black);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (File.Exists("a.yaml"))
            {
                var yaml = File.ReadAllText("a.yaml", Encoding.UTF8);

                var deserializer = new DeserializerBuilder().Build();
                MemoBook.Instance = deserializer.Deserialize<MemoBook>(yaml);
                var itm = RefreshCatalogs();
                if (itm != null)
                    SelectCatalogItem(itm);
            }
        }

        private void ucCatalogNew_Click(object sender, System.EventArgs e)
        {
            MemoBook.Instance.AddCatalog();

            RefreshCatalogs();
        }

        private void columnNew_Click(object sender, System.EventArgs e)
        {
            if (nowCatalog == null)
                return;

            nowCatalog.AddColumn("新项");
            RefreshColumns(nowCatalog.Id);
        }

        private UCCatalogItem RefreshCatalogs()
        {
            flowLayoutPanel1.Controls.Clear();

            UCCatalogItem firstMenu = null;
            foreach(var catalog in MemoBook.Instance.CatalogInfos)
            {
                var newItem = new UCCatalogItem(); 
                newItem.Id = catalog.Id;
                newItem.Title = catalog.Name;
                newItem.Click += CatalogItem_Click;
                newItem.Width = flowLayoutPanel1.Width - 5;
                flowLayoutPanel1.Controls.Add(newItem);

                if(firstMenu == null)
                    firstMenu = newItem;
            }
            nowCatalogCtr = null;
            return firstMenu;
        }

        private void CatalogItem_Click(object sender, System.EventArgs e)
        {
            var mItem = sender as UCCatalogItem;

            SelectCatalogItem(mItem);
        }

        private void SelectCatalogItem(UCCatalogItem mItem)
        {
            textChangeLock = true;
            textBoxCatalogTitle.Text = mItem.Title;
            textChangeLock = false;

            if (nowCatalogCtr != null)
                nowCatalogCtr.SetSelect(false);
            nowCatalogCtr = mItem;
            mItem.SetSelect(true);

            RefreshColumns(mItem.Id);
        }

        private void RefreshColumns(int cid)
        {
            var ucIndex = 1;
            panel1.Visible = false;
            panel1.Controls.Clear();
            columnCtrs.Clear();
            nowCatalog = MemoBook.Instance.GetCatalog(cid);
            foreach(var column in nowCatalog.Columns)
            {
                columnCtrs.Add(AddUCColumn(column.Id, ucIndex, column.Title, Color.FromArgb(column.BgColor)));
                ucIndex++;
            }
            panel1.Controls.Add(ucTipAdd1);
            ucTipAdd1.Location = new System.Drawing.Point((ucIndex - 1) * 270, 0);
            panel1.Width = (ucIndex - 1) * 270 + ucTipAdd1.Width;
            panel1.Visible = true;
        }

        private UCTipColumn AddUCColumn(int itid, int ucIndex, string title, Color c)
        {
            var columnUC = new UCTipColumn();

            columnUC.Height = panel1.Height - 1;
            columnUC.Name = "UCTipGroup" + ucIndex;
            panel1.Controls.Add(columnUC);
            columnUC.Location = new Point((ucIndex - 1) * 270, 0);
            columnUC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            columnUC.Width = 270;
            columnUC.ParentC = this;

            columnUC.Init(nowCatalog.Id, itid, title, c);
            columnUC.OnClickItem += OnRowItemClick;

            panel1.Width = (ucIndex - 2) * 270;

            return columnUC;
        }

        private void OnRowItemClick(object sender, EventItemClickArgs args)
        {
            if(args == null)
            {
                HidePaperPad();
                return;
            }

            ShowPaperPad(sender as IRowItem, nowCatalog.GetColumn(args.ColumnId).GetItem(args.ItemId));
        }

        //外部调用展示面板
        public void ShowPaperPadEx(int catalogId, MemoItemInfo item)
        {
            foreach(UCCatalogItem ctr in flowLayoutPanel1.Controls)
            {
                if(ctr != null && ctr.Id == catalogId)
                    SelectCatalogItem(ctr);
            }

            IRowItem showRow = null;
            foreach(var column in columnCtrs)
            {
                var result = column.FindItemControl(item.Id);
                if (result != null)
                    showRow = result;
            }

            ShowPaperPad(showRow, item);
        }

        private void ShowPaperPad(IRowItem showItem, MemoItemInfo itemInfo)
        {
            if(showItem == null)
            {
                HidePaperPad();
                return;
            }

            //更新选中
            if (nowRowItemCtr != null)
                nowRowItemCtr.SetSelect(false);
            nowRowItemCtr = showItem;
            nowRowItemCtr.SetSelect(true);
            nowRowItem = itemInfo;

            //更新显示文件内容
            textChangeLock = true;
            textBoxPaperTitle.Text = nowRowItem.Title;
            UpdatePaperIcon(nowRowItem.Icon);
            textChangeLock = false;
            uckvList1.Init(itemInfo);
            dasayEditor1.Location = new Point(uckvList1.Location.X, uckvList1.Location.Y + uckvList1.Height);
            dasayEditor1.Height = splitContainer2.Panel2.Height - uckvList1.Location.Y - uckvList1.Height;
            dasayEditor1.LoadFile(nowRowItem.Id.ToString());

            //调整pad显示
            splitContainer2.SplitterDistance = System.Math.Max(0, splitContainer2.Width - 700);

        }

        private void HidePaperPad()
        {
            //更新选中
            if (nowRowItemCtr != null)
                nowRowItemCtr.SetSelect(false);
            nowRowItemCtr = null;
            nowRowItem = null;

            //调整pad隐藏
            splitContainer2.SplitterDistance = splitContainer2.Width;
        }

        private void UpdatePaperIcon(string icon)
        {
            if (string.IsNullOrEmpty(icon))
                pictureBoxPaperIcon.Image = ResLoader.Read("Icon/atr0.PNG");
            else
                pictureBoxPaperIcon.Image = ResLoader.Read(icon);
        }

        private void splitContainer2_Panel1_Click(object sender, System.EventArgs e)
        {
            HidePaperPad();
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
                if (nowRowItem != null)
                    nowRowItem.Title = textBoxPaperTitle.Text;
                if (nowRowItemCtr != null)
                    nowRowItemCtr.SetTitle(textBoxPaperTitle.Text);
            }
        }

        public void HideAll()
        {
            panelBlack.HideAll();
        }

        private void textBoxTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowCatalog != null)
                    nowCatalog.Name = textBoxCatalogTitle.Text;
                if (nowCatalogCtr != null)
                    nowCatalogCtr.Title = textBoxCatalogTitle.Text;
            }
        }

        private void pictureBoxPaperIcon_Click(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowRowItem != null)
                    nowRowItem.Icon = "Icon/atr3.PNG";
                if (nowRowItemCtr != null)
                    nowRowItemCtr.SetIcon(nowRowItem.Icon);
                UpdatePaperIcon(nowRowItem.Icon);
            }
        }
        private void ucCatalogSearch_Click(object sender, System.EventArgs e)
        {
            Bitmap bitmap = new Bitmap(splitContainer1.Width, splitContainer1.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(splitContainer1.PointToScreen(Point.Empty), Point.Empty, splitContainer1.Size);
            }

            panelBlack.BG = bitmap;
            var search = new UCSearch();
            search.Form1 = this;
            panelBlack.AddControl(search);
            panelBlack.BringToFront();

        }

        private void ucCatalogSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
