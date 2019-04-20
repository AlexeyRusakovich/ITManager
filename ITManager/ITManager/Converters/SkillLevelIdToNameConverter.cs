﻿using ITManager.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ITManager.Converters
{
    public class SkillLevelIdToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var skillLevels = (IList<SkillLevel>)((CollectionViewSource) parameter).Source;
            return skillLevels.FirstOrDefault(l => l.Id == (int) value)?.Level;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
