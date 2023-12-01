using MemoHippo.Model;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCKVListMultisel : UserControl
    {
        private MemoItemInfo itemInfo;

        public UCKVListMultisel()
        {
            InitializeComponent();
        }

        public void SetData(string k, MemoItemInfo itemInfo1)
        {
            label1.Text = k;
            textBox1.Text = itemInfo1.Tag;
            itemInfo = itemInfo1;
        }

        private void textBox1_Leave(object sender, System.EventArgs e)
        {
            Invalidate();
            itemInfo.Tag = textBox1.Text;
            textBox1.Visible = false;
        }

        private void UCKVListMultisel_Paint(object sender, PaintEventArgs e)
        {
            if (textBox1.Visible)
                return;

            var startX = 210;
            var startY = 5;
            if (!string.IsNullOrEmpty(itemInfo.Tag))
            {
                var dts = itemInfo.Tag.Split(',');
                foreach (string word in dts)
                {
                 
                    // 绘制白色文本
                    e.Graphics.DrawString(word, Font, Brushes.White, startX + 3, startY + 5);

                    // 获取文本框的大小
                    SizeF textSize = e.Graphics.MeasureString(word, Font);

                    Rectangle borderRect = new Rectangle(startX, startY, (int)textSize.Width+6, (int)textSize.Height+6);
                    e.Graphics.FillRectangle(Brushes.DeepSkyBlue, borderRect);

                    e.Graphics.DrawString(word, Font, Brushes.White, startX+3, startY+5);

                    // 调整下一个词的位置
                    startX += (int)textSize.Width + 6+4;
                }
            }
            else
            {
                e.Graphics.DrawString("点击输入", Font, Brushes.DarkGray, startX + 3, startY + 5);
            }
        }

        private void UCKVListMultisel_Click(object sender, System.EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Focus();
            Invalidate();
        }
    }
}
