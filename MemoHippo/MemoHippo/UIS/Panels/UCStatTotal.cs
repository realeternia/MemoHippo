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
            var now = DateTime.Now;
            var currentYear = now.Year;
            var currentMonth = now.Month;
            var lastMonth = now.AddMonths(-1);

            int totalCount = 0;
            int thisYearCount = 0;
            int lastYearCount = 0;
            int thisMonthCount = 0;
            int lastMonthCount = 0;

            if (MemoBook.Instance.Items != null)
            {
                foreach (var item in MemoBook.Instance.Items)
                {
                    totalCount++;
                    var createTime = item.GetCreateTime();
                    if (createTime.Year == currentYear)
                    {
                        thisYearCount++;
                        if (createTime.Month == currentMonth)
                        {
                            thisMonthCount++;
                        }
                    }
                    if (createTime.Year == currentYear - 1)
                    {
                        lastYearCount++;
                    }
                    if (createTime.Year == lastMonth.Year && createTime.Month == lastMonth.Month)
                    {
                        lastMonthCount++;
                    }
                }
            }

            AddLine("文档总计", "数量", totalCount.ToString(), Color.White);
            AddLine("", "今年文档数", thisYearCount.ToString(), Color.LawnGreen);
            AddLine("", "去年文档数", lastYearCount.ToString(), Color.LightGray);
            AddLine("", "本月文档数", thisMonthCount.ToString(), Color.LawnGreen);
            AddLine("", "上月文档数", lastMonthCount.ToString(), Color.LightGray);
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
