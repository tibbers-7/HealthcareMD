using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HealthcareMD.Tools
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string statusString=value.ToString();
            switch (statusString)
            {
                case "waiting":
                    return "\\Resources\\waitGreypng";
                case "accepted":
                    return "C:\\TEMP\\two_stars.png";
                default:
                    return "C:\\TEMP\\no_stars.png";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
