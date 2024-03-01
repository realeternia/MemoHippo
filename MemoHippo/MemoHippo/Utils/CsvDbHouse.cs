using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoHippo.Utils
{
    class CsvDbHouse
    {
        public static CsvDbHouse Instance = new CsvDbHouse();

        public CsvDb RoleDb { get; private set; }
        public CsvDb UrlDb { get; private set; }

        public CsvDbHouse()
        {
            RoleDb = CsvDb.Create("rolelist");
            UrlDb = CsvDb.Create("urllist");
        }
    }
}
