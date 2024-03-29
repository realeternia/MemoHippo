﻿using MemoHippo.Model;
using MemoHippo.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static MemoHippo.UCTipColumn;

namespace MemoHippo
{
    public class UCRowNikon : UCRowCommon
    {
        private List<string> lines = new List<string>();
        private System.Threading.Timer t;
        private int tick;

        public override RowItemType Type { get { return RowItemType.Nikon; } }

        public UCRowNikon() 
            : base()
        {
            UpdateView();
        }

        protected override void UpdateView()
        {
            Height = 70;
        }


        private void T_Tick(object state)
        {
            tick++;
            Invalidate();
        }

        public override void AfterInit()
        {
            lines.Clear();

            var infos = RtfModifier.ReadRtfPlainText(ItemId);
            foreach(var info in infos.Split('\n'))
            {
                if (!string.IsNullOrWhiteSpace(info))
                    lines.Add(info.Trim());
            }

            t = new System.Threading.Timer(T_Tick, null, MathTool.GetRandom(MemoBook.Instance.Cfg.NikonInterval / 2 * 1000), MemoBook.Instance.Cfg.NikonInterval * 1000);
        }

        public override void OnRemove()
        {
            t.Dispose();
        }

        protected override void UCRowCommon_Paint(object sender, PaintEventArgs e)
        {
            DrawBase(e);
            if (lines.Count > 0)
            {
                using (var brush = new SolidBrush(MemoBook.Instance.Cfg.NikonForeColor.ToColor()))
                    e.Graphics.DrawString(lines[tick % lines.Count], Font, brush, 35, 35);
            }
        }
    }
}
