using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp.Converters
{
    public class DictionaryToValueConverter<T, U> : IValueConverter
    {
        public IDictionary<T, U> ValuesMapping { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (ValuesMapping != null)
            {
                var keyT = (T)value;
                if (ValuesMapping.ContainsKey(keyT))
                    return ValuesMapping[keyT];
                else
                    return default(U);
            }
            else
                return default(U);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // not relevant
        }
    }
}
