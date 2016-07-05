using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp.Converters
{
    public class ExerciseTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.GetType().Equals(typeof(ExerciseType)))
            {
                return ((ExerciseType)value).Name;
            }
            else
            {
                var types = value as List<ExerciseType>;
                if (types == null)
                    return value;

                return types.Select(x => x.Name).ToList();
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
