using System;
using System.Collections.Generic;

namespace MemoHippo.Model
{
    class MemoBookCfg
    {
        public List<string> RecentIcons = new List<string>();
        public List<string> PeopleNames = new List<string>();

        public IEnumerable<string> GetNamesOnly()
        {
            foreach (var people in PeopleNames)
            {
                var realname = people;
                if (realname.Contains("-"))
                    realname = realname.Split('-')[0];
                yield return realname;
            }
        }
    }
}
