using System.Collections.Generic;

namespace MemoHippo.Model
{
    internal class MemoBookProgress
    {
        internal class ReadProgress
        {
            public int Id { get; set; }
            public int RecordId { get; set; }
            public int TotalPage { get; set; }
            public string Progress { get; set; }
        }

        public List<ReadProgress> Records = new List<ReadProgress>();
        public int MaxId = 1001;

        public int GetNextId()
        {
            MaxId++;
            return MaxId;
        }
    }
}
