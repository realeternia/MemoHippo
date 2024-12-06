using MemoHippo.Model.Types;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MemoHippo.Model
{
    class MemoBookCfg
    {
        public List<string> RecentIcons = new List<string>();

        [SetupItemDes("主要", "人员列表", "balalbalb")]
        public string[] PeopleNames { get; set; } = new string[0];

        [SetupItemDes("测试", "测试A", "balalbalb")]
        public bool TestFlagA { get; set; }

        [SetupItemDes("测试", "测试B", "balalbalb")]
        public bool TestFlagB { get; set; }

        [SetupItemDes("测试", "字符AAAA", "balalbalb")]
        public string TestStringB { get; set; }

        [SetupItemDes("主要", "关闭标签", "禁用文档的标签功能")]
        public bool DisableTag { get; set; }
        [SetupItemDes("主要", "滚动字幕替换间隔时间", "单位秒", 5, 3600)]
        public int NikonInterval { get; set; } = 30;

        [SetupItemDes("外观", "滚动字幕颜色", "")]
        public ColorCfg NikonForeColor { get; set; } = new ColorCfg(Color.Yellow);
        [SetupItemDes("外观", "人名字色", "编辑器中人名颜色")]
        public ColorCfg PeopleColor { get; set; } = new ColorCfg(Color.Yellow);
        [SetupItemDes("外观", "时间字色", "编辑器中普通时间的颜色")]
        public ColorCfg TimeCommonColor { get; set; } = new ColorCfg(Color.LightGreen);
        [SetupItemDes("外观", "ddl字色", "编辑器中ddl时间的颜色")]
        public ColorCfg TimeDDLColor { get; set; } = new ColorCfg(Color.Purple);

        [SetupItemDes("外观", "关键词", "关键词颜色")]
        public TextColorCfg[] TextColors { get; set; } = new TextColorCfg[0];

        public IEnumerable<string> GetNamesOnly()
        {
            foreach (var people in PeopleNames)
            {
                var realname = people;
                if (realname.Contains("-"))
                    realname = realname.Split('-')[0];
                yield return realname;
            }
        }

        public IEnumerable<string> GetExportTexts()
        {
            foreach (var text in TextColors)
            {
                if (!string.IsNullOrEmpty(text.Tag) && text.Tag == "export")
                    yield return text.Text;
            }
        }
    }
}
