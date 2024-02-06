﻿using System;

namespace MemoHippo.UIS
{
    interface IDocComp
    {
        void SetData(string k, string v);
        Action<string> OnModify { get; set; }
        void SetReadOnly(bool readOnly);
    }
}
