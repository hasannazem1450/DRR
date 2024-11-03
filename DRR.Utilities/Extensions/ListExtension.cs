using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Utilities.Extensions
{
    public static class ListExtension
    {
        public static bool IsNullOrEmpty(this IList value)
        {
            return value == null || value.Count == 0;
        }

        public static bool IsNullOrEmptyExtension<T>(this IList<T> value)
        {
            return value == null || value.Count == 0;
        }

        public static bool IsNull(this IList value)
        {
            return value == null;
        }

        public static bool IsEmpty(this IList value)
        {
            return value != null && value.Count == 0;
        }
    }
}
