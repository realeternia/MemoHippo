using System;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace MemoHippo
{
    class ResLoader
    {
        static public Image Read(string path)
        {
            Bitmap bmp = null;
            try
            {
                var dts = path.Split('/');
                Assembly myAssembly = Assembly.LoadFrom("PicResource.dll");
                Stream myStream = myAssembly.GetManifestResourceStream(string.Format("PicResource.{0}.{1}", dts[0], dts[1]));
                if (myStream != null) bmp = new Bitmap(myStream);
            }
            catch
            {
                bmp = Properties.Resources.dicon;
            }
            return bmp;
        }
    }
}
