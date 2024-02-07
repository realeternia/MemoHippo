﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemoHippo.Utils
{
    class RtfModifier
    {
        static RichTextBox targetBox = new RichTextBox();

        public static void Modify(Font font, string path, string txt, string srcTitle)
        {
            targetBox.LoadFile(path);

            targetBox.AppendText("\r\n");

            targetBox.SelectionStart = targetBox.TextLength;
            var oldPos = targetBox.SelectionStart;
            targetBox.SelectedRtf = txt;

            int newIndex = targetBox.Find("\r", oldPos, RichTextBoxFinds.None);

            var sign = string.Format(" [来自：{0}]", srcTitle);
            if (newIndex >= 0)
            {
                targetBox.SelectionStart = newIndex - 1;
                InsertString(targetBox, sign);
            }
            else
            {
                newIndex = oldPos;
                targetBox.AppendText(sign);
            }

            targetBox.Select(newIndex, sign.Length);

            targetBox.SelectionFont = font;
            targetBox.SelectionColor = Color.DimGray;

            targetBox.SaveFile(path, RichTextBoxStreamType.RichText);
        }

        public static void InsertString(RichTextBox box, string str)
        {
            var pos = box.SelectionStart;
            //  Clipboard.SetDataObject(name);
            Clipboard.SetText(str); // paste可能会失败

            int tryCount = 0;
            do
            {
                box.Paste(DataFormats.GetFormat(DataFormats.Text)); tryCount++;
                if (tryCount > 1)
                    HLog.Info("insertString try {0} times", tryCount);
                if (tryCount > 10)
                    break;
            }
            while (pos >= box.Text.Length || box.Text[pos] != str[0]);
        }

        public static string ReadRtfPlainText(int itemId, bool checkEncryto = false)
        {
            var fullPath = string.Format("{0}/{1}.rtf", ENV.SaveDir, itemId);
            var itemInfo = MemoBook.Instance.GetItem(itemId);
            if (checkEncryto && itemInfo.IsEncrypt())
            {
                fullPath = fullPath.Replace(".rtf", ".rz");
            }

            if (!File.Exists(fullPath)) 
                return "";

            string fileData;
            if (checkEncryto && itemInfo.IsEncrypt())
            {
                string tempFilePath = Path.GetTempFileName();
                FileEncryption.DecryptFile(fullPath, tempFilePath);

                fileData = File.ReadAllText(tempFilePath);
            }
            else
            {
                fileData = File.ReadAllText(fullPath);
            }

            using (RichTextBox richTextBox = new RichTextBox())
            {
                richTextBox.Rtf = fileData;
                return richTextBox.Text;
            }
        }

    }
}
