using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Utilities.Extensions
{
    public static class ObjectExtension
    {
        public static bool ObjectIsAnyNullOrEmpty(this object myObject)
        {
            if (myObject == null)
            {
                return true;
            }

            foreach (var pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (!string.IsNullOrEmpty(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
