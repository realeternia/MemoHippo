using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    class UCBGPropertyAttrItem : Label
    {
        private bool checked1;
        //private Image icon;
        private Color foreColor;
        private Color bgColor = Color.White;
        public bool Checked { get { return checked1; } set { checked1 = value; Invalidate(); } }

        public override string Text { get { return base.Text; } set { base.Text = value; CheckWords(value); Invalidate(); } }

        public UCBGPropertyAttrItem()
        {
            AutoSize = true;
            Click += UCBGPropertyAttrItem_Click;
        }

        private void CheckWords(string wrd)
        {
            // 默认颜色  
            foreColor = Color.White;
            bgColor = DrawTool.GetTagColor(wrd); // 假设默认背景色是白色  
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (checked1)
            {
                if (bgColor != Color.White)
                    using (var b = new SolidBrush(bgColor))
                        e.Graphics.FillRectangle(b, 0, 0, Width, Height);
                using (var b = new SolidBrush(foreColor))
                    e.Graphics.DrawString(Text, Font, b, 0, 0);
            }
            else
            {
                e.Graphics.DrawString(Text, Font, Brushes.DimGray, 0, 0);
            }
        }

        private void UCBGPropertyAttrItem_Click(object sender, EventArgs e)
        {
            checked1 = !checked1;
            Invalidate();
        }

    }
}
