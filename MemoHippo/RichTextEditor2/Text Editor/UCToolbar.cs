using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MemoHippo.Utils;

namespace Text_Editor
{
    public partial class UCToolbar : UserControl
    {
        private static Dictionary<string, Color> ColorTable = new Dictionary<string, Color>
        {
            ["绯色"] = Color.FromArgb(237, 87, 54),
            ["赫赤"] = Color.FromArgb(201, 31, 55),
            ["石榴红"] = Color.FromArgb(242, 12, 0),
            ["海棠红"] = Color.FromArgb(219, 90, 107),
            ["品红"] = Color.FromArgb(240, 0, 86),
            ["洋红色"] = Color.FromArgb(255, 0, 151),
            ["胭脂"] = Color.FromArgb(157, 41, 51),
            ["桃夭"] = Color.FromArgb(246, 190, 200),
            ["长春"] = Color.FromArgb(220, 107, 130),
            ["蚩尤旗"] = Color.FromArgb(168, 88, 88),
            ["鹅黄色"] = Color.FromArgb(255, 241, 67),
            ["半见"] = Color.FromArgb(255, 251, 199),
            ["姚黄"] = Color.FromArgb(214, 188, 70),
            ["杏黄"] = Color.FromArgb(255, 166, 49),
            ["琥珀"] = Color.FromArgb(202, 105, 36),
            ["鞠衣"] = Color.FromArgb(211, 162, 55),
            ["黄埃"] = Color.FromArgb(180, 146, 115),
            ["黄封"] = Color.FromArgb(202, 178, 114),
            ["鸭卵青"] = Color.FromArgb(224, 238, 232),
            ["瓷秘"] = Color.FromArgb(191, 192, 150),
            ["青玉荼"] = Color.FromArgb(168, 176, 146),
            ["麹尘"] = Color.FromArgb(192, 208, 157),
            ["青粲"] = Color.FromArgb(195, 217, 78),
            ["嫩绿"] = Color.FromArgb(189, 221, 34),
            ["青色"] = Color.FromArgb(0, 224, 158),
            ["松花色"] = Color.FromArgb(188, 230, 114),
            ["人籁"] = Color.FromArgb(158, 188, 25),
            ["绿色"] = Color.FromArgb(0, 229, 0),
            ["碧山"] = Color.FromArgb(119, 150, 73),
            ["松柏绿"] = Color.FromArgb(33, 166, 117),
            ["庭芫绿"] = Color.FromArgb(104, 148, 92),
            ["官绿"] = Color.FromArgb(42, 11, 63),
            ["雀梅"] = Color.FromArgb(120, 138, 111),
            ["绿云"] = Color.FromArgb(69, 73, 61),
            ["碧落"] = Color.FromArgb(174, 208, 238),
            ["碧蓝"] = Color.FromArgb(62, 237, 231),
            ["湖蓝"] = Color.FromArgb(48, 223, 243),
            ["孔雀蓝"] = Color.FromArgb(73, 148, 196),
            ["苍苍"] = Color.FromArgb(89, 118, 186),
            ["宝蓝"] = Color.FromArgb(75, 92, 196),
            ["柔蓝"] = Color.FromArgb(16, 104, 152),
            ["群青"] = Color.FromArgb(46, 89, 167),
            ["藏蓝"] = Color.FromArgb(59, 46, 126),
            ["绀青绀紫"] = Color.FromArgb(0, 51, 113),
            ["花青"] = Color.FromArgb(26, 40, 71),
            ["暮山紫"] = Color.FromArgb(164, 171, 214),
            ["丁香色"] = Color.FromArgb(204, 164, 227),
            ["雪青"] = Color.FromArgb(176, 164, 227),
            ["紫色"] = Color.FromArgb(141, 75, 187),
            ["青莲"] = Color.FromArgb(128, 29, 174),
            ["紫棠"] = Color.FromArgb(86, 0, 79),
            ["自酱紫"] = Color.FromArgb(129, 84, 118),
            ["黛紫"] = Color.FromArgb(87, 66, 102),
            ["紫檀"] = Color.FromArgb(76, 34, 27),
            ["苍色"] = Color.FromArgb(117, 135, 138),
            ["仓青"] = Color.FromArgb(115, 151, 171),
            ["苍翠"] = Color.FromArgb(81, 154, 115),
            ["仓黑"] = Color.FromArgb(57, 82, 96),
            ["苍白"] = Color.FromArgb(209, 217, 224),
            ["水色"] = Color.FromArgb(136, 173, 166),
            ["水蓝"] = Color.FromArgb(210, 240, 244),
            ["淡青"] = Color.FromArgb(211, 224, 243),
            ["霜色"] = Color.FromArgb(233, 241, 246),
            ["玉色"] = Color.FromArgb(234, 228, 209),
            ["藕丝秋半"] = Color.FromArgb(211, 203, 197),
            ["普鲁士蓝"] = Color.FromArgb(0, 49, 83),
            ["勃艮第红"] = Color.FromArgb(128, 0, 32),
            ["邦迪蓝"] = Color.FromArgb(0, 149, 182),
            ["木乃伊棕"] = Color.FromArgb(143, 75, 40),
            ["卡布里蓝"] = Color.FromArgb(26, 85, 153),
            ["提香红"] = Color.FromArgb(176, 89, 35),
            ["蒂凡尼蓝"] = Color.FromArgb(129, 216, 208),
            ["覆盆子红"] = Color.FromArgb(158, 46, 36),
            ["虎皮黄"] = Color.FromArgb(226, 175, 66),
            ["薄荷绿"] = Color.FromArgb(64, 125, 82),
            ["草黄"] = Color.FromArgb(207, 182, 74),
            ["星蓝"] = Color.FromArgb(154, 180, 205),
            ["鸢尾蓝"] = Color.FromArgb(65, 138, 180),
            ["苋菜紫"] = Color.FromArgb(142, 41, 97),
            ["钢蓝"] = Color.FromArgb(16, 20, 32),
            ["云峰白"] = Color.FromArgb(218, 227, 230),
            ["岩石棕"] = Color.FromArgb(140, 80, 44),
            ["橄榄石绿"] = Color.FromArgb(184, 206, 142),
            ["竹绿"] = Color.FromArgb(79, 164, 133),
            ["钴蓝"] = Color.FromArgb(70, 146, 185),
            ["月影白"] = Color.FromArgb(194, 196, 195),
            ["笋皮棕"] = Color.FromArgb(107, 51, 26),
        };

        private Timer fadeInTimer;
        private bool toShow;
        private DateTime timeToFinish;

        const int MIDDLE = 382;    // middle sum of RGB - max is 765
        int sumRGB;    // sum of the selected colors RGB

        public UCToolbar()
        {
            InitializeComponent();

            fadeInTimer = new Timer();
            fadeInTimer.Interval = 10; // 设置速度
            fadeInTimer.Tick += new EventHandler(FadeInTimer_Tick);

            foreach (var cr in ColorTable)
            {
                ToolStripMenuItem blueMenuItem = new ToolStripMenuItem(cr.Key);
                //    blueMenuItem.BackColor = Color.Blue;
                blueMenuItem.BackColor = Color.FromArgb(24, 24, 24);
                blueMenuItem.ForeColor = Color.White;
                blueMenuItem.Image = ImageTool.CreateSolidColorBitmap(Color.FromArgb(cr.Value.R + 40, cr.Value.G + 40, cr.Value.B + 40), 32, 32);
                blueMenuItem.Click += ColorMenuItem_Click;
                colorStripDropDownButton.DropDownItems.Add(blueMenuItem);
            }

            // fill the drop down items list
            foreach (string color in colorList)
            {
                colorStripDropDownButton.DropDownItems.Add(color);
            }

            //fill BackColor for each color in the DropDownItems list
            for (int i = 0; i < colorStripDropDownButton.DropDownItems.Count; i++)
            {
                // Create KnownColor object
                KnownColor selectedColor;
                selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), colorList[i]);    // parse to a KnownColor
                colorStripDropDownButton.DropDownItems[i].BackColor = Color.FromKnownColor(selectedColor);    // set the BackColor to its appropriate list item

                // Set the text color depending on if the barkground is darker or lighter
                // create Color object
                Color col = Color.FromName(colorList[i]);

                // 255,255,255 = White and 0,0,0 = Black
                // Max sum of RGB values is 765 -> (255 + 255 + 255)
                // Middle sum of RGB values is 382 -> (765/2)
                // Color is considered darker if its <= 382
                // Color is considered lighter if its > 382
                sumRGB = ConvertToRGB(col);    // get the color objects sum of the RGB value
                if (sumRGB <= MIDDLE)    // Darker Background
                {
                    colorStripDropDownButton.DropDownItems[i].ForeColor = Color.White;    // set to White text
                }
                else if (sumRGB > MIDDLE)    // Lighter Background
                {
                    colorStripDropDownButton.DropDownItems[i].ForeColor = Color.Black;    // set to Black text
                }
            }
        }

        public void DelayVisible(bool visible, int ms)
        {
            if (Visible == visible)
                return;

            fadeInTimer.Stop();
            toShow = visible;
            timeToFinish = DateTime.Now.AddMilliseconds(ms);
            fadeInTimer.Start();
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now > timeToFinish)
            {
                fadeInTimer.Stop();
                Visible = toShow;
            }
          
        }

        //******************************************************************************************************************************
        // ConvertToRGB - Accepts a Color object as its parameter. Gets the RGB values of the object passed to it, calculates the sum. *
        //******************************************************************************************************************************
        private int ConvertToRGB(System.Drawing.Color c)
        {
            int r = c.R, // RED component value
                g = c.G, // GREEN component value
                b = c.B; // BLUE component value
            int sum = 0;

            // calculate sum of RGB
            sum = r + g + b;

            return sum;
        }
    }
}
