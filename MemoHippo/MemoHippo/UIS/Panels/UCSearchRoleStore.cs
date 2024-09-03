using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCSearchRoleStore : UserControl
    {
        private List<SearchManager.SearchData> searchResults = new List<SearchManager.SearchData>();
        public Form1 Form1 { get; set; }

        private List<string> nameList = new List<string>();
        private List<float> crList = new List<float>();
        private List<float> cr2List = new List<float>();
        private List<float> jixiaoList = new List<float>();

        public UCSearchRoleStore()
        {
            InitializeComponent();

            Panels.PanelBorders.InitBorder(this);
            hintTextBoxSearch.OnLoad();

            rjComboBox1.SelectedIndex = 0;

        }

        public void OnInit(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                listView1.Hide();

            panel1.Visible = false;

            hintTextBoxSearch.TrueText = "";

            var db = CsvDbHouse.Instance.RoleDb;
            RefreshNameList(db);
            if (nameList.Count == 0)
            {
                crList = db.GetValuesByHeader("TTCCR值").ConvertAll<float>(s => float.Parse(s));
                crList.RemoveAll(s => s == 0);
                cr2List = db.GetValuesByHeader("TP1CR值").ConvertAll<float>(s => float.Parse(s));
                cr2List.RemoveAll(s => s == 0);
                jixiaoList = db.GetValuesByHeader("绩效").ConvertAll<float>(s => float.Parse(s));
                jixiaoList.RemoveAll(s => s == 0);

                crList.Sort();
                cr2List.Sort();
                jixiaoList.Sort();
            }

            foreach (ListViewItem item in listViewNames.Items)
            {
                string itemText = item.Text;

                // 判断是否为目标项
                if (itemText == keyword)
                {
                    item.Selected = true; // 设置选中项
                    break; // 可以提前结束循环，因为已经找到了目标项
                }
            }

            SearchManager.GenSearchCache(GetBeginTime());
        }

        private void RefreshNameList(CsvDb db)
        {
            nameList = db.GetValuesByHeader("姓名", "职级", (a, b) => { return int.Parse(b.Substring(1)) - int.Parse(a.Substring(1)); });
            listViewNames.Items.Clear();
            //listViewNames.Items.Add("all");
            var searchText = hintTextBoxSearch.TrueText;
            foreach (var name in nameList)
            {
                var rowInfo = db.GetRowStringByKey(name);
                if (!string.IsNullOrEmpty(searchText) && rowInfo.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) < 0)
                    continue;
                var listItem = new ListViewItem(name);
                var job = db.GetValueByKey(name, "岗位");
                listItem.ForeColor = GetCatalogColor(job);
                listViewNames.Items.Add(listItem);
            }
        }

        private Dictionary<string, Color> colorDict = new Dictionary<string, Color>();
        private List<Color> leftColor = new List<Color> { Color.Red, Color.Yellow, Color.LightBlue, Color.LawnGreen, Color.Orange, Color.Cyan };
        private int colorIndex = 0;
        private Color GetCatalogColor(string type)
        {
            if (colorDict.ContainsKey(type))
            {
                return colorDict[type];
            }
            else
            {
                Color color = leftColor[colorIndex % leftColor.Count];
                colorDict.Add(type, color);
                colorIndex++;
                return color;
            }
        }

        private void SearchAct()
        {
            listView1.Visible = false; //防止中途绘制出现奇怪问题
            searchResults.Clear();

        
            if (listViewNames.SelectedItems.Count == 0 || string.IsNullOrWhiteSpace(listViewNames.SelectedItems[0].Text))
            {
                listView1.VirtualListSize = 0;
                return;
            }
            var searchTxt = listViewNames.SelectedItems[0].Text;

            SearchManager.DoSearch(searchTxt, results =>
            {
                searchResults.AddRange(results);
                listView1.VirtualListSize = searchResults.Count;
                listView1.Visible = true;
            });
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= 0 && e.ItemIndex < searchResults.Count)
            {
                ListViewItem item = new ListViewItem(searchResults[e.ItemIndex].Line);
                item.SubItems.Add(searchResults[e.ItemIndex].Title);

                e.Item = item;
            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var lineInfo = searchResults[e.ItemIndex];

            string line = lineInfo.Line;

            // 寻找行中的+和-，并删除
            line = line.Replace("+", "").Replace("-", "");

            // 统计+和-的数量
            int plusCount = lineInfo.Line.Length - lineInfo.Line.Replace("+", "").Length;
            int minusCount = lineInfo.Line.Length - lineInfo.Line.Replace("-", "").Length;
            var remarkStr = "";

            if (plusCount > 0)
                remarkStr = " 正" + plusCount;
            if (minusCount > 0)
                remarkStr = " 负" + minusCount;

            e.Graphics.DrawString(
               string.Format("{0} {2} {1}", TimeTool.GetTimeAgo(lineInfo.CreateTime), line, remarkStr),
               e.Item.Font, Brushes.White, e.Bounds.X + 5, e.Bounds.Y + 5, StringFormat.GenericDefault);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var destRT = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 4);
            var lineInfo = searchResults[e.ItemIndex];
            var bgColor = Color.FromArgb(60, 60, 60);
            if (lineInfo.Line.Contains("+"))
                bgColor = Color.FromArgb(60, 100, 60);
            else if (lineInfo.Line.Contains("-"))
                bgColor = Color.FromArgb(100, 60, 60);
            using (var b = new SolidBrush(bgColor))
                e.Graphics.FillRectangle(b, destRT);
        }

        private void rjComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SearchManager.GenSearchCache(GetBeginTime());
            if (listViewNames.SelectedItems != null && listViewNames.SelectedItems.Count > 0)
                SearchAct();
        }

        private DateTime GetBeginTime()
        {
            if (rjComboBox1.SelectedIndex == 0) //一个月
                return DateTime.Now.Subtract(TimeSpan.FromDays(30));
            else if (rjComboBox1.SelectedIndex == 1) //三个月
                return DateTime.Now.Subtract(TimeSpan.FromDays(90));
            else
                return DateTime.Now.Subtract(TimeSpan.FromDays(365 * 30));
        }

        private void UpdateRoleInfo()
        {
            if (listViewNames.SelectedItems.Count == 0)
                return;

            var searchTxt = listViewNames.SelectedItems[0].Text;

            var db = CsvDbHouse.Instance.RoleDb;
            var enterTime = db.GetValueByKey(searchTxt, "入职日期");
            DateTime startDate = DateTime.ParseExact(enterTime, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            labelTime.Text = CalculateMonthDifference(startDate, DateTime.Now).ToString() + "月";
            labelLv.Text = db.GetValueByKey(searchTxt, "职级");
            labelPlus1.Text = db.GetValueByKey(searchTxt, "主管姓名");
            labelPos.Text = db.GetValueByKey(searchTxt, "岗位");
            CheckCRRate(labelCR, float.Parse(db.GetValueByKey(searchTxt, "TTCCR值")), crList);
            CheckCRRate(labelCR2, float.Parse(db.GetValueByKey(searchTxt, "TP1CR值")), cr2List);
            CheckCRRate(labelJixiao, float.Parse(db.GetValueByKey(searchTxt, "绩效")), jixiaoList);
        }
        // 计算月份差
        public static int CalculateMonthDifference(DateTime startDate, DateTime endDate)
        {
            return (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;
        }

        private void CheckCRRate(Label l, float val, List<float> valList)
        {
            if(val == 0)
            {
                l.Text = "-";
                l.ForeColor = Color.Gray;
                return;
            }
            // 查找自己的 CR 值在排序后的列表中的位置
            int index = valList.BinarySearch(val);

            // 计算占比
            double percentage = (double)index / valList.Count * 100;

            var showRate = 100 - percentage;
            l.Text = string.Format("{0}({1:F2}%)", val, showRate);
            if (showRate < 30)
                l.ForeColor = (valList == jixiaoList) ? Color.Lime : Color.Red;
            else if (showRate > 80)
                l.ForeColor = (valList == jixiaoList) ? Color.Red : Color.Lime;
            else
                l.ForeColor = Color.White;
        }

        private void rjButtonShow_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void listViewNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAct();
            UpdateRoleInfo();
        }

        private void hintTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var db = CsvDbHouse.Instance.RoleDb;
            RefreshNameList(db);
        }
    }
}
