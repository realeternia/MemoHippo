using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public class CustomMenuStrip : ContextMenuStrip
    {
        public CustomMenuStrip()
             : base()
        {
            Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColorTable());
            //   RenderMode = ToolStripRenderMode.Custom;
            BackColor = Color.FromArgb(24, 24, 24);
            ForeColor = Color.White;
        }

        public CustomMenuStrip(IContainer container)
            : base(container)
        {
            Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColorTable());
            //    RenderMode = ToolStripRenderMode.Custom;
            BackColor = Color.FromArgb(24, 24, 24);
            ForeColor = Color.White;
        }

    }

    public class CustomProfessionalColorTable : ProfessionalColorTable
    {
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(24, 24, 24); } // 设置选中菜单项的背景色
        }
        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(24, 24, 24); } // 设置选中菜单项的背景色
        }
        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(24, 24, 24); } // 设置选中菜单项的背景色
        }

        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(72, 72, 72); } // 设置选中菜单项的背景色
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(24, 24, 24); } // 设置菜单项边框的颜色
        }

    }
}
