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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DasayEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFileStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.undoStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imgStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.leftAlignStripButton = new System.Windows.Forms.ToolStripButton();
            this.centerAlignStripButton = new System.Windows.Forms.ToolStripButton();
            this.rightAlignStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.zoomDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.pictureBoxLeftS = new System.Windows.Forms.PictureBox();
            this.ucToolbar1 = new Text_Editor.UCToolbar();
            this.richTextBox1 = new Text_Editor.RichTextBoxEx();
            this.contextStripMouse = new Text_Editor.CustomMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customMenuStripRow = new Text_Editor.CustomMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBullet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftS)).BeginInit();
            this.contextStripMouse.SuspendLayout();
            this.customMenuStripRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveStripButton,
            this.openFileStripButton,
            this.toolStripSeparator10,
            this.undoStripButton,
            this.redoStripButton,
            this.toolStripSeparator1,
            this.imgStripButton,
            this.toolStripSeparator2,
            this.leftAlignStripButton,
            this.centerAlignStripButton,
            this.rightAlignStripButton,
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.zoomDropDownButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1029, 31);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveStripButton
            // 
            this.saveStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveStripButton.Image")));
            this.saveStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveStripButton.Name = "saveStripButton";
            this.saveStripButton.Size = new System.Drawing.Size(28, 28);
            this.saveStripButton.Text = "Save File";
            this.saveStripButton.Click += new System.EventHandler(this.saveStripButton_Click);
            // 
            // openFileStripButton
            // 
            this.openFileStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openFileStripButton.Image")));
            this.openFileStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileStripButton.Name = "openFileStripButton";
            this.openFileStripButton.Size = new System.Drawing.Size(28, 28);
            this.openFileStripButton.Text = "Open File";
            this.openFileStripButton.Click += new System.EventHandler(this.openFileStripButton_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 31);
            // 
            // undoStripButton
            // 
            this.undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("undoStripButton.Image")));
            this.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoStripButton.Name = "undoStripButton";
            this.undoStripButton.Size = new System.Drawing.Size(28, 28);
            this.undoStripButton.Text = "Undo Move";
            this.undoStripButton.Click += new System.EventHandler(this.undoStripButton_Click);
            // 
            // redoStripButton
            // 
            this.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("redoStripButton.Image")));
            this.redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoStripButton.Name = "redoStripButton";
            this.redoStripButton.Size = new System.Drawing.Size(28, 28);
            this.redoStripButton.Text = "Redo Move";
            this.redoStripButton.Click += new System.EventHandler(this.redoStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // imgStripButton
            // 
            this.imgStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgStripButton.Image = ((System.Drawing.Image)(resources.GetObject("imgStripButton.Image")));
            this.imgStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgStripButton.Name = "imgStripButton";
            this.imgStripButton.Size = new System.Drawing.Size(28, 28);
            this.imgStripButton.Text = "Clear All Formatting";
            this.imgStripButton.Click += new System.EventHandler(this.imgStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // leftAlignStripButton
            // 
            this.leftAlignStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.leftAlignStripButton.Image = ((System.Drawing.Image)(resources.GetObject("leftAlignStripButton.Image")));
            this.leftAlignStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftAlignStripButton.Name = "leftAlignStripButton";
            this.leftAlignStripButton.Size = new System.Drawing.Size(28, 28);
            this.leftAlignStripButton.Text = "Left Align";
            this.leftAlignStripButton.Click += new System.EventHandler(this.leftAlignStripButton_Click);
            // 
            // centerAlignStripButton
            // 
            this.centerAlignStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.centerAlignStripButton.Image = ((System.Drawing.Image)(resources.GetObject("centerAlignStripButton.Image")));
            this.centerAlignStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.centerAlignStripButton.Name = "centerAlignStripButton";
            this.centerAlignStripButton.Size = new System.Drawing.Size(28, 28);
            this.centerAlignStripButton.Text = "Center Align";
            this.centerAlignStripButton.Click += new System.EventHandler(this.centerAlignStripButton_Click);
            // 
            // rightAlignStripButton
            // 
            this.rightAlignStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightAlignStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rightAlignStripButton.Image")));
            this.rightAlignStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightAlignStripButton.Name = "rightAlignStripButton";
            this.rightAlignStripButton.Size = new System.Drawing.Size(28, 28);
            this.rightAlignStripButton.Text = "Right Align";
            this.rightAlignStripButton.Click += new System.EventHandler(this.rightAlignStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 28);
            this.toolStripButton1.Text = "WordWrap";
            this.toolStripButton1.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // zoomDropDownButton
            // 
            this.zoomDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomDropDownButton.Image")));
            this.zoomDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomDropDownButton.Name = "zoomDropDownButton";
            this.zoomDropDownButton.Size = new System.Drawing.Size(37, 28);
            this.zoomDropDownButton.Text = "Zoom Factor";
            this.zoomDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.zoomDropDownButton_DropDownItemClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "rtf文件|*.rtf";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.Filter = "rtf文件|*.rtf";
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            this.fontDialog1.HelpRequest += new System.EventHandler(this.fontDialog1_HelpRequest);
            // 
            // pictureBoxLeftS
            // 
            this.pictureBoxLeftS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxLeftS.Image = global::Text_Editor.Properties.Resources._2023_10_25_194154;
            this.pictureBoxLeftS.Location = new System.Drawing.Point(19, 290);
            this.pictureBoxLeftS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxLeftS.Name = "pictureBoxLeftS";
            this.pictureBoxLeftS.Size = new System.Drawing.Size(18, 30);
            this.pictureBoxLeftS.TabIndex = 21;
            this.pictureBoxLeftS.TabStop = false;
            this.pictureBoxLeftS.Visible = false;
            this.pictureBoxLeftS.Click += new System.EventHandler(this.pictureBoxLeftS_Click);
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.BackColor = System.Drawing.Color.White;
            this.ucToolbar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucToolbar1.Location = new System.Drawing.Point(489, 278);
            this.ucToolbar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(292, 28);
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
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.richTextBox1.Location = new System.Drawing.Point(39, 34);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(990, 637);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragDrop);
            this.richTextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragEnter);
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
            this.contextStripMouse.Size = new System.Drawing.Size(167, 124);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteStripMenuItem
            // 
            this.deleteStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteStripMenuItem.Image")));
            this.deleteStripMenuItem.Name = "deleteStripMenuItem";
            this.deleteStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.deleteStripMenuItem.Text = "Delete";
            this.deleteStripMenuItem.Click += new System.EventHandler(this.deleteStripMenuItem_Click);
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
            this.customMenuStripRow.Size = new System.Drawing.Size(167, 100);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 30);
            this.toolStripMenuItem2.Text = "Copy";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItem4.Size = new System.Drawing.Size(166, 30);
            this.toolStripMenuItem4.Text = "Delete";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.toolStripMenuItemBullet});
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.styleToolStripMenuItem.Text = "style";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.textToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.textToolStripMenuItem.Text = "text";
            // 
            // toolStripMenuItemBullet
            // 
            this.toolStripMenuItemBullet.BackColor = System.Drawing.Color.Black;
            this.toolStripMenuItemBullet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuItemBullet.Name = "toolStripMenuItemBullet";
            this.toolStripMenuItemBullet.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItemBullet.Text = "bullet";
            // 
            // DasayEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftS)).EndInit();
            this.contextStripMouse.ResumeLayout(false);
            this.customMenuStripRow.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton saveStripButton;
        private System.Windows.Forms.ToolStripButton openFileStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton leftAlignStripButton;
        private System.Windows.Forms.ToolStripButton centerAlignStripButton;
        private System.Windows.Forms.ToolStripButton rightAlignStripButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton undoStripButton;
        private System.Windows.Forms.ToolStripButton redoStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripDropDownButton zoomDropDownButton;
        private System.Windows.Forms.ToolStripButton imgStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
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
    }
}