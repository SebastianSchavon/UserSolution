using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace User_WPF.Helpers;

/// <summary>
///     Enables Radiobutton value binding
///     Reason: Radiobuttons value is boolean and not set to content value 
/// </summary>
internal class EnumBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.Equals(parameter);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((bool)value) ? parameter : Binding.DoNothing;
    }
}
