using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public class TransparentPanel : Panel
    {
        public Bitmap BG { get; set; }

        public TransparentPanel()
        {
            DoubleBuffered = true;

            this.Click += new System.EventHandler(this.TransparentPanel_Click);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float brightness = 0.5f; // 控制亮度，1 为不变，大于 1 变亮，小于 1 变暗
            float[][] matrixItems ={
                    new float[] {brightness, 0, 0, 0, 0},
                    new float[] {0, brightness, 0, 0, 0},
                    new float[] {0, 0, brightness, 0, 0},
                    new float[] {0, 0, 0, 1, 0}, // 不影响 Alpha 通道（透明度）
                    new float[] {0, 0, 0, 0, 1}
                };
            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            e.Graphics.DrawImage(BG, new Rectangle(0, 0, Width, Height), 0, 0, BG.Width, BG.Height, GraphicsUnit.Pixel, imageAttr);
        }

        private void TransparentPanel_Click(object sender, System.EventArgs e)
        {
            Controls.Clear();

            SendToBack();
        }

        public void AddControl(Control c)
        {
            int x = (Width - c.Width) / 2;
            int y = (Height - c.Height) / 2;

            // 设置 labelControl 的位置
             c.Location = new Point(x, y);

            Controls.Add(c);
        }
    }
}
