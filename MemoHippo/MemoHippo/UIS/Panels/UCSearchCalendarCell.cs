using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    public partial class UCSearchCalendarCell : UserControl
    {
        private DateTime startTime;
        private List<Utils.SearchManager.SearchData> lines;
        private string searchTxt;

        public UCSearchCalendarCell()
        {
            InitializeComponent();
        }

        public void Init(DateTime wkTime, string search, List<Utils.SearchManager.SearchData> dts)
        {
            startTime = wkTime;
            searchTxt = search;
            lines = dts;
            Height = Math.Min(350, Math.Max(120, lines.Count * 20 + 10 + 25));
            if (startTime > DateTime.Now)
                BackColor = Color.FromArgb(64,64,64);
        }


        private void DrawLine(Graphics g, float startX, float startY, string fullText, string searshText, Font font)
        {
            // 逐字绘制
            float x = startX;
            float y = startY;

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
                var brush = matchIndx.Contains(i) ? Brushes.LawnGreen : Brushes.LightGray;

                // 设置字符之间的间距
                float characterSpacing = -5.0f; // 调整字符之间的距离

                var sf = new StringFormat
                {
                    FormatFlags = StringFormatFlags.MeasureTrailingSpaces,
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near
                };
                // e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.DrawString(c.ToString(), font, brush, x, y, sf);

                // 更新 x 位置
                x += g.MeasureString(c.ToString(), font).Width + characterSpacing;

                if (x > Width)
                    break;
            }
        }

        private void UCSearchCalendarCell_Paint(object sender, PaintEventArgs e)
        {
            // Get the Graphics object
            Graphics g = e.Graphics;

            var headlineColor = Brushes.LightGreen;
            if(startTime > DateTime.Now || lines.Count == 0)
                headlineColor = Brushes.Gray;

            // Define the pen to draw the line
            using (Pen pen = new Pen(headlineColor, 2))
            {
                // Define the start and end points of the line
                Point startPoint = new Point(3, 25);
                Point endPoint = new Point(160, 25);

                // Draw the line
                g.DrawLine(pen, startPoint, endPoint);
            }

            using (var ft = new Font("微软雅黑", 9.5f))
            {
                g.DrawString(string.Format("{0} ~ {1}", startTime.ToString("MM/dd"), startTime.AddDays(5).ToString("MM/dd")), ft, headlineColor, new PointF(3, 3));

                for (int i = 0; i < lines.Count; i++)
                {
                    DrawLine(g, 10, 5 + 25 + 20 * i, lines[i].Line, searchTxt, ft);
                    //g.DrawString(lines[i].Line, ft, Brushes.White, new PointF(10, 5 + 25 + 20 * i ));
                }
            }
        }
    }
}
