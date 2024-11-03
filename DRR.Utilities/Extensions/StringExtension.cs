using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DRR.Utilities.Extensions;

public static class StringExtension
{
    public static string TrimToPersian(this string value)
    {
        return value.Trim();
    }

    public static bool IsNullOrEmptyExtension(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static bool IsNotNullOrEmpty(this string value)
    {
        return !string.IsNullOrEmpty(value);
    }

    public static string TrimForBackslash(this string value)
    {
        var result = "Has Erro";

        var contentOne = value[0] == '[' ? value.Remove(0, 1) : value;

        var contentTwo = value[contentOne.Length - 1] == ']' ? contentOne.Remove(contentOne.Length - 1, 1) : value;
        ;

        var contentThree = contentTwo.Replace('\"', '"');

        result = new StringBuilder(contentThree).Replace(@"\", string.Empty).ToString();

        return result;
    }

    public static bool IsValidBase64(this string value)
    {
        value = value.Trim();
        return value.Length % 4 == 0 && Regex.IsMatch(value, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
    }

    public static string CleanBase64(this string value)
    {
        var result = value;

        if (!value.IsNullOrEmptyExtension())
        {
            var spl = value.Split('/')[1];
            var format = spl.Split(';')[0];
            result = value.Replace($"data:image/{format};base64,", string.Empty);
        }

        return result;
    }

    public static bool IsPersianString(this string value)
    {
        var result = false;

        var regex = new Regex(@"^[ آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیكيئ۰۱۲۳۴۵۶۷۸۹]+$");

        if (regex.IsMatch(value))
            result = true;

        return result;
    }

    public static string ConvertToPurePersian(this string value)
    {
        return value.Replace('ي', 'ی').Replace('ك', 'ک');
    }

    public static string RemoveMobilePrefix(this string value)
    {
        var result = value;

        if (result.Length != 10)
            if (result.StartsWith("+989") && result.Length == 13)
                result = result.Substring(3, 10);
            else if (result.StartsWith("989") && result.Length == 12)
                result = result.Substring(2, 10);
            else if (result.StartsWith("09") && result.Length == 11)
                result = result.Substring(1, 10);

        return result;
    }
    public static string ConvertToValidMobile(this string value)
    {
        var result = $"+98{RemoveMobilePrefix(value)}";

        return result;
    }

    public static string GetExtensionFromFilename(this string value)
    {
        var result = value.Split(".").LastOrDefault();

        return result;
    }
}