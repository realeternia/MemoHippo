using MemoHippo.UIS.Panels;
using MemoHippo.Utils;
using RJControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCSearchCalendar : UserControl
    {
        private ListViewItem selectLine;
        private List<SearchManager.SearchData> searchResults = new List<SearchManager.SearchData>();
        public Form1 Form1 { get; set; }

        public UCSearchCalendar()
        {
            InitializeComponent();

            textBox1.OnLoad();
            Panels.PanelBorders.InitBorder(this);

            rjComboBox1.SelectedIndex = 0;
        }

        public void OnInit(string keyword)
        {
            textBox1.Text = keyword;
            textBox1.Focus();
            if (string.IsNullOrEmpty(keyword))
                doubleBufferedPanel1.Hide();

            SearchManager.GenSearchCache(GetBeginTime());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchAct();
        }

        private void SearchAct()
        {
            doubleBufferedPanel1.Visible = false; //防止中途绘制出现奇怪问题
            doubleBufferedPanel1.Controls.Clear();
            searchResults.Clear();

            var searchTxt = textBox1.TrueText.Trim();
            if (string.IsNullOrWhiteSpace(searchTxt))
            {
                return;
            }

            SearchManager.DoSearch(searchTxt, results =>
            {
                selectLine = null;
                searchResults.AddRange(results);

                var startTime = GetStartOfWeek(DateTime.Now);
                var searchBeginTime = GetBeginTime();
                int ctrGap = 5;
                int ctrX = ctrGap;
                int ctrY = ctrGap + 30;
                bool firstLine = true;
                while (startTime > searchBeginTime)
                {
                    var endTime = startTime.AddDays(7);
                    var list = results.FindAll(a => a.CreateTime > startTime && a.CreateTime < endTime);
                    foreach (var item in list)
                        results.Remove(item);

                    if(firstLine)
                    {
                        var lbl = new Label();
                        lbl.Text = startTime.Year.ToString() + " / " + startTime.Month.ToString();
                        lbl.ForeColor = Color.FromArgb(100, Color.LightBlue);
                        lbl.Location = new System.Drawing.Point(ctrX, ctrGap);
                        doubleBufferedPanel1.Controls.Add(lbl);
                    }

                    var ctr = new UCSearchCalendarCell();
                    ctr.Location = new System.Drawing.Point(ctrX, ctrY);
                    ctr.Init(startTime, searchTxt, list);
                    doubleBufferedPanel1.Controls.Add(ctr);
                    var newstartTime = startTime.AddDays(-7);

                    if (newstartTime.Month != startTime.Month)
                    {
                        ctrY = ctrGap + 30;
                        ctrX += ctrGap + ctr.Width;
                        firstLine = true;
                    }
                    else
                    {
                        ctrY += ctrGap + ctr.Height;
                        firstLine = false;
                    }

                    startTime = newstartTime;
                }

                doubleBufferedPanel1.Visible = true;
            });
        }

        private static DateTime GetStartOfWeek(DateTime date)
        {
            // 获取给定日期所在月份的最后一天
            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

            // 从最后一天开始倒退，直到找到一个星期一
            while (lastDayOfMonth.DayOfWeek != DayOfWeek.Monday)
            {
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);
            }

            // 返回找到的最后一个星期一
            return lastDayOfMonth;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lineInfo = searchResults[selectLine.Index];
            var itemInfo = MemoBook.Instance.GetItem(lineInfo.ItemId);

            Form1.ShowPaperPadEx(itemInfo, new Model.Types.ShowPaperParm { SearchTxt = lineInfo.Line.Trim() });

            PanelManager.Instance.HideBlackPanel();
        }

        private void rjComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SearchManager.GenSearchCache(GetBeginTime());
            if (!string.IsNullOrEmpty(textBox1.Text))
                SearchAct();
        }

        private DateTime GetBeginTime()
        {
            if (rjComboBox1.SelectedIndex == 0) //一月
                return DateTime.Now.Subtract(TimeSpan.FromDays(30*6));
            else //一年
                return DateTime.Now.Subtract(TimeSpan.FromDays(365));
        }
    }
}
