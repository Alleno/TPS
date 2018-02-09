using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPS.MVC.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<T> EnsureNotNull<T>(this IEnumerable<T> enumerable)
        {
            return enumerable ?? new List<T>();
        }

    }

}
