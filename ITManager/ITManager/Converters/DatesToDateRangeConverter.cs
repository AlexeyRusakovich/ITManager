using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ITManager.Converters
{
    public class DatesToDateRangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var startDate = values.FirstOrDefault();
            var endDate = values.LastOrDefault();
            if(startDate == null || startDate.GetType() != typeof(DateTime))
                return null;
            var endDateStringValue = endDate == null ? "Present" : 
                endDate.GetType() == typeof(DateTime) ? ((DateTime)endDate).ToShortDateString() : "";
            return $"{((DateTime)startDate).ToShortDateString()} - {endDateStringValue}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
