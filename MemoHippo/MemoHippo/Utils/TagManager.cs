using System;
using System.Collections.Generic;

namespace MemoHippo.Utils
{
    class TagManager
    {
        public static HashSet<string> Tags = new HashSet<string>();

        public static void Init()
        {
            foreach (var memoItem in MemoBook.Instance.Items)
            {
                if (string.IsNullOrWhiteSpace(memoItem.Tag))
                    continue;
                var tagsInfo = memoItem.Tag.Split(',');
                foreach (var tag in tagsInfo)
                    Tags.Add(tag);
            }
        }

        public static void Add(string tag)
        {
            Tags.Add(tag);
        }
    }
}
