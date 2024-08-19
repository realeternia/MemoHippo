using MemoHippo.Model;
using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCDocPropertyList : UserControl
    {
        private int itemId;
        public Color BgColor
        {
            get { return doubleBufferedPanel1.BackColor; }
            set { doubleBufferedPanel1.BackColor = value; }
        }

        public UCDocPropertyList()
        {
            InitializeComponent();
        }

        public void Init(MemoItemInfo itemInfo)
        {
            itemId = itemInfo.Id;
            var oldCtrList = new List<Control>();
            foreach (Control c in doubleBufferedPanel1.Controls)
                oldCtrList.Add(c);
            doubleBufferedPanel1.Controls.Clear();

            // 需要逆序
            if (!MemoBook.Instance.Cfg.DisableTag)
                CheckCtrs(oldCtrList, "tag",  "标签", itemInfo.Tag, (s) => { itemInfo.SetTag(s); });
            CheckCtrs(oldCtrList, "common",  "存储路径", itemInfo.Folder, (s) => { itemInfo.SetFolder(s); });
            CheckCtrs(oldCtrList, "common",  "别名", string.IsNullOrEmpty(itemInfo.NickName) ? itemInfo.Id.ToString() : itemInfo.NickName, (s) => itemInfo.NickName = s);
            CheckCtrs(oldCtrList, "common",  "创建时间", itemInfo.GetCreateTime().ToString(), null);

            //Width = 700 - 5; //width 在外部控制
            Height = doubleBufferedPanel1.Controls.Count * 37 + 10;
            doubleBufferedPanel1.Invalidate();
        }

        public void OnSizeChanged()
        {
            foreach (Control c in doubleBufferedPanel1.Controls)
                c.Width = Math.Max(1, Width - 220);
        }

        private void CheckCtrs(List<Control> cc, string type, string k, string v, Action<string> onModify)
        {
            var found = FindCtr(cc, k);
            if(found == null)
            {
                if (type == "common")
                    found = new UCDocStringItem();
                else if (type == "multisel")
                    found = new UCDocMultiselItem();
                else if (type == "tag")
                    found = new UCDocTagItem();

                var foundCtr = found as Control;
                foundCtr.Name = k;
                foundCtr.Height = 37;
            }
            found.OnModify = onModify;
            found.SetData(k, v);
            found.SetReadOnly(onModify == null);

            doubleBufferedPanel1.Controls.Add(found as Control);
            var foundCtr2 = found as Control;
            foundCtr2.Location = new Point(0, doubleBufferedPanel1.Controls.Count * 37);
            foundCtr2.Width = Math.Max(1, Width - 220);
           // foundCtr2.Dock = DockStyle.Top;
        }

        private IDocComp FindCtr(List<Control> cc, string k)
        {
            foreach(Control c in cc)
            {
                if (c.Name == k)
                    return c as IDocComp;
            }
            return null;
        }

        private void doubleBufferedPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (itemId == 0)
                return;

           // var width = 200;
            Image img = ImageBook.Instance.Load(ENV.GetImgDir() + itemId + "/cover.jpg");
            if(img == null)
                img = ImageBook.Instance.Load(ImageBook.Instance.FindFirstFilePath(ENV.GetImgDir() + itemId));

            // 如果图片加载成功  
            if (img != null)
            {
                int maxWidth = 200;
                // 计算缩放比例  
                float scaleWidth = (float)maxWidth / img.Width;
                float scaleHeight = (float)Height / img.Height;

                if (scaleHeight < scaleWidth)
                    scaleWidth = scaleHeight;

                // 计算缩放后的图片尺寸  
                int scaledWidth = (int)(img.Width * scaleWidth);
                int scaledHeight = (int)(img.Height * scaleWidth);

                // 计算图片绘制的起始位置，确保图片在目标区域内居中  
                int x = Math.Max(0, Width - 220); // 减去220是为了在右侧留出空间  
                int y = (Height - scaledHeight) / 2;

                // 在指定位置绘制图片  
                e.Graphics.DrawImage(img, new Rectangle(x, y, scaledWidth, scaledHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            }
        }
    }
}
