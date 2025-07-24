using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

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

            List<Tuple<int, uint, int>> tubes = new List<Tuple<int, uint, int>>(); //id, time, pagecount

            var nowTick = TimeTool.DateTimeToUnixTime(DateTime.Now);
            foreach (var record in rs)
            {
                var bgInfo = MemoBook.Instance.GetItem(record.RecordId);
                foreach (var recordInfo in record.Progress.Split('|'))
                {
                    if (string.IsNullOrWhiteSpace(recordInfo))
                        continue;
                    var reduce = recordInfo.Split(',');
                    var time = uint.Parse(reduce[0]);
                    if(time < nowTick - 86400 * 45)
                        continue;

                    var readCount = MemoBook.Instance.Records.GetReadPageCount(record.Id, TimeTool.UnixTimeToDateTime(time));
                    tubes.Add(new Tuple<int, uint, int>(record.Id, time, readCount));
                }
            }

            // 按记录ID和日期聚合数据
            
            var dayTubes = new List<Tuple<uint, List<Tuple<int, int>>>>();
            // 将tubes数据按日期分组并填充到dayTubes
            dayTubes = tubes
                .GroupBy(t => TimeTool.UnixTimeToDateTime(t.Item2).Date)
                .Select(g => Tuple.Create(
                    TimeTool.DateTimeToUnixTime(g.Key),
                    g.Select(t => Tuple.Create(t.Item1, t.Item3)).ToList()
                ))
                .ToList();
            dayTubes.Sort((a, b) => b.Item1.CompareTo(a.Item1));

            foreach(var tube in dayTubes)
            {
                var item = new ListViewItem(TimeTool.UnixTimeToDateTime(tube.Item1).ToString("yyyy/MM/dd")); // 时间
                item.SubItems.Add(tube.Item2.Sum(t => t.Item2).ToString());              // 桌游名

                var str = tube.Item2.ConvertAll(t => MemoBook.Instance.GetItem(t.Item1).Title + "-" + t.Item2 + "页").Aggregate((a, b) => a + " " + b);
                item.SubItems.Add(str);             // 详情

                listView1.Items.Add(item);
            }
        }
    }
}
