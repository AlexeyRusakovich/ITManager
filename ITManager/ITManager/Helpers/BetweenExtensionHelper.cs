using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Helpers
{
    public static class BetweenExtensionHelper
    {
        public static bool IsBetween(this int value, int from, int to)
        {
            return value >= from && value <= to;
        }
    }
}
