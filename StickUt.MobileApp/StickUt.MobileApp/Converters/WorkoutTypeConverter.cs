using StickUt.MobileApp.Converters;
using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp.Converters
{
    public class WorkoutTypeConverter: IValueConverter
    { 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            return WorkoutTypeFriendyNames.FriendyNames.Values.ToList();            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return WorkoutTypeFriendyNames.FriendyNames.Keys.ToList();
        }
    }
}
