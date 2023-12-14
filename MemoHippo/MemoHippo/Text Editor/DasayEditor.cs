/*
 * Programmer: Hunter Johnson
 * Name: Rich Text Editor
 * Date: November 1, 2016 
 */
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using MemoHippo;
using MemoHippo.Utils;
using MemoHippo.Model;

namespace Text_Editor
{
    public partial class DasayEditor : UserControl
    {
        // 定义关键词和相应的颜色
        private Dictionary<string, Color> keywords = new Dictionary<string, Color>
        {
            ["todo"] = Color.Gray,
            ["done"] = Color.LimeGreen,
            ["url"] = Color.LightBlue,
            ["share"] = Color.Goldenrod,
        };

        private MemoItemInfo memoItemInfo;
        private string filenamee;    // file opened inside of RTB
        public Form1 ParentC;
        private bool checkChangeLock = true;
        private bool hasModify;

        public DasayEditor()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(32, 32, 32);
            richTextBox1.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            richTextBox1.AcceptsTab = true;    // allow tab
            richTextBox1.ShortcutsEnabled = true;    // allow shortcuts
            richTextBox1.DetectUrls = true;    // allow detect url

            // fill zoomDropDownButton item list
            zoomDropDownButton.DropDown.Items.Add("20%");
            zoomDropDownButton.DropDown.Items.Add("50%");
            zoomDropDownButton.DropDown.Items.Add("70%");
            zoomDropDownButton.DropDown.Items.Add("100%");
            zoomDropDownButton.DropDown.Items.Add("150%");
            zoomDropDownButton.DropDown.Items.Add("200%");
            zoomDropDownButton.DropDown.Items.Add("300%");

            this.ResumeLayout();

            this.ucToolbar1.boldStripButton.Click += new System.EventHandler(this.boldStripButton3_Click);
            this.ucToolbar1.italicStripButton.Click += new System.EventHandler(this.italicStripButton_Click);
            this.ucToolbar1.underlineStripButton.Click += new System.EventHandler(this.underlineStripButton_Click);
            this.ucToolbar1.toolStripButtonDel.Click += new System.EventHandler(this.delStripButton_Click);
            this.ucToolbar1.colorStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.colorStripDropDownButton_DropDownItemClicked);
            foreach (var sub in ucToolbar1.colorStripDropDownButton.DropDownItems)
                (sub as ToolStripMenuItem).DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.colorStripDropDownButton_DropDownItemClicked);
            this.ucToolbar1.clearFormattingStripButton.Click += new System.EventHandler(this.clearFormattingStripButton_Click);
            this.ucToolbar1.blistToolStripMenuItem.Click += bulletListStripButton_Click;
            this.ucToolbar1.textToolStripMenuItem.Click += textListStripButton_Click;
            this.ucToolbar1.head1ToolStripMenuItem.Click += head1ToolStripMenuItem_Click;
            this.ucToolbar1.head2ToolStripMenuItem.Click += head2ToolStripMenuItem_Click;
            this.ucToolbar1.head3ToolStripMenuItem.Click += head3ToolStripMenuItem_Click;

            textToolStripMenuItem.Click += textListStripButton_Click;
            toolStripMenuItemBullet.Click += bulletListStripButton_Click;
            head1ToolStripMenuItem.Click += head1ToolStripMenuItem_Click;
            head2ToolStripMenuItem.Click += head2ToolStripMenuItem_Click;
            head3ToolStripMenuItem.Click += head3ToolStripMenuItem_Click;

            foreach (var file in Directory.GetFiles(ENV.TemplateDir))
            {
                var fileName = file.Substring(file.LastIndexOf('/')+1);
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem(fileName);
                toolStripDropDownButtonTemplate.DropDownItems.Add(menuItem1);
                menuItem1.Click += (o, ea) =>
                {
                    var menuItem = o as ToolStripMenuItem;
                    richTextBox1.LoadFile(ENV.TemplateDir + menuItem.Text, RichTextBoxStreamType.RichText);
                    var ttl = string.Format("{0}{1}", fileName.Replace(".rtf", ""), DateTime.Now.ToString("yy.MM.dd"));
                    ParentC.SetRowTitleInfo(ttl, "Work/285665_calendar_calendar.png");
                };
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();     // paste text
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();      // copy text
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();     // cut text
        }
        private void ModifyFontStyle(FontStyle flag)
        {
            if (richTextBox1.SelectionFont == null)
                return;

            // create fontStyle object
            FontStyle style = richTextBox1.SelectionFont.Style;

            // determines the font style
            if ((style & flag) == flag)
                style &= ~flag;
            else
                style |= flag;

            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style); // sets the font style
        }

        private void boldStripButton3_Click(object sender, EventArgs e)
        {
            ModifyFontStyle(FontStyle.Bold);
        }

        private void underlineStripButton_Click(object sender, EventArgs e)
        {
            ModifyFontStyle(FontStyle.Underline);
        }

        private void italicStripButton_Click(object sender, EventArgs e)
        {
            ModifyFontStyle(FontStyle.Italic);
        }

        private void delStripButton_Click(object sender, EventArgs e)
        {
            ModifyFontStyle(FontStyle.Strikeout);
        }

        private void OnSave()
        {
            HighlightKeywords();

            var txt = richTextBox1.Text;
            foreach(var keyPair in keywords)
            {
                var todoCount = StringTool.CountSubstring(txt, keyPair.Key);
                memoItemInfo.SetParm(keyPair.Key, todoCount.ToString());
            }
        }

        public void Save(bool checkSaveAct)
        {
            if (checkSaveAct)
            {//修改过才会重新highlight
                checkChangeLock = false;
                OnSave();
                checkChangeLock = true;
            }
         
            richTextBox1.SaveFile(filenamee, RichTextBoxStreamType.RichText);

            HLog.Debug("SaveFile {0} finish checkSaveAct={1}", filenamee, checkSaveAct);
        }

        public void LoadFile(MemoItemInfo itemInfo)
        {
            if (!string.IsNullOrEmpty(filenamee))
            {
                // 立刻存档，并且取消timer
                if (hasModify)
                    DelayedActionExecutor.Trigger("desaySave", 0, () => Save(true));
            }

            memoItemInfo = itemInfo;
            var path = memoItemInfo.Id.ToString();
            var fullPath = string.Format("{0}/{1}.rtf", ENV.SaveDir, path);
            filenamee = fullPath;
            hasModify = false;
            if (File.Exists(fullPath))
            {
                checkChangeLock = false;
                richTextBox1.LoadFile(filenamee, RichTextBoxStreamType.RichText);
                HLog.Debug("LoadFile {0} success", filenamee);
                checkChangeLock = true;
            }
            else
            {
                richTextBox1.Clear();
            }
        }

        private void colorStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            richTextBox1.SelectionColor = (Color)e.ClickedItem.Tag;
            ucToolbar1.colorStripDropDownButton.HideDropDown();
        }

        private void RichtextSelect(int start, int count)
        {
            monitorRichtextboxChange = true;
            richTextBox1.Select(start, count);
            monitorRichtextboxChange = false;
        }

        private bool monitorRichtextboxChange = false;
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.IsSuspendPainting || monitorRichtextboxChange)
                return;

            if (!string.IsNullOrEmpty(richTextBox1.SelectedText))
            {
                var charPos = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
                int finalX = richTextBox1.Location.X+ charPos.X - 12;
                int finalY = richTextBox1.Location.Y + charPos.Y - 30;
                if (finalX + ucToolbar1.Width > richTextBox1.Location.X + richTextBox1.Width)
                    finalX = richTextBox1.Location.X + richTextBox1.Width - ucToolbar1.Width;

                ucToolbar1.Location = new Point(finalX, finalY);
                ucToolbar1.DelayVisible(true, 200);
            }
            else
            {
                ucToolbar1.DelayVisible(false, 500);
            }
        }

 #region 行格式

        private void SetBulletState(bool isOn)
        {
            if (richTextBox1.Text.Length == 0)
                return;

            if(isOn)
            {
                // 判断当前行的第一个字符是否是 "x"
                if (!IsLineMyBullet(out int currentLineIndex))
                {
                    // 如果不是 "x"，在当前行的开头插入 "x"
                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(currentLineIndex), 0);
                    richTextBox1.SelectedText = bulletMarker[richTextBox1.SelectionIndent / 30].ToString() + " ";
                }
            }
            else
            {
                // 判断当前行的第一个字符是否是 "x"
                if (IsLineMyBullet(out int currentLineIndex))
                {
                    // 如果是 "x"，选中并删除它
                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(currentLineIndex), 1);
                    richTextBox1.SelectedText = "";

                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(currentLineIndex), 1);
                    if (string.IsNullOrWhiteSpace(richTextBox1.SelectedText))
                        richTextBox1.SelectedText = "";
                }
            }
        }

        private void SetLineFormat(float size, int charOff, bool bold)
        {
            if (richTextBox1.Text.Length == 0)
                return;

            int rowIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            int firstCharIndex = richTextBox1.GetFirstCharIndexFromLine(rowIndex);
            int lineLength = richTextBox1.Lines[rowIndex].Length;

            RichtextSelect(firstCharIndex, lineLength);

            richTextBox1.SelectionFont = bold ? FontMgr.GetFont(size) : new Font("微软雅黑", size, FontStyle.Regular);
            richTextBox1.SelectionCharOffset = charOff;
            richTextBox1.SelectionLength = 0;
        }

        private void bulletListStripButton_Click(object sender, EventArgs e)
        {
            SetBulletState(true);
            SetLineFormat(12, 0, false);
        }

        private void textListStripButton_Click(object sender, EventArgs e)
        {
            SetBulletState(false);
            SetLineFormat(12, 0, false);
        }

        private void head1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBulletState(false);
            SetLineFormat(22, -50, true);
        }

        private void head2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBulletState(false);
            SetLineFormat(18, -30, true);
        }

        private void head3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBulletState(false);
            SetLineFormat(16, -10, true);
        }
#endregion

        private void undoStripButton_Click(object sender, EventArgs e)
        {           
            richTextBox1.Undo();     // undo move
        }

        private void redoStripButton_Click(object sender, EventArgs e)
        {            
            richTextBox1.Redo();    // redo move
        }

        private void zoomDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            float zoomPercent = Convert.ToSingle(e.ClickedItem.Text.Trim('%')); // convert
            richTextBox1.ZoomFactor = zoomPercent / 100;    // set zoom factor

            if(e.ClickedItem.Image == null)
            {
                // sets all the image properties to null - incase one is already selected beforehand
                for (int i = 0; i < zoomDropDownButton.DropDownItems.Count; i++)
                {
                    zoomDropDownButton.DropDownItems[i].Image = null;
                }

                // draw bmp in image property of selected item, while its active
                Bitmap bmp = new Bitmap(5, 5);
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
                }
                e.ClickedItem.Image = bmp;    // draw ellipse in image property
            }
            else
            {
                e.ClickedItem.Image = null;
                richTextBox1.ZoomFactor = 1.0f;    // set back to NO ZOOM
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = !richTextBox1.WordWrap;
        }

        private void deleteStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = ""; // delete selected text
        }

        private void clearFormattingStripButton_Click(object sender, EventArgs e)
        {
            ClearFormat();
        }

        private void ClearFormat()
        {
            if (richTextBox1.SelectionFont == null)
                return;

            richTextBox1.SelectionFont = new Font("微软雅黑", 12);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
            richTextBox1.SelectionCharOffset = 0;
        }

        private void imgStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImageDlg = new OpenFileDialog();
            openImageDlg.Filter = "所有图片(*.bmp,*.gif,*.jpg)|*.bmp;*.gif;*jpg";
            openImageDlg.Title = "选择图片";
            Bitmap bmp;
            if (openImageDlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = openImageDlg.FileName;
                if (null == fileName || fileName.Trim().Length == 0)
                    return;
                try
                {
                    bmp = new Bitmap(fileName);
                    Clipboard.SetDataObject(bmp);
                    DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (richTextBox1.CanPaste(dataFormat))
                        richTextBox1.Paste(dataFormat);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("图片插入失败。" + exc.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButtonScreen_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                richTextBox1.Paste();
            }
        }

        private void toolStripButtonEmo_Click(object sender, EventArgs e)
        {
            AddIcon();
        }

        string bulletMarker = "●◆◇▷▪";
        private bool IsLineMyBullet(out int currentLineIndex, int lineOff = 0)
        {
            // 获取当前行的索引
            currentLineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);

            // 获取当前行的文本
            string currentLineText = richTextBox1.Lines[Math.Max(0, currentLineIndex + lineOff)];

            // 判断当前行的第一个字符是否是 "x"
            if (currentLineText.Length > 0 && bulletMarker.Contains(currentLineText[0]))
                return true;
            return false;
        }

        //****************************************************************************************************************************************
        // richTextBox1_KeyUp - Determines which key was released and gets the line and column numbers of the current cursor position in the RTB *
        //**************************************************************************************************************************************** 
        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            // determine key released
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    if (e.Shift)
                        richTextBox1.SelectionIndent = Math.Max(0, richTextBox1.SelectionIndent - 30);
                    else
                        richTextBox1.SelectionIndent = Math.Min(240, richTextBox1.SelectionIndent + 30);
                    if (IsLineMyBullet(out int lineIndex))
                    {
                        richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
                        richTextBox1.SelectionLength = 2;
                        richTextBox1.SelectedText = bulletMarker[richTextBox1.SelectionIndent / 30].ToString() + " ";
                    }
                    break;
                case Keys.E: //表情
                    if (richTextBox1.SelectionStart >= 2 && richTextBox1.Text[richTextBox1.SelectionStart - 2] == '/')
                    { // /e
                        RichtextSelect(richTextBox1.SelectionStart - 2, 2);
                        richTextBox1.SelectedText = "";
                        
                        AddIcon();
                    }
                    break;
                case Keys.P: //人名
                    if (richTextBox1.SelectionStart >= 2 && richTextBox1.Text[richTextBox1.SelectionStart - 2] == '/')
                    { // /p
                        RichtextSelect(richTextBox1.SelectionStart - 2, 2);
                        richTextBox1.SelectedText = "";

                        AddPeople();
                    }
                    break;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 放在这里不会触发输出法选字的那下enter
            // 防止 AddIcon 最后回车的那下，击穿
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    ClearFormat(); //格式不带到下一行
                    if (IsLineMyBullet(out int currentLineIndex, -1))
                    {
                        RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(currentLineIndex), 0);
                        richTextBox1.SelectedText = bulletMarker[richTextBox1.SelectionIndent / 30].ToString() + " ";
                    }
                    break;
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;// 阻止 Tab 键的默认行为
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (IsLineMyBullet(out int currentLineIndex))
                {//左键不可超过bullet
                    var idx = richTextBox1.GetFirstCharIndexFromLine(currentLineIndex);
                    if(richTextBox1.SelectionStart <= idx + 2)
                        e.SuppressKeyPress = true;// 阻止 Tab 键的默认行为
                }
            }
            else if (e.KeyCode == Keys.Home)
            {
                if (IsLineMyBullet(out int currentLineIndex))
                {//home键不可超过bullet
                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(currentLineIndex)+2, 0);
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }


        private void AddIcon()
        {
            var pos = richTextBox1.SelectionStart;

            Point cursorPosition = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);

            // 如果需要，将坐标转换为屏幕坐标
            cursorPosition = richTextBox1.PointToScreen(cursorPosition);

            PanelManager.Instance.ShowIconForm(cursorPosition.X - ParentC.Location.X, 
                cursorPosition.Y - ParentC.Location.Y,
                (iconPath) =>
                {
                    // 将图片添加到剪贴板
                    Clipboard.SetImage(ImageTool.Transparent2Color((Bitmap)ResLoader.Read(iconPath), richTextBox1.BackColor, 24, 24));
                    richTextBox1.Paste();

                    RichtextSelect(pos + 1, 0);
                    richTextBox1.Focus();
                    //DelayedActionExecutor.Trigger("choosetarget", 0.1f, () => richTextBox1.Focus()); //防止enter事件击穿
                }
            );
        }

        private void AddPeople()
        {
            var pos = richTextBox1.SelectionStart;

            Point cursorPosition = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);

            // 如果需要，将坐标转换为屏幕坐标
            cursorPosition = richTextBox1.PointToScreen(cursorPosition);

            PanelManager.Instance.ShowPeopleForm(cursorPosition.X - ParentC.Location.X,
                cursorPosition.Y - ParentC.Location.Y,
                (name) =>
                {
                    Clipboard.SetText(name);
                    richTextBox1.Paste(DataFormats.GetFormat(DataFormats.Text));

                    RichtextSelect(pos, name.Length);
                    richTextBox1.SelectionColor = Color.Yellow; //给名字变色

                    RichtextSelect(pos + name.Length, 0);
                    richTextBox1.SelectionColor = richTextBox1.ForeColor;

                    richTextBox1.Focus();
                    //DelayedActionExecutor.Trigger("choosetarget", 0.1f, () => richTextBox1.Focus()); //防止enter事件击穿
                }
            );
        }

        private void HighlightKeywords()
        {
            // 保存原始光标位置和选择范围
            int originalSelectionStart = richTextBox1.SelectionStart;
            int originalSelectionLength = richTextBox1.SelectionLength;

            richTextBox1.SuspendPainting();

            // 移动光标到文本开始
            //richTextBox1.SelectionStart = 0;
            //richTextBox1.SelectionBackColor = Color.Black;
            //richTextBox1.SelectionLength = richTextBox1.TextLength;
            //richTextBox1.SelectionColor = richTextBox1.ForeColor; // 恢复默认颜色

            // 遍历关键词并高亮
            foreach (var keyword in keywords.Keys)
            {
                int index = 0;
                while (index < richTextBox1.TextLength)
                {
                    index = richTextBox1.Find(keyword, index, RichTextBoxFinds.None);
                    if (index == -1)
                        break;

                    RichtextSelect(index, keyword.Length);

                    richTextBox1.SelectionColor = keywords[keyword];

                    index += keyword.Length;
                }
            }

            // 还原光标位置和选择范围
            RichtextSelect(originalSelectionStart, originalSelectionLength);

            richTextBox1.ResumePainting();
        }


        //****************************************************************************************************************************
        // richTextBox1_MouseDown - Gets the line and column numbers of the cursor position in the RTB when the mouse clicks an area *
        //****************************************************************************************************************************

        int previousScrollPos = 0;
        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            int currentScrollPos = richTextBox1.GetPositionFromCharIndex(0).Y;

            if (currentScrollPos != previousScrollPos)
            {
                pictureBoxLeftS.Visible = false; // 滚动后，隐藏操作图标
            }

            previousScrollPos = currentScrollPos;
        }

        int lastRowId = -1;
        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var charIndex = richTextBox1.GetCharIndexFromPosition(e.Location);
            int rowIndex = richTextBox1.GetLineFromCharIndex(charIndex);

            if (lastRowId != rowIndex)
            {
                pictureBoxLeftS.Visible = true;

                var charPos = richTextBox1.GetPositionFromCharIndex(charIndex);
                pictureBoxLeftS.Location = new Point(12, charPos.Y + richTextBox1.Location.Y);
                lastRowId = rowIndex;
            }
        }

        private void pictureBoxLeftS_Click(object sender, EventArgs e)
        {
            var p = PointToScreen(pictureBoxLeftS.Location);
            customMenuStripRow.Show(p.X - 200, p.Y);
        }

        private void richTextBox1_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标进入时，清除掉粘贴板的格式
            IDataObject dataObj = Clipboard.GetDataObject();
            if (dataObj.GetDataPresent(DataFormats.StringFormat))
            {
                var txt = (string)Clipboard.GetData(DataFormats.StringFormat);
                Clipboard.Clear();
                Clipboard.SetData(DataFormats.StringFormat, txt);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!checkChangeLock)
                return;

            HLog.Debug("DasayEditor textchanged");
            hasModify = true;
            DelayedActionExecutor.Trigger("desaySave", 10, () => Save(false));
        }
    }
}
