using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Web.Extension
{
    public static class StringExtension
    {
        public static List<T> GetList<T>(this string s)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
            IEnumerable<T> z = s.Replace(" ", "").Split(",").Select(x => (T) tc.ConvertFrom(x));
            var y = z.ToList();
            return y;
        }
    }
}
