using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWeapon.MyExt
{
    public static class FormatExtension
    {
        public static string Args(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

        public static string JoinS(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values);
        }

    }
}
