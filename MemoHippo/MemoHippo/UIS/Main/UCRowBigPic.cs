﻿using MemoHippo.Utils;
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
                // 计算缩放比例
                float scale = Math.Min((float)drawRect.Width / bmp.Width, (float)drawRect.Height / bmp.Height);

                // 计算绘制的宽度和高度
                int newWidth = (int)(bmp.Width * scale);
                int newHeight = (int)(bmp.Height * scale);

                // 计算绘制的位置使图像居中
                int x = drawRect.X + (drawRect.Width - newWidth) / 2;
                int y = drawRect.Y + (drawRect.Height - newHeight) / 2;

                // 创建用于绘制的矩形
                Rectangle destRect = new Rectangle(x, y, newWidth, newHeight);

                // 绘制图像
                e.Graphics.DrawImage(bmp, destRect);
            }
        }
    }
}
