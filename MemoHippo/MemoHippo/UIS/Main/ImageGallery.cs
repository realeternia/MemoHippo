using MemoHippo.Model;
using System.IO;
using System.Windows.Forms;

namespace MemoHippo.UIS.Main
{
    public partial class ImageGallery : UserControl
    {
        public Form1 ParentC;
        private MemoItemInfo itemInfo;

        public ImageGallery()
        {
            InitializeComponent();

            doubleBufferedFlowLayoutPanel1.AllowDrop = true;
        }

        public void Init(MemoItemInfo item)
        {
            if (item == itemInfo)
                return;

            itemInfo = item;

            RefreshAll();
        }

        private void RefreshAll()
        {
            doubleBufferedFlowLayoutPanel1.Controls.Clear();

            if (!Directory.Exists(ENV.ImgDir + itemInfo.Id))
                return;

            foreach (var path in Directory.GetFiles(ENV.ImgDir + itemInfo.Id))
            {
                var showItem = new UCImageGalleryItem();
                showItem.Init(itemInfo.Id, path);
                doubleBufferedFlowLayoutPanel1.Controls.Add(showItem);
            }
        }

        private void doubleBufferedFlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            // 获取拖放的文件路径
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (!Directory.Exists(ENV.ImgDir + itemInfo.Id))
                Directory.CreateDirectory(ENV.ImgDir + itemInfo.Id);
            var destPath = Path.Combine(Directory.GetCurrentDirectory(), ENV.ImgDir + itemInfo.Id);
            foreach (var f in files)
            {
                File.Move(f, destPath + "\\" + new FileInfo(f).Name);
            }
            RefreshAll();
        }

        private void doubleBufferedFlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            // 检查拖放的数据是否包含文件
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
