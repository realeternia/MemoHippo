using MemoHippo.Model;
using MemoHippo.UIS.Panels;
using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCBGPropertyModify : UserControl
    {
        private Label addLabel;
        public Action<string> AfterSelect;

        public UCBGPropertyModify()
        {
            InitializeComponent();
        }

        public void OnInit(string myTag)
        {

            flowLayoutPanel1.Controls.Clear();
            var myTags = new HashSet<string>();
            if(myTag != null)
            {
                var listTag = new List<string>(myTag.Split(','));
                listTag.Sort();
                foreach (var tag in listTag)
                {
                    AddAttrItem(tag, true);
                    myTags.Add(tag);
                }
            }
            var list = new List<string>(TagManager.Tags);
            list.Sort();
            foreach (var tag in list)
            {
                if (myTags.Contains(tag))
                    continue;
                AddAttrItem(tag, false);
            }
            if (addLabel == null)
            {
                var btn = new Label();
                btn.Cursor = Cursors.Hand;
                btn.AutoSize = true;
                btn.Font = new Font("微软雅黑", 11, FontStyle.Regular);
                btn.BackColor = Color.FromArgb(32, 32, 32);
                btn.Text = "+添加";
                btn.Click += (e, o) => {
                   // Point absoluteLocation = this.PointToScreen(new Point(0, 0));

                    var inputBox = new InputTextBox();
                    inputBox.OnCustomTextChanged = OnAddTag;

                    PanelManager.Instance.ShowBlackPanel(inputBox, 0, 0, 1);
                    inputBox.Focus();
                };
                addLabel = btn;
            }

            flowLayoutPanel1.Controls.Add(addLabel);
        }

        private void OnAddTag(string tag)
        {
            AddAttrItem(tag, true);
            flowLayoutPanel1.Controls.SetChildIndex(addLabel, flowLayoutPanel1.Controls.Count);

            TagManager.Add(tag);
        }

        private void AddAttrItem(string tag, bool checked1)
        {
            var tagItem = new UCBGPropertyAttrItem();
            tagItem.Cursor = Cursors.Hand;
            tagItem.Text = tag;
            tagItem.Checked = checked1;
            tagItem.Font = new Font("微软雅黑", 11, FontStyle.Regular);
            flowLayoutPanel1.Controls.Add(tagItem);
        }


        private void rjButtonOk_Click(object sender, EventArgs e)
        {
            List<string> tags = new List<string>();
            foreach (var ctr in flowLayoutPanel1.Controls)
            {
                var checkControl = ctr as UCBGPropertyAttrItem;
                if (checkControl == null || !checkControl.Checked || string.IsNullOrEmpty(checkControl.Text))
                    continue;

                tags.Add(checkControl.Text.Trim());
            }

            if (AfterSelect != null)
                AfterSelect(string.Join(",", tags));

            PanelManager.Instance.HideBlackPanel();
        }
    }
}

