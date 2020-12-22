using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Theme
    {
        public string BackGroundColor { get; set; }
        public string FontColor { get; set; }
        public string ButtonBackGroundColor { get; set; }

        public Theme(bool isDark)
        {
            if (isDark)
            {
                this.Dark();
            }
            else
            {
                this.Light();
            }
        }

        public void Light()
        {
            BackGroundColor = "#FFFFFF";
            FontColor = "#000000";
            ButtonBackGroundColor = "#E5E5E5";
        }

        public void Dark()
        {
            BackGroundColor = "#191919";
            FontColor = "#FFFFFF";
            ButtonBackGroundColor = "#4C4C4C";
        }


    }
}
