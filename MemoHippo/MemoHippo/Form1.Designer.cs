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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ucCatalogRoleStore = new MemoHippo.UCCatalogFix();
            this.ucCatalogNew = new MemoHippo.UCCatalogFix();
            this.ucCatalogSearch = new MemoHippo.UCCatalogFix();
            this.ucCatalogSetup = new MemoHippo.UCCatalogFix();
            this.flowLayoutPanel1 = new MemoHippo.UIS.DoubleBufferedFlowLayoutPanel();
            this.ucListSelectBar1 = new MemoHippo.UIS.Main.UCListSelectBar();
            this.viewStack1 = new MemoHippo.UIS.ViewStack();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new MemoHippo.UIS.DoubleBufferedPanel();
            this.ucTipAdd1 = new MemoHippo.UCColumnAdd();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView1 = new MemoHippo.UIS.DoubleBufferedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxCatalogTitle = new MemoHippo.UIS.HintTextBox();
            this.doubleBufferedFlowLayoutPanel1 = new MemoHippo.UIS.DoubleBufferedFlowLayoutPanel();
            this.ucDocTopBar1 = new MemoHippo.UIS.DocComp.UCDocTopBar();
            this.pictureBoxPaperIcon = new System.Windows.Forms.PictureBox();
            this.textBoxRowItemTitle = new MemoHippo.UIS.HintTextBox();
            this.uckvList1 = new MemoHippo.UIS.UCDocPropertyList();
            this.ucListSelectBar2 = new MemoHippo.UIS.Main.UCListSelectBar();
            this.viewStack2 = new MemoHippo.UIS.ViewStack();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dasayEditor1 = new Text_Editor.DasayEditor();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.imageGallery1 = new MemoHippo.UIS.Main.ImageGallery();
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
            this.toolStripMenuItemBook = new System.Windows.Forms.ToolStripMenuItem();
            this.ddlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCata = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCryto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.viewStack1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.doubleBufferedFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaperIcon)).BeginInit();
            this.viewStack2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogRoleStore);
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogNew);
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogSearch);
            this.splitContainer1.Panel1.Controls.Add(this.ucCatalogSetup);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1813, 1078);
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
            this.splitContainer2.Panel1.Controls.Add(this.ucListSelectBar1);
            this.splitContainer2.Panel1.Controls.Add(this.viewStack1);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxCatalogTitle);
            this.splitContainer2.Panel1.Click += new System.EventHandler(this.splitContainer2_Panel1_Click);
            this.splitContainer2.Panel1.Resize += new System.EventHandler(this.splitContainer2_Panel1_Resize);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.splitContainer2.Panel2.Controls.Add(this.doubleBufferedFlowLayoutPanel1);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(1569, 1078);
            this.splitContainer2.SplitterDistance = 1074;
            this.splitContainer2.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(40, 40);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ucCatalogRoleStore
            // 
            this.ucCatalogRoleStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucCatalogRoleStore.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ucCatalogRoleStore.ForeColor = System.Drawing.Color.DarkGray;
            this.ucCatalogRoleStore.Location = new System.Drawing.Point(0, 80);
            this.ucCatalogRoleStore.Margin = new System.Windows.Forms.Padding(0);
            this.ucCatalogRoleStore.Name = "ucCatalogRoleStore";
            this.ucCatalogRoleStore.PicImg = global::MemoHippo.Properties.Resources.store;
            this.ucCatalogRoleStore.Size = new System.Drawing.Size(240, 38);
            this.ucCatalogRoleStore.TabIndex = 4;
            this.ucCatalogRoleStore.Title = "卡牌库";
            this.ucCatalogRoleStore.Click += new System.EventHandler(this.ucCatalogRoleStore_Click);
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
            // ucListSelectBar1
            // 
            this.ucListSelectBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucListSelectBar1.BackColor = System.Drawing.Color.Black;
            this.ucListSelectBar1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucListSelectBar1.ForeColor = System.Drawing.Color.White;
            this.ucListSelectBar1.Location = new System.Drawing.Point(0, 90);
            this.ucListSelectBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucListSelectBar1.Name = "ucListSelectBar1";
            this.ucListSelectBar1.SelectedIndex = 0;
            this.ucListSelectBar1.Size = new System.Drawing.Size(1074, 40);
            this.ucListSelectBar1.TabIndex = 3;
            this.ucListSelectBar1.TabNames = "进行中|所有内容";
            // 
            // viewStack1
            // 
            this.viewStack1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.viewStack1.Controls.Add(this.tabPage1);
            this.viewStack1.Controls.Add(this.tabPage2);
            this.viewStack1.Location = new System.Drawing.Point(0, 130);
            this.viewStack1.Name = "viewStack1";
            this.viewStack1.SelectedIndex = 0;
            this.viewStack1.Size = new System.Drawing.Size(1074, 948);
            this.viewStack1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.viewStack1.TabIndex = 2;
            this.viewStack1.SelectedIndexChanged += new System.EventHandler(this.viewStack1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1066, 916);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.Click += new System.EventHandler(this.splitContainer2_Panel1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.ucTipAdd1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 909);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.splitContainer2_Panel1_Click);
            // 
            // ucTipAdd1
            // 
            this.ucTipAdd1.BackColor = System.Drawing.Color.Black;
            this.ucTipAdd1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucTipAdd1.ForeColor = System.Drawing.Color.White;
            this.ucTipAdd1.Location = new System.Drawing.Point(348, 33);
            this.ucTipAdd1.Margin = new System.Windows.Forms.Padding(2);
            this.ucTipAdd1.Name = "ucTipAdd1";
            this.ucTipAdd1.Size = new System.Drawing.Size(60, 83);
            this.ucTipAdd1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1066, 916);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(1060, 910);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.VirtualMode = true;
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.SizeChanged += new System.EventHandler(this.listView1_SizeChanged);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 50;
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
            // doubleBufferedFlowLayoutPanel1
            // 
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.ucDocTopBar1);
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.pictureBoxPaperIcon);
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.textBoxRowItemTitle);
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.uckvList1);
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.ucListSelectBar2);
            this.doubleBufferedFlowLayoutPanel1.Controls.Add(this.viewStack2);
            this.doubleBufferedFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferedFlowLayoutPanel1.Name = "doubleBufferedFlowLayoutPanel1";
            this.doubleBufferedFlowLayoutPanel1.Size = new System.Drawing.Size(491, 1078);
            this.doubleBufferedFlowLayoutPanel1.TabIndex = 6;
            this.doubleBufferedFlowLayoutPanel1.SizeChanged += new System.EventHandler(this.doubleBufferedFlowLayoutPanel1_SizeChanged);
            // 
            // ucDocTopBar1
            // 
            this.ucDocTopBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDocTopBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ucDocTopBar1.Location = new System.Drawing.Point(3, 3);
            this.ucDocTopBar1.Name = "ucDocTopBar1";
            this.ucDocTopBar1.Size = new System.Drawing.Size(476, 27);
            this.ucDocTopBar1.TabIndex = 6;
            // 
            // pictureBoxPaperIcon
            // 
            this.pictureBoxPaperIcon.Location = new System.Drawing.Point(20, 58);
            this.pictureBoxPaperIcon.Margin = new System.Windows.Forms.Padding(20, 25, 3, 20);
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
            this.textBoxRowItemTitle.Location = new System.Drawing.Point(65, 53);
            this.textBoxRowItemTitle.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.textBoxRowItemTitle.Name = "textBoxRowItemTitle";
            this.textBoxRowItemTitle.Size = new System.Drawing.Size(387, 40);
            this.textBoxRowItemTitle.TabIndex = 2;
            this.textBoxRowItemTitle.Text = "点击输入标题";
            this.textBoxRowItemTitle.TrueText = "";
            this.textBoxRowItemTitle.TextChanged += new System.EventHandler(this.textBoxRowItemTitle_TextChanged);
            // 
            // uckvList1
            // 
            this.uckvList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.uckvList1.BgColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.uckvList1.Location = new System.Drawing.Point(3, 116);
            this.uckvList1.Name = "uckvList1";
            this.uckvList1.Size = new System.Drawing.Size(491, 165);
            this.uckvList1.TabIndex = 5;
            // 
            // ucListSelectBar2
            // 
            this.ucListSelectBar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ucListSelectBar2.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.ucListSelectBar2.ForeColor = System.Drawing.Color.White;
            this.ucListSelectBar2.Location = new System.Drawing.Point(3, 287);
            this.ucListSelectBar2.Name = "ucListSelectBar2";
            this.ucListSelectBar2.SelectedIndex = 0;
            this.ucListSelectBar2.Size = new System.Drawing.Size(485, 35);
            this.ucListSelectBar2.TabIndex = 9;
            this.ucListSelectBar2.TabNames = "说明|图片";
            // 
            // viewStack2
            // 
            this.viewStack2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.viewStack2.Controls.Add(this.tabPage3);
            this.viewStack2.Controls.Add(this.tabPage4);
            this.viewStack2.Location = new System.Drawing.Point(0, 325);
            this.viewStack2.Margin = new System.Windows.Forms.Padding(0);
            this.viewStack2.Name = "viewStack2";
            this.viewStack2.SelectedIndex = 0;
            this.viewStack2.Size = new System.Drawing.Size(491, 746);
            this.viewStack2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.viewStack2.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tabPage3.Controls.Add(this.dasayEditor1);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(483, 714);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            // 
            // dasayEditor1
            // 
            this.dasayEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.dasayEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dasayEditor1.Location = new System.Drawing.Point(3, 3);
            this.dasayEditor1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dasayEditor1.Name = "dasayEditor1";
            this.dasayEditor1.Size = new System.Drawing.Size(477, 708);
            this.dasayEditor1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tabPage4.Controls.Add(this.imageGallery1);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(483, 714);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            // 
            // imageGallery1
            // 
            this.imageGallery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageGallery1.Location = new System.Drawing.Point(3, 3);
            this.imageGallery1.Margin = new System.Windows.Forms.Padding(4);
            this.imageGallery1.Name = "imageGallery1";
            this.imageGallery1.Size = new System.Drawing.Size(477, 708);
            this.imageGallery1.TabIndex = 0;
            // 
            // panelBlack
            // 
            this.panelBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBlack.BackColor = System.Drawing.Color.Black;
            this.panelBlack.Location = new System.Drawing.Point(0, 0);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(1810, 1078);
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
            this.toolStripMenuItemCata,
            this.toolStripMenuItemCryto,
            this.toolStripMenuItem2});
            this.rjDropdownMenuRow.MenuItemHeight = 25;
            this.rjDropdownMenuRow.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuRow.Name = "rjDropdownMenu1";
            this.rjDropdownMenuRow.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuRow.Size = new System.Drawing.Size(183, 144);
            // 
            // storeToolStripMenuItem
            // 
            this.storeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.storeToolStripMenuItem.Name = "storeToolStripMenuItem";
            this.storeToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.storeToolStripMenuItem.Text = "存档";
            this.storeToolStripMenuItem.Click += new System.EventHandler(this.storeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commonToolStripMenuItem1,
            this.nikonToolStripMenuItem1,
            this.toolStripMenuItemBook,
            this.ddlToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(182, 28);
            this.toolStripMenuItem3.Text = "小标题样式";
            // 
            // commonToolStripMenuItem1
            // 
            this.commonToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.commonToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.commonToolStripMenuItem1.Name = "commonToolStripMenuItem1";
            this.commonToolStripMenuItem1.Size = new System.Drawing.Size(162, 28);
            this.commonToolStripMenuItem1.Text = "普通";
            this.commonToolStripMenuItem1.Click += new System.EventHandler(this.commonToolStripMenuItem_Click);
            // 
            // nikonToolStripMenuItem1
            // 
            this.nikonToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nikonToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.nikonToolStripMenuItem1.Name = "nikonToolStripMenuItem1";
            this.nikonToolStripMenuItem1.Size = new System.Drawing.Size(162, 28);
            this.nikonToolStripMenuItem1.Text = "轮播行";
            this.nikonToolStripMenuItem1.Click += new System.EventHandler(this.nikonToolStripMenuItem_Click);
            // 
            // toolStripMenuItemBook
            // 
            this.toolStripMenuItemBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemBook.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItemBook.Name = "toolStripMenuItemBook";
            this.toolStripMenuItemBook.Size = new System.Drawing.Size(162, 28);
            this.toolStripMenuItemBook.Text = "图片预览";
            this.toolStripMenuItemBook.Click += new System.EventHandler(this.toolStripMenuItemBook_Click);
            // 
            // ddlToolStripMenuItem
            // 
            this.ddlToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ddlToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ddlToolStripMenuItem.Name = "ddlToolStripMenuItem";
            this.ddlToolStripMenuItem.Size = new System.Drawing.Size(162, 28);
            this.ddlToolStripMenuItem.Text = "截止时间";
            this.ddlToolStripMenuItem.Click += new System.EventHandler(this.ddlToolStripMenuItem_Click);
            // 
            // toolStripMenuItemCata
            // 
            this.toolStripMenuItemCata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemCata.Name = "toolStripMenuItemCata";
            this.toolStripMenuItemCata.Size = new System.Drawing.Size(182, 28);
            this.toolStripMenuItemCata.Text = "标记为：汇总";
            this.toolStripMenuItemCata.Click += new System.EventHandler(this.toolStripMenuItemCata_Click);
            // 
            // toolStripMenuItemCryto
            // 
            this.toolStripMenuItemCryto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemCryto.Name = "toolStripMenuItemCryto";
            this.toolStripMenuItemCryto.Size = new System.Drawing.Size(182, 28);
            this.toolStripMenuItemCryto.Text = "标记为：加密";
            this.toolStripMenuItemCryto.Click += new System.EventHandler(this.toolStripMenuItemCryto_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.IndianRed;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 28);
            this.toolStripMenuItem2.Text = "删除";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.deleteToolStripMenuItemRow_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1813, 1078);
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
            this.viewStack1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.doubleBufferedFlowLayoutPanel1.ResumeLayout(false);
            this.doubleBufferedFlowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaperIcon)).EndInit();
            this.viewStack2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
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
        private HintTextBox textBoxRowItemTitle;
        private System.Windows.Forms.PictureBox pictureBoxPaperIcon;
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
        private UCCatalogFix ucCatalogRoleStore;
        private ViewStack viewStack1;
        private System.Windows.Forms.TabPage tabPage1;
        public DoubleBufferedPanel panel1;
        private UCColumnAdd ucTipAdd1;
        private System.Windows.Forms.TabPage tabPage2;
        private DoubleBufferedListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private UIS.Main.UCListSelectBar ucListSelectBar1;
        private System.Windows.Forms.ToolStripMenuItem ddlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCata;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCryto;
        private UIS.DocComp.UCDocTopBar ucDocTopBar1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBook;
        private ViewStack viewStack2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private UIS.Main.UCListSelectBar ucListSelectBar2;
        private UIS.Main.ImageGallery imageGallery1;
    }
}

