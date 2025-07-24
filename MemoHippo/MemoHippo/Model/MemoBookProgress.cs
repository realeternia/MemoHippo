using MemoHippo.UIs;
using MemoHippo.Utils;
using System;
using System.Collections.Generic;

namespace MemoHippo.Model
{
    internal class MemoBookProgress
    {
        internal class ReadProgress
        {
            public int Id { get; set; }
            public int RecordId { get; set; }
            public string Progress { get; set; }
        }

        public List<ReadProgress> Records = new List<ReadProgress>();


        public int GetReadPageCount(int itemId, DateTime checkDate)
        {
            var item = Records.Find(a => a.Id == itemId);
            if (item == null)
                return 0;

            DateTime closestDate = DateTime.MinValue;
            int closestPage = 0;
            int checkDatePage = 0; // 初始化checkDate对应页数
            foreach (var recordInfo in item.Progress.Split('|'))
            {
                var reduce = recordInfo.Split(',');
                if (reduce.Length >= 2)
                {
                    var recordDate = TimeTool.UnixTimeToDateTime(uint.Parse(reduce[0]));
                    var page = int.Parse(reduce[1]);
                    // 查找checkDate对应页数
                    if (recordDate.Date == checkDate.Date)
                    {
                        checkDatePage = page;
                    }
                    // 查找checkDate之前最近的页数
                    else if (recordDate < checkDate && recordDate > closestDate)
                    {
                        closestDate = recordDate;
                        closestPage = page;
                    }
                }
            }

            if (closestPage > checkDatePage)
                return checkDatePage;

            return checkDatePage - closestPage; // 返回两者差值
        }
    }
}
