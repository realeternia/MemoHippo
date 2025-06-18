using MemoHippo;
using MemoHippo.Model;
using MemoHippo.UIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static MemoHippo.Model.MemoBookProgress;
using static MemoHippo.UIs.UCDataView;

namespace MemoHippo.UIS.Main
{
    public partial class RecordBox : UserControl
    {
        private MemoItemInfo itemInfo;
        public Action OnDataChanged;

        public RecordBox()
        {
            InitializeComponent();

            ucDataView1.OnClickNew += OnNewRecord;
            ucDataView1.OnSave += OnSave;
            ucDataView1.OnButtonClick += OnButtonClick;

            ucDataView1.AddColumn(UCDataView.OptiControlTypes.TextBox, "id", "id", 60, UCDataView.OptiTagTypes.None, null, true);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.TextBox, "时间", "checkTime", 140, UCDataView.OptiTagTypes.Time, null, false);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.TextBox, "页面", "page", 60, UCDataView.OptiTagTypes.None, null, false);
            //  ucDataView1.AddColumn(UCDataView.OptiControlTypes.Button, "保存", "commit", 80, UCDataView.OptiTagTypes.None, null, false);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.Button, "删除", "delete", 80, UCDataView.OptiTagTypes.None, null, false);
        }

        public void Init(MemoItemInfo item)
        {
            if (item == itemInfo)
                return;

            itemInfo = item;

            ucDataView1.ClearData();
            var rs = MemoBook.Instance.Records.Records.FindAll(a => a.RecordId == itemInfo.Id);
            if (rs.Count > 0)
            {
                // 这里应该只有一项数据
                var checkRecord = rs[0];
                var tubes = new List<UCDataView.OptiDataTube>();
                int idx = 1;
                if (!string.IsNullOrEmpty(checkRecord.Progress))
                {
                    foreach (var recordInfo in checkRecord.Progress.Split('|'))
                    {
                        var reduce = recordInfo.Split(',');
                        var tube = new UCDataView.OptiDataTube();
                        tube.Add("id", idx++);
                        tube.Add("checkTime", reduce[0]);
                        tube.Add("page", reduce[1]);
                        tubes.Add(tube);
                    }
                    ucDataView1.AddDatas(tubes);
                }
                ucDataView1.RefreshView();
            }
            //RefreshAll();

            if(OnDataChanged !=null) OnDataChanged();
        }

        public void OnNewRecord()
        {
            var tube = new UCDataView.OptiDataTube();
            var dts = ucDataView1.ExportData();
            int newId = 1;
            if (dts.Count > 0)
            {
                int maxId = dts.Max(item => int.Parse(item.GetId()));
                newId = maxId + 1;
            }
            tube.Add("id", newId);
            tube.Add("checkTime", 0);
            tube.Add("page", 0);
            ucDataView1.AddData(tube);
            ucDataView1.RefreshView();
        }

        public void OnSave()
        {
            var dts = ucDataView1.ExportData();

            List<ReadProgress> newRecords = new List<ReadProgress>();
            var recordDict = MemoBook.Instance.Records.Records.ToDictionary(a => a.Id);

            // 构建 Progress 字段内容
            List<string> progressEntries = new List<string>();

            foreach (var item in dts)
            {
                string checkTime = item.GetValue("checkTime")?.ToString() ?? string.Empty;
                string pageStr = item.GetValue("page")?.ToString() ?? string.Empty;

                if (string.IsNullOrEmpty(checkTime) || string.IsNullOrEmpty(pageStr))
                    continue;

                // 拼接每条记录为 "time,page"
                progressEntries.Add($"{checkTime},{pageStr}");
            }

            string finalProgress = string.Join("|", progressEntries);

            // 假设当前只保存一条主记录，ID 固定为 itemInfo.Id
            if (recordDict.TryGetValue(itemInfo.Id, out var checkItem))
            {
                // 修改已有项
                checkItem.TotalPage = 1000;
                checkItem.Progress = finalProgress;
            }
            else
            {
                // 创建新项，默认 TotalPage 为第一条记录的 page 值
                int totalPage = 1000;

                var newRecord = new ReadProgress
                {
                    Id = itemInfo.Id,
                    RecordId = itemInfo.Id,
                    TotalPage = totalPage,
                    Progress = finalProgress
                };
                newRecords.Add(newRecord);
            }

            MemoBook.Instance.Records.Records.AddRange(newRecords);

            if (OnDataChanged != null) OnDataChanged();

        }

        public bool OnButtonClick(OptiRowDataAgent rowData, int rowIndex, int columnIndex, string colName)
        {
            if (colName == "checkTime")
            {
                PanelManager.Instance.ShowEditTimeForm(0, 0, null, t => rowData.SetValue(colName, t.ToString()));
            }

            return true;
        }

        /// <summary>
        /// 导出当前表格中的 checkTime 和 page 数据为两个数组，并将第一行数据放到最后
        /// </summary>
        /// <param name="timeArray">时间数组，格式 MM/dd</param>
        /// <param name="pageArray">页码数组</param>
        public void ExportCheckTimeAndPageWithFirstRowToLast(out string[] timeArray, out int[] pageArray)
        {
            var dts = ucDataView1.ExportData();

            List<string> times = new List<string>();
            List<int> pages = new List<int>();

            if (dts.Count == 0)
            {
                timeArray = new string[0];
                pageArray = new int[0];
                return;
            }

            // 将第一行缓存到最后添加
            string firstTime = string.Empty;
            int firstPage = 0;

            bool isFirst = true;

            foreach (var item in dts)
            {
                // 提取 checkTime 字段并格式化为 MM/dd
                var checkTimeObj = item.GetValue("checkTime");
                uint checkTime;
                string timeStr = "-";

                if (checkTimeObj is string checkTimeStr && uint.TryParse(checkTimeStr, out checkTime))
                {
                    if (checkTime > 0)
                    {
                        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(checkTime).ToLocalTime();
                        timeStr = dateTime.ToString("MM/dd");
                    }
                }

                // 提取 page 字段并尝试解析为整数
                var pageObj = item.GetValue("page");
                int pageInt = 0;

                if (pageObj is string pageStr && int.TryParse(pageStr, out int parsedPage))
                {
                    pageInt = parsedPage;
                }
                else if (pageObj is int pageIntVal)
                {
                    pageInt = pageIntVal;
                }

                if (isFirst)
                {
                    firstTime = timeStr;
                    firstPage = pageInt;
                    isFirst = false;
                }
                else
                {
                    times.Add(timeStr);
                    pages.Add(pageInt);
                }
            }

            // 添加第一行到最后
            times.Add(firstTime);
            pages.Add(firstPage);

            timeArray = times.ToArray();
            pageArray = pages.ToArray();
        }
    }
}
