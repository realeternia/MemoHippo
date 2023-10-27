using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCTipGroup : UserControl
    {
        public Form1 ParentC;
        private Color itemColor;

        public event System.EventHandler<int> OnClickItem;
        private Timer delayTimer;
        private Control delayControl;

        public UCTipGroup()
        {
            InitializeComponent();

            delayTimer = new Timer();
            delayTimer.Interval = 100; // 设置为 100 毫秒）
            delayTimer.Enabled = false; // 初始状态为停用

            // 绑定定时器的 Tick 事件处理程序
            delayTimer.Tick += new EventHandler(OnDelayTimerTick);
        }

        public Color ColorPlus(Color c, float exp)
        {
            return Color.FromArgb((byte)(c.R * exp), (byte)(c.G * exp), (byte)(c.B * exp));
        }

        public void Init(string title, Color cr)
        {
            labelTT.Text = title;
            labelTT.BackColor = ColorPlus(cr, 2);
          //  BackColor = ColorPlus(cr, 0.65f);
            flowLayoutPanel1.BackColor = ColorPlus(cr, 0.65f);
            itemColor = cr;

            AddTestLabel();
            AddTestLabel();
        }

        private void AddTestLabel()
        {
            var label1 = new System.Windows.Forms.Label();
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.BackColor = System.Drawing.Color.White;
            label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label1.ForeColor = System.Drawing.Color.White;
            label1.BackColor = itemColor;
            label1.Location = new System.Drawing.Point(10, 95);
            label1.Margin = new System.Windows.Forms.Padding(5);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(3);
            label1.Size = new System.Drawing.Size(230, 53);
            label1.TabIndex = 2;
            label1.Text = "label1";
            label1.Width = flowLayoutPanel1.Width - 10;
            label1.MouseDown += new System.Windows.Forms.MouseEventHandler(label_MouseDown);
            label1.MouseClick += Label1_MouseClick;
            AddControl(label1);
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

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            delayTimer.Start();
            delayControl = (Control)sender;
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
            }
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string[] names = ((string)e.Data.GetData(DataFormats.StringFormat)).Split('.');

                // 根据 Name 查找 Label 控件
                var flowCtr = ParentC.panel1.Controls[names[0]];
                if (!(flowCtr is FlowLayoutPanel))
                    flowCtr = flowCtr.Controls["flowLayoutPanel1"];
                var label = flowCtr.Controls[names[1]];

                if (label != null)
                {

                    // 从原始 FlowLayoutPanel 中移除 Label
                    label.Parent.Controls.Remove(label);

                    // 添加 Label 到目标 FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(label);
                    label.BackColor = itemColor;
                }
            }
        }

        private void flowLayoutPanel1_Click(object sender, System.EventArgs e)
        {
            if (OnClickItem != null)
                OnClickItem(sender, 0);
        }
    }
}
