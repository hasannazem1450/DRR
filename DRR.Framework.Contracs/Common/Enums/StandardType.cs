using System.ComponentModel;

namespace DRR.Framework.Contracts.Common.Enums;

public enum StandardType
{
    /// <summary>
    ///     ISO
    /// </summary>
    [Description("ISO")] ISO = 1,

    /// <summary>
    ///     DIN
    /// </summary>
    [Description("DIN")] DIN = 2,

    /// <summary>
    ///     ASTM
    /// </summary>
    [Description("ASTM")] ASTM = 3
}