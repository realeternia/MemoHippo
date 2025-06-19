using MemoHippo.Utils;
using System;
using System.Linq;
using System.Windows.Forms;
using Text_Editor;

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
            richTextBox1.Text = "AI 思考中...";
            bool firstResult = false;

            try
            {
                richTextBox1.Tag = 0;
                await AITool.CallDeepSeekApi(txt, (chunk) =>
                {
                    if(!firstResult)
                    {
                        richTextBox1.Clear();
                        firstResult = true;
                    }

                    // 使用 Invoke 避免跨线程异常
                    richTextBox1.Invoke((MethodInvoker)delegate
                    {
                        richTextBox1.AppendText(chunk);

                        if (richTextBox1.Lines.Count() != (int)richTextBox1.Tag)
                        {
                            // 稳定滚动到底部
                            richTextBox1.SelectionStart = richTextBox1.TextLength;
                            richTextBox1.SelectionLength = 0;
                            richTextBox1.ScrollToCaret();

                            richTextBox1.Tag = richTextBox1.Lines.Count();
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                richTextBox1.Text = "AI 调用失败：" + ex.Message;
            }

            richTextBox1.Select(0, 0);
            richTextBox1.SelectionIndent = 0;
        }
    }
}
