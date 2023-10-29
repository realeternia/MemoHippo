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

        public void AddCatalog()
        {
            CatalogInfos.Add(new MemoCatalogInfo { Id = catalogIndex, Name = "新建文件" + catalogIndex });
            catalogIndex++;
        }
    }
}
