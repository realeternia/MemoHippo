
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucCatalogSearch = new MemoHippo.UCCatalogNew();
            this.ucCatalogNew1 = new MemoHippo.UCCatalogNew();
            this.flowLayoutPanel1 = new MemoHippo.UIS.DoubleBufferedFlowLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBoxCatalogTitle = new MemoHippo.UIS.HintTextBox();
            this.panel1 = new MemoHippo.UIS.DoubleBufferedPanel();
            this.ucTipAdd1 = new MemoHippo.UCColumnAdd();
            this.uckvList1 = new MemoHippo.UIS.UCKVList();
            this.pictureBoxPaperIcon = new System.Windows.Forms.PictureBox();
            this.textBoxRowItemTitle = new MemoHippo.UIS.HintTextBox();
            this.dasayEditor1 = new Text_Editor.DasayEditor();
            this.panelBlack = new MemoHippo.UIS.TransparentPanel();
            this.customMenuStrip1 = new MemoHippo.UIS.CustomMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customMenuStripCol = new MemoHippo.UIS.CustomMenuStrip(this.components);
            this.toolStripMenuItemDelCol = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleBufferedFlowLayoutPanel1 = new MemoHippo.UIS.DoubleBufferedFlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaperIcon)).BeginInit();
            this.customMenuStrip1.SuspendLayout();
            this.customMenuStripCol.SuspendLayout();
            this.doubleBufferedFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogSearch);
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogNew1);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1833, 1078);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 3;
            // 
            // ucCatalogSearch
            // 
            this.ucCatalogSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucCatalogSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ucCatalogSearch.Location = new System.Drawing.Point(0, 2);
            this.ucCatalogSearch.Margin = new System.Windows.Forms.Padding(0);
            this.ucCatalogSearch.Name = "ucCatalogSearch";
            this.ucCatalogSearch.PicPath = "Icon/rac4.PNG";
            this.ucCatalogSearch.Size = new System.Drawing.Size(240, 38);
            this.ucCatalogSearch.TabIndex = 2;
            this.ucCatalogSearch.Title = "搜索";
            this.ucCatalogSearch.Click += new System.EventHandler(this.ucCatalogSearch_Click);
            // 
            // ucCatalogNew1
            // 
            this.ucCatalogNew1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucCatalogNew1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ucCatalogNew1.Location = new System.Drawing.Point(0, 41);
            this.ucCatalogNew1.Margin = new System.Windows.Forms.Padding(0);
            this.ucCatalogNew1.Name = "ucCatalogNew1";
            this.ucCatalogNew1.PicPath = "Icon/rac3.PNG";
            this.ucCatalogNew1.Size = new System.Drawing.Size(240, 38);
            this.ucCatalogNew1.TabIndex = 1;
            this.ucCatalogNew1.Title = "新项目";
            this.ucCatalogNew1.Click += new System.EventHandler(this.ucCatalogNew_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 85);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 993);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.splitContainer2.Panel2.Controls.Add(this.doubleBufferedFlowLayoutPanel1);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(1589, 1078);
            this.splitContainer2.SplitterDistance = 1094;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBoxCatalogTitle
            // 
            this.textBoxCatalogTitle.BackColor = System.Drawing.Color.Black;
            this.textBoxCatalogTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCatalogTitle.DefaultText = "点击输入标题";
            this.textBoxCatalogTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCatalogTitle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxCatalogTitle.ForeColorDE = System.Drawing.Color.White;
            this.textBoxCatalogTitle.Location = new System.Drawing.Point(24, 36);
            this.textBoxCatalogTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCatalogTitle.Name = "textBoxCatalogTitle";
            this.textBoxCatalogTitle.Size = new System.Drawing.Size(451, 40);
            this.textBoxCatalogTitle.TabIndex = 1;
            this.textBoxCatalogTitle.Text = "点击输入标题";
            this.textBoxCatalogTitle.TrueText = "";
            this.textBoxCatalogTitle.TextChanged += new System.EventHandler(this.textBoxCatalogTitle_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.ucTipAdd1);
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 978);
            this.panel1.TabIndex = 0;
            // 
            // ucTipAdd1
            // 
            this.ucTipAdd1.BackColor = System.Drawing.Color.Black;
            this.ucTipAdd1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucTipAdd1.ForeColor = System.Drawing.Color.White;
            this.ucTipAdd1.Location = new System.Drawing.Point(3, 3);
            this.ucTipAdd1.Margin = new System.Windows.Forms.Padding(2);
            this.ucTipAdd1.Name = "ucTipAdd1";
            this.ucTipAdd1.Size = new System.Drawing.Size(60, 60);
            this.ucTipAdd1.TabIndex = 0;
            // 
            // uckvList1
            // 
            this.uckvList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uckvList1.Location = new System.Drawing.Point(3, 103);
            this.uckvList1.Name = "uckvList1";
            this.uckvList1.Size = new System.Drawing.Size(491, 165);
            this.uckvList1.TabIndex = 5;
            // 
            // pictureBoxPaperIcon
            // 
            this.pictureBoxPaperIcon.Location = new System.Drawing.Point(20, 45);
            this.pictureBoxPaperIcon.Margin = new System.Windows.Forms.Padding(20, 45, 3, 20);
            this.pictureBoxPaperIcon.Name = "pictureBoxPaperIcon";
            this.pictureBoxPaperIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxPaperIcon.TabIndex = 3;
            this.pictureBoxPaperIcon.TabStop = false;
            this.pictureBoxPaperIcon.Click += new System.EventHandler(this.pictureBoxPaperIcon_Click);
            // 
            // textBoxRowItemTitle
            // 
            this.textBoxRowItemTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBoxRowItemTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRowItemTitle.DefaultText = "点击输入标题";
            this.textBoxRowItemTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRowItemTitle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxRowItemTitle.ForeColorDE = System.Drawing.Color.White;
            this.textBoxRowItemTitle.Location = new System.Drawing.Point(65, 40);
            this.textBoxRowItemTitle.Margin = new System.Windows.Forms.Padding(10, 40, 10, 20);
            this.textBoxRowItemTitle.Name = "textBoxRowItemTitle";
            this.textBoxRowItemTitle.Size = new System.Drawing.Size(318, 40);
            this.textBoxRowItemTitle.TabIndex = 2;
            this.textBoxRowItemTitle.Text = "点击输入标题";
            this.textBoxRowItemTitle.TrueText = "";
            this.textBoxRowItemTitle.TextChanged += new System.EventHandler(this.textBoxRowItemTitle_TextChanged);
            // 
            // dasayEditor1
            // 
            this.dasayEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.dasayEditor1.Location = new System.Drawing.Point(4, 273);
            this.dasayEditor1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dasayEditor1.Name = "dasayEditor1";
            this.dasayEditor1.Size = new System.Drawing.Size(491, 826);
            this.dasayEditor1.TabIndex = 0;
            // 
            // panelBlack
            // 
            this.panelBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBlack.BackColor = System.Drawing.Color.Black;
            this.panelBlack.BG = null;
            this.panelBlack.Brightness = 0.5F;
            this.panelBlack.Location = new System.Drawing.Point(0, 0);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(1830, 1078);
            this.panelBlack.TabIndex = 2;
            // 
            // customMenuStrip1
            // 
            this.customMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.customMenuStrip1.ForeColor = System.Drawing.Color.White;
            this.customMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.customMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.customMenuStrip1.Name = "customMenuStrip1";
            this.customMenuStrip1.Size = new System.Drawing.Size(126, 28);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // customMenuStripCol
            // 
            this.customMenuStripCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.customMenuStripCol.ForeColor = System.Drawing.Color.White;
            this.customMenuStripCol.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.customMenuStripCol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDelCol,
            this.colorToolStripMenuItem});
            this.customMenuStripCol.Name = "customMenuStrip1";
            this.customMenuStripCol.Size = new System.Drawing.Size(126, 52);
            // 
            // toolStripMenuItemDelCol
            // 
            this.toolStripMenuItemDelCol.Name = "toolStripMenuItemDelCol";
            this.toolStripMenuItemDelCol.Size = new System.Drawing.Size(125, 24);
            this.toolStripMenuItemDelCol.Text = "delete";
            this.toolStripMenuItemDelCol.Click += new System.EventHandler(this.toolStripMenuItemDelCol_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.colorToolStripMenuItem.Text = "color";
            // 
            // doubleBufferedFlowLayoutPanel1
            // 
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.pictureBoxPaperIcon);
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.textBoxRowItemTitle);
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.uckvList1);
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.dasayEditor1);
            this.doubleBufferedFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferedFlowLayoutPanel1.Name = "doubleBufferedFlowLayoutPanel1";
            this.doubleBufferedFlowLayoutPanel1.Size = new System.Drawing.Size(491, 1078);
            this.doubleBufferedFlowLayoutPanel1.TabIndex = 6;
            this.doubleBufferedFlowLayoutPanel1.SizeChanged += new System.EventHandler(this.doubleBufferedFlowLayoutPanel1_SizeChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1833, 1078);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelBlack);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaperIcon)).EndInit();
            this.customMenuStrip1.ResumeLayout(false);
            this.customMenuStripCol.ResumeLayout(false);
            this.doubleBufferedFlowLayoutPanel1.ResumeLayout(false);
            this.doubleBufferedFlowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Text_Editor.DasayEditor dasayEditor1;
        private DoubleBufferedFlowLayoutPanel flowLayoutPanel1;
        private HintTextBox textBoxCatalogTitle;
        private UCColumnAdd ucTipAdd1;
        private HintTextBox textBoxRowItemTitle;
        private System.Windows.Forms.PictureBox pictureBoxPaperIcon;
        public DoubleBufferedPanel panel1;
        private UCCatalogNew ucCatalogNew1;
        private UCCatalogNew ucCatalogSearch;
        private TransparentPanel panelBlack;
        private UCKVList uckvList1;
        private CustomMenuStrip customMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private CustomMenuStrip customMenuStripCol;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelCol;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private DoubleBufferedFlowLayoutPanel doubleBufferedFlowLayoutPanel1;
    }
}

