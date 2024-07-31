using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace MemoHippo.Utils
{
    class ProcessTool
    {
        public static bool CheckProcessPath(string processName)
        {
            // 获取所有运行中的进程
            var processes = Process.GetProcessesByName(processName);

            if (processes.Length > 1)
            {
                return true;
            }

            // 如果没有找到匹配的进程，返回 null
            return false;
        }
    }
}
