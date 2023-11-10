using MemoHippo.Model;
using System;
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
        private UCCatalogItem lastSelect = null;
        private Model.MemoCatalogInfo nowCatalog = null;
        private Model.MemoItemInfo nowItem = null;
        private IRowItem nowRowCtr = null;
        private bool textChangeLock;

        public Form1()
        {
            InitializeComponent();

            ucTipAdd1.button1.Click += Button1_Click;

            // 先隐藏面板
            ShowPaperPad(false);

            panelBlack.BackColor = Color.FromArgb(128, Color.Black);
        }

        private void ucCatalogNew1_Click(object sender, System.EventArgs e)
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
         
            foreach(var catalog in MemoBook.Instance.CatalogInfos)
            {
                var newItem = new UCCatalogItem();
                newItem.Id = catalog.Id;
                newItem.Title = catalog.Name;
                newItem.Click += MenuItem_Click;
                newItem.Width = flowLayoutPanel1.Width - 5;
                flowLayoutPanel1.Controls.Add(newItem);
            }
            lastSelect = null;
        }

        private void MenuItem_Click(object sender, System.EventArgs e)
        {
            var mItem = sender as UCCatalogItem;

            textChangeLock = true;
            textBoxCatalogTitle.Text = mItem.Title;
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
            ucTipAdd1.Location = new System.Drawing.Point((ucIndex - 1) * 270, 0);
            panel1.Width = (ucIndex - 1) * 270 + ucTipAdd1.Width;
            panel1.Visible = true;
        }

        private void AddUCColumn(int itid, int ucIndex, string title, Color c)
        {
            var uctool = new UCTipColumn();

            uctool.Height = panel1.Height - 1;
            uctool.Name = "UCTipGroup" + ucIndex;
            panel1.Controls.Add(uctool);
            uctool.Location = new Point((ucIndex - 1) * 270, 0);
            uctool.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            uctool.Width = 270;
            uctool.ParentC = this;

            uctool.Init(nowCatalog.Id, itid, title, c);
            uctool.OnClickItem += Uctool_OnClickItem;

            panel1.Width = (ucIndex - 2) * 270;
        }

        private void Uctool_OnClickItem(object sender, EventItemClickArgs args)
        {
            if(args == null)
            {
                nowRowCtr = null;
                nowItem = null;
                ShowPaperPad(false);
                return;
            }

            nowRowCtr = sender as IRowItem;
            nowItem = nowCatalog.GetColumn(args.ColumnId).GetItem(args.ItemId);
            ShowPaperPad(true);
        }

        private void ShowPaperPad(bool show)
        {
            if(show && nowItem != null)
            {
                textChangeLock = true;
                textBoxPaperTitle.Text = nowItem.Title;
                UpdatePaperIcon(nowItem.Icon);
                textChangeLock = false;
                dasayEditor1.LoadFile(nowItem.Id.ToString());
            }
            if (show)
                splitContainer2.SplitterDistance = System.Math.Max(0, splitContainer2.Width - 700);
            else
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
            ShowPaperPad(false);
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
                    nowItem.Title = textBoxPaperTitle.Text;
                if (nowRowCtr != null)
                    nowRowCtr.SetTitle(textBoxPaperTitle.Text);
            }
        }

        private void textBoxTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowCatalog != null)
                    nowCatalog.Name = textBoxCatalogTitle.Text;
                if (lastSelect != null)
                    lastSelect.Title = textBoxCatalogTitle.Text;
            }
        }

        private void pictureBoxPaperIcon_Click(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowItem != null)
                    nowItem.Icon = "Icon/atr3.PNG";
                if (nowRowCtr != null)
                    nowRowCtr.SetIcon(nowItem.Icon);
                UpdatePaperIcon(nowItem.Icon);
            }
        }
        private void ucCatalogSearch_Click(object sender, System.EventArgs e)
        {
            //var niu = DateTime.Now;

            //for (int i = 0; i < 10000; i++)
            //{
            //    string rtfContent = File.ReadAllText(@"F:\MemoHippo\MemoHippo\MemoHippo\bin\Debug\save\200002.rtf");
            //    string plainText = GetPlainTextFromRtf(rtfContent);
            //}
            //var past = DateTime.Now - niu;

            Bitmap bitmap = new Bitmap(splitContainer1.Width, splitContainer1.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(splitContainer1.PointToScreen(Point.Empty), Point.Empty, splitContainer1.Size);
            }

            panelBlack.BG = bitmap;
            panelBlack.AddControl(new UCSearch());
            panelBlack.BringToFront();

        }

        private RichTextBox richTextBox = new RichTextBox();
        private string GetPlainTextFromRtf(string rtfContent)
        {
          
            richTextBox.Rtf = rtfContent;
            return richTextBox.Text;
        }

        private void ucCatalogSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
