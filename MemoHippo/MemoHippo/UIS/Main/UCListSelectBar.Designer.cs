﻿
namespace MemoHippo.UIS.Main
{
    partial class UCListSelectBar
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
            this.SuspendLayout();
            // 
            // UCListSelectBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UCListSelectBar";
            this.Size = new System.Drawing.Size(633, 59);
            this.Load += new System.EventHandler(this.UCListSelectBar_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UCListSelectBar_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCListSelectBar_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
