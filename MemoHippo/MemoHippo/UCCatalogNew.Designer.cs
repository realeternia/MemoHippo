
namespace MemoHippo
{
    partial class UCCatalogNew
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
            this.tbutton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbutton1
            // 
            this.tbutton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbutton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbutton1.FlatAppearance.BorderSize = 0;
            this.tbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbutton1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tbutton1.ForeColor = System.Drawing.Color.Silver;
            this.tbutton1.Location = new System.Drawing.Point(45, -1);
            this.tbutton1.Name = "tbutton1";
            this.tbutton1.Size = new System.Drawing.Size(154, 30);
            this.tbutton1.TabIndex = 0;
            this.tbutton1.Text = "< 点击添加新项 >";
            this.tbutton1.UseVisualStyleBackColor = true;
            // 
            // UCCatalogNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Controls.Add(this.tbutton1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCCatalogNew";
            this.Size = new System.Drawing.Size(240, 30);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button tbutton1;
    }
}
