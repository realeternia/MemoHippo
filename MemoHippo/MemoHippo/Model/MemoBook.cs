using MemoHippo.Model;
using System.Collections.Generic;

namespace MemoHippo
{
    //数据存储类
    class MemoBook
    {
        public static MemoBook Instance = new MemoBook();

        public List<MemoCatalogInfo> CatalogInfos = new List<MemoCatalogInfo>();
        private int catalogIndex = 1;
        public int ColumnIndex = 100001;
        public int ItemIndex = 200001;

        public void AddCatalog()
        {
            var newCatalog = new MemoCatalogInfo { Id = catalogIndex, Name = "新目录" + catalogIndex++ };
            newCatalog.AddColumn("默认");
            CatalogInfos.Add(newCatalog);
        }

        public MemoCatalogInfo GetCatalog(int id)
        {
            return CatalogInfos.Find(i => i.Id == id);
        }
    }
}
