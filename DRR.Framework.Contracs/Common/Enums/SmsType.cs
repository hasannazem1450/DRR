using System.ComponentModel;

namespace DRR.Framework.Contracts.Common.Enums;

public enum SmsType
{
    /// <summary>
    ///     فعالسازی ثبت‌نام
    /// </summary>
    [Description("فعالسازی ثبت‌نام")] ActivatingRegistration,

    /// <summary>
    ///     تایید مدیرعامل
    /// </summary>
    [Description("تایید مدیرعامل")] ManagerAccept,

    /// <summary>
    ///     بازیابی رمزعبور
    /// </summary>
    [Description("بازیابی رمزعبور")] ResetPassword,
}