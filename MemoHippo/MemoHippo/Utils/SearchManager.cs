using MemoHippo.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace MemoHippo.Utils
{
    internal class SearchManager
    {
        public class SearchData
        {
            public string Title;
            public int ItemId;
            public string Line;
            public string SearchPos;
            public DateTime CreateTime;
        }
        private static List<MemoItemInfo> searchCaches = new List<MemoItemInfo>();
        public static void GenSearchCache(DateTime start)
        {
            searchCaches.Clear();
            foreach (var itemInfo in MemoBook.Instance.Items)
            {
                if (itemInfo.IsEncrypt())
                    continue;

                var fullPath = itemInfo.GetFilePath();
                if (File.Exists(fullPath))
                {
                    var fi = new FileInfo(fullPath);
                    if (fi.LastWriteTime < start)
                        continue;

                    searchCaches.Add(itemInfo);
                }
            }

            searchCaches.Sort((a, b) => (int)(b.GetCreateTime() - a.GetCreateTime()).TotalSeconds);
        }

        public static void DoSearch(string searchTxt, Action<List<SearchData>> onResults)
        {
            DelayedExecutor.Trigger("ucsearch", 0.3f, () =>
            {     
                List<SearchData> searchResults = new List<SearchData>();
                foreach (var itemInfo in searchCaches)
                {
                    var itemIdStr = itemInfo.Title;
                    var writeTime = itemInfo.GetModifyTime();

                    if (itemInfo.Title.Contains(searchTxt))
                        searchResults.Add(new SearchData { Line = itemInfo.Title, Title = itemIdStr, ItemId = itemInfo.Id, CreateTime = writeTime, SearchPos = "Title" });
                    if (itemInfo.Tag != null && itemInfo.Tag.Contains(searchTxt))
                        searchResults.Add(new SearchData { Line = itemInfo.Tag, Title = itemIdStr, ItemId = itemInfo.Id, CreateTime = writeTime, SearchPos = "Tag" });

                    string plainText = RtfModifier.ReadRtfPlainText(itemInfo.Id);

                    int lineid = 0;
                    foreach (var line in plainText.Split('\n'))
                    {
                        if (line.IndexOf(searchTxt) >= 0)
                        {
                            searchResults.Add(new SearchData { Line = line, Title = itemIdStr, ItemId = itemInfo.Id, CreateTime = writeTime, SearchPos = "行" + (lineid + 1) });
                        }
                        lineid++;
                    }
                }

                onResults(searchResults);
            });
        }
    }
}
