using MemoHippo.Model;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemoHippo
{
    public class UCRowNikon : UCRowCommon
    {
        private List<string> lines = new List<string>();
        private Timer t;
        private int tick;

        public UCRowNikon(MemoItemInfo itemIf)
            : base(itemIf)
        {
            Height = 70;

            t = new Timer();
            t.Interval = 30000;
            t.Tick += T_Tick;
        }


        private void T_Tick(object sender, System.EventArgs e)
        {
            tick++;
            Invalidate();
        }

        public override void AfterInit()
        {
            var fullPath = string.Format("{0}/{1}.rtf", ENV.SaveDir, ItemId);
            var infos = ConvertRtfToPlainText(File.ReadAllText(fullPath));
            foreach(var info in infos.Split('\n'))
            {
                if (!string.IsNullOrWhiteSpace(info))
                    lines.Add(info.Trim());
            }

            t.Start();
        }

        private string ConvertRtfToPlainText(string rtfContent)
        {
            using (RichTextBox richTextBox = new RichTextBox())
            {
                richTextBox.Rtf = rtfContent;
                return richTextBox.Text;
            }
        }


        protected override void UCRowCommon_Paint(object sender, PaintEventArgs e)
        {
            DrawBase(e);
            if (lines.Count > 0)
                e.Graphics.DrawString(lines[tick % lines.Count], Font, Brushes.Yellow, 35, 35);
        }
    }
}
