using MemoHippo.Model;
using MemoHippo.Panels;
using MemoHippo.UIS;
using MemoHippo.Utils;
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
        private InputTextBox2 colAddInputBox;

        public CustomMenuStrip CustomMenuStripCol { get { return customMenuStripCol; } }


        public Form1()
        {
            InitializeComponent();

            dasayEditor1.ParentC = this;

            ucTipAdd1.button1.Click += columnNew_Click;

            // 先隐藏面板
            HidePaperPad();

            panelBlack.BackColor = Color.FromArgb(128, Color.Black);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            FontMgr.Init();

            textBoxCatalogTitle.OnLoad();
            textBoxRowItemTitle.OnLoad();

            colAddInputBox = new InputTextBox2();
            colAddInputBox.Form1 = this;
            colAddInputBox.OnCustomTextChanged += Hintbox_OnCustomTextChanged;

            if (File.Exists(ENV.BaseDir+ "/memo.yaml"))
            {
                var yaml = File.ReadAllText(ENV.BaseDir + "/memo.yaml", Encoding.UTF8);

                var deserializer = new DeserializerBuilder().Build();
                MemoBook.Instance = deserializer.Deserialize<MemoBook>(yaml);
                if (MemoBook.Instance.Cfg == null)
                    MemoBook.Instance.Cfg = new MemoBookCfg();
                var itm = RefreshCatalogs();
                if (itm != null)
                    SelectCatalogItem(itm);
            }
            InitMenu();
        }

        //添加一个新的分类
        private void ucCatalogNew_Click(object sender, System.EventArgs e)
        {
            var newCat = MemoBook.Instance.AddCatalog();
            RefreshCatalogs();

            var ctrs = flowLayoutPanel1.Controls.Find(newCat.Id.ToString(), false);
            if (ctrs.Length > 0)
                SelectCatalogItem(ctrs[0] as UCCatalogItem);

            textBoxCatalogTitle.Focus(); //光标停留到输入栏
        }

        //添加一个新的栏目
        private void columnNew_Click(object sender, System.EventArgs e)
        {
            if (nowCatalog == null)
                return;

            Point absoluteLocation = ucTipAdd1.PointToScreen(new Point(0, 0));

            ShowBlackPanel(colAddInputBox, absoluteLocation.X - Location.X, absoluteLocation.Y - Location.Y, 1);
            colAddInputBox.Focus();
        }

        private void Hintbox_OnCustomTextChanged(object sender, EventArgs e)
        {
            var newId = nowCatalog.AddColumn(colAddInputBox.Text);
            RefreshColumns(nowCatalog.Id);

            panel1.Controls.Find("col" + newId.ToString(), false);
        }

        private UCCatalogItem RefreshCatalogs()
        {
            flowLayoutPanel1.Controls.Clear();

            UCCatalogItem firstMenu = null;
            foreach(var catalog in MemoBook.Instance.CatalogInfos)
            {
                var newItem = new UCCatalogItem();
                newItem.Id = catalog.Id;
                newItem.Name = catalog.Id.ToString();
                newItem.Title = catalog.Name;
                newItem.Click += CatalogItem_Click;
                newItem.Width = flowLayoutPanel1.Width - 5;
                newItem.Menu = customMenuStrip1;
                flowLayoutPanel1.Controls.Add(newItem);

                newItem.AfterInit();

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
            textBoxCatalogTitle.TrueText = mItem.Title;
            textChangeLock = false;

            if (nowCatalogCtr != null)
                nowCatalogCtr.SetSelect(false);
            nowCatalogCtr = mItem;
            mItem.SetSelect(true);

            RefreshColumns(mItem.Id);
        }

        private int catalogId;
        private void RefreshColumns(int cid)
        {
            var ucIndex = 1;
            panel1.Visible = false;
            textBoxCatalogTitle.Visible = false;
            panel1.Controls.Clear();
            columnCtrs.Clear();

            if(cid > 0)
            {
                catalogId = cid;
                nowCatalog = MemoBook.Instance.GetCatalog(cid);
                foreach (var column in nowCatalog.Columns)
                {
                    var newItem = AddUCColumn(column.Id, ucIndex, column.Title, Color.FromArgb(column.BgColor));
                    columnCtrs.Add(newItem);
                    ucIndex++;
                }
                panel1.Controls.Add(ucTipAdd1);
                ucTipAdd1.Location = new System.Drawing.Point((ucIndex - 1) * 270, 0);
                panel1.Width = (ucIndex - 1) * 270 + ucTipAdd1.Width;
                panel1.Visible = true;
                textBoxCatalogTitle.Visible = true;
            }
 
        }

        private UCTipColumn AddUCColumn(int itid, int ucIndex, string title, Color c)
        {
            var columnUC = new UCTipColumn();

            columnUC.Height = panel1.Height - 1;
            columnUC.Name = "col" + itid;
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

            ShowPaperPad(sender as IRowItem, nowCatalog.GetColumn(args.ColumnId).GetItem(args.ItemId), args.FocusTitle);
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

        private void ShowPaperPad(IRowItem showItem, MemoItemInfo itemInfo, bool focusTitle = false)
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
            textBoxRowItemTitle.TrueText = nowRowItem.Title;
            if (focusTitle)
                textBoxRowItemTitle.Focus();
            UpdatePaperIcon(nowRowItem.Icon);
            textChangeLock = false;
            uckvList1.Init(itemInfo);
           // dasayEditor1.Location = new Point(uckvList1.Location.X, uckvList1.Location.Y + uckvList1.Height);
            dasayEditor1.Height = splitContainer2.Panel2.Height - uckvList1.Location.Y - uckvList1.Height;
            dasayEditor1.LoadFile(nowRowItem.Id.ToString());

            //调整pad显示
            splitContainer2.SplitterDistance = System.Math.Max(0, splitContainer2.Width - 800);

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
            File.WriteAllText(ENV.BaseDir + "/memo.yaml", yaml, Encoding.UTF8);
        }

        private void textBoxRowItemTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowRowItem != null)
                    nowRowItem.Title = textBoxRowItemTitle.TrueText;
                if (nowRowItemCtr != null)
                    nowRowItemCtr.SetTitle(textBoxRowItemTitle.TrueText);
            }
        }

        public void SetRowTitleInfo(string title, string iconPath)
        {
            textBoxRowItemTitle.TrueText = title;
            UpdateIcon(iconPath);
        }

        private void textBoxCatalogTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowCatalog != null)
                    nowCatalog.Name = textBoxCatalogTitle.TrueText;
                if (nowCatalogCtr != null)
                    nowCatalogCtr.Title = textBoxCatalogTitle.TrueText;
            }
        }

        private void UpdateIcon(string iconPath)
        {
            if (nowRowItem != null)
                nowRowItem.Icon = iconPath;
            if (nowRowItemCtr != null)
                nowRowItemCtr.SetIcon(iconPath);
            UpdatePaperIcon(iconPath);
        }

        private void pictureBoxPaperIcon_Click(object sender, System.EventArgs e)
        {
            var iconPanel = new UCIconPicker();
            iconPanel.Form1 = this;
            iconPanel.AfterSelect = (iconPath) =>
            {
                UpdateIcon(iconPath);
            };

            Point absoluteLocation = pictureBoxPaperIcon.PointToScreen(new Point(0, 0));
            ShowBlackPanel(iconPanel, absoluteLocation.X - Location.X - iconPanel.Width / 2, absoluteLocation.Y - Location.Y+5, 1);
            iconPanel.OnInit();
        }

        private void ucCatalogSearch_Click(object sender, System.EventArgs e)
        {
            var search = new UCSearch();
            search.Form1 = this;

            ShowBlackPanel(search, 0, 0);
            search.OnInit();
        }

        public void ShowBlackPanel(Control ctr, int x, int y, float bright = 0.5f)
        {
            Bitmap bitmap = new Bitmap(splitContainer1.Width, splitContainer1.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
                graphics.CopyFromScreen(splitContainer1.PointToScreen(Point.Empty), Point.Empty, splitContainer1.Size);

            panelBlack.BG = bitmap;
            panelBlack.Brightness = bright;
            panelBlack.AddControl(ctr, x, y);
            panelBlack.BringToFront();
        }

        public void HideBlackPanel()
        {
            panelBlack.HideAll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(customMenuStrip1.Tag.ToString());
            MemoBook.Instance.DeleteCatalog(itemId);
            RefreshCatalogs();

            RefreshColumns(0);
            ShowPaperPad(null, null);
        }

        #region column的菜单支持
        private void InitMenu()
        {
            foreach (var cr in ColorTool.DarkColorTable)
            {
                ToolStripMenuItem blueMenuItem = new ToolStripMenuItem(cr.Key);
                blueMenuItem.BackColor = Color.FromArgb(24, 24, 24);
                blueMenuItem.ForeColor = Color.White;
                blueMenuItem.Image = ImageTool.CreateSolidColorBitmap(Color.FromArgb(cr.Value.R+40, cr.Value.G+40, cr.Value.B+40), 32, 32);
                blueMenuItem.Click += ColorMenuItem_Click;
                colorToolStripMenuItem.DropDownItems.Add(blueMenuItem);
            }
        }

        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            var columnId = int.Parse(customMenuStripCol.Tag.ToString());
            nowCatalog.GetColumn(columnId).BgColor = ColorTool.DarkColorTable[(sender as ToolStripMenuItem).Text].ToArgb();

            //todo 可以精细处理，就刷一列
            RefreshColumns(catalogId);
        }

        private void toolStripMenuItemDelCol_Click(object sender, EventArgs e)
        {
            var columnId = int.Parse(customMenuStripCol.Tag.ToString());
            if (nowCatalog == null || nowCatalog.GetColumn(columnId).Items.Count > 0)
                return;

            MemoBook.Instance.GetCatalog(nowCatalog.Id).RemoveColumn(columnId);

            RefreshColumns(nowCatalog.Id);
        }

        #endregion

        private void doubleBufferedFlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            dasayEditor1.Width = doubleBufferedFlowLayoutPanel1.Width;
            dasayEditor1.Height = doubleBufferedFlowLayoutPanel1.Height - uckvList1.Location.Y - uckvList1.Height;
        }

        private void pictureBoxPaperIcon_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxPaperIcon.BackColor = Color.FromArgb(96, 96, 96);
        }

        private void pictureBoxPaperIcon_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxPaperIcon.BackColor = Color.FromArgb(32, 32, 32);
        }
    }
}
