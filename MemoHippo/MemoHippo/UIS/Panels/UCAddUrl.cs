using MemoHippo;
using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    public partial class UCAddUrl : UserControl
    {
        public Action<string> AfterSelect;

        public UCAddUrl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    control.KeyUp += TextBox_KeyDown;
            }
        }


        public void OnInit()
        {
            textBoxUrl.Text = "";
            textBoxDes.Text = "";
            textBoxAlias.Text = "";

            textBoxUrl.Focus();
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUrl.Text))
                return;
            if (string.IsNullOrEmpty(textBoxAlias.Text))
                return;

            var urlDb = CsvDbHouse.Instance.UrlDb;
            urlDb.AddValue(textBoxAlias.Text, new string[] { textBoxAlias.Text, textBoxDes.Text, textBoxUrl.Text });

            var desStr = string.Format("{0} file://url/{1}", textBoxDes.Text, textBoxAlias.Text);

            if (AfterSelect != null)
                AfterSelect(desStr);

            PanelManager.Instance.HideBlackPanel();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (AfterSelect != null)
                        AfterSelect("");
                    PanelManager.Instance.HideBlackPanel();
                    break;
            }
        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUrl.Text))
                return;

            var urlDb = CsvDbHouse.Instance.UrlDb;
            var key = urlDb.FindKeyByValue("url", textBoxUrl.Text);
            if (string.IsNullOrEmpty(key))
                return;

            textBoxDes.Text = urlDb.GetValueByKey(key, "des");
            textBoxAlias.Text = key;
        }
    }
}
