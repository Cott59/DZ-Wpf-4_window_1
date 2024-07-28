using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DZ_Wpf_4_window
{
    public class DataTimeLessDayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var d = value as DateTime?;
            if (d != null)
            {
                return DateTime.Now > d.Value;
            }

            return false;
        }

        public object ConvertBack(object value, Type TargetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
