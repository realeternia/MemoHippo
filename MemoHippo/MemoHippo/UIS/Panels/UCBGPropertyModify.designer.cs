
using MemoHippo.UIS;
using RJControls;

namespace MemoHippo.UIS
{
    partial class UCBGPropertyModify
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rjButtonOk = new RJControls.RJButton();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(30, 30);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(613, 308);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // rjButtonOk
            // 
            this.rjButtonOk.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButtonOk.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButtonOk.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButtonOk.BorderRadius = 0;
            this.rjButtonOk.BorderSize = 0;
            this.rjButtonOk.FlatAppearance.BorderSize = 0;
            this.rjButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtonOk.ForeColor = System.Drawing.Color.White;
            this.rjButtonOk.Location = new System.Drawing.Point(268, 332);
            this.rjButtonOk.Name = "rjButtonOk";
            this.rjButtonOk.Size = new System.Drawing.Size(92, 27);
            this.rjButtonOk.TabIndex = 11;
            this.rjButtonOk.Text = "保 存";
            this.rjButtonOk.TextColor = System.Drawing.Color.White;
            this.rjButtonOk.UseVisualStyleBackColor = false;
            this.rjButtonOk.Click += new System.EventHandler(this.rjButtonOk_Click);
            // 
            // UCBGPropertyModify
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.rjButtonOk);
            this.Name = "UCBGPropertyModify";
            this.Size = new System.Drawing.Size(644, 378);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private RJButton rjButtonOk;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
