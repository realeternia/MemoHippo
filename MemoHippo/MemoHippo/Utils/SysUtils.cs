using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoHippo.Utils
{
    class SysUtils
    {
        public static void MoveDirectory(string sourcePath, string destPath)
        {
            if (!Directory.Exists(sourcePath))
                return;

            if (!Directory.Exists(destPath))
                Directory.CreateDirectory(destPath);

            // 获取源目录中的所有文件
            string[] files = Directory.GetFiles(sourcePath);

            // 移动每个文件到目标目录
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationFile = Path.Combine(destPath, fileName);
                File.Move(file, destinationFile);
            }

            // 删除源目录
            Directory.Delete(sourcePath, true);
        }
    }
}
