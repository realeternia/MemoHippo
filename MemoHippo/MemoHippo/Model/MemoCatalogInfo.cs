using MemoHippo.Utils;
using System.Collections.Generic;
using System.Drawing;

namespace MemoHippo.Model
{
    class MemoCatalogInfo
    {
        //全局唯一id
        public int Id { get; set; }
        public string Name { get; set; }
        public int Offset { get; set; }

        private static Color[] ColorArray;

        public List<MemoColumnInfo> Columns = new List<MemoColumnInfo>();

        static MemoCatalogInfo()
        {
            ColorArray = new Color[ColorTool.DarkColorTable.Count];
            ColorTool.DarkColorTable.Values.CopyTo(ColorArray, 0);
        }

        public int AddColumn(string title)
        {
            MemoBook.Instance.ColumnIndex++;
            Offset++;
            var cInfo = new MemoColumnInfo();
            cInfo.Id = MemoBook.Instance.ColumnIndex;
            cInfo.Title = title;
            cInfo.BgColor = ColorArray[Offset % ColorArray.Length].ToArgb();
            Columns.Add(cInfo);

            return cInfo.Id;
        }

        public MemoColumnInfo GetColumn(int id)
        {
            return Columns.Find(a => a.Id == id);
        }

        public MemoColumnInfo RemoveColumn(int id)
        {
            var itm = Columns.Find(a => a.Id == id);
            Columns.Remove(itm);
            return itm;
        }

        public List<MemoItemInfo> GetItems()
        {
            var results = new List<MemoItemInfo>();
            foreach (var col in Columns)
                results.AddRange(col.Items);

            return results;
        }
        public MemoItemInfo FindItemInfo(int id)
        {
            foreach (var col in Columns)
            {
                foreach (var item in col.Items)
                {
                    if (item.Id == id)
                        return item;
                }
            }
            return null;
        }
    }
}
