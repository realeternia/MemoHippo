
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucCatalogStore = new MemoHippo.UCCatalogFix();
            this.ucCatalogNew = new MemoHippo.UCCatalogFix();
            this.ucCatalogSearch = new MemoHippo.UCCatalogFix();
            this.ucCatalogSetup = new MemoHippo.UCCatalogFix();
            this.flowLayoutPanel1 = new MemoHippo.UIS.DoubleBufferedFlowLayoutPanel();
            this.textBoxCatalogTitle = new MemoHippo.UIS.HintTextBox();
            this.panel1 = new MemoHippo.UIS.DoubleBufferedPanel();
            this.ucTipAdd1 = new MemoHippo.UCColumnAdd();
            this.doubleBufferedFlowLayoutPanel1 = new MemoHippo.UIS.DoubleBufferedFlowLayoutPanel();
            this.pictureBoxPaperIcon = new System.Windows.Forms.PictureBox();
            this.textBoxRowItemTitle = new MemoHippo.UIS.HintTextBox();
            this.uckvList1 = new MemoHippo.UIS.UCDocPropertyList();
            this.dasayEditor1 = new Text_Editor.DasayEditor();
            this.panelBlack = new MemoHippo.UIS.TransparentPanel();
            this.rjDropdownMenuCol = new RJControls.RJDropdownMenu(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rjDropdownMenuCatlog = new RJControls.RJDropdownMenu(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rjDropdownMenuRow = new RJControls.RJDropdownMenu(this.components);
            this.storeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.commonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nikonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.doubleBufferedFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaperIcon)).BeginInit();
            this.rjDropdownMenuCol.SuspendLayout();
            this.rjDropdownMenuCatlog.SuspendLayout();
            this.rjDropdownMenuRow.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogStore);
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogNew);
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogSearch);
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogSetup);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1833, 1078);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 3;
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
            // ucCatalogStore
            // 
            this.ucCatalogStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucCatalogStore.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ucCatalogStore.ForeColor = System.Drawing.Color.DarkGray;
            this.ucCatalogStore.Location = new System.Drawing.Point(0, 80);
            this.ucCatalogStore.Margin = new System.Windows.Forms.Padding(0);
            this.ucCatalogStore.Name = "ucCatalogStore";
            this.ucCatalogStore.PicImg = global::MemoHippo.Properties.Resources.store;
            this.ucCatalogStore.Size = new System.Drawing.Size(240, 38);
            this.ucCatalogStore.TabIndex = 4;
            this.ucCatalogStore.Title = "归档间";
            this.ucCatalogStore.Click += new System.EventHandler(this.ucCatalogStore_Click);
            // 
            // ucCatalogNew
            // 
            this.ucCatalogNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucCatalogNew.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ucCatalogNew.ForeColor = System.Drawing.Color.DarkGray;
            this.ucCatalogNew.Location = new System.Drawing.Point(0, 119);
            this.ucCatalogNew.Margin = new System.Windows.Forms.Padding(0);
            this.ucCatalogNew.Name = "ucCatalogNew";
            this.ucCatalogNew.PicImg = global::MemoHippo.Properties.Resources.noteadd;
            this.ucCatalogNew.Size = new System.Drawing.Size(240, 38);
            this.ucCatalogNew.TabIndex = 3;
            this.ucCatalogNew.Title = "新项目";
            this.ucCatalogNew.Click += new System.EventHandler(this.ucCatalogNew_Click);
            // 
            // ucCatalogSearch
            // 
            this.ucCatalogSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucCatalogSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ucCatalogSearch.ForeColor = System.Drawing.Color.DarkGray;
            this.ucCatalogSearch.Location = new System.Drawing.Point(0, 2);
            this.ucCatalogSearch.Margin = new System.Windows.Forms.Padding(0);
            this.ucCatalogSearch.Name = "ucCatalogSearch";
            this.ucCatalogSearch.PicImg = global::MemoHippo.Properties.Resources.search;
            this.ucCatalogSearch.Size = new System.Drawing.Size(240, 38);
            this.ucCatalogSearch.TabIndex = 2;
            this.ucCatalogSearch.Title = "搜索";
            this.ucCatalogSearch.Click += new System.EventHandler(this.ucCatalogSearch_Click);
            // 
            // ucCatalogSetup
            // 
            this.ucCatalogSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucCatalogSetup.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ucCatalogSetup.ForeColor = System.Drawing.Color.DarkGray;
            this.ucCatalogSetup.Location = new System.Drawing.Point(0, 41);
            this.ucCatalogSetup.Margin = new System.Windows.Forms.Padding(0);
            this.ucCatalogSetup.Name = "ucCatalogSetup";
            this.ucCatalogSetup.PicImg = global::MemoHippo.Properties.Resources.wheel;
            this.ucCatalogSetup.Size = new System.Drawing.Size(240, 38);
            this.ucCatalogSetup.TabIndex = 1;
            this.ucCatalogSetup.Title = "设置中心";
            this.ucCatalogSetup.Click += new System.EventHandler(this.ucCatalogSetup_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 160);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 918);
            this.flowLayoutPanel1.TabIndex = 0;
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
            this.panel1.Size = new System.Drawing.Size(500, 981);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.splitContainer2_Panel1_Click);
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
            // pictureBoxPaperIcon
            // 
            this.pictureBoxPaperIcon.Location = new System.Drawing.Point(20, 45);
            this.pictureBoxPaperIcon.Margin = new System.Windows.Forms.Padding(20, 45, 3, 20);
            this.pictureBoxPaperIcon.Name = "pictureBoxPaperIcon";
            this.pictureBoxPaperIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxPaperIcon.TabIndex = 3;
            this.pictureBoxPaperIcon.TabStop = false;
            this.pictureBoxPaperIcon.Click += new System.EventHandler(this.pictureBoxPaperIcon_Click);
            this.pictureBoxPaperIcon.MouseEnter += new System.EventHandler(this.pictureBoxPaperIcon_MouseEnter);
            this.pictureBoxPaperIcon.MouseLeave += new System.EventHandler(this.pictureBoxPaperIcon_MouseLeave);
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
            // uckvList1
            // 
            this.uckvList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uckvList1.BackColor = System.Drawing.Color.DarkBlue;
            this.uckvList1.BgColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.uckvList1.Location = new System.Drawing.Point(3, 103);
            this.uckvList1.Name = "uckvList1";
            this.uckvList1.Size = new System.Drawing.Size(491, 165);
            this.uckvList1.TabIndex = 5;
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
            this.panelBlack.Location = new System.Drawing.Point(0, 0);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(1830, 1078);
            this.panelBlack.TabIndex = 2;
            // 
            // rjDropdownMenuCol
            // 
            this.rjDropdownMenuCol.BackColor = System.Drawing.Color.Black;
            this.rjDropdownMenuCol.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rjDropdownMenuCol.ForeColor = System.Drawing.Color.White;
            this.rjDropdownMenuCol.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rjDropdownMenuCol.IsMainMenu = false;
            this.rjDropdownMenuCol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.colorToolStripMenuItem1});
            this.rjDropdownMenuCol.MenuItemHeight = 25;
            this.rjDropdownMenuCol.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuCol.Name = "rjDropdownMenu1";
            this.rjDropdownMenuCol.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuCol.Size = new System.Drawing.Size(115, 60);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(114, 28);
            this.removeToolStripMenuItem.Text = "删除";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemDelCol_Click);
            // 
            // colorToolStripMenuItem1
            // 
            this.colorToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.colorToolStripMenuItem1.Name = "colorToolStripMenuItem1";
            this.colorToolStripMenuItem1.Size = new System.Drawing.Size(114, 28);
            this.colorToolStripMenuItem1.Text = "颜色";
            // 
            // rjDropdownMenuCatlog
            // 
            this.rjDropdownMenuCatlog.BackColor = System.Drawing.Color.Black;
            this.rjDropdownMenuCatlog.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rjDropdownMenuCatlog.ForeColor = System.Drawing.Color.White;
            this.rjDropdownMenuCatlog.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rjDropdownMenuCatlog.IsMainMenu = false;
            this.rjDropdownMenuCatlog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.rjDropdownMenuCatlog.MenuItemHeight = 25;
            this.rjDropdownMenuCatlog.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuCatlog.Name = "rjDropdownMenu1";
            this.rjDropdownMenuCatlog.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuCatlog.Size = new System.Drawing.Size(115, 32);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 28);
            this.toolStripMenuItem1.Text = "删除";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // rjDropdownMenuRow
            // 
            this.rjDropdownMenuRow.BackColor = System.Drawing.Color.Black;
            this.rjDropdownMenuRow.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rjDropdownMenuRow.ForeColor = System.Drawing.Color.White;
            this.rjDropdownMenuRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rjDropdownMenuRow.IsMainMenu = false;
            this.rjDropdownMenuRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storeToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.rjDropdownMenuRow.MenuItemHeight = 25;
            this.rjDropdownMenuRow.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuRow.Name = "rjDropdownMenu1";
            this.rjDropdownMenuRow.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuRow.Size = new System.Drawing.Size(115, 88);
            // 
            // storeToolStripMenuItem
            // 
            this.storeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.storeToolStripMenuItem.Name = "storeToolStripMenuItem";
            this.storeToolStripMenuItem.Size = new System.Drawing.Size(114, 28);
            this.storeToolStripMenuItem.Text = "存档";
            this.storeToolStripMenuItem.Click += new System.EventHandler(this.storeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commonToolStripMenuItem1,
            this.nikonToolStripMenuItem1});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(114, 28);
            this.toolStripMenuItem3.Text = "转换";
            // 
            // commonToolStripMenuItem1
            // 
            this.commonToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.commonToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.commonToolStripMenuItem1.Name = "commonToolStripMenuItem1";
            this.commonToolStripMenuItem1.Size = new System.Drawing.Size(145, 28);
            this.commonToolStripMenuItem1.Text = "普通";
            this.commonToolStripMenuItem1.Click += new System.EventHandler(this.commonToolStripMenuItem_Click);
            // 
            // nikonToolStripMenuItem1
            // 
            this.nikonToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nikonToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.nikonToolStripMenuItem1.Name = "nikonToolStripMenuItem1";
            this.nikonToolStripMenuItem1.Size = new System.Drawing.Size(145, 28);
            this.nikonToolStripMenuItem1.Text = "轮播行";
            this.nikonToolStripMenuItem1.Click += new System.EventHandler(this.nikonToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(114, 28);
            this.toolStripMenuItem2.Text = "删除";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.deleteToolStripMenuItemRow_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "MemoHippo";
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
            this.doubleBufferedFlowLayoutPanel1.ResumeLayout(false);
            this.doubleBufferedFlowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaperIcon)).EndInit();
            this.rjDropdownMenuCol.ResumeLayout(false);
            this.rjDropdownMenuCatlog.ResumeLayout(false);
            this.rjDropdownMenuRow.ResumeLayout(false);
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
        private UCCatalogFix ucCatalogSetup;
        private UCCatalogFix ucCatalogSearch;
        public TransparentPanel panelBlack;
        private UCDocPropertyList uckvList1;
        private DoubleBufferedFlowLayoutPanel doubleBufferedFlowLayoutPanel1;
        private RJControls.RJDropdownMenu rjDropdownMenuCol;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem1;
        private RJControls.RJDropdownMenu rjDropdownMenuCatlog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private RJControls.RJDropdownMenu rjDropdownMenuRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem commonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nikonToolStripMenuItem1;
        private UCCatalogFix ucCatalogNew;
        private System.Windows.Forms.ToolStripMenuItem storeToolStripMenuItem;
        private UCCatalogFix ucCatalogStore;
    }
}

