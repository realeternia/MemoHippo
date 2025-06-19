using MemoHippo.Utils;
using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    public partial class UCAIBox : UserControl
    {
        public UCAIBox()
        {
            InitializeComponent();
            richTextBox1.ShortcutsEnabled = true;    // allow shortcuts
            richTextBox1.DetectUrls = true;    // allow detect url

            Panels.PanelBorders.InitBorder(this);
        }

        public async void OnInit(string txt)
        {
            richTextBox1.Text = "ai思考中...";
            string result = await AITool.CallDeepSeekApi("什么是C#语言");
            richTextBox1.Text = result;
            richTextBox1.Select(0, 0);
            richTextBox1.SelectionIndent = 0;
        }
    }
}
