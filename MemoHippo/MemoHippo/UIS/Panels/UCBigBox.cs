﻿using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    public partial class UCBigBox : UserControl
    {
        public UCBigBox()
        {
            InitializeComponent();
            richTextBox1.ShortcutsEnabled = true;    // allow shortcuts
            richTextBox1.DetectUrls = true;    // allow detect url

            Panels.PanelBorders.InitBorder(this);
        }

        public void OnInit(string s, string txt)
        {
            if (!string.IsNullOrEmpty(s))
                richTextBox1.Rtf = s;
            else
                richTextBox1.Text = txt;
            richTextBox1.Select(0, 0);
            richTextBox1.SelectionIndent = 0;
        }
    }
}
