using MemoHippo.Model;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCKVList : UserControl
    {
        public UCKVList()
        {
            InitializeComponent();
        }

        public void Init(MemoItemInfo itemInfo)
        {
            BackColor = Color.DarkBlue;
            doubleBufferedFlowLayoutPanel1.Controls.Clear();

            AddData("类型", itemInfo.Type.ToString());
            AddData("创建时间", new FileInfo("save/"+itemInfo.Id+".rtf").CreationTime.ToString());

            Height = doubleBufferedFlowLayoutPanel1.Controls.Count * 37+10;
        }

        public void AddData(string k, string v)
        {
            var item = new UCKVListItem();
            item.Width = 700 - 5;
            item.Height = 37;
            item.SetData(k, v);
            doubleBufferedFlowLayoutPanel1.Controls.Add(item);
        }
    }
}
