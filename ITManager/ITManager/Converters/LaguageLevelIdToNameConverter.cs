using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using AutoMapper;
using ITManager.Database;

namespace ITManager.Converters
{
    public class LaguageLevelIdToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var languageLevels = (IList<LanguageLevel>)((CollectionViewSource) parameter).Source;
            return languageLevels.FirstOrDefault(l => l.Id == (int) value)?.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
