﻿using MemoHippo.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCDocMultiselItem : UserControl, IDocComp
    {
        public Action<string> OnModify { get; set; }

        public UCDocMultiselItem()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void SetData(string k, string tagStr1)
        {
            label1.Text = k;
            textBox1.Text = tagStr1;
        }

        private void textBox1_Leave(object sender, System.EventArgs e)
        {
            Invalidate();
            OnModify(textBox1.Text);
            textBox1.Visible = false;
        }

        private void UCKVListMultisel_Paint(object sender, PaintEventArgs e)
        {
            if (textBox1.Visible)
                return;

            var startX = 210;
            var startY = 5;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                var dts = textBox1.Text.Split(',');
                foreach (string word in dts)
                {
                 
                    // 绘制白色文本
                    e.Graphics.DrawString(word, Font, Brushes.White, startX + 3, startY + 5);

                    // 获取文本框的大小
                    SizeF textSize = e.Graphics.MeasureString(word, Font);

                    Rectangle borderRect = new Rectangle(startX, startY, (int)textSize.Width+6, (int)textSize.Height+6);
                    e.Graphics.FillRectangle(Brushes.DeepSkyBlue, borderRect);

                    e.Graphics.DrawString(word, Font, Brushes.White, startX+3, startY+5);

                    // 调整下一个词的位置
                    startX += (int)textSize.Width + 6+4;
                }
            }
            else
            {
                e.Graphics.DrawString("点击输入", Font, Brushes.DarkGray, startX + 3, startY + 5);
            }
        }

        private void UCKVListMultisel_Click(object sender, System.EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Focus();
            Invalidate();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Invalidate();
                OnModify(textBox1.Text);
                textBox1.Visible = false;
            }
        }
    }
}
