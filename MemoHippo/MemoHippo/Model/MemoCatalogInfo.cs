using System.Collections.Generic;
using System.Drawing;

namespace MemoHippo.Model
{
    class MemoCatalogInfo
    {
        //全局唯一id
        public int Id { get; set; } 
        public string Name { get; set; }
        //全局唯一id
        private int offset { get; set; }

        private Color[] ColorTable = { 
            Color.FromArgb(0x40, 0x33, 0x24),
            Color.FromArgb(0x1b, 0x2d, 0x38),
            Color.FromArgb(0x3e, 0x28, 0x25)
        };

        public List<MemoColumnInfo> Columns = new List<MemoColumnInfo>();

        public void AddColumn(string title)
        {
            MemoBook.Instance.ColumnIndex++;
            offset++;
            var cInfo = new MemoColumnInfo();
            cInfo.Id = MemoBook.Instance.ColumnIndex;
            cInfo.Title = title;
            cInfo.BgColor = ColorTable[offset % ColorTable.Length];
            Columns.Add(cInfo);
        }

        public MemoColumnInfo GetColumn(int id)
        {
            return Columns.Find(a => a.Id == id);
        }
    }

    public class MemoColumnInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Color BgColor { get; set; }

        public List<MemoItemInfo> Items = new List<MemoItemInfo>();

        public void AddItem(string title)
        {
            MemoBook.Instance.ItemIndex++;
            var itmInfo = new MemoItemInfo();
            itmInfo.Id = MemoBook.Instance.ItemIndex;
            itmInfo.Title = title;
            Items.Add(itmInfo);
        }

        public MemoItemInfo RemoveItem(int id)
        {
            var itm = Items.Find(a => a.Id == id);
            Items.Remove(itm);
            return itm;
        }

        public void AddItem(MemoItemInfo itm)
        {
            Items.Add(itm);
        }
    }

    public class MemoItemInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
