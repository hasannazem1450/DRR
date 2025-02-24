using System;
using System.Globalization;

namespace DRR.Utilities.Extensions;

public static class DatetimeExtension
{
    private static string[] Days = { "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه" };
    private static string[] Months = { "فروردین", "اریبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
    private static PersianCalendar pc = new PersianCalendar();
    public static string ToPersianDateStringFull(this DateTime date)
    {
        return ($"{Days[pc.GetDayOfWeek(date).GetHashCode()]} {pc.GetDayOfMonth(date)} {Months[pc.GetMonth(date) - 1]} {pc.GetYear(date)}");
    }
    public static string ToPersianDateStringDay(this DateTime date)
    {
        return ($"{Days[pc.GetDayOfWeek(date).GetHashCode()]}");
    }
    public static string ToPersianDateStringMonth(this DateTime date)
    {
        return ($"{Months[pc.GetMonth(date) - 1]}");
    }
    public static string ToPersianDateStringDayofMonth(this DateTime date)
    {
        return ($"{pc.GetDayOfMonth(date)}");
    }
    public static int DateToNumber(string dateStr)
    {
        // تاریخ را به فرمت عددی تبدیل می‌کند
        // فرض می‌شود که تاریخ به صورت 'YYYY/MM/DD' وارد شده است
        string[] parts = dateStr.Split('/');
        string year = parts[0];
        string month = parts[1].PadLeft(2, '0');
        string day = parts[2].PadLeft(2, '0');

        return int.Parse(year + month + day);
    }

    public static string NumberToDate(int dateNum)
    {
        // عدد را به فرمت تاریخ تبدیل می‌کند
        string dateStr = dateNum.ToString();

        string year = dateStr.Substring(0, 4);
        string month = dateStr.Substring(4, 2);
        string day = dateStr.Substring(6, 2);

        return $"{year}/{month}/{day}";
    }
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