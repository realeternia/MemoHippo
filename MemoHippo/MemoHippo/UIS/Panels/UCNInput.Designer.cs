
namespace MemoHippo.UIS.Panels
{
    partial class UCNInput
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
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxText
            // 
            this.textBoxText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBoxText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxText.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.textBoxText.ForeColor = System.Drawing.Color.White;
            this.textBoxText.Location = new System.Drawing.Point(5, 283);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(200, 40);
            this.textBoxText.TabIndex = 3;
            this.textBoxText.TextChanged += new System.EventHandler(this.textBoxText_TextChanged);
            this.textBoxText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBoxText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 27;
            this.listBox1.Items.AddRange(new object[] {
            "啊",
            "a2",
            "啊",
            "a2",
            "啊",
            "a2",
            "啊",
            "a2",
            "啊",
            "a2"});
            this.listBox1.Location = new System.Drawing.Point(5, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 272);
            this.listBox1.TabIndex = 4;
            // 
            // UCNInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBoxText);
            this.Name = "UCNInput";
            this.Size = new System.Drawing.Size(210, 330);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.ListBox listBox1;
    }
}
