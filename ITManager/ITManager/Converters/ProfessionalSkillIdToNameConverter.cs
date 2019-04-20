using ITManager.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ITManager.Converters
{
    public class ProfessionalSkillIdToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var professionalSkills = (IList<ProfessionalSkill>)((CollectionViewSource) parameter).Source;
            return professionalSkills.FirstOrDefault(l => l.Id == (int) value)?.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
