using System.ComponentModel;

namespace DRR.Framework.Contracts.Common.Enums;

public enum SmeType
{
    /// <summary>
    /// بیمار
    /// </summary>
    [Description("بیمار")]
    Productive = 1,

    /// <summary>
    /// مرکز درمانی
    /// </summary>
    [Description("مرکز درمانی")]
    Business = 2,

    /// <summary>
    /// دکتر
    /// </summary>
    [Description("دکتر")]
    Technical = 3,

    /// <summary>
    /// دندانپزشک
    /// </summary>
    [Description("دندانپزشک")]
    ProductiveBusiness = 4,

    /// <summary>
    /// تولیدی - خدمات فنی مهندسی
    /// </summary>
    [Description("روانشناس")]
    ProductiveTechnical = 5,

    /// <summary>
    /// داروخانه
    /// </summary>
    [Description("داروخانه")]
    BusinessTechnical = 6,

    /// <summary>
    /// تولیدی - خدمات کسب‌و‌کار - خدمات فنی مهندسی
    /// </summary>
    [Description("تولیدی - خدمات کسب‌و‌کار - خدمات فنی مهندسی")]
    ProductiveBusinessTechnical = 7

}