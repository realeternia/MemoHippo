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
        public RecordBox()
        {
            InitializeComponent();

            ucDataView1.OnClickNew += OnNewRecord;
            ucDataView1.OnSave += OnSave;
            ucDataView1.OnButtonClick += OnButtonClick;

            ucDataView1.AddColumn(UCDataView.OptiControlTypes.TextBox, "id", "id", 60, UCDataView.OptiTagTypes.None, null, true);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.TextBox, "时间", "checkTime", 140, UCDataView.OptiTagTypes.Time, null, false);
            ucDataView1.AddColumn(UCDataView.OptiControlTypes.ComboBox, "页面", "page", 60, UCDataView.OptiTagTypes.None, new string[] { "", "30分", "1小时", "2小时", "3小时" }, false);
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
            if(rs.Count > 0)
            {
                // 这里应该只有一项数据
                var checkRecord = rs[0];
                var tubes = new List<UCDataView.OptiDataTube>();
                int idx = 1;
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
                ucDataView1.RefreshView();
            }
            //RefreshAll();

        }

        public void OnNewRecord()
        {
            var tube = new UCDataView.OptiDataTube();
            tube.Add("id", MemoBook.Instance.Records.GetNextId());
            tube.Add("checkTime", "");
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

        }

        public bool OnButtonClick(OptiRowDataAgent rowData, int rowIndex, int columnIndex, string colName)
        {
            if(colName == "begintime")
            {
                PanelManager.Instance.ShowEditTimeForm(0, 0, t => rowData.SetValue(colName, t.ToString()));
            }

            return true;
        }
    }

}
