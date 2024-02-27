using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cercos.Converters
{
    public class ActionToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = value?.Equals(parameter) ?? parameter is null;
            return flag ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                return (Visibility)value == Visibility.Visible;
            }

            return false;
        }
    }
}