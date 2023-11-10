using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class UCSearch : UserControl
    {
        class SearchData
        {
            public string Title;
            public string Line;
        }
        private List<SearchData> yourData = new List<SearchData>();

        public UCSearch()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            yourData.Clear();
            var searchTxt = textBox1.Text;
            if (string.IsNullOrWhiteSpace(searchTxt))
            {
                listView1.VirtualListSize = 0;
                return;
            }

            foreach (var file in Directory.GetFiles("save"))
            {
                var fi = new FileInfo(file);
                var itemId = fi.Name;

                string rtfContent = File.ReadAllText(file);
                string plainText = GetPlainTextFromRtf(rtfContent);

                int lineid = 0;
                foreach(var line in plainText.Split('\n'))
                {
                    if(line.IndexOf(searchTxt) >= 0)
                    {
                        yourData.Add(new SearchData { Line = line, Title = itemId });
                    }
                }
            }
            listView1.VirtualListSize = yourData.Count;
        }

        private RichTextBox richTextBox = new RichTextBox();
        private string GetPlainTextFromRtf(string rtfContent)
        {

            richTextBox.Rtf = rtfContent;
            return richTextBox.Text;
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {

            if (e.ItemIndex >= 0 && e.ItemIndex < yourData.Count)
            {
                ListViewItem item = new ListViewItem(yourData[e.ItemIndex].Line);
                item.SubItems.Add(yourData[e.ItemIndex].Title);

                e.Item = item;
            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
        //    e.DrawDefault = true; // 让 ListView 控件绘制默认的内容

         //   擦除竖线
          //  e.Graphics.DrawLine(Pens.DimGray, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);
            //   e.Graphics.DrawLine(Pens.White, e.Bounds.Right, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);

            e.Graphics.DrawString(e.SubItem.Text, e.Item.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);

        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
         //   e.DrawDefault = true; // Use the default drawing


          //  e.DrawBackground();
          //  e.Graphics.DrawRectangle(Pens.Black, e.Bounds); // Optional: Draw a border
            //e.Graphics.DrawString(e.Item.Text, e.Item.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();

         //   e.Graphics.DrawLine(Pens.DimGray, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);
        }
    }
}
