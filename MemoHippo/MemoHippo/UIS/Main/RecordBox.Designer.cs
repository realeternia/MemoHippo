﻿namespace MemoHippo.UIS.Main
{
    partial class RecordBox
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
            this.ucDataView1 = new MemoHippo.UIs.UCDataView();
            this.SuspendLayout();
            // 
            // ucDataView1
            // 
            this.ucDataView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataView1.IdReadOnly = false;
            this.ucDataView1.Location = new System.Drawing.Point(0, 0);
            this.ucDataView1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDataView1.Name = "ucDataView1";
            this.ucDataView1.NoModify = false;
            this.ucDataView1.Size = new System.Drawing.Size(1391, 929);
            this.ucDataView1.TabIndex = 0;
            // 
            // RecordBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.ucDataView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RecordBox";
            this.Size = new System.Drawing.Size(1391, 929);
            this.ResumeLayout(false);

        }

        #endregion

        private UIs.UCDataView ucDataView1;
    }
}
