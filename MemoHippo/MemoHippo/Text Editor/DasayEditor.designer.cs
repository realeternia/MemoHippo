namespace Text_Editor
{
    public partial class DasayEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DasayEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ucToolbar1 = new Text_Editor.UCToolbar();
            this.richTextBox1 = new Text_Editor.RichTextBoxEx();
            this.contextStripMouse = new Text_Editor.CustomMenuStrip();
            this.customMenuStripRow = new Text_Editor.CustomMenuStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBoxLeftS = new System.Windows.Forms.PictureBox();
            this.undoStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoStripButton = new System.Windows.Forms.ToolStripButton();
            this.imgStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonScreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.zoomDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBullet = new System.Windows.Forms.ToolStripMenuItem();
            this.head1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextStripMouse.SuspendLayout();
            this.customMenuStripRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftS)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoStripButton,
            this.redoStripButton,
            this.toolStripSeparator1,
            this.imgStripButton,
            this.toolStripButtonScreen,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.zoomDropDownButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1029, 31);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.BackColor = System.Drawing.Color.White;
            this.ucToolbar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucToolbar1.Location = new System.Drawing.Point(520, 278);
            this.ucToolbar1.Margin = new System.Windows.Forms.Padding(2);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(322, 28);
            this.ucToolbar1.TabIndex = 20;
            this.ucToolbar1.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ContextMenuStrip = this.contextStripMouse;
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.richTextBox1.Location = new System.Drawing.Point(39, 47);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(990, 624);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.VScroll += new System.EventHandler(this.richTextBox1_VScroll);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            this.richTextBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseMove);
            // 
            // contextStripMouse
            // 
            this.contextStripMouse.BackColor = System.Drawing.Color.Black;
            this.contextStripMouse.ForeColor = System.Drawing.Color.White;
            this.contextStripMouse.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextStripMouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteStripMenuItem});
            this.contextStripMouse.Name = "richContextStrip";
            this.contextStripMouse.Size = new System.Drawing.Size(192, 124);
            // 
            // customMenuStripRow
            // 
            this.customMenuStripRow.BackColor = System.Drawing.Color.Black;
            this.customMenuStripRow.ForeColor = System.Drawing.Color.White;
            this.customMenuStripRow.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.customMenuStripRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.toolStripSeparator3,
            this.styleToolStripMenuItem});
            this.customMenuStripRow.Name = "richContextStrip";
            this.customMenuStripRow.Size = new System.Drawing.Size(186, 100);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // pictureBoxLeftS
            // 
            this.pictureBoxLeftS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxLeftS.Image = MemoHippo.Properties.Resources.selector;
            this.pictureBoxLeftS.Location = new System.Drawing.Point(19, 290);
            this.pictureBoxLeftS.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxLeftS.Name = "pictureBoxLeftS";
            this.pictureBoxLeftS.Size = new System.Drawing.Size(18, 30);
            this.pictureBoxLeftS.TabIndex = 21;
            this.pictureBoxLeftS.TabStop = false;
            this.pictureBoxLeftS.Visible = false;
            this.pictureBoxLeftS.Click += new System.EventHandler(this.pictureBoxLeftS_Click);
            // 
            // undoStripButton
            // 
            this.undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("undoStripButton.Image")));
            this.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoStripButton.Name = "undoStripButton";
            this.undoStripButton.Size = new System.Drawing.Size(29, 28);
            this.undoStripButton.Text = "Undo Move";
            this.undoStripButton.Click += new System.EventHandler(this.undoStripButton_Click);
            // 
            // redoStripButton
            // 
            this.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("redoStripButton.Image")));
            this.redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoStripButton.Name = "redoStripButton";
            this.redoStripButton.Size = new System.Drawing.Size(29, 28);
            this.redoStripButton.Text = "Redo Move";
            this.redoStripButton.Click += new System.EventHandler(this.redoStripButton_Click);
            // 
            // imgStripButton
            // 
            this.imgStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgStripButton.Image = MemoHippo.Properties.Resources.pictureadd;
            this.imgStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgStripButton.Name = "imgStripButton";
            this.imgStripButton.Size = new System.Drawing.Size(29, 28);
            this.imgStripButton.Text = "插入图片";
            this.imgStripButton.Click += new System.EventHandler(this.imgStripButton_Click);
            // 
            // toolStripButtonScreen
            // 
            this.toolStripButtonScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonScreen.Image = MemoHippo.Properties.Resources.picturepaste;
            this.toolStripButtonScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonScreen.Name = "toolStripButtonScreen";
            this.toolStripButtonScreen.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonScreen.Text = "黏贴图片";
            this.toolStripButtonScreen.Click += new System.EventHandler(this.toolStripButtonScreen_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(73, 28);
            this.toolStripButton1.Text = "自动换行";
            this.toolStripButton1.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // zoomDropDownButton
            // 
            this.zoomDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomDropDownButton.Image")));
            this.zoomDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomDropDownButton.Name = "zoomDropDownButton";
            this.zoomDropDownButton.Size = new System.Drawing.Size(38, 28);
            this.zoomDropDownButton.Text = "Zoom Factor";
            this.zoomDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.zoomDropDownButton_DropDownItemClicked);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteStripMenuItem
            // 
            this.deleteStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.deleteStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteStripMenuItem.Image")));
            this.deleteStripMenuItem.Name = "deleteStripMenuItem";
            this.deleteStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.deleteStripMenuItem.Text = "Delete";
            this.deleteStripMenuItem.Click += new System.EventHandler(this.deleteStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.toolStripMenuItem2.Image = MemoHippo.Properties.Resources.copy;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 30);
            this.toolStripMenuItem2.Text = "复制";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.toolStripMenuItem4.Image = MemoHippo.Properties.Resources.del;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItem4.Size = new System.Drawing.Size(185, 30);
            this.toolStripMenuItem4.Text = "删除";
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.toolStripMenuItemBullet,
            this.head1ToolStripMenuItem,
            this.head2ToolStripMenuItem,
            this.head3ToolStripMenuItem});
            this.styleToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.styleToolStripMenuItem.Image = MemoHippo.Properties.Resources.convert;
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.styleToolStripMenuItem.Text = "转换格式";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.textToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.textToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(162, 28);
            this.textToolStripMenuItem.Text = "文本";
            // 
            // toolStripMenuItemBullet
            // 
            this.toolStripMenuItemBullet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.toolStripMenuItemBullet.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.toolStripMenuItemBullet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuItemBullet.Name = "toolStripMenuItemBullet";
            this.toolStripMenuItemBullet.Size = new System.Drawing.Size(162, 28);
            this.toolStripMenuItemBullet.Text = "条目";
            // 
            // head1ToolStripMenuItem
            // 
            this.head1ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.head1ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.head1ToolStripMenuItem.Name = "head1ToolStripMenuItem";
            this.head1ToolStripMenuItem.Size = new System.Drawing.Size(162, 28);
            this.head1ToolStripMenuItem.Text = "一级标题";
            // 
            // head2ToolStripMenuItem
            // 
            this.head2ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.head2ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.head2ToolStripMenuItem.Name = "head2ToolStripMenuItem";
            this.head2ToolStripMenuItem.Size = new System.Drawing.Size(162, 28);
            this.head2ToolStripMenuItem.Text = "二级标题";
            // 
            // head3ToolStripMenuItem
            // 
            this.head3ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.head3ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.head3ToolStripMenuItem.Name = "head3ToolStripMenuItem";
            this.head3ToolStripMenuItem.Size = new System.Drawing.Size(162, 28);
            this.head3ToolStripMenuItem.Text = "三级标题";
            // 
            // DasayEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pictureBoxLeftS);
            this.Controls.Add(this.ucToolbar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DasayEditor";
            this.Size = new System.Drawing.Size(1029, 670);
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextStripMouse.ResumeLayout(false);
            this.customMenuStripRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBoxEx richTextBox1;
        private CustomMenuStrip contextStripMouse;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton undoStripButton;
        private System.Windows.Forms.ToolStripButton redoStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton zoomDropDownButton;
        private System.Windows.Forms.ToolStripButton imgStripButton;
        private UCToolbar ucToolbar1;
        private System.Windows.Forms.PictureBox pictureBoxLeftS;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private CustomMenuStrip customMenuStripRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBullet;
        private System.Windows.Forms.ToolStripButton toolStripButtonScreen;
        private System.Windows.Forms.ToolStripMenuItem head1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem head2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem head3ToolStripMenuItem;
    }
}