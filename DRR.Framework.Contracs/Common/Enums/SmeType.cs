using System.ComponentModel;

namespace DRR.Framework.Contracts.Common.Enums;

public enum SmeType
{
    /// <summary>
    /// تولیدی
    /// </summary>
    [Description("تولیدی")]
    Productive = 1,

    /// <summary>
    /// خدمات کسب‌و‌کار
    /// </summary>
    [Description("خدمات کسب‌و‌کار")]
    Business = 2,

    /// <summary>
    /// خدمات فنی مهندسی
    /// </summary>
    [Description("خدمات فنی مهندسی")]
    Technical = 3,

    /// <summary>
    /// تولیدی - خدمات کسب‌و‌کار
    /// </summary>
    [Description("تولیدی - خدمات کسب‌و‌کار")]
    ProductiveBusiness = 4,

    /// <summary>
    /// تولیدی - خدمات فنی مهندسی
    /// </summary>
    [Description("تولیدی - خدمات فنی مهندسی")]
    ProductiveTechnical = 5,

    /// <summary>
    /// خدمات کسب‌و‌کار - خدمات فنی مهندسی
    /// </summary>
    [Description("خدمات کسب‌و‌کار - خدمات فنی مهندسی")]
    BusinessTechnical = 6,

    /// <summary>
    /// تولیدی - خدمات کسب‌و‌کار - خدمات فنی مهندسی
    /// </summary>
    [Description("تولیدی - خدمات کسب‌و‌کار - خدمات فنی مهندسی")]
    ProductiveBusinessTechnical = 7

}