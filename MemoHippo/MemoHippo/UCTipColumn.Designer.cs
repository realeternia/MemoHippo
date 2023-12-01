﻿
using MemoHippo.UIS;

namespace MemoHippo
{
    partial class UCTipColumn
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new MemoHippo.UIS.DoubleBufferedFlowLayoutPanel();
            this.customMenuStripRow = new MemoHippo.UIS.CustomMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nikonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customMenuStripRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.labelTitle.Location = new System.Drawing.Point(6, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(3);
            this.labelTitle.Size = new System.Drawing.Size(73, 31);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "label1";
            this.labelTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 685);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel1_DragDrop);
            this.flowLayoutPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel1_DragEnter);
            this.flowLayoutPanel1.DragOver += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel1_DragOver);
            this.flowLayoutPanel1.DragLeave += new System.EventHandler(this.flowLayoutPanel1_DragLeave);
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            this.flowLayoutPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCTipColumn_MouseClick);
            // 
            // customMenuStripRow
            // 
            this.customMenuStripRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.customMenuStripRow.ForeColor = System.Drawing.Color.White;
            this.customMenuStripRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.customMenuStripRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.convertToolStripMenuItem});
            this.customMenuStripRow.Name = "customMenuStrip1";
            this.customMenuStripRow.Size = new System.Drawing.Size(135, 52);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commonToolStripMenuItem,
            this.nikonToolStripMenuItem});
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.convertToolStripMenuItem.Text = "convert";
            // 
            // commonToolStripMenuItem
            // 
            this.commonToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.commonToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.commonToolStripMenuItem.Name = "commonToolStripMenuItem";
            this.commonToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.commonToolStripMenuItem.Text = "common";
            this.commonToolStripMenuItem.Click += new System.EventHandler(this.commonToolStripMenuItem_Click);
            // 
            // nikonToolStripMenuItem
            // 
            this.nikonToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.nikonToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.nikonToolStripMenuItem.Name = "nikonToolStripMenuItem";
            this.nikonToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.nikonToolStripMenuItem.Text = "nikon";
            this.nikonToolStripMenuItem.Click += new System.EventHandler(this.nikonToolStripMenuItem_Click);
            // 
            // UCTipColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UCTipColumn";
            this.Size = new System.Drawing.Size(340, 747);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UCTipColumn_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCTipColumn_MouseClick);
            this.MouseEnter += new System.EventHandler(this.UCTipColumn_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UCTipColumn_MouseLeave);
            this.customMenuStripRow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DoubleBufferedFlowLayoutPanel flowLayoutPanel1;
        private CustomMenuStrip customMenuStripRow;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nikonToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
    }
}
