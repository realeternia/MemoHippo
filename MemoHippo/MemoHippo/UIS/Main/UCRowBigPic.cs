using MemoHippo.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static MemoHippo.UCTipColumn;

namespace MemoHippo
{
    public class UCRowBigPic : UCRowCommon
    {
        public override RowItemType Type { get { return RowItemType.BigPic; } }

        public UCRowBigPic() 
            : base()
        {
            UpdateView();
        }

        protected override void UpdateView()
        {
            Height = 140;
        }

        public override void AfterInit()
        {

        }

        public override void OnRemove()
        {
        }

        protected override void UCRowCommon_Paint(object sender, PaintEventArgs e)
        {
            DrawBase(e);

            var drawRect = new Rectangle(2, 37, Width-4, Height - 39);
            Image bmp;
            var fullPath = string.Format("{0}/cover.jpg", itemInfo.GetImageDirectory());
            if (File.Exists(fullPath))
            {
                bmp = ImageBook.Instance.Load(fullPath);
            }
            else
            {
                bmp = ImageBook.Instance.Load(string.Format("{0}/d.jpg", ENV.GetImgDir()));
            }
            if (bmp != null)
            {
// 保持宽高比，宽度拉满
float scale = (float)drawRect.Width / bmp.Width;

int newWidth = drawRect.Width;
int newHeight = (int)(bmp.Height * scale);

// 计算 Y 偏移量，并限制最小值为 0（防止向上溢出）
int y = drawRect.Y + Math.Max(0, (drawRect.Height - newHeight) / 2);

// 创建绘制区域
Rectangle destRect = new Rectangle(drawRect.X, y, newWidth, newHeight);

e.Graphics.DrawImage(bmp, destRect);
            }
        }
    }
}
