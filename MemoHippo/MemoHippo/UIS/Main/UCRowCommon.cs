using MemoHippo.Model;
using MemoHippo.Properties;
using MemoHippo.UIS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCRowCommon : UserControl, IRowItem
    {
        public int ItemId { get; set; }
        public event MouseEventHandler NLMouseClick;
        public event MouseEventHandler NLMouseDown;
        public event MouseEventHandler NLMouseUp;

        public CustomMenuStrip Menu { get; set; }

        private Rectangle menuRegion;

        private bool selected;
        protected Image icon;
        private string title;
        protected bool isMouseOver;

        protected MemoItemInfo itemInfo;
        private Dictionary<string, int> parmCount = new Dictionary<string, int>();

        public UCRowCommon(MemoItemInfo itemIf)
        {
            InitializeComponent();

            MouseClick += UCRowCommon_MouseClick;
            MouseDown += UCRowCommon_MouseDown;
            MouseUp += UCRowCommon_MouseUp;

            menuRegion = new Rectangle(Width - 40, Height / 2 - Resources.menu.Height / 2, 34, 31);
            itemInfo = itemIf;

            var parmList = itemInfo.GetParmList();
            foreach(var parm in parmList)
            {
                if (parm.Item2 != "0")
                    parmCount[parm.Item1] = int.Parse(parm.Item2);
            }
            if (parmCount.Count > 0)
                Height = 70;
        }

        public virtual void AfterInit()
        {

        }

        public void SetTitle(string str)
        {
            title = str;
        }

        public void SetIcon(string icon1)
        {
            icon = ResLoader.Read(icon1);
        }

        private void UCRowCommon_MouseClick(object sender, MouseEventArgs e)
        {
            if (menuRegion.Contains(e.Location) && Menu != null)
            {
                Menu.Show(this, menuRegion.X + menuRegion.Width, menuRegion.Y);
                Menu.Tag = ItemId;
            }

            if (NLMouseClick != null)
                NLMouseClick(this, e);
        }
        private void UCRowCommon_MouseDown(object sender, MouseEventArgs e)
        {
            if (NLMouseDown != null)
                NLMouseDown(this, e);
        }
        private void UCRowCommon_MouseUp(object sender, MouseEventArgs e)
        {
            if (NLMouseUp != null)
                NLMouseUp(this, e);
        }
        private void UCRowCommon_MouseEnter(object sender, EventArgs e)
        {
            isMouseOver = true;
            // 重新绘制控件
            this.Invalidate();
        }

        private void UCRowCommon_MouseLeave(object sender, EventArgs e)
        {
            isMouseOver = false;
            // 重新绘制控件
            this.Invalidate();
        }

        public void SetSelect(bool sel)
        {
            selected = sel;
            Invalidate();
        }

        protected void DrawBase(PaintEventArgs e)
        {
            if (icon != null)
                e.Graphics.DrawImage(icon, 1, 5, 32, 32);
            e.Graphics.DrawString(title, Font, Brushes.WhiteSmoke, 35, 8);

            if (isMouseOver)
                e.Graphics.DrawImage(Resources.menu, menuRegion);

            if (selected)
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, 0, Width - 1, Height - 1);
        }

        protected virtual void UCRowCommon_Paint(object sender, PaintEventArgs e)
        {
            DrawBase(e);

            int offset = 0;

            if (parmCount.ContainsKey("todo"))
                offset += DrawItem(e.Graphics, Resources.add, parmCount["todo"], 35 + 45 * offset);
            if (parmCount.ContainsKey("done"))
                offset += DrawItem(e.Graphics, Resources.done1, parmCount["done"], 35 + 45 * offset);
            if (parmCount.ContainsKey("share"))
                offset += DrawItem(e.Graphics, Resources.share, parmCount["share"], 35 + 45 * offset);
            if (parmCount.ContainsKey("url"))
                offset += DrawItem(e.Graphics, Resources.url, parmCount["url"], 35 + 45 * offset);
        }

        private int DrawItem(Graphics g, Image img, int val, int posX)
        {
            if (val <= 0)
                return 0;
            g.DrawImage(img, posX, 35 + 2, 20, 20);
            g.DrawString(val.ToString(), Font, Brushes.Yellow, posX + 23, 35);
            return 1;
        }

    }
}
