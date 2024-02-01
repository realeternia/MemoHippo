using MemoHippo.Model;
using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static MemoHippo.UCTipColumn;

namespace MemoHippo
{
    public class UCRowDDL : UCRowCommon
    {
        class TimeInfoData
        {
            public DateTime Time;
            public string ActInfo;
        }
        private List<TimeInfoData> lines = new List<TimeInfoData>();
        private System.Threading.Timer t;
        private int tick;

        public override RowItemType Type { get { return RowItemType.DDL; } }

        public UCRowDDL() 
            : base()
        {
            UpdateView();
        }

        protected override void UpdateView()
        {
            Height = 70;
        }


        private void T_Tick(object state)
        {
            tick++;
            Invalidate();
        }

        public override void AfterInit()
        {
            lines.Clear();

            var fullPath = string.Format("{0}/{1}.rtf", ENV.SaveDir, ItemId);
            var infos = RtfModifier.ConvertRtfToPlainText(File.ReadAllText(fullPath));
            string pattern = @"(.*)(ddl \d{4}/\d{2}/\d{2} \d{1,2}时)(.*)";


            foreach (var info in infos.Split('\n'))
            {
                Match match = Regex.Match(info, pattern);
                if (match.Success)
                {
                    string matchedText = match.Groups[2].Value.Replace("ddl ", "");
                    string remainingText = match.Groups[1].Value + match.Groups[3].Value;
                    if (remainingText.Contains("done"))
                        continue;

                    remainingText = remainingText.Replace("todo", "").Trim();
                    if (string.IsNullOrWhiteSpace(remainingText))
                        remainingText = "待添加";

                    var checkDate = TimeTool.ParseTime(matchedText);
                    lines.Add(new TimeInfoData { Time = checkDate, ActInfo = remainingText });
                }
            }

            t = new System.Threading.Timer(T_Tick, null, MathTool.GetRandom(MemoBook.Instance.Cfg.NikonInterval / 2 * 1000), MemoBook.Instance.Cfg.NikonInterval * 1000);
        }

        public override void OnRemove()
        {
            t.Dispose();
        }

        protected override void UCRowCommon_Paint(object sender, PaintEventArgs e)
        {
            DrawBase(e);
            if (lines.Count > 0)
            {
                var timeInfo = lines[tick % lines.Count];
                // 获取时间差
                TimeSpan timeDifference = timeInfo.Time - DateTime.Now;

                // 判断是否小于1天
                if (timeDifference.TotalHours > 0)
                {
                    // 显示小时
                    string hoursText = $"{Math.Floor(timeDifference.TotalHours)}小时后";
                    if(timeDifference.TotalHours > 24*2)
                        hoursText = $"{Math.Floor(timeDifference.TotalDays)}天后";

                    // 绘制文字，使用不同颜色
                    using (SolidBrush brush1 = new SolidBrush(Color.LawnGreen))
                    using (SolidBrush brush2 = new SolidBrush(Color.LightCyan))
                    {
                        e.Graphics.DrawString(hoursText, this.Font, brush1, 35, 35);
                        e.Graphics.DrawString(timeInfo.ActInfo, this.Font, brush2, 35 + e.Graphics.MeasureString(hoursText, this.Font).Width + 10, 35);
                    }
                }
                else
                {
                    // 显示超时
                    string overdueText = "超时";

                    // 绘制文字，使用不同颜色
                    using (SolidBrush brush1 = new SolidBrush(Color.Red))
                    using (SolidBrush brush2 = new SolidBrush(Color.LightCyan))
                    {
                        e.Graphics.DrawString(overdueText, this.Font, brush1, 35, 35);
                        e.Graphics.DrawString(timeInfo.ActInfo, this.Font, brush2, 35 + e.Graphics.MeasureString(overdueText, this.Font).Width + 10, 35);
                    }
                }
            }
            else
            {
                e.Graphics.DrawString("无日程", this.Font, Brushes.Gray, 35, 35);
            }
        }
    }
}
