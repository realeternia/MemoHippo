
using MemoHippo.UIS;
using RJControls;

namespace MemoHippo.UIS
{
    partial class UCSettingBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uckvList1 = new MemoHippo.UIS.UCDocPropertyList();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(70, 70);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // uckvList1
            // 
            this.uckvList1.BackColor = System.Drawing.Color.Lime;
            this.uckvList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uckvList1.Location = new System.Drawing.Point(232, 0);
            this.uckvList1.Name = "uckvList1";
            this.uckvList1.Size = new System.Drawing.Size(921, 797);
            this.uckvList1.TabIndex = 0;
            // 
            // UCSettingBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.uckvList1);
            this.Name = "UCSettingBar";
            this.Size = new System.Drawing.Size(1153, 797);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private UCDocPropertyList uckvList1;
    }
}
