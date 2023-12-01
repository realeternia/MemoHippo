using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MemoHippo.Utils;

namespace Text_Editor
{

    public partial class UCToolbar : UserControl
    {
        private Timer fadeInTimer;
        private bool toShow;
        private DateTime timeToFinish;

        public UCToolbar()
        {
            InitializeComponent();

            fadeInTimer = new Timer();
            fadeInTimer.Interval = 10; // 设置速度
            fadeInTimer.Tick += new EventHandler(FadeInTimer_Tick);

            foreach (var cr in ColorTool.BaseColorTable)
            {
                ToolStripMenuItem blueMenuItem = new ToolStripMenuItem(cr.Key);
                //    blueMenuItem.BackColor = Color.Blue;
                blueMenuItem.BackColor = Color.FromArgb(24, 24, 24);
                blueMenuItem.ForeColor = Color.White;
                blueMenuItem.Image = ImageTool.CreateSolidColorBitmap(Color.FromArgb(cr.Value.R, cr.Value.G, cr.Value.B), 32, 32);
                blueMenuItem.Tag = cr.Value;
           //     blueMenuItem.Click += ColorMenuItem_Click;
                colorStripDropDownButton.DropDownItems.Add(blueMenuItem);
            }

            foreach (var cr in ColorTool.FullColorTable)
            {
                ToolStripMenuItem blueMenuItem = new ToolStripMenuItem(cr.Key);
                //    blueMenuItem.BackColor = Color.Blue;
                blueMenuItem.BackColor = Color.FromArgb(24, 24, 24);
                blueMenuItem.ForeColor = Color.White;
                blueMenuItem.Image = ImageTool.CreateSolidColorBitmap(Color.FromArgb(cr.Value.R, cr.Value.G, cr.Value.B), 32, 32);
                blueMenuItem.Tag = cr.Value;
                //     blueMenuItem.Click += ColorMenuItem_Click;

                var colorS = ColorClassifier.ClassifyColor(cr.Value);
                var subItem = colorStripDropDownButton.DropDownItems[(int)colorS] as ToolStripMenuItem;
                subItem.DropDownItems.Add(blueMenuItem);
            }
        }

        public void DelayVisible(bool visible, int ms)
        {
            if (Visible == visible)
                return;

            fadeInTimer.Stop();
            toShow = visible;
            timeToFinish = DateTime.Now.AddMilliseconds(ms);
            fadeInTimer.Start();
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now > timeToFinish)
            {
                fadeInTimer.Stop();
                Visible = toShow;
            }
          
        }
    }

}
