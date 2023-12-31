﻿
using MemoHippo.UIS;

namespace MemoHippo
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBoxCatalogTitle = new System.Windows.Forms.TextBox();
            this.pictureBoxPaperIcon = new System.Windows.Forms.PictureBox();
            this.textBoxPaperTitle = new System.Windows.Forms.TextBox();
            this.ucMenuNew1 = new MemoHippo.UCCatalogNew();
            this.panel1 = new MemoHippo.UIS.DoubleBufferedPanel();
            this.ucTipAdd1 = new MemoHippo.UCColumnAdd();
            this.dasayEditor1 = new Text_Editor.DasayEditor();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaperIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1375, 862);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel1.Controls.Add(this.ucMenuNew1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 862);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.textBoxCatalogTitle);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Click += new System.EventHandler(this.splitContainer2_Panel1_Click);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.splitContainer2.Panel2.Controls.Add(this.pictureBoxPaperIcon);
            this.splitContainer2.Panel2.Controls.Add(this.textBoxPaperTitle);
            this.splitContainer2.Panel2.Controls.Add(this.dasayEditor1);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(1132, 862);
            this.splitContainer2.SplitterDistance = 639;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBoxCatalogTitle
            // 
            this.textBoxCatalogTitle.BackColor = System.Drawing.Color.Black;
            this.textBoxCatalogTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCatalogTitle.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.textBoxCatalogTitle.ForeColor = System.Drawing.Color.White;
            this.textBoxCatalogTitle.Location = new System.Drawing.Point(18, 29);
            this.textBoxCatalogTitle.Name = "textBoxCatalogTitle";
            this.textBoxCatalogTitle.Size = new System.Drawing.Size(338, 32);
            this.textBoxCatalogTitle.TabIndex = 1;
            this.textBoxCatalogTitle.Text = "哈哈哈哈";
            this.textBoxCatalogTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // pictureBoxPaperIcon
            // 
            this.pictureBoxPaperIcon.Location = new System.Drawing.Point(11, 23);
            this.pictureBoxPaperIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxPaperIcon.Name = "pictureBoxPaperIcon";
            this.pictureBoxPaperIcon.Size = new System.Drawing.Size(24, 26);
            this.pictureBoxPaperIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPaperIcon.TabIndex = 3;
            this.pictureBoxPaperIcon.TabStop = false;
            this.pictureBoxPaperIcon.Click += new System.EventHandler(this.pictureBoxPaperIcon_Click);
            // 
            // textBoxPaperTitle
            // 
            this.textBoxPaperTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBoxPaperTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPaperTitle.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.textBoxPaperTitle.ForeColor = System.Drawing.Color.White;
            this.textBoxPaperTitle.Location = new System.Drawing.Point(44, 20);
            this.textBoxPaperTitle.Name = "textBoxPaperTitle";
            this.textBoxPaperTitle.Size = new System.Drawing.Size(238, 32);
            this.textBoxPaperTitle.TabIndex = 2;
            this.textBoxPaperTitle.Text = "哈哈哈哈";
            this.textBoxPaperTitle.TextChanged += new System.EventHandler(this.textBoxTitle2_TextChanged);
            // 
            // ucMenuNew1
            // 
            this.ucMenuNew1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucMenuNew1.Location = new System.Drawing.Point(0, 0);
            this.ucMenuNew1.Margin = new System.Windows.Forms.Padding(0);
            this.ucMenuNew1.Name = "ucMenuNew1";
            this.ucMenuNew1.Size = new System.Drawing.Size(180, 30);
            this.ucMenuNew1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.ucTipAdd1);
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 782);
            this.panel1.TabIndex = 0;
            // 
            // ucTipAdd1
            // 
            this.ucTipAdd1.BackColor = System.Drawing.Color.Black;
            this.ucTipAdd1.ForeColor = System.Drawing.Color.White;
            this.ucTipAdd1.Location = new System.Drawing.Point(2, 2);
            this.ucTipAdd1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucTipAdd1.Name = "ucTipAdd1";
            this.ucTipAdd1.Size = new System.Drawing.Size(45, 71);
            this.ucTipAdd1.TabIndex = 0;
            // 
            // dasayEditor1
            // 
            this.dasayEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dasayEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.dasayEditor1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.dasayEditor1.Location = new System.Drawing.Point(0, 68);
            this.dasayEditor1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dasayEditor1.Name = "dasayEditor1";
            this.dasayEditor1.Size = new System.Drawing.Size(491, 794);
            this.dasayEditor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1375, 862);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaperIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Text_Editor.DasayEditor dasayEditor1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UCCatalogNew ucMenuNew1;
        private System.Windows.Forms.TextBox textBoxCatalogTitle;
        private UCColumnAdd ucTipAdd1;
        private System.Windows.Forms.TextBox textBoxPaperTitle;
        private System.Windows.Forms.PictureBox pictureBoxPaperIcon;
        public DoubleBufferedPanel panel1;
    }
}

