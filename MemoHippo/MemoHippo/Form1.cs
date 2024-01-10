﻿using MemoHippo.Model;
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
        private InputTextBox colAddInputBox;

        public RJControls.RJDropdownMenu CustomMenuStripCol { get { return rjDropdownMenuCol; } }

        public Form1()
        {
            InitializeComponent();

            dasayEditor1.ParentC = this;

            ucTipAdd1.button1.Click += columnNew_Click;
            ucListSelectBar1.OnIndexChanged = OnSelectBarIndexChanged;

            // 先隐藏面板
            HidePaperPad();

            panelBlack.BackColor = Color.FromArgb(128, Color.Black);

            PanelManager.Instance.Init(this);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            FontMgr.Init();

            textBoxCatalogTitle.OnLoad();
            textBoxRowItemTitle.OnLoad();

            colAddInputBox = new InputTextBox();
            colAddInputBox.OnCustomTextChanged = Hintbox_OnCustomTextChanged;

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

            rjDropdownMenuCatlog.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuCatlog.MenuItemTextColor = Color.White;
            rjDropdownMenuCatlog.MenuItemHeight = 25;
            rjDropdownMenuCol.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuCol.MenuItemTextColor = Color.White;
            rjDropdownMenuCol.MenuItemHeight = 25;

            rjDropdownMenuRow.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuRow.MenuItemTextColor = Color.White;
            rjDropdownMenuRow.MenuItemHeight = 25;

            InitMenu();

           // DeleteRemovedFiles();
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

        private void ucCatalogSetup_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowSetup();
        }

        //添加一个新的栏目
        private void columnNew_Click(object sender, System.EventArgs e)
        {
            if (nowCatalog == null)
                return;

            Point absoluteLocation = ucTipAdd1.PointToScreen(new Point(0, 0));

            PanelManager.Instance.ShowBlackPanel(colAddInputBox, absoluteLocation.X - Location.X, absoluteLocation.Y - Location.Y, 1);
            colAddInputBox.Focus();
        }

        private void Hintbox_OnCustomTextChanged(string s)
        {
            var newId = nowCatalog.AddColumn(s);
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
                newItem.Menu = rjDropdownMenuCatlog;
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
            if (nowCatalogCtr == mItem)
                return;

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

            RefreshColumns(mItem.Id); //todo 这个现在每次都刷

            if (viewStack1.SelectedIndex == 1)
            {
                listMouseOnLine = null;
                listCachedItems = nowCatalog.GetItems();
                listView1.VirtualListSize = listCachedItems.Count;
            }
        }

        private int catalogId;
        private void RefreshColumns(int cid)
        {
            var ucIndex = 1;
            panel1.Visible = false;
            textBoxCatalogTitle.Visible = false;
            foreach(var ctr in panel1.Controls)
            {
                var columnCtr = ctr as UCTipColumn;
                if (columnCtr != null)
                    columnCtr.ReleaseAllLabels();
            }
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

            columnUC.RowMenu = rjDropdownMenuRow;
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

            ShowPaperPad(nowCatalog.GetColumn(args.ColumnId).GetItem(args.ItemId), args.FocusTitle);
        }

        //外部调用展示面板
        public void ShowPaperPadEx(int catalogId, MemoItemInfo item)
        {
            foreach(UCCatalogItem ctr in flowLayoutPanel1.Controls)
            {
                if(ctr != null && ctr.Id == catalogId)
                    SelectCatalogItem(ctr);
            }

            ShowPaperPad(item);
        }

        private void ShowPaperPad(MemoItemInfo itemInfo, bool focusTitle = false)
        {
            if(itemInfo == null)
            {
                HidePaperPad();
                return;
            }

            //更新选中
            if (nowRowItemCtr != null)
                nowRowItemCtr.SetSelect(false);
            foreach (var column in columnCtrs)
            {
                var result = column.FindItemControl(itemInfo.Id);
                if (result != null)
                {
                    nowRowItemCtr = result;
                    nowRowItemCtr.SetSelect(true);
                    break;
                }
            }

            nowRowItem = itemInfo;
            listView1.Invalidate(); //todo 有优化空间

            //更新显示文件内容
            textChangeLock = true;
            textBoxRowItemTitle.TrueText = nowRowItem.Title;
            if (focusTitle)
                textBoxRowItemTitle.Focus();
            UpdatePaperIcon(nowRowItem.Icon);
            textChangeLock = false;
            uckvList1.Init(itemInfo);
           // dasayEditor1.Location = new Point(uckvList1.Location.X, uckvList1.Location.Y + uckvList1.Height);
            dasayEditor1.Height = splitContainer2.Panel2.Height - uckvList1.Location.Y - uckvList1.Height-15;
            dasayEditor1.LoadFile(nowRowItem);

            if (splitContainer2.SplitterDistance > splitContainer2.Width-10)
                splitContainer2.SplitterDistance = Math.Min(lastDistance, Math.Max(0, splitContainer2.Width - 800));

        }

        private int lastDistance;
        private void HidePaperPad()
        {
            if (splitContainer2.SplitterDistance > splitContainer2.Width - 10)
                return;
            //更新选中
            if (nowRowItemCtr != null)
                nowRowItemCtr.SetSelect(false);
            nowRowItemCtr = null;
            nowRowItem = null;

            lastDistance = splitContainer2.SplitterDistance;
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
            Point absoluteLocation = pictureBoxPaperIcon.PointToScreen(new Point(0, 0));
            PanelManager.Instance.ShowIconForm(absoluteLocation.X - Location.X - 500 / 2,
                absoluteLocation.Y - Location.Y + 5,
                (iconPath) =>
                {
                    UpdateIcon(iconPath);
                }
            );
        }

        private void ucCatalogSearch_Click(object sender, System.EventArgs e)
        {
            PanelManager.Instance.ShowSearchForm();
        }

        private void ucCatalogStore_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuCatlog.Tag.ToString());
            MemoBook.Instance.DeleteCatalog(itemId);
            RefreshCatalogs();

            RefreshColumns(0);
            ShowPaperPad(null);
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
                colorToolStripMenuItem1.DropDownItems.Add(blueMenuItem);
            }
        }

        private void DeleteRemovedFiles()
        {
            foreach (var file in Directory.GetFiles(ENV.SaveDir))
            {
                var fi = new FileInfo(file);
                var itemId = fi.Name;
                if (MemoBook.Instance.FindItemInfo(int.Parse(itemId.Replace(".rtf", ""))) == null)
                    File.Delete(file);
            }
        }

        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            var columnId = int.Parse(rjDropdownMenuCol.Tag.ToString());
            nowCatalog.GetColumn(columnId).BgColor = ColorTool.DarkColorTable[(sender as ToolStripMenuItem).Text].ToArgb();

            //todo 可以精细处理，就刷一列
            RefreshColumns(catalogId);
        }

        private void toolStripMenuItemDelCol_Click(object sender, EventArgs e)
        {
            var columnId = int.Parse(rjDropdownMenuCol.Tag.ToString());
            if (nowCatalog == null || nowCatalog.GetColumn(columnId).Items.Count > 0)
                return;

            MemoBook.Instance.GetCatalog(nowCatalog.Id).RemoveColumn(columnId);

            RefreshColumns(nowCatalog.Id);
        }

        #endregion

        #region row菜单支持

        private void commonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeType((int)RowItemType.Common);
        }

        private void nikonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeType((int)RowItemType.Nikon);
        }
        private void ddlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeType((int)RowItemType.DDL);
        }

        private void ChangeType(int type)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());
            var columnCtr = rjDropdownMenuRow.Bind as UCTipColumn;

            var itemInfo = columnCtr.ColumnInfo.GetItem(itemId);
            if (itemInfo != null)
                itemInfo.Type = type;

            columnCtr.RefreshLabels();
        }

        private void deleteToolStripMenuItemRow_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());
            var columnCtr = rjDropdownMenuRow.Bind as UCTipColumn;

            columnCtr.ColumnInfo.RemoveItem(itemId);

            var fullPath = string.Format("{0}/{1}.rtf", ENV.SaveDir, itemId);
            if (File.Exists(fullPath))
                File.Delete(fullPath);

            columnCtr.RefreshLabels();
        }

        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());
            var columnCtr = rjDropdownMenuRow.Bind as UCTipColumn;

            var itemInfo = columnCtr.ColumnInfo.GetItem(itemId);
            itemInfo.AddTag("存档");

            columnCtr.RefreshLabels();
        }
        #endregion

        private void doubleBufferedFlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            dasayEditor1.Width = doubleBufferedFlowLayoutPanel1.Width;
            dasayEditor1.Height = doubleBufferedFlowLayoutPanel1.Height - uckvList1.Location.Y - uckvList1.Height-15;
            uckvList1.Width = doubleBufferedFlowLayoutPanel1.Width;
        }

        private void pictureBoxPaperIcon_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxPaperIcon.BackColor = Color.FromArgb(96, 96, 96);
        }

        private void pictureBoxPaperIcon_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxPaperIcon.BackColor = Color.FromArgb(32, 32, 32);
        }

        #region 全部信息列表

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= 0 && e.ItemIndex < listCachedItems.Count)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = listCachedItems[e.ItemIndex].Id;

                e.Item = item;
            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (listCachedItems == null)
                return;

            var itemInfo = listCachedItems[e.ItemIndex];
            if (itemInfo != null)
            {
                e.Graphics.DrawImage(ResLoader.Read(itemInfo.Icon), e.Bounds.X + 8, e.Bounds.Y + 10, 24, 24);

                string textToDraw = string.Format("{0}/{1}", itemInfo.Id, itemInfo.Title);
                e.Graphics.DrawString(textToDraw,
                    e.Item.Font, Brushes.White, e.Bounds.X + 8 + 30, e.Bounds.Y + 10, StringFormat.GenericDefault);

                // 获取文本的大小
                SizeF textSize1 = e.Graphics.MeasureString(textToDraw, e.Item.Font);

                // 调整坐标以居中绘制文本
                int startX = e.Bounds.X + 8 + 30 + (int)textSize1.Width;
                int startY = e.Bounds.Y + 10;

                if (!string.IsNullOrEmpty(itemInfo.Tag))
                {
                    var dts = itemInfo.Tag.Split(',');
                    foreach (string word in dts)
                    {
                        // 获取文本框的大小
                        SizeF textSize = e.Graphics.MeasureString(word, Font);

                        Rectangle borderRect = new Rectangle(startX, startY, (int)textSize.Width + 6, (int)textSize.Height + 6);
                        var brush = DrawTool.GetTagBrush(word);
                        e.Graphics.FillRoundRectangle(brush, borderRect, 3);

                        e.Graphics.DrawString(word, Font, Brushes.White, startX + 3, startY + 5);

                        // 调整下一个词的位置
                        startX += (int)textSize.Width + 6 + 6;
                    }
                }

                using (var ft = new Font("Arial", 9))
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    e.Graphics.DrawString(string.Format("{0}", itemInfo.GetCreateTime()),
                 ft, Brushes.Gray, e.Bounds.X + listView1.Width - 8, e.Bounds.Y + 10 + 3, stringFormat);
                }
            }

            //using (var ft = new Font("微软雅黑", 9.5f))
            //    DrawLine(e, e.SubItem.Text, textBox1.Text, ft);
        }


        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (listCachedItems == null)
                return;

            var itemInfo = listCachedItems[e.ItemIndex];

            var destRT = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 2, e.Bounds.Width-5, e.Bounds.Height - 4);

            if (listMouseOnLine != null && e.ItemIndex == listMouseOnLine.Index)
            {
                using (var b = new SolidBrush(Color.FromArgb(60, 60, 60)))
                    e.Graphics.FillRectangle(b, destRT);
            }
            if (nowRowItem != null && itemInfo.Id == nowRowItem.Id)
            {
                e.Graphics.DrawRectangle(Pens.LightBlue, destRT);
            }
        }

        private List<MemoItemInfo> listCachedItems;
        private ListViewItem listMouseOnLine;

        private void viewStack1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewStack1.SelectedIndex == 1)
            {
                listCachedItems = nowCatalog.GetItems();
                listView1.VirtualListSize = listCachedItems.Count;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMouseOnLine == null)
            {
                ShowPaperPad(null);
            }
            else
            {
                var lineInfo = listCachedItems[listMouseOnLine.Index];
                ShowPaperPad(nowCatalog.FindItemInfo(lineInfo.Id), false);
            }
        }

        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            Point localPoint = listView1.PointToClient(Cursor.Position);

            // 使用 HitTest 方法判断鼠标下方的项目
            ListViewHitTestInfo hitTest = listView1.HitTest(localPoint);
            if (hitTest.Item != null)
            {
                if (listMouseOnLine != null)
                    listView1.Invalidate(listMouseOnLine.Bounds);
                listMouseOnLine = hitTest.Item;
                listView1.Invalidate(listMouseOnLine.Bounds);
                // 在这里你可以处理鼠标悬停在项目上的逻辑
                // 例如获取项目的信息，更新UI等
            }
            else
            {
                if (listMouseOnLine != null)
                    listView1.Invalidate(listMouseOnLine.Bounds);
                listMouseOnLine = null;
            }
        }


        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            listView1.Columns[0].Width = listView1.Width - 8;
        }

        private void OnSelectBarIndexChanged(int idx)
        {
            viewStack1.SelectedIndex = idx;
        }
        #endregion

        private void splitContainer2_Panel1_Resize(object sender, EventArgs e)
        {
            viewStack1.Height = splitContainer2.Panel1.Height - 135;
        }

    }
}
