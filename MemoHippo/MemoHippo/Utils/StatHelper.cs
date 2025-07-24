
using MemoHippo;
using System;
using System.Collections.Generic;
using System.Linq;

public class StatHelper
{
    private static string DateToStr(DateTime time)
    {
        string day = time.Day.ToString("D2");
        if (day == "01")
            return $"{time.Month}月";
        else if (new[] { "05", "10", "15", "20", "25" }.Contains(day))
            return day;
        return "";
    }

    public static Tuple<List<string>, List<float>> GenerateTimeSeriesData(int days, bool isBook, Func<DateTime, string> labelFormatter = null)
    {
        if(labelFormatter == null)
            labelFormatter = DateToStr;
        List<string> xData = new List<string>();
        List<string> originalDates = new List<string>();
        Dictionary<string, int> dateCount = new Dictionary<string, int>();
        DateTime today = DateTime.Today;

        // 生成日期序列
        for (int i = days - 1; i >= 0; i--)
        {
            DateTime date = today.AddDays(-i);
            string originalDate = date.ToString("MM-dd");
            originalDates.Add(originalDate);
            xData.Add(labelFormatter(date));
            dateCount[originalDate] = 0;
        }

        // 统计符合条件的数据
        foreach (var item in MemoBook.Instance.Items)
        {        
            DateTime modifyTime = item.GetModifyTime();
            if (modifyTime >= DateTime.Today.AddDays(1 - days) && modifyTime <= DateTime.Today && (isBook ? (item.HasTag("读书") || item.HasTag("读完")) : !item.HasTag("读书") && !item.HasTag("读完")))
            {
                string dateStr = item.GetModifyTime().ToString("MM-dd");
                if (dateCount.ContainsKey(dateStr))
                    dateCount[dateStr]++;
            }
        }

        // 转换为图表数据
        List<float> yData = originalDates.Select(date => (float)dateCount[date]).ToList();
        return new Tuple<List<string>, List<float>>(xData, yData);
    }
}