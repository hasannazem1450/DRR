using System;
using System.Globalization;

namespace DRR.Utilities.Extensions;

public static class DatetimeExtension
{
    public static string ToPersianString(this DateTime value)
    {
        var result = value.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));

        return result;
    }
    public static string ToPersianString(this DateTime? value)
    {
        string result = value?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")) ?? "";

        return result;
    }

    public static DateTime? ToGregorianDateTime(this string value)
    {
        DateTime? result = null;

        if (value.IsNotNullOrEmpty())
        {

            var year = Convert.ToInt32(value.Split("/")[0]);
            var month = Convert.ToInt32(value.Split("/")[1]);
            var day = Convert.ToInt32(value.Split("/")[2]);

            result = new DateTime(year, month, day, new PersianCalendar());
        }

        return result;
    }

}