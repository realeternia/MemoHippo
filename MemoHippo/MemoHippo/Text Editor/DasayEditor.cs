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
using MemoHippo.Model.Types;

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
        private string filenamee;    // file opened inside of RTB
        public Form1 ParentC;
        private bool checkChangeLock = true;
        private bool hasModify;
        private int rjButtonLeftSLineId = -1;

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
            this.ucToolbar1.blistToolStripMenuItem.Click += barbulletListStripButton_Click;
            this.ucToolbar1.textToolStripMenuItem.Click += bartextListStripButton_Click;
            this.ucToolbar1.head1ToolStripMenuItem.Click += barhead1ToolStripMenuItem_Click;
            this.ucToolbar1.head2ToolStripMenuItem.Click += barhead2ToolStripMenuItem_Click;
            this.ucToolbar1.head3ToolStripMenuItem.Click += barhead3ToolStripMenuItem_Click;
            ucToolbar1.qutoToolStripMenuItem.Click += barqutoToolStripMenuItem_Click;

            textToolStripMenuItem1.Click += textListStripButton_Click;
            bulletToolStripMenuItem.Click += bulletListStripButton_Click;
            head1ToolStripMenuItem.Click += head1ToolStripMenuItem_Click;
            head2ToolStripMenuItem.Click += head2ToolStripMenuItem_Click;
            head3ToolStripMenuItem.Click += head3ToolStripMenuItem_Click;
            showlineToolStripMenuItem.Click += showlineToolStripMenuItem_Click;
            toolStripMenuItemPeople.Click += toolStripMenuItemPeople_Click;
            qutoToolStripMenuItem.Click += qutoToolStripMenuItem_Click;

            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            removeToolStripMenuItem.Click += deleteStripMenuItem_Click;

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
                        var ttl = string.Format("{0}{1}", fileName.Replace(".rtf", ""), DateTime.Now.ToString("yy.MM.dd"));
                        ParentC.SetRowTitleInfo(ttl, "Work/285665_calendar_calendar.png");
                    };
                }

            rjDropdownMenuBar.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuBar.MenuItemTextColor = Color.White;
            rjDropdownMenuBar.MenuItemHeight = 25;
            rjDropdownMenuRightClick.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuRightClick.MenuItemTextColor = Color.White;
            rjDropdownMenuRightClick.MenuItemHeight = 25;
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
                var todoCount = StringTool.CountSubstring(txt, keyPair);
                memoItemInfo.SetParm(keyPair, todoCount.ToString());
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
                    DelayedExecutor.Trigger("desaySave", 0, () => Save(true));
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

        private void toolStripMenuItemPeople_Click(object sender, EventArgs e)
        {
            var name = toolStripMenuItemPeople.Text.Replace("查找：", "");
            PanelManager.Instance.ShowSearchForm(name);
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
                    if(richTextBox1.SelectionStart <= idx + 2)
                        e.SuppressKeyPress = true;// 阻止 Tab 键的默认行为
                }
            }
            else if (e.KeyCode == Keys.Home && !e.Shift)
            {
                var lineIdx = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                if (IsLineWithSpecialChar(lineIdx))
                {//home键不可超过bullet
                    RichtextSelect(richTextBox1.GetFirstCharIndexFromLine(lineIdx) +2, 0);
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
                    richTextBox1.SelectionColor = MemoBook.Instance.Cfg.PeopleColor.ToColor(); //给名字变色

                    RichtextSelect(pos + name.Length, 0);
                    richTextBox1.SelectionColor = richTextBox1.ForeColor;

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
            ColorCfg color = null;
            foreach (var keyword in keywords)
            {
                int index = 0;
                while (index < richTextBox1.TextLength)
                {
                    index = richTextBox1.Find(keyword, index, RichTextBoxFinds.None);
                    if (index == -1)
                        break;

                    RichtextSelect(index, keyword.Length);

                    switch (keyword)
                    {
                        case "todo": color = MemoBook.Instance.Cfg.KWTodoColor; break;
                        case "done": color = MemoBook.Instance.Cfg.KWDoneColor; break;
                        case "url": color = MemoBook.Instance.Cfg.KWUrlColor; break;
                        case "share": color = MemoBook.Instance.Cfg.KWShareColor; break;
                        case "follow": color = MemoBook.Instance.Cfg.KWFollowColor; break;
                        case "main": color = MemoBook.Instance.Cfg.KWMainColor; break;
                    }
                    
                    richTextBox1.SelectionColor = color.ToColor();

                    index += keyword.Length;
                }
            }

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
                rjButtonLeftS.Visible = true;
                var charPos = richTextBox1.GetPositionFromCharIndex(charIndex);
                rjButtonLeftS.Location = new Point(12, charPos.Y + richTextBox1.Location.Y);
                rjButtonLeftSLineId = rowIndex;
            }
        }

        private void rjButtonLeftS_Click(object sender, EventArgs e)
        {
            showlineToolStripMenuItem.Visible = richTextBox1.Lines[rjButtonLeftSLineId].Length > 30;
            string nameExist = "";
            foreach(var name in MemoBook.Instance.Cfg.GetNamesOnly())
            {
                if (richTextBox1.Lines[rjButtonLeftSLineId].Contains(name))
                {
                    nameExist = name;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(nameExist))
            {
                toolStripMenuItemPeople.Text = "查找：" + nameExist;
                toolStripMenuItemPeople.Visible = true;
            }
            else
            {
                toolStripMenuItemPeople.Visible = false;
            }
            rjDropdownMenuBar.Show(rjButtonLeftS, -rjDropdownMenuBar.Width, 0);
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

          //  HLog.Debug("DasayEditor textchanged");
            hasModify = true;
            DelayedExecutor.Trigger("desaySave", 10, () => Save(false));
        }

    }
}
