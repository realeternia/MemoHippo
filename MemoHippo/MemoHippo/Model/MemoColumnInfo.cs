using System.Collections.Generic;

namespace MemoHippo.Model
{
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
}
