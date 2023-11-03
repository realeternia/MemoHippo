
namespace Text_Editor
{
    partial class Form1
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
            this.dasayEditor1 = new Text_Editor.DasayEditor();
            this.SuspendLayout();
            // 
            // dasayEditor1
            // 
            this.dasayEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.dasayEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dasayEditor1.Location = new System.Drawing.Point(0, 0);
            this.dasayEditor1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dasayEditor1.Name = "dasayEditor1";
            this.dasayEditor1.Size = new System.Drawing.Size(895, 636);
            this.dasayEditor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(895, 636);
            this.Controls.Add(this.dasayEditor1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DasayEditor dasayEditor1;
    }
}