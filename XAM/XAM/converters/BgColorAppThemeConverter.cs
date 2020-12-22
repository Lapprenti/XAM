using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XAM.converters
{
    public class BgColorAppThemeConverter : IValueConverter
    {
        private readonly Theme DARK = new Theme(true);
        private readonly Theme LIGHT = new Theme(false);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return this.DARK.BackGroundColor;
            } else
            {
                return this.LIGHT.BackGroundColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == false)
            {
                return this.LIGHT.BackGroundColor;
            }
            else
            {
                return this.DARK.BackGroundColor;
            }
        }
    }
}
