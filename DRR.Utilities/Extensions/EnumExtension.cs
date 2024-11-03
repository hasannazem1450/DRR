using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace DRR.Utilities.Extensions;

public static class EnumExtension
{
    public static string GetDisplayName(this Enum val)
    {
        return val.GetType()
                   .GetMember(val.ToString())
                   .FirstOrDefault()
                   ?.GetCustomAttribute<DisplayAttribute>(false)
                   ?.Name
               ?? val.ToString();
    }

    public static string GetDescription(this Enum val)
    {
        return val.GetType()
                   .GetMember(val.ToString())
                   .FirstOrDefault()
                   ?.GetCustomAttribute<DescriptionAttribute>(false)
                   ?.Description
               ?? val.ToString();
    }
}