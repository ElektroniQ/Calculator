using System;
using System.Threading;
using System.Windows.Data;

namespace WpfApp1.Resources.Style.Controls
{
    public class AddConverter : IValueConverter
    {
        public double Value { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
        {
            string param = parameter.ToString();
            param=param.Replace('.', System.Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            return System.Convert.ToDouble(param) + System.Convert.ToDouble(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
        {
            string param = parameter.ToString();
            param = param.Replace('.', System.Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            return System.Convert.ToDouble(param) - System.Convert.ToDouble(value);
        }
    }
}
