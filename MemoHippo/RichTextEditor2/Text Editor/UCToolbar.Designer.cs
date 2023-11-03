
namespace Text_Editor
{
    partial class UCToolbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCToolbar));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeCaseDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.lowercaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uppercaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.clearFormattingStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.boldStripButton = new System.Windows.Forms.ToolStripButton();
            this.italicStripButton = new System.Windows.Forms.ToolStripButton();
            this.underlineStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bulletListStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.colorStripDropDownButton,
            this.changeCaseDropDownButton,
            this.toolStripSeparator9,
            this.clearFormattingStripButton,
            this.toolStripSeparator2,
            this.boldStripButton,
            this.italicStripButton,
            this.underlineStripButton,
            this.toolStripSeparator3,
            this.bulletListStripButton,
            this.toolStripSeparator8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(438, 31);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.blistToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(83, 28);
            this.toolStripDropDownButton1.Text = "切换类型";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.textToolStripMenuItem.Text = "文本";
            // 
            // blistToolStripMenuItem
            // 
            this.blistToolStripMenuItem.Name = "blistToolStripMenuItem";
            this.blistToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.blistToolStripMenuItem.Text = "段落";
            // 
            // colorStripDropDownButton
            // 
            this.colorStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("colorStripDropDownButton.Image")));
            this.colorStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorStripDropDownButton.Name = "colorStripDropDownButton";
            this.colorStripDropDownButton.Size = new System.Drawing.Size(38, 28);
            this.colorStripDropDownButton.Text = "Font Color";
            // 
            // changeCaseDropDownButton
            // 
            this.changeCaseDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.changeCaseDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowercaseToolStripMenuItem,
            this.uppercaseToolStripMenuItem});
            this.changeCaseDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("changeCaseDropDownButton.Image")));
            this.changeCaseDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changeCaseDropDownButton.Name = "changeCaseDropDownButton";
            this.changeCaseDropDownButton.Size = new System.Drawing.Size(38, 28);
            this.changeCaseDropDownButton.Text = "Change Case";
            // 
            // lowercaseToolStripMenuItem
            // 
            this.lowercaseToolStripMenuItem.Name = "lowercaseToolStripMenuItem";
            this.lowercaseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lowercaseToolStripMenuItem.Text = "&lowercase";
            // 
            // uppercaseToolStripMenuItem
            // 
            this.uppercaseToolStripMenuItem.Name = "uppercaseToolStripMenuItem";
            this.uppercaseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.uppercaseToolStripMenuItem.Text = "&UPPERCASE";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 31);
            // 
            // clearFormattingStripButton
            // 
            this.clearFormattingStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearFormattingStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearFormattingStripButton.Image")));
            this.clearFormattingStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearFormattingStripButton.Name = "clearFormattingStripButton";
            this.clearFormattingStripButton.Size = new System.Drawing.Size(29, 28);
            this.clearFormattingStripButton.Text = "Clear All Formatting";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // boldStripButton
            // 
            this.boldStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boldStripButton.Image = ((System.Drawing.Image)(resources.GetObject("boldStripButton.Image")));
            this.boldStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldStripButton.Name = "boldStripButton";
            this.boldStripButton.Size = new System.Drawing.Size(29, 28);
            this.boldStripButton.Text = "Bold";
            // 
            // italicStripButton
            // 
            this.italicStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italicStripButton.Image = ((System.Drawing.Image)(resources.GetObject("italicStripButton.Image")));
            this.italicStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicStripButton.Name = "italicStripButton";
            this.italicStripButton.Size = new System.Drawing.Size(29, 28);
            this.italicStripButton.Text = "Italics";
            // 
            // underlineStripButton
            // 
            this.underlineStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.underlineStripButton.Image = ((System.Drawing.Image)(resources.GetObject("underlineStripButton.Image")));
            this.underlineStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underlineStripButton.Name = "underlineStripButton";
            this.underlineStripButton.Size = new System.Drawing.Size(29, 28);
            this.underlineStripButton.Text = "Underline";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // bulletListStripButton
            // 
            this.bulletListStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bulletListStripButton.Image = ((System.Drawing.Image)(resources.GetObject("bulletListStripButton.Image")));
            this.bulletListStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bulletListStripButton.Name = "bulletListStripButton";
            this.bulletListStripButton.Size = new System.Drawing.Size(29, 28);
            this.bulletListStripButton.Text = "Bullet List";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 31);
            // 
            // UCToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.toolStrip1);
            this.Name = "UCToolbar";
            this.Size = new System.Drawing.Size(438, 34);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripDropDownButton colorStripDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton changeCaseDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem lowercaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uppercaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripButton clearFormattingStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton boldStripButton;
        public System.Windows.Forms.ToolStripButton italicStripButton;
        public System.Windows.Forms.ToolStripButton underlineStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bulletListStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        public System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem blistToolStripMenuItem;
    }
}
