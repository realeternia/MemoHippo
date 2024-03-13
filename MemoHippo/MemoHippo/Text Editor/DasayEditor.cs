﻿/*
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
        private List<string> keywords = new List<string>
        {
            "todo",
            "done",
            "url",
            "share",
            "follow",
            "main",
        };

        private MemoItemInfo memoItemInfo;
        public Form1 ParentC;
        private bool checkChangeLock = true;
        private bool hasModify;
        private int rjButtonLeftSLineId = -1;

        public DasayEditor()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.BackColor = Color.FromArgb(32, 32, 32);
            richTextBox1.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            richTextBox1.AcceptsTab = true;    // allow tab
            richTextBox1.ShortcutsEnabled = true;    // allow shortcuts
            richTextBox1.DetectUrls = true;    // allow detect url
         //   richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;

            this.ResumeLayout();

            this.ucToolbar1.boldStripButton.Click += new System.EventHandler(this.boldStripButton3_Click);
            this.ucToolbar1.italicStripButton.Click += new System.EventHandler(this.italicStripButton_Click);
            this.ucToolbar1.underlineStripButton.Click += new System.EventHandler(this.underlineStripButton_Click);
            this.ucToolbar1.toolStripButtonDel.Click += new System.EventHandler(this.delStripButton_Click);
            this.ucToolbar1.colorStripDropDownButton.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.colorStripDropDownButton_DropDownItemClicked);
            foreach (var sub in ucToolbar1.colorStripDropDownButton.DropDownItems)
                (sub as ToolStripMenuItem).DropDownItemClicked += new ToolStripItemClickedEventHandler(this.colorStripDropDownButton_DropDownItemClicked);
            ucToolbar1.toolStripDropDownButtonCata.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.cataStripDropDownButton_DropDownItemClicked);
            this.ucToolbar1.clearFormattingStripButton.Click += new System.EventHandler(this.clearFormattingStripButton_Click);
            this.ucToolbar1.blistToolStripMenuItem.Click += barbulletListStripButton_Click;
            this.ucToolbar1.textToolStripMenuItem.Click += bartextListStripButton_Click;
            this.ucToolbar1.head1ToolStripMenuItem.Click += barhead1ToolStripMenuItem_Click;
            this.ucToolbar1.head2ToolStripMenuItem.Click += barhead2ToolStripMenuItem_Click;
            this.ucToolbar1.head3ToolStripMenuItem.Click += barhead3ToolStripMenuItem_Click;
            this.ucToolbar1.qutoToolStripMenuItem.Click += barqutoToolStripMenuItem_Click;

            textToolStripMenuItem.Click += textListStripButton_Click;
            bulletToolStripMenuItem.Click += bulletListStripButton_Click;
            head1ToolStripMenuItem.Click += head1ToolStripMenuItem_Click;
            head2ToolStripMenuItem.Click += head2ToolStripMenuItem_Click;
            head3ToolStripMenuItem.Click += head3ToolStripMenuItem_Click;
            showlineToolStripMenuItem.Click += showlineToolStripMenuItem_Click;
            qutoToolStripMenuItem.Click += qutoToolStripMenuItem_Click;

            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            findToolStripMenuItem.Click += findToolStripMenuItem_Click;

            toolStripMenuItemPName.Click += ToolStripMenuItemPName_Click;
            toolStripMenuItemTime.Click += ToolStripMenuItemTime_Click;
            toolStripMenuItemLink.Click += ToolStripMenuItemLink_Click;
            toolStripMenuItemEmotion.Click += ToolStripMenuItemEmotion_Click;
            toolStripMenuItemUrl.Click += ToolStripMenuItemUrl_Click;

            if (Directory.Exists(ENV.TemplateDir))
                foreach (var file in Directory.GetFiles(ENV.TemplateDir))
                {
                    var fileName = file.Substring(file.LastIndexOf('/') + 1);
                    ToolStripMenuItem menuItem1 = new ToolStripMenuItem(fileName);
                    toolStripDropDownButtonTemplate.DropDownItems.Add(menuItem1);
                    menuItem1.Click += (o, ea) =>
                    {
                        var menuItem = o as ToolStripMenuItem;
                        richTextBox1.LoadFile(ENV.TemplateDir + menuItem.Text, RichTextBoxStreamType.RichText);
                        var ttl = string.Format("{0}{1}", fileName.Replace(".rtf", ""), DateTime.Now.ToString("yy.MM.dd")); //--模板
                        ParentC.SetRowTitleInfo(ttl, "Work/285665_calendar_calendar.png");
                    };
                }

            rjDropdownMenuBar.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuBar.MenuItemTextColor = Color.White;
            rjDropdownMenuBar.MenuItemHeight = 25;
            rjDropdownMenuRightClick.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuRightClick.MenuItemTextColor = Color.White;
            rjDropdownMenuRightClick.MenuItemHeight = 25;
            rjDropdownMenuLine.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuLine.MenuItemTextColor = Color.White;
            rjDropdownMenuLine.MenuItemHeight = 25;

        }

        private void ToolStripMenuItemEmotion_Click(object sender, EventArgs e)
        {
            AddIcon();
        }

        private void ToolStripMenuItemLink_Click(object sender, EventArgs e)
        {
            AddPage();
        }

        private void ToolStripMenuItemTime_Click(object sender, EventArgs e)
        {
            AddTime();
        }

        private void ToolStripMenuItemPName_Click(object sender, EventArgs e)
        {
            AddPeople();
        }
        private void ToolStripMenuItemUrl_Click(object sender, EventArgs e)
        {
            AddUrl();
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
            FontStyle style = FontStyle.Regular;
            Font f = richTextBox1.Font;
            if (richTextBox1.SelectionFont != null)
            {
                style = richTextBox1.SelectionFont.Style;
                f = richTextBox1.SelectionFont;
            }       
            // determines the font style
            if ((style & flag) == flag)
                style &= ~flag;
            else
                style |= flag;

            richTextBox1.SelectionFont = new Font(f, style); // sets the font style
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
            if (!memoItemInfo.HasTag("db"))
                HighlightKeywords();

            var txt = richTextBox1.Text;
            foreach(var keys in keywords)
            {
                if (keys == "url") //url 只上色，不统计
                    continue;
                var todoCount = StringTool.CountSubstring(txt, keys);
                memoItemInfo.SetParm(keys, todoCount.ToString());
            }
        }

        public void SaveOnClose()
        {
            if (memoItemInfo != null)
            {
                // 立刻存档，并且取消timer
                if (hasModify || memoItemInfo.GetAndResetDirty())
                    DelayedExecutor.Trigger("desaySave", 0, () => Save(true));
            }
        }

        private void Save(bool checkSaveAct)
        {
            if (checkSaveAct)
            {//修改过才会重新highlight
                checkChangeLock = false;
                OnSave();
                checkChangeLock = true;
            }

            var savePath = memoItemInfo.GetFilePath();
            if (memoItemInfo.IsEncrypt())
            {
                string tempFilePath = Path.GetTempFileName();
                richTextBox1.SaveFile(tempFilePath, RichTextBoxStreamType.RichText);
                FileEncryption.EncryptFile(tempFilePath, savePath);
            }
            else
            {
                richTextBox1.SaveFile(savePath, RichTextBoxStreamType.RichText);
            }
            
            HLog.Info("SaveFile {0} finish checkSaveAct={1}", memoItemInfo.Id, checkSaveAct);
        }

        public void LoadFile(MemoItemInfo itemInfo)
        {
            memoItemInfo = itemInfo;
            var fullPath = memoItemInfo.GetFilePath();
            hasModify = false;

            checkChangeLock = false;
            richTextBox1.Clear();
            if (File.Exists(fullPath))
            {
                if (itemInfo.IsEncrypt())
                {
                    string tempFilePath = Path.GetTempFileName();
                    FileEncryption.DecryptFile(fullPath, tempFilePath);

                    richTextBox1.LoadFile(tempFilePath, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.LoadFile(fullPath, RichTextBoxStreamType.RichText);
                }

                HLog.Debug("LoadFile {0} success", fullPath);
                ucToolbar1.OnLoadFile();
            }
            checkChangeLock = true;
            //else
            //{
            //    richTextBox1.Clear();
            //}
            ////让滚动条到最前面
            //richTextBox1.SelectionStart = 0;
            //richTextBox1.ScrollToCaret();
        }

        private void colorStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            richTextBox1.SelectionColor = (Color)e.ClickedItem.Tag;
            ucToolbar1.colorStripDropDownButton.HideDropDown();
        }

        private void cataStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var itemId = (int)e.ClickedItem.Tag;

            var iteminfo = MemoBook.Instance.GetItem(itemId);
            RtfModifier.Modify(richTextBox1.Font, iteminfo.GetFilePath(), richTextBox1.SelectedRtf, memoItemInfo.Title);
        }

        public void RichtextSelect(int start, int count)
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
                ucToolbar1.DelayVisible(false, 200);
            }
        }

 #region 行格式

        private void SetLeadingSpecialChar(int lineIdx, string charTxt, Color c)
        {
            if (richTextBox1.Text.Length == 0)
                return;

            if (!string.IsNullOrEmpty(charTxt))
            {
                // 判断当前行的第一个字符是否是 "x"
                if (!IsLineWithSpecialChar(lineIdx))
                {
                    // 如果不是 "x"，在当前行的开头插入 "x"
                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIdx), 0);
                }
                else
                {
                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIdx), 2);
                }
                richTextBox1.SelectedText = charTxt + " ";
                RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIdx), 2);
                richTextBox1.SelectionColor = c;
                RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIdx), 0);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
            }
            else
            {
                // 判断当前行的第一个字符是否是 "x"
                if (IsLineWithSpecialChar(lineIdx))
                {
                    // 如果是 "x"，选中并删除它
                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIdx), 2);
                    richTextBox1.SelectedText = "";
                }
            }
        }

        private void SetLineFormat(int lineIdx, float size, int charOff, bool bold)
        {
            if (richTextBox1.Text.Length == 0)
                return;

            int firstCharIndex = richTextBox1.GetFirstCharIndexFromLine(lineIdx);
            int lineLength = richTextBox1.Lines[lineIdx].Length;

            RichtextSelect(firstCharIndex, lineLength);

            richTextBox1.SelectionFont = bold ? FontMgr.GetFont(size) : new Font("微软雅黑", size, FontStyle.Regular);
            richTextBox1.SelectionCharOffset = charOff;
            richTextBox1.SelectionLength = 0;
        }

        private int[] GetSelectRange()
        {
            var start = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            var end = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart + richTextBox1.SelectionLength);
            var result = new int[end - start + 1];
            for (var lineIndex = start; lineIndex <= end; lineIndex++)
                result[lineIndex - start] = lineIndex;
            return result;
        }

        private void SetLineFormatCommon(int[] lineIndexes, string specialChar, int fontSize, int leftIndent, bool bold)
        {
            using (new TextBoxSelectRecover(this, richTextBox1, true))
            {
                foreach (var lineIndex in lineIndexes)
                {
                    SetLeadingSpecialChar(lineIndex, specialChar, richTextBox1.ForeColor);
                    SetLineFormat(lineIndex, fontSize, leftIndent, bold);
                }
            }
        }

        private void barbulletListStripButton_Click(object sender, EventArgs e)
        {
            var specialChar = bulletMarker[richTextBox1.SelectionIndent / 30].ToString();
            SetLineFormatCommon(GetSelectRange(), specialChar, 12, 0, false);
        }

        private void bartextListStripButton_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(GetSelectRange(), "", 12, 0, false);
        }

        private void barhead1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(GetSelectRange(), "", 22, -50, true);
        }

        private void barhead2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(GetSelectRange(), "", 18, -30, true);
        }

        private void barhead3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(GetSelectRange(), "", 16, -10, true);
        }

        private void barqutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(GetSelectRange(), "▎", 12, 0, false);
        }

        private void bulletListStripButton_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(new int[] { rjButtonLeftSLineId }, bulletMarker[richTextBox1.SelectionIndent / 30].ToString(), 12, 0, false);
        }

        private void textListStripButton_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(new int[] { rjButtonLeftSLineId }, "", 12, 0, false);
        }

        private void head1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(new int[] { rjButtonLeftSLineId }, "", 22, -50, true);
        }

        private void head2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(new int[] { rjButtonLeftSLineId }, "", 18, -30, true);
        }

        private void head3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(new int[] { rjButtonLeftSLineId }, "", 16, -10, true);
        }

        private void qutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLineFormatCommon(new int[] { rjButtonLeftSLineId }, "▎", 12, 0, false);
        }

        private void showlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rtfOfCurrentLine;
            using (new TextBoxSelectRecover(this, richTextBox1))
            {
                // 设置选择范围为当前行
                RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(rjButtonLeftSLineId), 
                    richTextBox1.GetFirstCharIndexFromLine(rjButtonLeftSLineId + 1) - richTextBox1.SelectionStart);

                // 获取当前行的RTF文本
                rtfOfCurrentLine = richTextBox1.SelectedRtf;
            }

            PanelManager.Instance.ShowBigBox(rtfOfCurrentLine);
        }

        #endregion

        private void undoStripButton_Click(object sender, EventArgs e)
        {           
            richTextBox1.Undo();     // undo
        }

        private void redoStripButton_Click(object sender, EventArgs e)
        {            
            richTextBox1.Redo();    // redo
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = ""; // delete selected text
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.SelectedText))
                return;

            PanelManager.Instance.ShowSearchForm(richTextBox1.SelectedText);
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

                bmp = new Bitmap(fileName);
                PanelManager.Instance.ShowEditImage(bmp, img => { Clipboard.SetImage(img); richTextBox1.Paste(); });
            }
        }

        private void toolStripButtonScreen_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                PanelManager.Instance.ShowEditImage(Clipboard.GetImage(), img => { Clipboard.SetImage(img); richTextBox1.Paste(); });
            }
        }

        private void toolStripButtonEmo_Click(object sender, EventArgs e)
        {
            AddIcon();
        }

        private void toolStripButtonTodo_Click(object sender, EventArgs e)
        {
            var keyword = (sender as ToolStripButton).Tag.ToString();

            int currentLineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            string currentLineText = richTextBox1.Lines[currentLineIndex];

            int todoIndex = currentLineText.IndexOf(keyword);
            if (todoIndex != -1)
            {
                RemoveWord(currentLineIndex, currentLineText, keyword);
            }
            else
            {
                // 处理单词互斥
                if(keyword == "todo")
                {
                    RemoveWord(currentLineIndex, currentLineText, "done");
                    RemoveWord(currentLineIndex, currentLineText, "follow");
                    RemoveWord(currentLineIndex, currentLineText, "main");
                }
                else if (keyword == "done")
                {
                    RemoveWord(currentLineIndex, currentLineText, "todo");
                    RemoveWord(currentLineIndex, currentLineText, "follow");
                    RemoveWord(currentLineIndex, currentLineText, "main");
                }
                else if (keyword == "follow")
                {
                    RemoveWord(currentLineIndex, currentLineText, "todo");
                    RemoveWord(currentLineIndex, currentLineText, "done");
                    RemoveWord(currentLineIndex, currentLineText, "main");
                }
                else if (keyword == "main")
                {
                    RemoveWord(currentLineIndex, currentLineText, "todo");
                    RemoveWord(currentLineIndex, currentLineText, "done");
                    RemoveWord(currentLineIndex, currentLineText, "follow");
                }

                var selectStart = richTextBox1.GetFirstCharIndexFromLine(currentLineIndex);
                if (IsLineWithSpecialChar(currentLineIndex))
                {     // 在第二个位置插入 "todo"
                    selectStart = selectStart + 2;
                }

                RichtextSelect(selectStart, 0);
                richTextBox1.SelectedText = keyword + " ";
                richTextBox1.SelectionColor = richTextBox1.ForeColor;

                RichtextSelect(selectStart, keyword.Length);
                richTextBox1.SelectionColor = GetKeywordColor(keyword);

                RichtextSelect(selectStart, 0);
            }
        }

        private void RemoveWord(int currentLineIndex, string currentLineText, string keyword)
        {
            int todoIndex = currentLineText.IndexOf(keyword);
            if (todoIndex < 0)
                return;

            // 移除 "todo"，包括可能的空格
            int endIndex = todoIndex + keyword.Length;
            if (endIndex < currentLineText.Length && currentLineText[endIndex] == ' ')
                endIndex++; // 移除空格

            RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(currentLineIndex) + todoIndex, endIndex - todoIndex);
            richTextBox1.SelectedText = string.Empty;
        }

        string bulletMarker = "●◆◇▷▪";
        string specialMarker = "▎";
        private bool IsLineWithSpecialChar(int lineIndex)
        {
            if (CheckLineMyBullet(lineIndex))
                return true;

            string currentLineText = richTextBox1.Lines[lineIndex];
            if (currentLineText.Length > 0 && specialMarker.Contains(currentLineText[0]))
                return true;

            return false;
        }

        private bool CheckLineMyBullet(int lineIndex)
        {
            // 获取当前行的文本
            string currentLineText = richTextBox1.Lines[lineIndex];

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

                    using(new TextBoxSelectRecover(this, richTextBox1))
                    {
                        foreach (var lineIndex in GetSelectRange())
                        {
                            if (CheckLineMyBullet(lineIndex))
                            {
                                RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIndex), 2);
                                richTextBox1.SelectedText = bulletMarker[richTextBox1.SelectionIndent / 30].ToString() + " ";
                            }
                        }
                    }

                    break;

            }

            if (e.KeyCode == Keys.OemQuestion && !e.Shift)
            {
                RichtextSelect(richTextBox1.SelectionStart - 1, 1);
                richTextBox1.SelectedText = "";

                Point cursorLocation = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
                rjDropdownMenuLine.Show(richTextBox1, cursorLocation.X + 10, cursorLocation.Y + 10);
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

                    var lineIdx = Math.Max(0, richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) - 1);
                    if (IsLineWithSpecialChar(lineIdx))
                    {
                        RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIdx+1), 0);
                        richTextBox1.SelectedText = richTextBox1.Lines[lineIdx].Substring(0, 2);
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
            else if (e.KeyCode == Keys.Left && !e.Shift)
            {
                var lineIdx = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                if (IsLineWithSpecialChar(lineIdx))
                {//左键不可超过bullet
                    var idx = richTextBox1.GetFirstCharIndexFromLine(lineIdx);
                    if (richTextBox1.SelectionStart <= idx + 2)
                        e.SuppressKeyPress = true;// 阻止 Tab 键的默认行为
                }
            }
            else if (e.KeyCode == Keys.Home && !e.Shift)
            {
                var lineIdx = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                if (IsLineWithSpecialChar(lineIdx))
                {//home键不可超过bullet
                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIdx) + 2, 0);
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.F && e.Control)
            {
                toolStripTextBoxKeyText.Visible = true;
                toolStripButtonFindNext.Visible = true;
                toolStripTextBoxKeyText.Focus();
            }
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
                    if(string.IsNullOrEmpty(iconPath))
                    {
                        richTextBox1.Focus();
                        return;
                    }

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
                    if (string.IsNullOrEmpty(name))
                    {
                        richTextBox1.Focus();
                        return;
                    }

                    RtfModifier.InsertString(richTextBox1, name);

                    RichtextSelect(pos, name.Length);
                    richTextBox1.SelectionColor = MemoBook.Instance.Cfg.PeopleColor.ToColor(); //给名字变色

                    RichtextSelect(pos + name.Length, 0);
                    richTextBox1.SelectionColor = richTextBox1.ForeColor;

                    richTextBox1.Focus();
                    //DelayedActionExecutor.Trigger("choosetarget", 0.1f, () => richTextBox1.Focus()); //防止enter事件击穿
                }
            );
        }
        private void AddPage()
        {
            var pos = richTextBox1.SelectionStart;
            Point cursorPosition = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);

            // 如果需要，将坐标转换为屏幕坐标
            cursorPosition = richTextBox1.PointToScreen(cursorPosition);

            PanelManager.Instance.ShowPageForm(cursorPosition.X - ParentC.Location.X,
                cursorPosition.Y - ParentC.Location.Y,
                (name) =>
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        richTextBox1.Focus();
                        return;
                    }

                    var splitDatas = name.Split('@');
                    var checkStr = "file://page/" + splitDatas[splitDatas.Length - 1];

                    RtfModifier.InsertString(richTextBox1, checkStr);

                    richTextBox1.Focus();
                    //DelayedActionExecutor.Trigger("choosetarget", 0.1f, () => richTextBox1.Focus()); //防止enter事件击穿
                }
            );
        }


        private void AddTime()
        {
            var pos = richTextBox1.SelectionStart;
            Point cursorPosition = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);

            // 如果需要，将坐标转换为屏幕坐标
            cursorPosition = richTextBox1.PointToScreen(cursorPosition);

            PanelManager.Instance.ShowTimeForm(cursorPosition.X - ParentC.Location.X,
                cursorPosition.Y - ParentC.Location.Y,
                (timeStr) =>
                {
                    if (string.IsNullOrEmpty(timeStr))
                    {
                        richTextBox1.Focus();
                        return;
                    }

                    RtfModifier.InsertString(richTextBox1, timeStr);

                    RichtextSelect(pos, timeStr.Length);
                    if (timeStr.Contains("ddl"))
                        richTextBox1.SelectionColor = MemoBook.Instance.Cfg.TimeDDLColor.ToColor(); //给名字变色
                    else
                        richTextBox1.SelectionColor = MemoBook.Instance.Cfg.TimeCommonColor.ToColor(); //给名字变色

                    RichtextSelect(pos + timeStr.Length, 0);
                    richTextBox1.SelectionColor = richTextBox1.ForeColor;

                    richTextBox1.Focus();
                }
            );
        }
        private void AddUrl()
        {
            var pos = richTextBox1.SelectionStart;
            Point cursorPosition = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);

            // 如果需要，将坐标转换为屏幕坐标
            cursorPosition = richTextBox1.PointToScreen(cursorPosition);

            PanelManager.Instance.ShowAddUrl((str) =>
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        richTextBox1.Focus();
                        return;
                    }

                    RtfModifier.InsertString(richTextBox1, str);

                    richTextBox1.Focus();
                    //DelayedActionExecutor.Trigger("choosetarget", 0.1f, () => richTextBox1.Focus()); //防止enter事件击穿
                }
            );
        }

        private void HighlightKeywords()
        {
            richTextBox1.SuspendPainting();

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                string line = richTextBox1.Lines[i].Trim();

                // 检查行中是否包含 URL（以简单的包含 "http" 判断）
                if (line.Contains("http") && !line.Contains("url"))
                {
                    var lineStart = richTextBox1.GetFirstCharIndexFromLine(i);
                    if (IsLineWithSpecialChar(i))
                        lineStart += 2;
                 
                    RichtextSelect(lineStart, 0);
                    richTextBox1.SelectedText = "url ";   // 在行首添加 "url"
                }
            }

            // 遍历关键词并高亮
            foreach (var keyword in keywords)
            {
                int index = 0;
                while (index < richTextBox1.TextLength)
                {
                    index = richTextBox1.Find(keyword, index, RichTextBoxFinds.None);
                    if (index == -1)
                        break;

                    RichtextSelect(index, keyword.Length);
                    richTextBox1.SelectionColor = GetKeywordColor(keyword);

                    index += keyword.Length;
                }
            }

            richTextBox1.ResumePainting();
        }

        private static Color GetKeywordColor(string keyword)
        {
            var color = MemoBook.Instance.Cfg.KWTodoColor;
            switch (keyword)
            {
                case "todo": color = MemoBook.Instance.Cfg.KWTodoColor; break;
                case "done": color = MemoBook.Instance.Cfg.KWDoneColor; break;
                case "url": color = MemoBook.Instance.Cfg.KWUrlColor; break;
                case "share": color = MemoBook.Instance.Cfg.KWShareColor; break;
                case "follow": color = MemoBook.Instance.Cfg.KWFollowColor; break;
                case "main": color = MemoBook.Instance.Cfg.KWMainColor; break;
            }

            return color.ToColor();
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
                rjButtonLeftS.Visible = false; // 滚动后，隐藏操作图标
            }

            previousScrollPos = currentScrollPos;
        }


        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var charIndex = richTextBox1.GetCharIndexFromPosition(e.Location);
            int rowIndex = richTextBox1.GetLineFromCharIndex(charIndex);

            if (rjButtonLeftSLineId != rowIndex)
            {
                var charPos = richTextBox1.GetPositionFromCharIndex(charIndex);
                if (charPos.Y > -15) //防止向上出框
                {
                    rjButtonLeftS.Visible = true;
                    rjButtonLeftS.Location = new Point(12, charPos.Y + richTextBox1.Location.Y);
                    rjButtonLeftSLineId = rowIndex;
                }
            }
        }

        private void rjButtonLeftS_Click(object sender, EventArgs e)
        {
            showlineToolStripMenuItem.Visible = richTextBox1.Lines[rjButtonLeftSLineId].Length > 30;
            var nowLine = richTextBox1.Lines[rjButtonLeftSLineId];

            List<string> searchNameList = new List<string>();

            foreach(var name in MemoBook.Instance.Cfg.GetNamesOnly())
            {
                if (nowLine.Contains(name))
                    searchNameList.Add(name);
            }

            if (searchNameList.Count > 0)
            {
                toolStripMenuItemPeople.DropDownItems.Clear();
                toolStripMenuItemPeople.Visible = true;

                foreach (var name in searchNameList)
                {
                    var toolStripMenuItemSearch = new ToolStripMenuItem();
                    toolStripMenuItemSearch.BackColor = Color.FromArgb(32, 32, 32);
                    //  this.toolStripMenuItemPeople.Name = "toolStripMenuItemPeople";
                    toolStripMenuItemSearch.Size = new Size(232, 36);
                    toolStripMenuItemSearch.Text = name;
                    toolStripMenuItemSearch.Click += ToolStripMenuItemSearch_Click;
                    toolStripMenuItemPeople.DropDownItems.Add(toolStripMenuItemSearch);
                }
            }
            else
            {
                toolStripMenuItemPeople.Visible = false;
            }

            var db = CsvDbHouse.Instance.RoleDb;
            searchNameList.Clear();
            foreach (var name in db.GetValuesByHeader("姓名"))
            {
                if (nowLine.Contains(name))
                    searchNameList.Add(name);
            }

            if (searchNameList.Count > 0)
            {
                toolStripMenuItemSearchCard.DropDownItems.Clear();
                toolStripMenuItemSearchCard.Visible = true;

                foreach (var name in searchNameList)
                {
                    var toolStripMenuItemSearch = new ToolStripMenuItem();
                    toolStripMenuItemSearch.BackColor = Color.FromArgb(32, 32, 32);
                    //  this.toolStripMenuItemPeople.Name = "toolStripMenuItemPeople";
                    toolStripMenuItemSearch.Size = new Size(232, 36);
                    toolStripMenuItemSearch.Text = name;
                    toolStripMenuItemSearch.Click += ToolStripMenuItemSearchCard_Click;
                    toolStripMenuItemSearchCard.DropDownItems.Add(toolStripMenuItemSearch);
                }
            }
            else
            {
                toolStripMenuItemSearchCard.Visible = false;
            }

            rjDropdownMenuBar.Show(rjButtonLeftS, -rjDropdownMenuBar.Width, 0);
        }

        private void ToolStripMenuItemSearch_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowSearchForm((sender as ToolStripMenuItem).Text);
        }
        private void ToolStripMenuItemSearchCard_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowRoleStore((sender as ToolStripMenuItem).Text);
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
            DelayedExecutor.Trigger("desaySave", 10, () => Save(false));
        }

        private string lastSearchText = "";
        private int lastSearch = 0;
        private void toolStripButtonFindNext_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            if (string.IsNullOrEmpty(toolStripTextBoxKeyText.Text))
                return;

            if (lastSearchText != toolStripTextBoxKeyText.Text)
            {
                lastSearchText = toolStripTextBoxKeyText.Text;
                lastSearch = 0;
            }

            string searchText = toolStripTextBoxKeyText.Text;
            monitorRichtextboxChange = true;
            int index = richTextBox1.Find(searchText, lastSearch, RichTextBoxFinds.None);
            monitorRichtextboxChange = false;

            if (index != -1)
            {
                lastSearch = index + 1;
                RichtextSelect(index, searchText.Length);
                richTextBox1.ScrollToCaret(); // 滚动到选定的文本
                richTextBox1.Focus();
            }
            else
            {
                if (lastSearch != 0)
                {
                    monitorRichtextboxChange = true;
                    index = richTextBox1.Find(searchText, 0, RichTextBoxFinds.None);
                    if (index != -1)
                    {
                        monitorRichtextboxChange = false;
                        lastSearch = index + 1;
                        RichtextSelect(index, searchText.Length);
                        richTextBox1.ScrollToCaret(); // 滚动到选定的文本
                        richTextBox1.Focus();
                    }
                }
            }
        }

        public void SearchTxt(string txt)
        {
            toolStripTextBoxKeyText.Text = txt;
            DoSearch();
        }

        private void toolStripButtonFormatNotion_Click(object sender, EventArgs e)
        {
            richTextBox1.SuspendPainting();

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                string line = richTextBox1.Lines[i];
                var lineStart = richTextBox1.GetFirstCharIndexFromLine(i);

                if (line.StartsWith("        - "))
                {
                    RichtextSelect(lineStart, 10);
                    richTextBox1.SelectedText = "";
                    richTextBox1.SelectionIndent = 90;
                    SetLineFormatCommon(new int[] { i }, bulletMarker[richTextBox1.SelectionIndent / 30].ToString(), 12, 0, false);
                }
                else if (line.StartsWith("    - "))
                {
                    RichtextSelect(lineStart, 6);
                    richTextBox1.SelectedText = "";
                    richTextBox1.SelectionIndent = 60;
                    SetLineFormatCommon(new int[] { i }, bulletMarker[richTextBox1.SelectionIndent / 30].ToString(), 12, 0, false);
                }
                else if (line.StartsWith("- "))
                {
                    RichtextSelect(lineStart, 2);
                    richTextBox1.SelectedText = "";
                    richTextBox1.SelectionIndent = 30;
                    SetLineFormatCommon(new int[] { i }, bulletMarker[richTextBox1.SelectionIndent / 30].ToString(), 12, 0, false);
                }
                else if (line.StartsWith("### "))
                {
                    RichtextSelect(lineStart, 3);
                    richTextBox1.SelectedText = "";

                    SetLineFormatCommon(new int[] { i }, "", 16, -10, true);
                }
                else if (line.StartsWith("## "))
                {
                    RichtextSelect(lineStart, 3);
                    richTextBox1.SelectedText = "";

                    SetLineFormatCommon(new int[] { i }, "", 18, -30, true);
                }
                else
                {
                    SetLineFormatCommon(new int[] { i }, "", 12, 0, false);
                }
            }

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                string line = richTextBox1.Lines[i];
                var lineStart = richTextBox1.GetFirstCharIndexFromLine(i);
                if (!CheckBold(i, line, "**"))
                    CheckBold(i, line, "*");
            }

            richTextBox1.ResumePainting();
            richTextBox1.Invalidate();
        }

        private bool CheckBold(int i, string line, string marker)
        {
            // 寻找第一个 *
            int firstAsterisk = line.IndexOf(marker);

            // 如果找到第一个 *，则继续寻找第二个 *
            if (firstAsterisk != -1)
            {
                int secondAsterisk = line.IndexOf(marker, firstAsterisk + marker.Length);

                // 如果找到第二个 *，则处理文本
                if (secondAsterisk != -1)
                {
                    var lineStart = richTextBox1.GetFirstCharIndexFromLine(i);
                    int selectionLength = secondAsterisk - firstAsterisk - marker.Length;

                    RichtextSelect(lineStart + firstAsterisk + marker.Length, selectionLength);
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);

                    // 删除第一个 * 和第二个 *
                    RichtextSelect(lineStart + secondAsterisk, marker.Length);
                    richTextBox1.SelectedText = "";
                    RichtextSelect(lineStart + firstAsterisk, marker.Length);
                    richTextBox1.SelectedText = "";

                    return true;
                }
            }
            return false;
        }
    }
}
