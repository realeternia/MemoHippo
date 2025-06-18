using MemoHippo.Model;
using MemoHippo.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCDocTagItem : UserControl, IDocComp
    {
        private string tagStr;
        public Action<string> OnModify { get; set; }

        public UCDocTagItem()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void SetData(string k, string tagStr1)
        {
            label1.Text = k;
            tagStr = tagStr1;
        }

        public void SetReadOnly(bool readOnly)
        {
        }

        private void UCDocTagItem_Paint(object sender, PaintEventArgs e)
        {
            var startX = 210;
            var startY = 3;
            if (!string.IsNullOrEmpty(tagStr))
            {
                var dts = tagStr.Split(',');
                foreach (string word in dts)
                {
                 
                    // 绘制白色文本
                    e.Graphics.DrawString(word, Font, Brushes.White, startX + 3, startY + 5);

                    // 获取文本框的大小
                    SizeF textSize = e.Graphics.MeasureString(word, Font);

                    Rectangle borderRect = new Rectangle(startX, startY+3, (int)textSize.Width+6, (int)textSize.Height+2);
                    var brush = DrawTool.GetTagBrush(word);
                    e.Graphics.FillRectangle(brush, borderRect);

                    e.Graphics.DrawString(word, Font, Brushes.White, startX+3, startY+5);

                    // 调整下一个词的位置
                    startX += (int)textSize.Width + 6+4;
                }
            }
            else
            {
                e.Graphics.DrawString("点击输入", Font, Brushes.DarkGray, startX, startY + 5);
            }
        }

        private void UCDocTagItem_Click(object sender, System.EventArgs e)
        {
            PanelManager.Instance.ShowBGPropertyModify(tagStr, (s) => { OnModify(s); tagStr = s; });
        }

    }
}
