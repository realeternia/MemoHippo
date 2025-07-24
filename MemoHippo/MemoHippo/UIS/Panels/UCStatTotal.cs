using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    public partial class UCStatTotal : UserControl
    {
        public UCStatTotal()
        {
            InitializeComponent();
        }

        public void Init()
        {
            AddLine("桌游总计", "数量", MemoBook.Instance.Items.Count.ToString());
            AddLine("", "今年文档数", MemoBook.Instance.Items.FindAll(a => a.GetCreateTime().Year == DateTime.Now.Year).Count.ToString());
            AddLine("", "本月文档数", MemoBook.Instance.Items.FindAll(a => a.GetCreateTime().Month == DateTime.Now.Month).Count.ToString());
        }

        private void AddLine(string t, string subt, string val)
        {
            ListViewItem lvi = new ListViewItem(t);
            lvi.UseItemStyleForSubItems = false; //aaaaaaaa
            lvi.SubItems.Add(subt);
            lvi.SubItems.Add(val);
            if (val.StartsWith("-"))
                lvi.SubItems[lvi.SubItems.Count - 1].ForeColor = Color.IndianRed;
            else if (val.StartsWith("￥"))
                lvi.SubItems[lvi.SubItems.Count - 1].ForeColor = Color.Orange;
            else
                lvi.SubItems[lvi.SubItems.Count - 1].ForeColor = Color.LawnGreen;
            listView1.Items.Add(lvi);
        }
    }
}
