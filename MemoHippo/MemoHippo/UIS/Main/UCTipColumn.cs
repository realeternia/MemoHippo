using MemoHippo.Model;
using MemoHippo.UIS;
using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCTipColumn : UserControl
    {
        private static List<UCRowCommon> labelCacheList = new List<UCRowCommon>();

        private static T FindAndRemove<T>() where T : UCRowCommon
        {
            foreach (var item in labelCacheList)
            {
                if (item.GetType() == typeof(T))
                {
                    labelCacheList.Remove(item);
                    return item as T;
                }
            }
            return null;
        }

        public class EventItemClickArgs : EventArgs
        {
            public int ItemId { get; set; }
            public int ColumnId { get; set; }

            public bool FocusTitle { get; set; }
        }

        public enum RowItemType
        {
            Common=1,
            Nikon
        }


        public Form1 ParentC;
        private Color itemColor;

        public event EventHandler<EventItemClickArgs> OnClickItem;
        private Timer delayTimer;
        private Control delayControl;
        private bool isDragging;
        private Point dragStartPos;

        private int catalogId;
        private int columnId;

        public MemoColumnInfo ColumnInfo;

        private UCRowAdd rowAdd;
        public RJControls.RJDropdownMenu RowMenu { get; set; }

        private int lineY;
        private bool textChangeLock;

        private InputTextBox2 inputBox;
        private Rectangle menuRegion;
        private bool isMouseOn;

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
            rowAdd.label1.Click += buttonAdd_Click;

            DoubleBuffered = true;
        }


        public void Init(int cid, int itid, string title, Color cr)
        {
            catalogId = cid;
            columnId = itid;
            textChangeLock = true;
            labelTitle.Text = title;
            textChangeLock = false;
            labelTitle.BackColor = ColorTool.ColorPlus(cr, 2);
            flowLayoutPanel1.BackColor = ColorTool.ColorPlus(cr, 0.65f);
            itemColor = cr;

            ColumnInfo = MemoBook.Instance.GetCatalog(catalogId).GetColumn(columnId);

            inputBox = new InputTextBox2();
            inputBox.Form1 = ParentC;
            inputBox.Text = labelTitle.Text;
            inputBox.OnCustomTextChanged += Hintbox_OnCustomTextChanged;

            menuRegion = new Rectangle(Width - 50, 13, 40, 30);

            RefreshLabels();
        }


        public void RefreshLabels()
        {
            ReleaseAllLabels();
            flowLayoutPanel1.Controls.Clear();

            foreach (var memoItem in ColumnInfo.Items)
            {
                UCRowCommon labelCtr;
                if (memoItem.Type == (int)RowItemType.Nikon)
                    labelCtr = FindAndRemove<UCRowNikon>() ?? new UCRowNikon();
                else
                    labelCtr = FindAndRemove<UCRowCommon>() ?? new UCRowCommon();

                labelCtr.itemInfo = memoItem;
                labelCtr.Menu = RowMenu;
                labelCtr.ColumnCtr = this;

                var rowItem = labelCtr as IRowItem;
                rowItem.ItemId = memoItem.Id;
                rowItem.SetTitle(memoItem.Title);
                rowItem.SetIcon(memoItem.Icon);
                DecorateControl(labelCtr, memoItem.Id);
                AddControl(labelCtr);

                rowItem.AfterInit();
            }
            AddControl(rowAdd);
            isDragging = false;
        }

        public void ReleaseAllLabels()
        {
            foreach(var ctr in flowLayoutPanel1.Controls)
            {
                var rowItem = ctr as UCRowCommon;
                if (rowItem != null)
                {
                    rowItem.NLMouseDown -= new MouseEventHandler(label_MouseDown);
                    rowItem.NLMouseUp -= new MouseEventHandler(label_MouseUp);
                    rowItem.NLMouseClick -= Label1_MouseClick;
                    labelCacheList.Add(rowItem);
                }
            }
        }

        private void DecorateControl(Control c, int id)
        {
            c.Name = "dragctr" + id;
            c.Width = flowLayoutPanel1.Width - 10;
            c.ForeColor = Color.White;
            if (id > 0)
                c.BackColor = itemColor;
            c.Margin = new Padding(5);

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
            var ctr = (Control)sender;
            delayTimer.Stop();

           // HLog.Info("UCTipColumn mouse up {0}", ctr.Name);
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            var ctr = (Control)sender;
            if (ctr.Name == "dragctr0") // add 对象
                return;

          //  HLog.Info("UCTipColumn mouse down {0}", ctr.Name);

            delayTimer.Start();
            delayControl = ctr;
        }

        private void Label1_MouseClick(object sender, MouseEventArgs e)
        {
            var senderName = (sender as Control).Name;
            if (OnClickItem != null)
            {
                var itemId = GetDragCtrItemId(senderName);
                OnClickItem(sender, new EventItemClickArgs { ItemId = itemId, ColumnId = columnId });
            }
            delayTimer.Stop();

      //      HLog.Info("UCTipColumn mouse click {0}", senderName);
        }

        private void OnDelayTimerTick(object sender, EventArgs e)
        {
            HLog.Info("UCTipColumn OnDelayTimerTick DoDragDrop {0}", delayControl.Name);

            delayTimer.Stop();

            var label = delayControl;

            label.DoDragDrop(label.Parent.Parent.Name + "." + delayControl.Name, DragDropEffects.Move);

         //   HLog.Info("UCTipColumn OnDelayTimerTick DoDragDrop end {0}", delayControl.Name);

            delayControl = null;
        }


        private void AddControl(Control c)
        {
            flowLayoutPanel1.Controls.Add(c);
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
                isDragging = true;

                dragStartPos = MousePosition;
          //      HLog.Info("UCTipColumn DragEnter data={0} mp={1}", e.Data.GetData(DataFormats.StringFormat), MousePosition);
            }
        }

        private void flowLayoutPanel1_DragLeave(object sender, EventArgs e)
        {
            isDragging = false;
            flowLayoutPanel1.Invalidate();

      //      HLog.Info("UCTipColumn DragLeave");
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
           //     HLog.Info("UCTipColumn DragDrop data={0} mp={1}", e.Data.GetData(DataFormats.StringFormat), MousePosition);

                if(Math.Abs(dragStartPos.X - MousePosition.X) + Math.Abs(dragStartPos.Y - MousePosition.Y) > 10)
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
                        flowLayoutPanel1.Invalidate();
                    }
                }

                isDragging = false;
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

        private void UCTipColumn_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender == this && menuRegion.Contains(new Point(e.X, e.Y)))
            {
                ParentC.CustomMenuStripCol.Tag = columnId;
                ParentC.CustomMenuStripCol.Show(this, menuRegion.X, menuRegion.Y + menuRegion.Height + 5);
                return;
            }

            if (OnClickItem != null)
                OnClickItem(sender, null);
        }

        //新增加一个页面
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var newItem = ColumnInfo.AddItem("");

            RefreshLabels();

            if (OnClickItem != null)
            {
                var ctrs = flowLayoutPanel1.Controls.Find("dragctr" + newItem.Id, false);
                if (ctrs.Length > 0)
                    OnClickItem(ctrs[0], new EventItemClickArgs { ItemId = newItem.Id, ColumnId = columnId, FocusTitle = true });
            }
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

        private void labelTitle_MouseClick(object sender, MouseEventArgs e)
        {
            Point absoluteLocation = labelTitle.PointToScreen(new Point(0, 0));

            ParentC.ShowBlackPanel(inputBox, absoluteLocation.X - ParentC.Location.X, absoluteLocation.Y - ParentC.Location.Y, 1);
            inputBox.Focus();
        }

        private void Hintbox_OnCustomTextChanged(object sender, EventArgs e)
        {
            labelTitle.Text = inputBox.Text;

            if (ColumnInfo != null && !textChangeLock)
                ColumnInfo.Title = inputBox.Text;
        }

        private void UCTipColumn_MouseEnter(object sender, EventArgs e)
        {
            isMouseOn = true;
            Invalidate(new Rectangle(menuRegion.X-1, menuRegion.Y-1, menuRegion.Width+2, menuRegion.Height+2));
        }

        private void UCTipColumn_MouseLeave(object sender, EventArgs e)
        {
            isMouseOn = false;
            Invalidate(new Rectangle(menuRegion.X - 1, menuRegion.Y - 1, menuRegion.Width + 2, menuRegion.Height + 2));
        }

        private void UCTipColumn_Paint(object sender, PaintEventArgs e)
        {
            if (isMouseOn)
            {
                e.Graphics.DrawRectangle(Pens.Gray, menuRegion);
                e.Graphics.DrawString("...", Font, Brushes.White, menuRegion.X+5, menuRegion.Y+5);
            }
        }

    }
}
