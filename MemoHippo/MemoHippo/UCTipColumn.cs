using MemoHippo.Model;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCTipColumn : UserControl
    {
        public class EventItemClickArgs : EventArgs
        {
            public int ItemId { get; set; }
            public int ColumnId { get; set; }
        }

        enum RowItemType
        {
            Common=1,
            Nikon
        }


        public Form1 ParentC;
        private Color itemColor;

        public event System.EventHandler<EventItemClickArgs> OnClickItem;
        private Timer delayTimer;
        private Control delayControl;

        private int catalogId;
        private int columnId;

        public MemoColumnInfo ColumnInfo;

        private UCRowAdd rowAdd;
        private bool isDragging;
        private int lineY;
        private bool textChangeLock;

        public UCTipColumn()
        {
            InitializeComponent();

            delayTimer = new Timer();
            delayTimer.Interval = 100; // 设置为 100 毫秒）
            delayTimer.Enabled = false; // 初始状态为停用

            // 绑定定时器的 Tick 事件处理程序
            delayTimer.Tick += new EventHandler(OnDelayTimerTick);

            rowAdd = new UCRowAdd();
            DecorateControl(rowAdd, 0);
            rowAdd.Width = 270;
            rowAdd.label1.Click += button1_Click;
        }

        public Color ColorPlus(Color c, float exp)
        {
            return Color.FromArgb((byte)(c.R * exp), (byte)(c.G * exp), (byte)(c.B * exp));
        }

        public void Init(int cid, int itid, string title, Color cr)
        {
            catalogId = cid;
            columnId = itid;
            textChangeLock = true;
            textBoxTitle.Text = title;
            textChangeLock = false;
            textBoxTitle.BackColor = ColorPlus(cr, 2);
          //  BackColor = ColorPlus(cr, 0.65f);
            flowLayoutPanel1.BackColor = ColorPlus(cr, 0.65f);
            itemColor = cr;

            ColumnInfo = MemoBook.Instance.GetCatalog(catalogId).GetColumn(columnId);

            RefreshLabels();
        }

        private void RefreshLabels()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var memoItem in ColumnInfo.Items)
            {
                UCRowCommon labelCtr;
                if (memoItem.Type == (int)RowItemType.Nikon)
                    labelCtr = new UCRowNikon();
                else
                    labelCtr = new UCRowCommon();
                labelCtr.Menu = customMenuStrip1;

                var rowItem = labelCtr as IRowItem;
                rowItem.ItemId = memoItem.Id;
                rowItem.SetTitle(memoItem.Title);
                rowItem.SetIcon(memoItem.Icon);
                DecorateControl(labelCtr, memoItem.Id);
                AddControl(labelCtr);

                rowItem.AfterInit();
            }
            AddControl(rowAdd);
        }

        private void DecorateControl(Control c, int id)
        {
            c.Name = "dragctr" + id;
            c.Width = flowLayoutPanel1.Width - 10;
            c.ForeColor = Color.White;
            if (id > 0)
                c.BackColor = itemColor;
           // c.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            c.Margin = new Padding(5);
            // c.Padding = new Padding(3);

            var rowItem = c as IRowItem;
            if (rowItem != null)
            {
                rowItem.NLMouseDown += new MouseEventHandler(label_MouseDown);
                rowItem.NLMouseUp += new MouseEventHandler(label_MouseUp);
                rowItem.NLMouseClick += Label1_MouseClick;
            }
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
          //  (sender as Control).BackColor = Color.Blue;
            delayTimer.Stop();
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            var ctr = (Control)sender;
            if (ctr.Name == "dragctr0") // add 对象
                return;

          //  ctr.BackColor = Color.Red;

            delayTimer.Start();
            delayControl = ctr;
        }

        private void Label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (OnClickItem != null)
            {
                var itemId = GetDragCtrItemId((sender as Control).Name);
                OnClickItem(sender, new EventItemClickArgs { ItemId = itemId, ColumnId = columnId });
            }
        }

        private void OnDelayTimerTick(object sender, EventArgs e)
        {
        //    delayControl.BackColor = Color.Blue;
            delayTimer.Stop();

            var label = delayControl;
            label.DoDragDrop(label.Parent.Parent.Name + "." + delayControl.Name, DragDropEffects.Move);

            delayControl = null;
        }


        public void AddControl(Control c)
        {
            flowLayoutPanel1.Controls.Add(c);
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
                isDragging = true;
            }
        }

        private void flowLayoutPanel1_DragLeave(object sender, EventArgs e)
        {
            isDragging = false;
            flowLayoutPanel1.Invalidate();
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string[] names = ((string)e.Data.GetData(DataFormats.StringFormat)).Split('.');

                var itemId = GetDragCtrItemId(names[1]);

                // 根据 Name 查找 Label 控件
                var beginColumn = ParentC.panel1.Controls[names[0]] as UCTipColumn;

                var movingControl = beginColumn.Controls["flowLayoutPanel1"].Controls[names[1]];

                var upCtr = GetUpControl(e, out var afterNode, out var lineOffY);
                var upCtrId = GetDragCtrItemId(upCtr.Name);
                lineY = lineOffY;

                if (movingControl != null)
                {
                    var itm = beginColumn.ColumnInfo.RemoveItem(itemId);
                    ColumnInfo.InsertItem(itm, upCtrId, afterNode);

                    beginColumn.RefreshLabels();
                    RefreshLabels();
                }

                isDragging = false;
                flowLayoutPanel1.Invalidate();
            }
        }

        private int GetDragCtrItemId(string ctrName)
        {
            return int.Parse(ctrName.Replace("dragctr", ""));
        }

        private void flowLayoutPanel1_DragOver(object sender, DragEventArgs e)
        {
            GetUpControl(e, out _, out var lineOffY);
            if (lineOffY != lineY)
            {
                lineY = lineOffY;
                // 刷新 FlowLayoutPanel，触发 Paint 事件
                flowLayoutPanel1.Invalidate();
            }
        }

        private Control GetUpControl(DragEventArgs e, out bool afterNode, out int lineY)
        {
            // 获取鼠标拖放的目标位置
            Point clientPoint = flowLayoutPanel1.PointToClient(new Point(e.X, e.Y));

            // 查找鼠标位置下的控件
            var upControl = flowLayoutPanel1.GetChildAtPoint(clientPoint);

            if (upControl == null)
            {
                upControl = flowLayoutPanel1.GetChildAtPoint(new Point(clientPoint.X, clientPoint.Y + 15)); //先试着往下打超出一个margin
            }

            if (upControl == null)
                upControl = rowAdd;

            if (upControl == rowAdd)
            {
                lineY = rowAdd.Location.Y - 5;
                afterNode = false;
            }
            else
            {
                if (clientPoint.Y > upControl.Location.Y + upControl.Height / 2)
                {
                    lineY = upControl.Location.Y + upControl.Height + 5;
                    afterNode = true;
                }
                else
                {
                    lineY = upControl.Location.Y - 5;
                    afterNode = false;
                }
            }

            return upControl;
        }

        public IRowItem FindItemControl(int id)
        {
            foreach (Control flowItem in flowLayoutPanel1.Controls)
            {
                if (flowItem.Name == "dragctr" + id)
                    return flowItem as IRowItem;
            }
            return null;
        }

        private void flowLayoutPanel1_Click(object sender, System.EventArgs e)
        {
            if (OnClickItem != null)
                OnClickItem(sender, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColumnInfo.AddItem("新数据" + MemoBook.Instance.ItemIndex);

            RefreshLabels();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (isDragging)
            {
                using (Pen pen = new Pen(Color.FromArgb(0x21, 0x49, 0x74), 3))
                {
                    e.Graphics.DrawLine(pen, new Point(0, lineY), new Point(flowLayoutPanel1.Width-2, lineY));
                }
            }
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            if (ColumnInfo != null && !textChangeLock)
                ColumnInfo.Title = textBoxTitle.Text;
        }

        private void commonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeType((int)RowItemType.Common);
        }

        private void nikonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeType((int)RowItemType.Nikon);
        }

        private void ChangeType(int type)
        {
            var itemId = int.Parse(customMenuStrip1.Tag.ToString());

            var itemInfo = ColumnInfo.GetItem(itemId);
            if (itemInfo != null)
                itemInfo.Type = type;

            RefreshLabels();
        }
    }
}
