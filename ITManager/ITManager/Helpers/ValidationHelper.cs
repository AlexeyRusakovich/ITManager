using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsLengthBetween(this string str, int from, int to)
        {
            return str.Length >= from && str.Length <= to;
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
