using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoHippo.UIS
{
    interface IDocComp
    {
        void SetData(string k, string v);
        Action<string> OnModify { get; set; }
    }
}
