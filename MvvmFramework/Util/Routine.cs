using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFramework.Util
{
    public class Routine
    {
        public static bool IsRangeEmpty(params string[] values)
        {
            return values.Any(e => string.IsNullOrEmpty(e));
        }

        public static bool IsRangeEmpty(IEnumerable<string> values)
        {
            return values.Any(e => !string.IsNullOrEmpty(e));
        }

        public static bool IsValueEmpty(string value) 
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
