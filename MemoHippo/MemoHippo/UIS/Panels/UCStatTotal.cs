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
            AddLine("文档总计", "数量", MemoBook.Instance.Items.Count.ToString(), Color.White);
            AddLine("", "今年文档数", MemoBook.Instance.Items.FindAll(a => a.GetCreateTime().Year == DateTime.Now.Year).Count.ToString(), Color.LawnGreen);
            AddLine("", "去年文档数", MemoBook.Instance.Items.FindAll(a => a.GetCreateTime().Year == DateTime.Now.Year - 1).Count.ToString(), Color.LightGray);
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;
            AddLine("", "本月文档数", (MemoBook.Instance.Items?.FindAll(a => a.GetCreateTime().Year == currentYear && a.GetCreateTime().Month == currentMonth).Count ?? 0).ToString(), Color.LawnGreen);
            var now = DateTime.Now;
            var lastMonth = now.AddMonths(-1);
            AddLine("", "上月文档数", MemoBook.Instance.Items.FindAll(a => a.GetCreateTime().Year == lastMonth.Year && a.GetCreateTime().Month == lastMonth.Month).Count.ToString(), Color.LightGray);
        }

        private void AddLine(string t, string subt, string val, Color foreColor)
        {
            ListViewItem lvi = new ListViewItem(t);
            lvi.UseItemStyleForSubItems = false; //aaaaaaaa
            lvi.SubItems.Add(subt);
            lvi.SubItems.Add(val);
            lvi.SubItems[lvi.SubItems.Count - 1].ForeColor = foreColor;
            listView1.Items.Add(lvi);
        }
    }
}
