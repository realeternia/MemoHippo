using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoHippo.Utils
{
    class RoleDB
    {
        public static RoleDB Instance = new RoleDB();

        public CsvDb DB { get; private set; }

        public RoleDB()
        {
            DB = CsvDb.Create("rolelist");
        }
    }
}
