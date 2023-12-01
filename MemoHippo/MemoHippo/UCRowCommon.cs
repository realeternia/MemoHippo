using MemoHippo.Model;
using MemoHippo.Properties;
using MemoHippo.UIS;
using System;
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
        private Image icon;
        private string title;
        private bool isMouseOver;

        public UCRowCommon()
        {
            InitializeComponent();

            MouseClick += UCRowCommon_MouseClick;
            MouseDown += UCRowCommon_MouseDown;
            MouseUp += UCRowCommon_MouseUp;

            menuRegion = new Rectangle(Width - 40, Height / 2 - Resources.menu.Height / 2, 34, 31);
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

        private void UCRowCommon_Paint(object sender, PaintEventArgs e)
        {
            if (icon != null)
                e.Graphics.DrawImage(icon, 1, 5, 32, 32);
            e.Graphics.DrawString(title, Font, Brushes.WhiteSmoke, 35, 8);

            if (isMouseOver)
                e.Graphics.DrawImage(Resources.menu, menuRegion);

            if (selected)
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, 0, Width-1, Height-1);

        }

    }
}
