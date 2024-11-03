using System.ComponentModel;

namespace DRR.Framework.Contracts.Common.Enums;

public enum EventInfoState
{
    /// <summary>
    /// گذشته
    /// </summary>
    [Description("گذشته")]
    Finished = -1,

    /// <summary>
    /// در حال برگزاری
    /// </summary>
    [Description("در حال برگزاری")]
    InProgress = 0,

    /// <summary>
    /// آینده
    /// </summary>
    [Description("آینده")]
    Feature = 1
}