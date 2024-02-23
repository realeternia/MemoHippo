using MemoHippo.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace MemoHippo
{
    //数据存储类
    class MemoBook
    {
        public static MemoBook Instance = new MemoBook();

        public List<MemoCatalogInfo> CatalogInfos = new List<MemoCatalogInfo>();

        public List<MemoItemInfo> Items = new List<MemoItemInfo>();

        public int CatalogIndex = 1;
        public int ColumnIndex = 100001;
        public int ItemIndex = 200001;
        public MemoBookCfg Cfg = new MemoBookCfg();

        public void Save()
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(this);
            File.WriteAllText(ENV.BaseDir + "/memo.yaml", yaml, Encoding.UTF8);
        }

        public MemoCatalogInfo AddCatalog()
        {
            var newCatalog = new MemoCatalogInfo { Id = CatalogIndex, Name = "" };
            CatalogIndex++;
            newCatalog.AddColumn("");
            CatalogInfos.Add(newCatalog);

            Save();

            return newCatalog;
        }

        public MemoCatalogInfo DeleteCatalog(int id)
        {
            var target = CatalogInfos.Find(a => a.Id == id);
            if (target == null)
                return null;
            CatalogInfos.Remove(target);

            Save();

            return target;
        }

        public MemoCatalogInfo GetCatalog(int id)
        {
            return CatalogInfos.Find(i => i.Id == id);
        }

        public List<MemoItemInfo> GetItemsByCatalog(int catalogId)
        {
            var results = new List<MemoItemInfo>();
            foreach (var item in Items)
                if (item.CatalogId == catalogId)
                    results.Add(item);

            return results;
        }
        public List<MemoItemInfo> GetItemsByColumn(int colId)
        {
            var results = new List<MemoItemInfo>();
            foreach (var item in Items)
                if (item.ColumnId == colId)
                    results.Add(item);

            return results;
        }

        public MemoItemInfo GetItemByNickname(string nkName)
        {
            foreach (var item in Items)
            {
                if (item.NickName == nkName)
                {
                    return item;
                }
            }
            return null;
        }

        public List<MemoItemInfo> FindItemInfosByTag(string tag, string revTag = "")
        {
            List<MemoItemInfo> rts = new List<MemoItemInfo>();
            foreach (var item in Items)
            {
                if (item.HasTag(tag) && (string.IsNullOrEmpty(revTag) || !item.HasTag(revTag)))
                {
                    rts.Add(item);
                }
            }
            return rts;
        }
        public void MoveItem(MemoItemInfo itm, int checkId, bool afterNode)
        {
            Items.Remove(itm);

            int off = 0;
            foreach (var pickItem in Items)
            {
                if (pickItem.Id == checkId)
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

        public MemoItemInfo AddItem(string title, int catalog, int column)
        {
            Instance.ItemIndex++;
            var itmInfo = new MemoItemInfo();
            itmInfo.Id = Instance.ItemIndex;
            itmInfo.Title = title;
            itmInfo.CatalogId = catalog;
            itmInfo.ColumnId = column;
            Items.Add(itmInfo);

            Save();

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

            Save();

            return itm;
        }

        public string[] GetAllPageInfos()
        {
            return Items.ConvertAll(a => string.Format("{1}@{0}", a.Id, a.Title)).ToArray();
        }
    }
}
