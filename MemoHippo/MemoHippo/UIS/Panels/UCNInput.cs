﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    public partial class UCNInput : UserControl
    {
        private int textHintIndex;
        private bool isAutoComplete;
        private static List<string> wordList = new List<string>();
        private List<string> results = new List<string>(); //当前显示的结果列表

        public Form1 Form1 { get; set; }
        public Action<string> AfterSelect;

        public UCNInput()
        {
            InitializeComponent();
        }

        public void OnInit(List<string> wordL)
        {
            wordList = wordL;
            textBoxText.Clear();
            textBoxText.Focus();

            UpdateHints();
        }

        private string GetHint(int index)
        {
            if (results.Count == 0)
            {
                return "";
            }
            return results[index % results.Count];
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                textHintIndex--;
                var hintResult = GetHint(10000000 + textHintIndex);
                if (hintResult != "")
                {
                    isAutoComplete = true;
                    textBoxText.Text = hintResult;
                    textBoxText.SelectionStart = textBoxText.Text.Length;
                    listBox1.SelectedIndex = results.IndexOf(hintResult);
                    isAutoComplete = false;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                textHintIndex++;
                var hintResult = GetHint(10000000 + textHintIndex);
                if (hintResult != "")
                {
                    isAutoComplete = true;
                    textBoxText.Text = hintResult;
                    textBoxText.SelectionStart = textBoxText.Text.Length;
                    listBox1.SelectedIndex = results.IndexOf(hintResult);
                    isAutoComplete = false;
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (AfterSelect != null)
                    AfterSelect(textBoxText.Text.Split('-')[0]);

                Form1.HideBlackPanel();
            }
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            if (textBoxText.Text.Contains("\n"))
            {
                textBoxText.Text = "";
                return;
            }

            UpdateHints();
        }

        private void UpdateHints()
        {
            var nowText = textBoxText.Text;
            if (isAutoComplete)
                return;

            textHintIndex = 0;

            results = new List<string>();
            nowText = nowText.Trim();
            foreach (var matchTxt in wordList)
            {
                if (results.Count >= 10)
                    break;
                if (string.IsNullOrEmpty(nowText))
                {
                    results.Add(matchTxt);
                    continue;
                }

                var matchTxts = matchTxt.Split('-');
                // 拼音匹配前半部分
                if (ConvertPinyinName(matchTxts[0]).StartsWith(nowText) || matchTxt.StartsWith(nowText))
                {
                    results.Add(matchTxt);
                    continue;
                }

                //匹配后半部分的描述
                if(matchTxts.Length > 1 && matchTxts[1].Contains(nowText))
                {
                    results.Add(matchTxt);
                    continue;
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(results.ToArray());
        }

        private string ConvertPinyinName(string nm)
        {
            var ss = NPinyin.Pinyin.GetPinyin(nm).Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (var s in ss)
            {
                if (s.Length == 0)
                    continue;
                sb.Append(s[0]);
            }
            return sb.ToString();
        }
    }
}