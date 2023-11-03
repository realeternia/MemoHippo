using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Text_Editor
{
    public class CustomMenuStrip : ContextMenuStrip
    {
        public CustomMenuStrip()
             : base()
        {
                Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColorTable());
         //   RenderMode = ToolStripRenderMode.Custom;
            BackColor = Color.Black;
            ForeColor = Color.White;
        }

        public CustomMenuStrip(IContainer container)
            :base(container)
        {
                 Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColorTable());
        //    RenderMode = ToolStripRenderMode.Custom;
            BackColor = Color.Black;
            ForeColor = Color.White;
        }

    }

    public class CustomProfessionalColorTable : ProfessionalColorTable
    {
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.Black; } // 设置选中菜单项的背景色
        }
        public override Color ImageMarginGradientBegin
        {
            get { return Color.Black; } // 设置选中菜单项的背景色
        }
        public override Color ImageMarginGradientEnd
        {
            get { return Color.Black; } // 设置选中菜单项的背景色
        }

        public override Color MenuItemSelected
        {
            get { return Color.DimGray; } // 设置选中菜单项的背景色
        }

        public override Color MenuItemBorder
        {
            get { return Color.Black; } // 设置菜单项边框的颜色
        }

    }
}
