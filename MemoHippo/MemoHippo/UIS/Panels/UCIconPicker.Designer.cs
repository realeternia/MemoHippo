﻿
namespace MemoHippo.UIS.Panels
{
    partial class UCIconPicker
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
            this.doubleBufferedPanel1 = new MemoHippo.UIS.DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(10, 10);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(449, 444);
            this.doubleBufferedPanel1.TabIndex = 0;
            this.doubleBufferedPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.UCIconPicker_Paint);
            this.doubleBufferedPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCIconPicker_MouseClick);
            this.doubleBufferedPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCIconPicker_MouseMove);
            this.doubleBufferedPanel1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.doubleBufferedPanel1_PreviewKeyDown);
            // 
            // UCIconPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.doubleBufferedPanel1);
            this.Name = "UCIconPicker";
            this.Size = new System.Drawing.Size(485, 520);
            this.ResumeLayout(false);

        }

        #endregion

        private UIS.DoubleBufferedPanel doubleBufferedPanel1;
    }
}
