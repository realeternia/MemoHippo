using System;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace MemoHippo
{
    class PicLoader
    {
        static public Image Read(string dir, string path)
        {
            Bitmap bmp = null;
            try
            {
                Assembly myAssembly = Assembly.LoadFrom("PicResource.dll");
                Stream myStream = myAssembly.GetManifestResourceStream(string.Format("PicResource.{0}.{1}", dir, path));
                if (myStream != null) bmp = new Bitmap(myStream);
            }
            catch
            {
                bmp = null;
            }
            return bmp;
        }
    }
}
