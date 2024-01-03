using System;
using System.Collections.Generic;


namespace MemoHippo.Model
{
    class StoreRoom
    {
        public List<MemoItemInfo> ItemInfos = new List<MemoItemInfo>();

        public void Store(MemoItemInfo info)
        {
            ItemInfos.Add(info);
        }
    }
}
