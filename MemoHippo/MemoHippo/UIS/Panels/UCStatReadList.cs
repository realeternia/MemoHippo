using MemoHippo.Utils;
using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    public partial class UCStatReadList : UserControl
    {
        public UCStatReadList()
        {
            InitializeComponent();
        }

        public void Init()
        {
            // 假设 itemInfo 是从外部传入或已绑定的数据
            var rs = MemoBook.Instance.Records.Records;

            // 清空旧数据
            listView1.Items.Clear();

            foreach (var record in rs)
            {
                var bgInfo = MemoBook.Instance.GetItem(record.RecordId);
                //// 假设 itemInfo.Name 是桌游名
                //var item = new ListViewItem(TimeTool.UnixTimeToDateTime(record.BeginTime).ToString("yyyy/MM/dd")); // 时间
                //item.SubItems.Add(bgInfo.Title);              // 桌游名
                //item.SubItems.Add(record.Details);             // 详情

                //listView1.Items.Add(item);
            }
        }
    }
}
