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

            var imgFolder = itemInfo.GetImageDirectory();
            if (!Directory.Exists(imgFolder))
                return;

            foreach (var path in Directory.GetFiles(imgFolder))
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

            var imgFolder = itemInfo.GetImageDirectory();
            if (!Directory.Exists(imgFolder))
                Directory.CreateDirectory(imgFolder);
            var destPath = Path.Combine(Directory.GetCurrentDirectory(), imgFolder);
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
