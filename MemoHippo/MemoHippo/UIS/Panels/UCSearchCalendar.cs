using MemoHippo.Utils;
using RJControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
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
                listView1.Hide();

            SearchManager.GenSearchCache(GetBeginTime());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchAct();
        }

        private void SearchAct()
        {
            listView1.Visible = false; //防止中途绘制出现奇怪问题
            searchResults.Clear();

            var searchTxt = textBox1.Text;
            if (string.IsNullOrWhiteSpace(searchTxt))
            {
                listView1.VirtualListSize = 0;
                return;
            }

            SearchManager.DoSearch(searchTxt, results =>
            {
                selectLine = null;
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

        private static void DrawLine(DrawListViewSubItemEventArgs e, string fullText, string searshText, Font font)
        {
            // 逐字绘制
            float x = e.Bounds.X + 5;
            float y = e.Bounds.Y + 40;

            List<int> matchIndx = new List<int>();

            foreach (Match match in Regex.Matches(fullText, searshText))
            {
                int index = match.Index;
                for (int i = 0; i < searshText.Length; i++)
                    matchIndx.Add(index + i);
            }

            for (int i = 0; i < fullText.Length; i++)
            {
                var c = fullText[i];
                // 随机选择一个画刷
                var brush = matchIndx.Contains(i) ? Brushes.WhiteSmoke : Brushes.DimGray;

                // 设置字符之间的间距
                float characterSpacing = -5.0f; // 调整字符之间的距离

                var sf = new StringFormat
                {
                    FormatFlags = StringFormatFlags.MeasureTrailingSpaces,
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near
                };
                // e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                e.Graphics.DrawString(c.ToString(), font, brush, x, y, sf);

                // 更新 x 位置
                x += e.Graphics.MeasureString(c.ToString(), font).Width + characterSpacing;

                if (x > e.Bounds.X + e.Bounds.Width - 10)
                    break;

            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var lineInfo = searchResults[e.ItemIndex];
            var itemInfo = MemoBook.Instance.GetItem(lineInfo.ItemId);
            if (itemInfo != null)
            {
                e.Graphics.DrawImage(ResLoader.Read(itemInfo.Icon), e.Bounds.X + 8, e.Bounds.Y + 10, 24, 24);
                e.Graphics.DrawString(string.Format("{2} ({0}/{1} {3})", itemInfo.GetCatalog(), itemInfo.GetColumn(), itemInfo.Title, lineInfo.SearchPos),
                    e.Item.Font, Brushes.White, e.Bounds.X + 8 + 30, e.Bounds.Y + 10, StringFormat.GenericDefault);
            }

            using (var ft = new Font("微软雅黑", 9.5f))
                DrawLine(e, e.SubItem.Text, textBox1.Text, ft);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var destRT = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, e.Bounds.Width, e.Bounds.Height - 10);
            if (selectLine != null && e.ItemIndex == selectLine.Index)
            {
                using (var b = new SolidBrush(Color.FromArgb(60, 60, 60)))
                    e.Graphics.FillRectangle(b, destRT);
            }
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
            if (rjComboBox1.SelectedIndex == 0) //一周
                return DateTime.Now.Subtract(TimeSpan.FromDays(7));
            else if (rjComboBox1.SelectedIndex == 1) //一周
                return DateTime.Now.Subtract(TimeSpan.FromDays(30));
            else
                return DateTime.Now.Subtract(TimeSpan.FromDays(365 * 30));
        }
    }
}
