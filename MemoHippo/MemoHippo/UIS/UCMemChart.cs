using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCMemChart : UserControl
    {
        private string chartName;
        public string[] XData;
        public float[] YData;

        private int barWidth;

        // 新增：支持外部设置颜色
        public Color BarColor { get; set; } = Color.Cyan;
        public Color LastBarColor { get; set; } = Color.Orange;
        public bool UseSeparateLastBarColor { get; set; } = true;

        public UCMemChart()
        {
            InitializeComponent();
        }

        public void InitBars(string name, string[] xData, float[] yData)
        {
            chartName = name;
            XData = xData;
            YData = yData;

            if (xData.Length == 0 || yData.Length == 0)
                barWidth = 1;
            else
                barWidth = this.Width / (XData.Length * 5 / 4);  // 减去一些间距  
            if (barWidth > 30)
                barWidth = 30;
            if (barWidth < 12)
                barWidth = 12;
            int barSpacing = barWidth / 4;

            doubleBufferedPanel1.Width = Math.Max(100, (barWidth + barSpacing) * xData.Length + 30);

            doubleBufferedPanel1.Invalidate();
        }

        private void UCMemChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.DrawString(chartName, this.Font, Brushes.White, new PointF(5, 5));

            if (XData == null || YData == null || XData.Length != YData.Length || YData.Length == 0)
                return;

            int barSpacing = barWidth / 4;
            int xStart = 20 + barSpacing;
            int maxY = Math.Max(1, (int)YData.Max());
            var heightTotal = Height - 20 - 40;

            for (int i = 0; i < XData.Length; i++)
            {
                int barHeight = (int)((YData[i] / (float)maxY) * (heightTotal - 2 * barSpacing)); // 减去顶部和底部的间距  
                Rectangle barRect = new Rectangle(xStart + i * (barWidth + barSpacing), heightTotal - barHeight - barSpacing + 20, barWidth, barHeight);

                // 判断是否是最后一个柱子，并决定使用哪种颜色
                Brush barBrush;
                if (UseSeparateLastBarColor && i == XData.Length - 1)
                    barBrush = new SolidBrush(LastBarColor);
                else
                    barBrush = new SolidBrush(BarColor);

                g.FillRectangle(barBrush, barRect);

                // 绘制X轴标签
                string label = XData[i];
                SizeF labelSize = g.MeasureString(label, this.Font);
                g.DrawString(label, this.Font, Brushes.White,
                    new PointF(barRect.Left + (barRect.Width - labelSize.Width) / 2,
                               heightTotal + 20 - barSpacing / 2 + 3));

                // 绘制Y轴值
                label = YData[i].ToString();
                labelSize = g.MeasureString(label, this.Font);
                g.DrawString(label, this.Font, Brushes.LawnGreen,
                    new PointF(barRect.Left + (barRect.Width - labelSize.Width) / 2,
                               barRect.Top - 20));
            }
        }
    }
}