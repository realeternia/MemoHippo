using System.Linq;
using System.Windows.Forms;

namespace MemoHippo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            flowLayoutPanel1.DragEnter += flowLayoutPanel1_DragEnter;
            flowLayoutPanel1.DragDrop += flowLayoutPanel1_DragDrop;
            flowLayoutPanel2.DragEnter += flowLayoutPanel1_DragEnter;
            flowLayoutPanel2.DragDrop += flowLayoutPanel1_DragDrop;
            flowLayoutPanel3.DragEnter += flowLayoutPanel1_DragEnter;
            flowLayoutPanel3.DragDrop += flowLayoutPanel1_DragDrop;
            label1.MouseDown += label_MouseDown;
            label2.MouseDown += label_MouseDown;
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string[] names = ((string)e.Data.GetData(DataFormats.StringFormat)).Split('.');

                // 根据 Name 查找 Label 控件
                var label = Controls[names[0]].Controls[names[1]];

                if (label != null)
                {

                    // 从原始 FlowLayoutPanel 中移除 Label
                    label.Parent.Controls.Remove(label);

                    // 添加 Label 到目标 FlowLayoutPanel
                    (sender as Control).Controls.Add(label);
                }
            }
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.DoDragDrop(label.Parent.Name + "." + label.Name, DragDropEffects.Move);
        }
    }
}
