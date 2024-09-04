
using MemoHippo.UIS;
using RJControls;

namespace MemoHippo.UIS
{
    partial class UCSearchCalendar
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new MemoHippo.UIS.HintTextBox();
            this.rjComboBox1 = new RJControls.RJComboBox();
            this.doubleBufferedPanel1 = new MemoHippo.UIS.DoubleBufferedPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MemoHippo.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(10, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.DefaultText = "输入搜索";
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.ForeColorDE = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(53, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(631, 33);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "输入搜索";
            this.textBox1.TrueText = "";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // rjComboBox1
            // 
            this.rjComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rjComboBox1.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.rjComboBox1.BorderSize = 1;
            this.rjComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rjComboBox1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.rjComboBox1.ForeColor = System.Drawing.Color.White;
            this.rjComboBox1.IconColor = System.Drawing.Color.Yellow;
            this.rjComboBox1.Items.AddRange(new object[] {
            "最近6个月",
            "最近一年"});
            this.rjComboBox1.ListBackColor = System.Drawing.Color.DimGray;
            this.rjComboBox1.ListTextColor = System.Drawing.Color.White;
            this.rjComboBox1.Location = new System.Drawing.Point(1098, 12);
            this.rjComboBox1.MinimumSize = new System.Drawing.Size(150, 30);
            this.rjComboBox1.Name = "rjComboBox1";
            this.rjComboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.rjComboBox1.Size = new System.Drawing.Size(150, 38);
            this.rjComboBox1.TabIndex = 3;
            this.rjComboBox1.Texts = "";
            this.rjComboBox1.OnSelectedIndexChanged += new System.EventHandler(this.rjComboBox1_OnSelectedIndexChanged);
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.AutoScroll = true;
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(10, 63);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(1238, 925);
            this.doubleBufferedPanel1.TabIndex = 4;
            // 
            // UCSearchCalendar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.doubleBufferedPanel1);
            this.Controls.Add(this.rjComboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "UCSearchCalendar";
            this.Size = new System.Drawing.Size(1260, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HintTextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RJComboBox rjComboBox1;
        private DoubleBufferedPanel doubleBufferedPanel1;
    }
}
