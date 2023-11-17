using MemoHippo.Model;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace MemoHippo
{
    //数据存储类
    class MemoBook
    {
        public static MemoBook Instance = new MemoBook();

        public List<MemoCatalogInfo> CatalogInfos = new List<MemoCatalogInfo>();
        public int CatalogIndex = 1;
        public int ColumnIndex = 100001;
        public int ItemIndex = 200001;

        public void AddCatalog()
        {
            var newCatalog = new MemoCatalogInfo { Id = CatalogIndex, Name = "新目录" + CatalogIndex++ };
            newCatalog.AddColumn("默认");
            CatalogInfos.Add(newCatalog);
        }

        public MemoCatalogInfo GetCatalog(int id)
        {
            return CatalogInfos.Find(i => i.Id == id);
        }

        public RTItemData FindItemInfo(int id)
        {
            foreach(var ct in CatalogInfos)
            {
                foreach (var col in ct.Columns)
                {
                    foreach (var item in col.Items)
                    {
                        if(item.Id == id)
                        {
                            RTItemData itemData = new RTItemData();
                            itemData.Catalog = ct.Name;
                            itemData.CatalogId = ct.Id;
                            itemData.Column = col.Title;
                            itemData.ItemInfo = item;
                            return itemData;
                        }
                    }
                }
            }
            return null;
        }
    }
}
