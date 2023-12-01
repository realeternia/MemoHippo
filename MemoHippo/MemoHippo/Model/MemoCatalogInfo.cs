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
    }

    public class MemoColumnInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BgColor { get; set; }

        public List<MemoItemInfo> Items = new List<MemoItemInfo>();

        public MemoItemInfo AddItem(string title)
        {
            MemoBook.Instance.ItemIndex++;
            var itmInfo = new MemoItemInfo();
            itmInfo.Id = MemoBook.Instance.ItemIndex;
            itmInfo.Title = title;
            Items.Add(itmInfo);

            return itmInfo;
        }
        public MemoItemInfo GetItem(int id)
        {
            return Items.Find(a => a.Id == id);
        }

        public MemoItemInfo RemoveItem(int id)
        {
            var itm = Items.Find(a => a.Id == id);
            Items.Remove(itm);
            return itm;
        }

        public void InsertItem(MemoItemInfo itm, int checkId, bool afterNode)
        {
            int off = 0;
            foreach(var pickItem in Items)
            {
                if(pickItem.Id == checkId)
                    break;
                off++;
            }

            if (afterNode)
                off++;

            if (off < Items.Count)
                Items.Insert(off, itm);
            else
                Items.Add(itm);
        }
    }

    public class MemoItemInfo
    {
        public int Id { get; set; } //同文件存储路径
        public int Type { get; set; } //0 默认，1 背单词
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Icon { get; set; }
    }
}
