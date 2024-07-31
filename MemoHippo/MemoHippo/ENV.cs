namespace MemoHippo
{
    class ENV
    {
        private const string BaseDir = "file/";
        private const string SaveDir = BaseDir + "save/";
        public const string TemplateDir = BaseDir + "template/";
        private const string ImgDir = BaseDir + "img/";

        public static string GetDocDir(string parent = "")
        {
            return string.IsNullOrEmpty(parent) ? SaveDir: parent + "/save/";
        }
        public static string GetImgDir(string parent = "")
        {
            return string.IsNullOrEmpty(parent) ? ImgDir : parent + "/img/";
        }
    }
}
