using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCTipColumn : UserControl
    {
        public Form1 ParentC;
        private Color itemColor;

        public event System.EventHandler<int> OnClickItem;
        private Timer delayTimer;
        private Control delayControl;

        private int catalogId;
        private int columnId;

        public Model.MemoColumnInfo ColumnInfo;

        private UCTipRowAdd rowAdd;
        private bool isDragging;
        private int lineY;

        public UCTipColumn()
        {
            InitializeComponent();

            delayTimer = new Timer();
            delayTimer.Interval = 100; // 设置为 100 毫秒）
            delayTimer.Enabled = false; // 初始状态为停用

            // 绑定定时器的 Tick 事件处理程序
            delayTimer.Tick += new EventHandler(OnDelayTimerTick);

            rowAdd = new UCTipRowAdd();
            DecorateControl(rowAdd);
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
            labelTT.Text = title;
            labelTT.BackColor = ColorPlus(cr, 2);
          //  BackColor = ColorPlus(cr, 0.65f);
            flowLayoutPanel1.BackColor = ColorPlus(cr, 0.65f);
            itemColor = cr;

            ColumnInfo = MemoBook.Instance.GetCatalog(catalogId).GetColumn(columnId);

            RefreshLabels();
        }

        private void RefreshLabels()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in ColumnInfo.Items)
            {
                var label1 = new Label();

                label1.Name = "dragctr" + item.Id;
                label1.Text = item.Title;
                label1.Height = 100;

                DecorateControl(label1);
                AddControl(label1);
            }
            AddControl(rowAdd);
        }

        private void DecorateControl(Control c)
        {
            c.Width = flowLayoutPanel1.Width - 10;
            c.ForeColor = Color.White;
            c.BackColor = itemColor;
            c.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            c.Margin = new Padding(5);
            c.Padding = new Padding(3);
            c.MouseDown += new MouseEventHandler(label_MouseDown);
            c.MouseClick += Label1_MouseClick;
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (!((Control)sender).Name.StartsWith("dragctr"))
                return;

            delayTimer.Start();
            delayControl = (Control)sender;
        }

        private void Label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (OnClickItem != null)
                OnClickItem(sender, 1);
            delayTimer.Stop();
        }

        private void OnDelayTimerTick(object sender, EventArgs e)
        {
            delayTimer.Stop();

            var label = delayControl;
            label.DoDragDrop(label.Parent.Parent.Name + "." + delayControl.Name, DragDropEffects.Move);
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

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string[] names = ((string)e.Data.GetData(DataFormats.StringFormat)).Split('.');

                var itemId = int.Parse(names[1].Replace("dragctr", ""));

                // 根据 Name 查找 Label 控件
                var beginColumn = ParentC.panel1.Controls[names[0]] as UCTipColumn;

                var label = beginColumn.Controls["flowLayoutPanel1"].Controls[names[1]];

                if (label != null)
                {
                    var itm = beginColumn.ColumnInfo.RemoveItem(itemId);
                    ColumnInfo.AddItem(itm);

                    beginColumn.RefreshLabels();
                    RefreshLabels();
                    // 从原始 FlowLayoutPanel 中移除 Label
                    // label.Parent.Controls.Remove(label);

                    // 添加 Label 到目标 FlowLayoutPanel
                    // flowLayoutPanel1.Controls.Add(label);

                    // label.BackColor = itemColor;
                }

                isDragging = false;
            }
        }
        private void flowLayoutPanel1_DragOver(object sender, DragEventArgs e)
        {
            // 获取鼠标拖放的目标位置
            Point clientPoint = flowLayoutPanel1.PointToClient(new Point(e.X, e.Y));

            // 更新线条的起点和终点
            var dragMousePoint = clientPoint;

            // 查找鼠标位置下的控件
            Control droppedControl = flowLayoutPanel1.GetChildAtPoint(dragMousePoint);

            if (droppedControl != null)
            {
                if (dragMousePoint.Y > droppedControl.Location.Y + droppedControl.Height / 2)
                    lineY = droppedControl.Location.Y + droppedControl.Height + 5;
                else
                    lineY = droppedControl.Location.Y - 5;
                Debug.Print(droppedControl.Name + lineY);
            }

            // 标记正在拖动
            isDragging = true;

            // 刷新 FlowLayoutPanel，触发 Paint 事件
            flowLayoutPanel1.Invalidate();
        }

        private void flowLayoutPanel1_Click(object sender, System.EventArgs e)
        {
            if (OnClickItem != null)
                OnClickItem(sender, 0);
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
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawLine(pen, new Point(0, lineY), new Point(200, lineY));
                }
            }
        }
    }
}
