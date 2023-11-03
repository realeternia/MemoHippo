using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class UCToolbar : UserControl
    {
        List<string> colorList = new List<string> { "Black", "Red", "Yellow", "Cyan", "LawnGreen", "MediumPurple" };    // holds the System.Drawing.Color names

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
